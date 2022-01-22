using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TourBy.Data.Persistent.Sql.Repository.Common;

namespace TourBy.Data.Persistent.Sql.Transaction;

public class TransactionService : ITransactionService, IDbContextProvider<ApplicationDbContext>
{
    private readonly IServiceProvider _serviceProvider;

    private readonly ApplicationDbContext _executionStrategyDbContext;
    
    private IServiceScope _dbContextScope;

    private bool _isDisposed;

    private bool _isInTransaction;

    public TransactionService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _executionStrategyDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        _dbContextScope = serviceProvider.CreateScope();
    }

    public ApplicationDbContext DbContext => _dbContextScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    private void EnsureIsNotDisposed()
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(TransactionService));
        }
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }
        _dbContextScope.Dispose();
        _isDisposed = true;
    }

    public async Task ExecuteInResilientTransactionAsync(Func<Task> operation)
    {
        await ExecuteInResilientTransactionAsync(
            async () =>
            {
                await operation();
                return 0;
            });
    }

    public async Task<T> ExecuteInResilientTransactionAsync<T>(Func<Task<T>> operation)
    {
        EnsureIsNotDisposed();

        void ResetDbContext()
        {
            _dbContextScope.Dispose();
            _dbContextScope = _serviceProvider.CreateScope();
        }

        if (_isInTransaction)
        {
             var result = await operation();
             return result;
        }

        try
        {
            _isInTransaction = true;
            var efStrategy = _executionStrategyDbContext.Database.CreateExecutionStrategy();
            var isRetry = false;
            T result = default;
            await efStrategy.ExecuteAsync(
                async () =>
                {
                    if (isRetry)
                    {
                        ResetDbContext();
                    }
                    try
                    {
                        await using var transaction = await DbContext.Database.BeginTransactionAsync();
                        result = await operation();
                        await transaction.CommitAsync();
                    }
                    finally
                    {
                        isRetry = true;
                    }
                });

            return result;
        }
        finally
        {
            _isInTransaction = false;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using TourBy.Data.Persistent.Base;
using TourBy.Domain.Base;

namespace TourBy.Data.Persistent.Sql.Repository.Common;

public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
    private readonly IDbContextProvider<ApplicationDbContext> _dbContextProvider;
    protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
    protected ApplicationDbContext DbContext => _dbContextProvider.DbContext;
    protected BaseRepository(IDbContextProvider<ApplicationDbContext> dbContextProvider)
    {
        _dbContextProvider = dbContextProvider;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await ExecuteDbAsync(() => DbSet.Add(entity));
        return entity;
    }

    public virtual async Task<TEntity> GetByIdAsync(TKey id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IList<TEntity>> GetByIdsAsync(IList<TKey> ids)
    {
        return await DbSet.Where(entity => ids.Contains(entity.Id)).ToListAsync();
    }

    public virtual async Task<IList<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    private async Task ExecuteDbAsync(Action action)
    {
        action.Invoke();
        await DbContext.SaveChangesAsync();
    }
}
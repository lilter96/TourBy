namespace TourBy.Data.Persistent.Sql.Transaction;

public interface ITransactionService
{
    Task<T> ExecuteInResilientTransactionAsync<T>(Func<Task<T>> operation);
}
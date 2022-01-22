using TourBy.Domain.Base;

namespace TourBy.Data.Persistent.Base;

public interface IRepository<TEntity, TKey> where TEntity : class, IBaseEntity<TKey>
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(TKey id);

    Task<IList<TEntity>> GetByIdsAsync(IList<TKey> ids);
    
    Task<IList<TEntity>> GetAllAsync();
}

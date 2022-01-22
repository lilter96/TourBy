using Microsoft.EntityFrameworkCore;

namespace TourBy.Data.Persistent.Sql.Repository.Common;

public interface IDbContextProvider<TDbContext> where TDbContext : DbContext
{
    TDbContext DbContext { get; }
}
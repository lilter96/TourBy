using Microsoft.EntityFrameworkCore;
using TourBy.Data.Persistent.IRepository;
using TourBy.Data.Persistent.Sql.Repository.Common;
using TourBy.Domain.Route;

namespace TourBy.Data.Persistent.Sql.Repository;

public class RouteRepository : BaseRepository<Route, Guid>, IRouteRepository
{
    private DbSet<Route> Routes => DbContext.Set<Route>();
    public RouteRepository(IDbContextProvider<ApplicationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
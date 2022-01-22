using TourBy.Data.Persistent.Base;
using TourBy.Domain.Route;

namespace TourBy.Data.Persistent.IRepository;

public interface IRouteRepository : IRepository<Route, Guid>
{
}
using TourBy.Data.Persistent.Base;
using TourBy.Domain.Post;

namespace TourBy.Data.Persistent.IRepository;

public interface IPostRepository : IRepository<Post, Guid>
{
}


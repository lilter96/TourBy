using Microsoft.EntityFrameworkCore;
using TourBy.Data.Persistent.IRepository;
using TourBy.Data.Persistent.Sql.Repository.Common;
using TourBy.Domain.Post;

namespace TourBy.Data.Persistent.Sql.Repository;

public class PostRepository : BaseRepository<Post, Guid>, IPostRepository
{
    private DbSet<Post> Pets => DbContext.Set<Post>();
    public PostRepository(IDbContextProvider<ApplicationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
using System.Dynamic;
using TourBy.Domain.Post;

namespace TourBy.Data.Persistent.IRepository;

internal interface IPostsRepository
{
    public List<Post> GetPosts();
    public Post GetPostById(Guid id);
} 


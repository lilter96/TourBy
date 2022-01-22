using TourBy.Domain.Route;

namespace TourBy.Application.Services.Post;

public interface IPostService
{
    Task<Domain.Post.Post> CreatePostWithRouteAsync(Domain.Post.Post post, Route route);
}
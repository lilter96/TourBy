using TourBy.Data.Persistent.IRepository;
using TourBy.Data.Persistent.Sql.Transaction;
using TourBy.Domain.Route;

namespace TourBy.Application.Services.Post;

public class PostService : IPostService
{
    private readonly ITransactionService _transactionService;
    
    private readonly IPostRepository _postRepository;
    
    private readonly IRouteRepository _routeRepository;

    public PostService(
        ITransactionService transactionService, 
        IPostRepository postRepository, 
        IRouteRepository routeRepository)
    {
        _transactionService = transactionService;
        _postRepository = postRepository;
        _routeRepository = routeRepository;
    }

    public async Task<Domain.Post.Post> CreatePostWithRouteAsync(Domain.Post.Post post, Route route)
    {
        var resultPost = await _transactionService.ExecuteInResilientTransactionAsync(async () =>
        {
            var routeRes = await _routeRepository.CreateAsync(route);
            post.RouteId = routeRes.Id;

            return await _postRepository.CreateAsync(post);
        });

        return resultPost;
    }
}
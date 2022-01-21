using MediatR;
using TourBy.Data.Persistent.Sql;
using TourBy.Domain.Post;

namespace TourBy.Application.Services.Mediator.Posts.Command;

public class AddPostCommandHandler: IRequestHandler<AddPostCommand, PostModel>
{
    private readonly ApplicationDbContext _dbContext;
    public AddPostCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PostModel> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var dbPost = new Post
        {
            Title = request.Post.Title
        };

        await _dbContext.Posts.AddAsync(dbPost);
        await _dbContext.SaveChangesAsync();

        return request.Post;
    }
}
using MediatR;

namespace TourBy.Application.Services.Mediator.Posts.Command;

public class AddPostCommand: IRequest<PostModel>
{
    public PostModel Post { get; set; }
}
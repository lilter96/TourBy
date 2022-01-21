using MediatR;
using Microsoft.AspNetCore.Mvc;
using TourBy.Application.Services.Mediator.Posts.Command;
using TourBy.Data.Persistent.Sql;
using TourBy.Domain.Post;
using TourBy.Web.Api.Models;

namespace TourBy.Web.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] AddPostCommand command)
        {
            var result = await _mediator.Send(command);

            return StatusCode(201, $"Post {result.Title} was successfully created.");
        }
    }
}

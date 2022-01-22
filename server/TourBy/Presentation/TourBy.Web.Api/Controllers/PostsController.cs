using Microsoft.AspNetCore.Mvc;
using TourBy.Application.Services.Post;
using TourBy.Domain.Post;
using TourBy.Web.Api.Models;
using Route = TourBy.Domain.Route.Route;

namespace TourBy.Web.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(
            IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] AddPostModel post)
        {
            var route = new Route(Guid.NewGuid())
            {
                Name = "The best route in the world! Made by the transaction service!"
            };

            var dbPost = new Post(Guid.NewGuid())
            {
                Title = post.Title,
            };

            await _postService.CreatePostWithRouteAsync(dbPost, route);

            return StatusCode(201, "Post was successfully created.");
        }
    }
}

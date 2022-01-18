using Microsoft.AspNetCore.Mvc;
using TourBy.Data.Persistent.Sql;
using TourBy.Domain.Post;
using TourBy.Web.Api.Models;

namespace TourBy.Web.Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PostsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] AddPostModel post)
        {
            var dbPost = new Post
            {
                Title = post.Title
            };

            await _dbContext.Posts.AddAsync(dbPost);
            await _dbContext.SaveChangesAsync();

            return StatusCode(201, "Post was successfully created.");
        }
    }
}

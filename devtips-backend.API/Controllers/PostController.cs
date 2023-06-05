using devtips_backend.Domain.Interfaces;
using devtips_backend.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace devtips_backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var post = await _postService.GetPostById(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostRequest request)
        {
            var response = await _postService.CreatePost(request);
            return Created($"{response.Id}" ,response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> RatePost(Guid id)
        {
            await _postService.RatePost(id);
            return NoContent();
        }
    }
}

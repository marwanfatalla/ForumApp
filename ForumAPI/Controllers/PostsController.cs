using ForumAPI.Dtos;
using ForumAPI.Entities;
using ForumAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        public IPostService postService;
        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpPost]
        public ActionResult<Post> CreatePost([FromBody]CreatePostDto dto)
        {
            var newPost = new Post();
            try
            {
                newPost = postService.CreatePost(dto);
            } catch(Exception ex)
            {
                return BadRequest();
            }
            if(newPost == null)
            {
                return BadRequest("Fill all fields");
            }
            
            return newPost;
        }
    }
}

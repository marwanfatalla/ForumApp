using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

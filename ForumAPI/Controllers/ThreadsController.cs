using ForumAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThreadsController : Controller
    {
        public IThreadServices threadServices;

        public ThreadsController(IThreadServices threadServices)
        {
            this.threadServices = threadServices;
        }
        [HttpGet]
        public ActionResult<List<Entities.Thread>> GetAll()
        {
            var threads = threadServices.GetAllThreads();
            if(threads == null || threads.Count == 0)
            {
                return NotFound();
            }
            return threads;
        }

        [HttpGet("{id}")]
        public ActionResult<Entities.Thread> GetById(string id)
        {
            var thread = new Entities.Thread();
            thread = threadServices.GetThreadById(id);
            if (thread.Id == null)
            {
                return NotFound();
            }
            return thread;
        }
    }
}

using ForumAPI.Entities;
using Thread = ForumAPI.Entities.Thread;

namespace ForumAPI.Services
{
    public interface IThreadServices
    {
        public List<Thread> GenerateThreads();
        public List<Thread> GetAllThreads();
        public Thread GetThreadById(string id);
    }
}

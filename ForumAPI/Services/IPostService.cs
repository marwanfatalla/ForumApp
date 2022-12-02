using ForumAPI.Dtos;
using ForumAPI.Entities;

namespace ForumAPI.Services
{
    public interface IPostService
    {
        public Post CreatePost(CreatePostDto post);
        public bool ContainsBannedWords(string body, string title);
    }
}

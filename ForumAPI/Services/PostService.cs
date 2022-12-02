using ForumAPI.Dtos;
using ForumAPI.Entities;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace ForumAPI.Services
{
    public class PostService :IPostService
    {
        public Post CreatePost(CreatePostDto post)
        {
            if(post == null)
            {
                throw new NullReferenceException();
            }
            if (!ContainsBannedWords(post.Body, post.Title)){
                throw new ArgumentException("Body or Title have bad words");
            }
            var newPost = new Post { Id= Guid.NewGuid(), Body=post.Body, Category=post.Category, ImageURL=post.ImageURL, Title=post.Title, Username= post.Username };
            return newPost;
        }

        public bool ContainsBannedWords(string body, string title)
        {
            var bannedWords = new List<string> { "Frick", "Crap", "Damn" };
            bool doesNotContainBannedWord = true;
            bannedWords.ForEach(word =>
            {
                if (body.Contains(word) || title.Contains(word))
                {
                    doesNotContainBannedWord=false;
                }
               
            });
            return doesNotContainBannedWord;

        }
    }
}

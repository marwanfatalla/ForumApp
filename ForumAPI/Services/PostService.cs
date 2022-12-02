using ForumAPI.Entities;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace ForumAPI.Services
{
    public class PostService :IPostService
    {
        public Post CreatePost(Post post)
        {
            if(post == null)
            {
                return null;
            }
            if (ContainsBannedWords(post)){
                throw new ArgumentException("Body or Title have bad words");
            }
            var newPost = new Post { Id= post.Id, Body=post.Body, Category=post.Category, ImageURL=post.ImageURL, Title=post.Title, Username= post.Username };
            return newPost;
        }

        public bool ContainsBannedWords(Post post)
        {
            var bannedWords = new List<string> { "Frick", "Crap", "Damn" };
            bool doesNotContainBannedWord = true;
            bannedWords.ForEach(word =>
            {
                if (post.Body.Contains(word) || post.Title.Contains(word))
                {
                    doesNotContainBannedWord=false;
                }
               
            });
            return doesNotContainBannedWord;

        }
    }
}

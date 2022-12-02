using ForumAPI.Enums;

namespace ForumAPI.Dtos
{
    public class CreatePostDto
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public CategoryEnum Category { get; set; }
        public string ImageURL { get; set; }
    }
}

using ForumAPI.Enums;

namespace ForumAPI.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Body{ get; set; }
        public CategoryEnum Category{ get; set; }
        public string ImageURL { get; set; }
    }
}

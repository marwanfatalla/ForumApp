namespace ForumAPI.Entities
{
    public class Thread
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}

namespace ForumAPI.Entities
{
    public class Thread
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}

namespace Landing.PL.ViewModels
{
    public class CommentVM
    {
        public int BlogId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

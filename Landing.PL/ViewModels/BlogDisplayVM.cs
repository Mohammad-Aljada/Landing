using Landing.DAL.Models;

namespace Landing.PL.ViewModels
{
    public class BlogDisplayVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }

        public string ImageName { get; set; }
        public List<Comment> Comments { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

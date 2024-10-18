namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class ItemDetailsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageName { get; set; }
        public string Portfolios { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

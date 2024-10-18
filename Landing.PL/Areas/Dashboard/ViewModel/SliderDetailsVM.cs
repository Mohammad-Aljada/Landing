namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class SliderDetailsVM
    {
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Link { get; set; }

        public bool IsDeleted { get; set; }


        public DateTime CreatedAt { get; set; }
    }
}

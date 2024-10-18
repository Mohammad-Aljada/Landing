namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class SliderFormVM
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Link { get; set; }

        public bool IsDeleted { get; set; }



    }
}

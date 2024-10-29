namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class TeamFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public string bio { get; set; }
        public string specialty { get; set; }
        public string FacebookLink { get; set; }
        public string LinkendInLink { get; set; }

        public string InstgramLink { get; set; }
    }
}

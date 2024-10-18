namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class PriceDetailsVM
    {
        public string Name { get; set; }

        public int InitalPrice { get; set; }
        public int Discount { get; set; }
        public bool IsDeleted { get; set; }
        public int FinalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

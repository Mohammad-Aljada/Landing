namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class PriceVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InitalPrice { get; set; }
        public int Discount { get; set; }
        public int FinalPrice { get; set; }

        public bool IsDeleted { get; set; }
    }
}

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class PriceFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InitalPrice { get; set; }
        public int Discount { get; set; } = 0;
        public bool IsDeleted { get; set; }
        public decimal FinalPrice { get; set; }
        public List<string> Features { get; set; }

    }
}

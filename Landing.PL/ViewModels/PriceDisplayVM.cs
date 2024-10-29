namespace Landing.PL.ViewModels
{
    public class PriceDisplayVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FinalPrice {   get; set; }
         public List<string> Features { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class PriceFormVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "price Name is Required..!")]

        public string Name { get; set; }
        [Required(ErrorMessage = "InitiL PRICE is Required..!")]

        public int InitalPrice { get; set; }
        public int Discount { get; set; } = 0;
        public bool IsDeleted { get; set; }
        public decimal FinalPrice { get; set; }
        public List<string> Features { get; set; }

    }
}

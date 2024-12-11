using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class ItemFormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Item Title is Required..!")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Item Descriptoin is Required..!")]

        public string Description { get; set; }

        public int PortfolioId { get; set; }

        public SelectList? Portfolios { get; set; }
        [Required(ErrorMessage = "Item image is Required..!")]

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}

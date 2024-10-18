using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class ItemFormVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int PortfolioId { get; set; }

        public SelectList? Portfolios { get; set; }

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}

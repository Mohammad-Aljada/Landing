using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class PortfolioFormVM
    {        
        public int Id { get; set; }
        [Required(ErrorMessage = "Portfolio Name is Required..!")]

        public string Name { get; set; }

        public bool IsDeleted { get; set; }


    }
}

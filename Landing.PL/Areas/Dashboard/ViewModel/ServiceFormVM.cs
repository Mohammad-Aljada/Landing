using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class ServiceFormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Service Name is Required..!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Service Description is Required..!")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Image is Required..!")]

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class ClientFormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Client Name is Required..!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Client Image is Required..!")]

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }

        public bool IsDeleted { get; set; }
    }
}

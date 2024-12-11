using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class SliderFormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Slider Image is Required..!")]

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }
        [Required(ErrorMessage = "Slider Title is Required..!")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Slider Descriptoin is Required..!")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Slider Link is Required..!")]

        public string Link { get; set; }

        public bool IsDeleted { get; set; }



    }
}

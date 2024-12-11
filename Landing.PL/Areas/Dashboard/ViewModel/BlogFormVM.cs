using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class BlogFormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Blog Title is Required..!")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Blog Short Descriptoin is Required..!")]

        public string DescriptionShort { get; set; }
        [Required(ErrorMessage = "Blog Long Descriptoin is Required..!")]

        public string DescriptionLong { get; set; }
        [Required(ErrorMessage = "Blog Image is Required..!")]

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }
    }
}

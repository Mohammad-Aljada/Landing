using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class TeamFormVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Member Name is Required..!")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Member Image is Required..!")]

        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        [Required(ErrorMessage = "Member bio is Required..!")]
        public string bio { get; set; }
        [Required(ErrorMessage = "Member speciality is Required..!")]
        public string specialty { get; set; }
        [Required(ErrorMessage = "member Facebook link is Required..!")]

        public string FacebookLink { get; set; }
        [Required(ErrorMessage = "member LinkendIn link is Required..!")]

        public string LinkendInLink { get; set; }
        [Required(ErrorMessage = "member Instgram link is Required..!")]


        public string InstgramLink { get; set; }
    }
}

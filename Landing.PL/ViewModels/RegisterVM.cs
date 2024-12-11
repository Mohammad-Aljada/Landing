using System.ComponentModel.DataAnnotations;

namespace Landing.PL.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="UserName is Required..!")]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required..!")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(ErrorMessage = "EMAIL is Required..!")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required..!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Required phone number..!")]
        [DataType(DataType.PhoneNumber)]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Required Address..!")]
        public string Address { get; set; }

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }
    }
}

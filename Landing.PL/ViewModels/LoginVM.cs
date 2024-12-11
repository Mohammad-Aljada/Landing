using System.ComponentModel.DataAnnotations;

namespace Landing.PL.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Password is Required..!")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required(ErrorMessage = "EMAIL is Required..!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool RememberMe { get; set; }
    }
}

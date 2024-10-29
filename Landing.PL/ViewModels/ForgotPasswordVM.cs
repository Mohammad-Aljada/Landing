using System.ComponentModel.DataAnnotations;

namespace Landing.PL.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "EMAIL is Required..!")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}

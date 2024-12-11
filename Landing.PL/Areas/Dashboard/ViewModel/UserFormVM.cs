using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class UserFormVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "User Name is Required..!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Email is Required..!")]

        public string Email { get; set; }
        [Required(ErrorMessage = "User Address is Required..!")]

        public string Address { get; set; }
        [Required(ErrorMessage = "User Phone Number is Required..!")]

        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
        [Required(ErrorMessage = "User Image is Required..!")]

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }

        public int PriceId { get; set; }
        public SelectList? Prices { get; set; }

        public string RoleId { get; set; }
        public SelectList? Roles { get; set; }
    }
}

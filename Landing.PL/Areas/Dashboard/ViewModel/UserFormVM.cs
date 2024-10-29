using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class UserFormVM
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }

        public IFormFile Image { get; set; }

        public string? ImageName { get; set; }

        public int PriceId { get; set; }
        public SelectList? Prices { get; set; }

        public string RoleId { get; set; }
        public SelectList? Roles { get; set; }
    }
}

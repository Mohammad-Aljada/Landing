using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Bio { get; set; }
        public string? ImageName { get; set; }

        public int? PriceId { get; set; }

        // Navigation property for the Plan
        public Price Price { get; set; }

        public int? RoleId { get; set; }


        
       

    }
}

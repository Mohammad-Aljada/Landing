using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; } // Foreign key reference to Blog
        public string UserId { get; set; } // Foreign key reference to ApplicationUser

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Blog Blog { get; set; }
        public ApplicationUser User { get; set; }
    }

}

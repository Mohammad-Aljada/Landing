using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionShort { get; set; }
        public string DescriptionLong { get; set; }
         public string ImageName { get; set; }

        public DateTime CreatedAt { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Link { get; set; }

        public bool IsDeleted { get; set; }


        public DateTime CreatedAt { get; set; }


    }
}

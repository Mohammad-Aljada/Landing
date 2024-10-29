using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string bio { get; set; }
        public string specialty { get; set; }
        public string FacebookLink { get; set; }
        public string LinkendInLink { get; set; }

        public string InstgramLink { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int InitalPrice { get; set; }
        public int Discount { get; set; }
        public bool IsDeleted { get; set; }
        public int FinalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

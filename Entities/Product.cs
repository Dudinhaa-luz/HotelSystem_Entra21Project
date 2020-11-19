using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Storage { get; set; }
        public double ProfitMargin { get; set; }
        public double Price { get; set; }
        public DateTime Validity { get; set; }
        public bool IsActive { get; set; }

    }
}

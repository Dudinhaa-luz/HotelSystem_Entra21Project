using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel {
    public class ProductOutputDetailQueryModel {
        public double ProductOutputDetailPrice { get; set; }
        public double ProductOutputDetailQuantity { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public DateTime ProductValidity { get; set; }
        public int ProductOutputID { get; set; }
        public DateTime ProductOutputEntryDate { get; set; }
        public double ProductOutputTotalValue { get; set; }
    }
}

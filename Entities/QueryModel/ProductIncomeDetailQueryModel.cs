using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel {
    public class ProductIncomeDetailQueryModel {

        public double ProductIncomeDetailPrice { get; set; }
        public double ProductIncomeDetailQuantity { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public DateTime ProductValidity { get; set; }
        public int ProductIncomeID { get; set; }
        public DateTime ProductIncomeEntryDate { get; set; }
        public double ProductIncomeTotalValue { get; set; }
    }
}

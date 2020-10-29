using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductIncomeDetail
    {
        public int IDProductIncome { get; set; }
        public int IDProduct { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductIncome
    {
        public ProductIncome() {
            Items = new List<ProductIncomeDetail>();
        }
        public int ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int EmployeesID { get; set; }
        public double TotalValue { get; set; }
        public int SuppliersID { get; set; }
        public List<ProductIncomeDetail> Items { get; set; }
    }
}

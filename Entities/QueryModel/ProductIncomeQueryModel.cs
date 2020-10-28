using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel
{
    public class ProductIncomeQueryModel
    {
        public int ProductIncomeID { get; set; }
        public DateTime ProductIncomeEntryDate { get; set; }
        public double ProductIncomeTotalValue { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCPF { get; set; }
        public string SupplierCompanyName { get; set; }
        public string SupplierCNPJ { get; set; }
    }
}

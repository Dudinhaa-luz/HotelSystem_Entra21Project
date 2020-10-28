using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel
{
    public class ProductOutputQueryModel
    {
        public int ProductOutputID { get; set; }
        public DateTime ProductOutputExitDate { get; set; }
        public double ProductOutputTotalValue { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCPF { get; set; }
        public string ClientName { get; set; }
        public string ClientCPF { get; set; }
    }
}

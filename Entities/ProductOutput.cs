using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductOutput
    {
        public int ID { get; set; }
        public DateTime ExitDate { get; set; }
        public int EmployeeID { get; set; }
        public double TotalValue { get; set; }
        public int ClientID { get; set; }
        public List<CheckoutClient> Items { get; set; }

    }
}

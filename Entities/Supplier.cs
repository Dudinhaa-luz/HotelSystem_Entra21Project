using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities {
    public class Supplier {

        //public Supplier() {
        //    Items = new List<Product>();
        //}
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CNPJ { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<Product> Items { get; set; }

    }
}

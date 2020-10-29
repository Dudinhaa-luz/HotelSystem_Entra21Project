using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities {
    public class CheckoutClient {
        public int ID { get; set; }
        public DateTime ExitDate { get; set; }
        public bool ExitOnTime { get; set; }
        public double Penalty { get; set; }
        public int IDCheckin { get; set; }
        public int IDEmployee { get; set; }
        public List<ProductOutput> Items { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CheckinClient
    {
        public int ID { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public int ClientID { get; set; }
        public int RoomID { get; set; }
        public int EmployeesID { get; set; }
    }
}

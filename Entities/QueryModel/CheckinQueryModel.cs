using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel
{
    public class CheckinQueryModel
    {
        public int CheckinID { get; set; }
        public DateTime CheckinEntryDate { get; set; }
        public DateTime CheckinExitDate { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientCPF{ get; set; }
        public string RoomNumber { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}

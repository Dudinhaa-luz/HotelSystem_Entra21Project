using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel {
    public class CheckoutQueryModel {
        public int CheckoutID { get; set; }
        public DateTime CheckoutExitDate { get; set; }
        public bool CheckoutExitOnTime { get; set; }
        public double CheckoutPenalty { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientCPF { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }
        public string RoomNumber { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CheckinEntryDate { get; set; }
    }
}

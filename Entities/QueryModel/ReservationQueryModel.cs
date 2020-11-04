using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel {
    public class ReservationQueryModel {
        public int ReservationID { get; set; }
        public DateTime ReservationDate { get; set; }
        public string RoomNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientCPF { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }
    }
}

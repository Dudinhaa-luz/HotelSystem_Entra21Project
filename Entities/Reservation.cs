using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reservation
    {
        public int ID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExitDatePrevision { get; set; }
        public int RoomID { get; set; }
        public int ClientID { get; set; }
    }
}

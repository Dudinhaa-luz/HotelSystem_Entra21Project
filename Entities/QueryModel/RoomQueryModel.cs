using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.QueryModel
{
    public class RoomQueryModel
    {
        public int RoomID { get; set; }
        public int RoomTypeID { get; set; }
        public bool RoomIsOcuppy { get; set; }
        public string RoomNumber { get; set; }
        public string TypeRoomDescription { get; set; }
        public double TypeRoomDailyValue { get; set; }
        public int TypeRoomGuestNumber { get; set; }
        public int TypeRoomIsActive { get; set; }

    }
}

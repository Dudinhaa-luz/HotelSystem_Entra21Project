using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities {
    public class RoomType {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public double DailyValue { get; set; }
        public int GuestNumber { get; set; }
    }
}

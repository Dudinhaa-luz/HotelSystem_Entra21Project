using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Room
    {
        public int ID { get; set; }
        public bool IsAvailable { get; set; }
        public string NumberRoom { get; set; }
        public string Description { get; set; }
        public int IDRoomType { get; set; }
    }
}

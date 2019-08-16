using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelJerbourg.Models
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int RoomFK { get; set; }

        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}

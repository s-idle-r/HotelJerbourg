using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelJerbourg.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int Number { get; set; }
        public bool Availability { get; set; }
        //public int HotelFK { get; set; }
        //public int RoomCategoryFK { get; set; }

        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        public virtual Hotel Hotel { get; set; }
        public virtual RoomCategory RoomCategories { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelJerbourg.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int RoomFK { get; set; }
        public int ClientFK { get; set; }
        public DateTime Date { get; set; }

        public Reservation()
        {

        }

        public virtual Room Room { get; set; }
        public virtual Client Client { get; set; }
    }
}

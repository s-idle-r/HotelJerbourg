using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelJerbourg.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }

        public Client()
        {
            Reservations = new HashSet<Reservation>();
            Bills = new HashSet<Bill>();
        }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}

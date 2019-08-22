using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelJerbourg.Models
{
    public class ModelsVM
    {
        public Client Client { get; set; }
        public Room Room { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public Hotel Hotel { get; set; }

        public List<Client> ClientList { get; set; }
        public List<Room> RoomList { get; set; }
        public List<Hotel> HotelList { get; set; }
        public List<RoomCategory> RoomCategoryList { get; set; }
        public List<Bill> Bill { get; set; }
        public List<Reservation> Reservation { get; set; }
    }
}
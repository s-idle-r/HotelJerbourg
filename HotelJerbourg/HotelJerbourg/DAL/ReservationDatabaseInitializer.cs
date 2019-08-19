using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HotelJerbourg.Models;

namespace HotelJerbourg.DAL
{
    public class ReservationDatabaseInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            var hotel = new List<Hotel>
            {
                new Hotel{Name="Hotel Jerbourg",Address="Rue de Bretagne 11"}
            };
            hotel.ForEach(s => context.Hotels.Add(s));
            context.SaveChanges();

            var rooms = new List<Room>
            {
                new Room{Number=001,Availability=true},
                new Room{Number=002,Availability=true},
                new Room{Number=003,Availability=true},
                new Room{Number=004,Availability=true},
                new Room{Number=005,Availability=true},
                new Room{Number=101,Availability=true},
                new Room{Number=102,Availability=true},
                new Room{Number=103,Availability=true},
                new Room{Number=104,Availability=true},
                new Room{Number=105,Availability=true}
            };
            rooms.ForEach(s => context.Rooms.Add(s));
            context.SaveChanges();

            var category = new List<RoomCategory>
            {
                new RoomCategory{Category="Standard"},
                new RoomCategory{Category="Premium"},
                new RoomCategory{Category="Suite"}
            };
            category.ForEach(s => context.RoomCategories.Add(s));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{Surname="Tobias",LastName="Tanner",Address="Tannenweg 3"},
                new Client{Surname="Billy",LastName="Bartholdi",Address="Blumenweg 12"},
                new Client{Surname="Fredy",LastName="Friedrich",Address="Friedheim 39"},
                new Client{Surname="Ralf",LastName="Röhrich",Address="Rabenstrasse 7"},
                new Client{Surname="Lara",LastName="Lang",Address="Lindenhof 21"},
                new Client{Surname="Udo",LastName="Ulrich",Address="Untere Halde 77"}
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var reservations = new List<Reservation>
            {
                new Reservation{ClientFK=1,RoomFK=1,Date=DateTime.Parse("2019-08-30")},
                new Reservation{ClientFK=2,RoomFK=5,Date=DateTime.Parse("2019-08-28")}
            };
            reservations.ForEach(s => context.Reservations.Add(s));
            context.SaveChanges();
        }
    }
}
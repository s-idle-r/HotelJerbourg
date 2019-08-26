namespace HotelJerbourg.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HotelJerbourg.Models;
    using HotelJerbourg.DAL;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelJerbourg.DAL.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //ContextKey = "HotelJerbourg.Models.HotelJerbourgContext";
            //ContextKey = "HotelJerbourg.DAL.HotelContext";
        }

        protected override void Seed(HotelJerbourg.DAL.HotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var hotel = new List<Hotel>
            {
                new Hotel{Name="Hotel Jerbourg",Address="Rue de Bretagne 11"}
            };
            hotel.ForEach(s => context.Hotels.AddOrUpdate(p => p.Name, s));
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
            rooms.ForEach(s => context.Rooms.AddOrUpdate(p => p.Number, s));
            context.SaveChanges();

            var category = new List<RoomCategory>
            {
                new RoomCategory{Category="Standard"},
                new RoomCategory{Category="Premium"},
                new RoomCategory{Category="Suite"}
            };
            category.ForEach(s => context.RoomCategories.AddOrUpdate(p => p.Category, s));
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
            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var reservations = new List<Reservation>
            {
                //new Reservation{ClientFK=1,RoomFK=1,Date=DateTime.Parse("2019-08-30")},
                //new Reservation{ClientFK=2,RoomFK=5,Date=DateTime.Parse("2019-08-28")}

                new Reservation
                {
                    ClientFK = clients.Single(s => s.LastName == "Tanner").ClientID,
                    RoomFK = rooms.Single(s => s.Number == 101).RoomID,
                    Date = DateTime.Parse("2019-08-30")
                },
                new Reservation
                {
                    ClientFK = clients.Single(s => s.LastName == "Friedrich").ClientID,
                    RoomFK = rooms.Single(s => s.Number == 004).RoomID,
                    Date = DateTime.Parse("2019-09-28")
                },
                new Reservation
                {
                    ClientFK = clients.Single(s => s.LastName == "Röhrich").ClientID,
                    RoomFK = rooms.Single(s => s.Number == 002).RoomID,
                    Date = DateTime.Parse("2019-09-03")
                },
            };
            //reservations.ForEach(s => context.Reservations.Add(s));
            //context.SaveChanges();
            foreach (Reservation r in reservations)
            {
                var reservationInDataBase = context.Reservations.Where(s => s.Client.ClientID == s.ClientFK);
                if (reservationInDataBase == null)
                {
                    context.Reservations.Add(r);
                    context.SaveChanges();
                }
            }
        }
    }
}

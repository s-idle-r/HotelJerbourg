using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data.Entity;
using HotelJerbourg.Models;

namespace HotelJerbourg.DAL
{
    public class ReservationDatabaseInitializer : DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            
        }

        private static Hotel GetHotel()
        {
            var
        }
    }
}
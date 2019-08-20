namespace HotelJerbourg.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
        }
    }
}

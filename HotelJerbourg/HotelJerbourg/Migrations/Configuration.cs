namespace HotelJerbourg.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HotelJerbourg.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelJerbourg.Models.HotelJerbourgContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HotelJerbourg.Models.HotelJerbourgContext";
        }

        protected override void Seed(HotelJerbourg.Models.HotelJerbourgContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

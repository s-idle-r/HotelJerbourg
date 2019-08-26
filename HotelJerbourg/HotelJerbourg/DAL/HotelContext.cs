using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HotelJerbourg.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HotelJerbourg.DAL
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("HotelJerbourg")
        {
            //Database.SetInitializer(new HotelDBInitializer());
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCategory> RoomCategories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOptional(s => s.RoomCategories).WithMany(s => s.Rooms)
                .Map(t => t.MapKey("RoomCategoryFK"));

            modelBuilder.Entity<Room>()
                .HasOptional(s => s.Hotel).WithMany(s => s.Rooms)
                .Map(t => t.MapKey("HotelFK"));

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID")
            //        .ToTable("CourseInstructor"));

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}
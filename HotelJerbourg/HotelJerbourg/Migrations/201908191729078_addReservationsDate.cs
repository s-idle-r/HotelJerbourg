namespace HotelJerbourg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReservationsDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Address");
            DropColumn("dbo.Reservations", "Date");
        }
    }
}

namespace HotelJerbourg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Client_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        RoomFK = c.Int(nullable: false),
                        ClientFK = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Client_ClientID = c.Int(),
                        Room_RoomID = c.Int(),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomID)
                .Index(t => t.Client_ClientID)
                .Index(t => t.Room_RoomID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Availability = c.Boolean(nullable: false),
                        RoomCategoryFK = c.Int(nullable: false),
                        Hotel_HotelID = c.Int(),
                        RoomCategories_RoomCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelID)
                .ForeignKey("dbo.RoomCategories", t => t.RoomCategories_RoomCategoryID)
                .Index(t => t.Hotel_HotelID)
                .Index(t => t.RoomCategories_RoomCategoryID);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        RoomFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelID);
            
            CreateTable(
                "dbo.RoomCategories",
                c => new
                    {
                        RoomCategoryID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.RoomCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomCategories_RoomCategoryID", "dbo.RoomCategories");
            DropForeignKey("dbo.Reservations", "Room_RoomID", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Hotel_HotelID", "dbo.Hotels");
            DropForeignKey("dbo.Reservations", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.Bills", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.Rooms", new[] { "RoomCategories_RoomCategoryID" });
            DropIndex("dbo.Rooms", new[] { "Hotel_HotelID" });
            DropIndex("dbo.Reservations", new[] { "Room_RoomID" });
            DropIndex("dbo.Reservations", new[] { "Client_ClientID" });
            DropIndex("dbo.Bills", new[] { "Client_ClientID" });
            DropTable("dbo.RoomCategories");
            DropTable("dbo.Hotels");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.Clients");
            DropTable("dbo.Bills");
        }
    }
}

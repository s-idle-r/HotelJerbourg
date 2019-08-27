namespace HotelJerbourg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Client_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.Client", t => t.Client_ClientID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Reservation",
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
                .ForeignKey("dbo.Client", t => t.Client_ClientID)
                .ForeignKey("dbo.Room", t => t.Room_RoomID)
                .Index(t => t.Client_ClientID)
                .Index(t => t.Room_RoomID);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Availability = c.Boolean(nullable: false),
                        HotelFK = c.Int(nullable: false),
                        RoomCategoryFK = c.Int(nullable: false),
                        Hotel_HotelID = c.Int(),
                        RoomCategories_RoomCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("dbo.Hotel", t => t.Hotel_HotelID)
                .ForeignKey("dbo.RoomCategory", t => t.RoomCategories_RoomCategoryID)
                .Index(t => t.Hotel_HotelID)
                .Index(t => t.RoomCategories_RoomCategoryID);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        RoomFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelID);
            
            CreateTable(
                "dbo.RoomCategory",
                c => new
                    {
                        RoomCategoryID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.RoomCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Room", "RoomCategories_RoomCategoryID", "dbo.RoomCategory");
            DropForeignKey("dbo.Reservation", "Room_RoomID", "dbo.Room");
            DropForeignKey("dbo.Room", "Hotel_HotelID", "dbo.Hotel");
            DropForeignKey("dbo.Reservation", "Client_ClientID", "dbo.Client");
            DropForeignKey("dbo.Bill", "Client_ClientID", "dbo.Client");
            DropIndex("dbo.Room", new[] { "RoomCategories_RoomCategoryID" });
            DropIndex("dbo.Room", new[] { "Hotel_HotelID" });
            DropIndex("dbo.Reservation", new[] { "Room_RoomID" });
            DropIndex("dbo.Reservation", new[] { "Client_ClientID" });
            DropIndex("dbo.Bill", new[] { "Client_ClientID" });
            DropTable("dbo.RoomCategory");
            DropTable("dbo.Hotel");
            DropTable("dbo.Room");
            DropTable("dbo.Reservation");
            DropTable("dbo.Client");
            DropTable("dbo.Bill");
        }
    }
}

namespace HotelJerbourg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingForSeedingMethod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Addresss", c => c.String());
            DropColumn("dbo.Clients", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Address", c => c.String());
            DropColumn("dbo.Clients", "Addresss");
        }
    }
}

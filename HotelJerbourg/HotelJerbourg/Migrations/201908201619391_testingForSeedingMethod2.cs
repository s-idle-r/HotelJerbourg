namespace HotelJerbourg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingForSeedingMethod2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Address", c => c.String());
            DropColumn("dbo.Clients", "Addresss");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Addresss", c => c.String());
            DropColumn("dbo.Clients", "Address");
        }
    }
}

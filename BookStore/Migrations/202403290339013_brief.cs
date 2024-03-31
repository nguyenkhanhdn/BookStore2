namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brief : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stationeries", "Brief", c => c.String(nullable: false));
            DropColumn("dbo.Stationeries", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stationeries", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Stationeries", "Brief");
        }
    }
}

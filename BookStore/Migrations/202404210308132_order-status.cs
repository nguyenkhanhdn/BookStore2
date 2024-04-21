namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stationeries", "Publisher", c => c.String(nullable: false));
            AddColumn("dbo.Stationeries", "UsedFor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stationeries", "UsedFor");
            DropColumn("dbo.Stationeries", "Publisher");
        }
    }
}

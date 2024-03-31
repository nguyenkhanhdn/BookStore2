namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brief1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stationeries", "Brief", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stationeries", "Brief", c => c.String(nullable: false));
        }
    }
}

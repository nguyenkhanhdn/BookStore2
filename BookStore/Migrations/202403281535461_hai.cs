namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hai : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Img", c => c.String(nullable: false));
            AlterColumn("dbo.Stationeries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stationeries", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Stationeries", "Img", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stationeries", "Img", c => c.String());
            AlterColumn("dbo.Stationeries", "Description", c => c.String());
            AlterColumn("dbo.Stationeries", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Img", c => c.String());
            AlterColumn("dbo.Categories", "Description", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}

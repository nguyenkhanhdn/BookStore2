namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nam : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stationeries", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Stationeries", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Stationeries", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Stationeries", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Stationeries", "CategoryId");
            AddForeignKey("dbo.Stationeries", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stationeries", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Stationeries", new[] { "CategoryId" });
            AlterColumn("dbo.Stationeries", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Stationeries", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Stationeries", "Category_Id");
            AddForeignKey("dbo.Stationeries", "Category_Id", "dbo.Categories", "Id");
        }
    }
}

namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderStatus", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderStatus", "StatusId");
            AddForeignKey("dbo.OrderStatus", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.OrderStatus", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderStatus", "Status", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.OrderStatus", "StatusId", "dbo.Status");
            DropIndex("dbo.OrderStatus", new[] { "StatusId" });
            DropColumn("dbo.OrderStatus", "StatusId");
            DropTable("dbo.Status");
        }
    }
}

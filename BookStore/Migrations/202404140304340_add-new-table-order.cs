namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewtableorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OrderedDate = c.DateTime(),
                        DeliveryType = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Note = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PDFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Publisher = c.String(),
                        Area = c.String(),
                        FileUrl = c.String(),
                        UploadedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            
        }
        
        public override void Down()
        {
           
            
            DropTable("dbo.PDFs");
            DropTable("dbo.Orders");
        }
    }
}

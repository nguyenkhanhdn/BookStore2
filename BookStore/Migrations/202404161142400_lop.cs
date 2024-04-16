namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PDFs", "ClassId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PDFs", "ClassId");
        }
    }
}

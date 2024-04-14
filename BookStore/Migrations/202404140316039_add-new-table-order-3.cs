namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewtableorder3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PDFs", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.PDFs", "Area", c => c.String(nullable: false));
            AlterColumn("dbo.PDFs", "FileUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PDFs", "FileUrl", c => c.String());
            AlterColumn("dbo.PDFs", "Area", c => c.String());
            AlterColumn("dbo.PDFs", "Title", c => c.String());
        }
    }
}

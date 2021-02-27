namespace ERP_Document.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_101 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "FileName", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "FileSize", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "FileType", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "FilePath", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Files", "FilePath", c => c.String());
            AlterColumn("dbo.Files", "FileType", c => c.String());
            AlterColumn("dbo.Files", "FileSize", c => c.String());
            AlterColumn("dbo.Files", "FileName", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
        }
    }
}

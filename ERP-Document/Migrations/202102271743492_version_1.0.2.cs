namespace ERP_Document.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_102 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Roles", "Description", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Roles", "Name", c => c.String());
        }
    }
}

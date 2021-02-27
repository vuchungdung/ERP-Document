namespace ERP_Document.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        CommandId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CommandId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileSize = c.String(),
                        FileType = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        FunctionId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Url = c.String(),
                        SortOrder = c.String(),
                        ParentId = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.FunctionId);
            
            CreateTable(
                "dbo.Notifies",
                c => new
                    {
                        NotifyId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                        FileId = c.Int(nullable: false),
                        SendTime = c.DateTime(nullable: false),
                        IsRecovery = c.Boolean(nullable: false),
                        RecoveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NotifyId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        CommandId = c.String(nullable: false, maxLength: 128),
                        FunctionId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CommandId, t.FunctionId, t.RoleId });
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Permissions");
            DropTable("dbo.Notifies");
            DropTable("dbo.Functions");
            DropTable("dbo.Files");
            DropTable("dbo.Departments");
            DropTable("dbo.Commands");
        }
    }
}

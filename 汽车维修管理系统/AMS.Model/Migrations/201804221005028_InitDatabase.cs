namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Icon = c.String(),
                        SelectedIcon = c.String(),
                        Url = c.String(),
                        ParentId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        ParentId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Account = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CreateBy = c.Guid(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                        Org_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.Org_Id)
                .Index(t => t.Org_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Org_Id", "dbo.Organization");
            DropForeignKey("dbo.Organization", "ParentId", "dbo.Organization");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropIndex("dbo.User", new[] { "Org_Id" });
            DropIndex("dbo.Organization", new[] { "ParentId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropTable("dbo.User");
            DropTable("dbo.Organization");
            DropTable("dbo.Menu");
        }
    }
}

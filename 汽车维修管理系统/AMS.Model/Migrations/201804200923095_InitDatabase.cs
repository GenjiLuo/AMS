namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentId = c.Guid(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropIndex("dbo.User", new[] { "Org_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Organization");
        }
    }
}

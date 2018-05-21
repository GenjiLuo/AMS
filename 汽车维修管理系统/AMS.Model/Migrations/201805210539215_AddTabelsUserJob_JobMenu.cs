namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTabelsUserJob_JobMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobMenu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        JobId = c.Guid(nullable: false),
                        MenuId = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNum = c.Int(),
                        Description = c.String(),
                        CreateBy = c.Guid(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.UserJob",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        JobId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNum = c.Int(),
                        Description = c.String(),
                        CreateBy = c.Guid(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Job", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserJob", "UserId", "dbo.User");
            DropForeignKey("dbo.UserJob", "JobId", "dbo.Job");
            DropForeignKey("dbo.JobMenu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.JobMenu", "JobId", "dbo.Job");
            DropIndex("dbo.UserJob", new[] { "UserId" });
            DropIndex("dbo.UserJob", new[] { "JobId" });
            DropIndex("dbo.JobMenu", new[] { "MenuId" });
            DropIndex("dbo.JobMenu", new[] { "JobId" });
            DropTable("dbo.UserJob");
            DropTable("dbo.JobMenu");
        }
    }
}

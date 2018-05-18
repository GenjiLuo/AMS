namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateServiceRepair : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepair", "WashCarMainOperatorId", c => c.Guid());
            CreateIndex("dbo.ServiceRepair", "WashCarMainOperatorId");
            AddForeignKey("dbo.ServiceRepair", "WashCarMainOperatorId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepair", "WashCarMainOperatorId", "dbo.User");
            DropIndex("dbo.ServiceRepair", new[] { "WashCarMainOperatorId" });
            DropColumn("dbo.ServiceRepair", "WashCarMainOperatorId");
        }
    }
}

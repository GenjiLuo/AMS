namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableRepairParts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairParts", "ServiceAccountTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.RepairParts", "ServiceAccountTypeId");
            AddForeignKey("dbo.RepairParts", "ServiceAccountTypeId", "dbo.ServiceAccountType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairParts", "ServiceAccountTypeId", "dbo.ServiceAccountType");
            DropIndex("dbo.RepairParts", new[] { "ServiceAccountTypeId" });
            DropColumn("dbo.RepairParts", "ServiceAccountTypeId");
        }
    }
}

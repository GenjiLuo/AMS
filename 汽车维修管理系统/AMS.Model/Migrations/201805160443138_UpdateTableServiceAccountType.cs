namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceAccountType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EstimateRepairParts", "ServiceAccountTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.EstimateRepairParts", "ServiceAccountTypeId");
            AddForeignKey("dbo.EstimateRepairParts", "ServiceAccountTypeId", "dbo.ServiceAccountType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstimateRepairParts", "ServiceAccountTypeId", "dbo.ServiceAccountType");
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceAccountTypeId" });
            DropColumn("dbo.EstimateRepairParts", "ServiceAccountTypeId");
        }
    }
}

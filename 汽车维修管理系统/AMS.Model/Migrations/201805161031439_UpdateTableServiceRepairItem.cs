namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceRepairItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepairItem", "ServiceAccountTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ServiceRepairItem", "ServiceAccountTypeId");
            AddForeignKey("dbo.ServiceRepairItem", "ServiceAccountTypeId", "dbo.ServiceAccountType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepairItem", "ServiceAccountTypeId", "dbo.ServiceAccountType");
            DropIndex("dbo.ServiceRepairItem", new[] { "ServiceAccountTypeId" });
            DropColumn("dbo.ServiceRepairItem", "ServiceAccountTypeId");
        }
    }
}

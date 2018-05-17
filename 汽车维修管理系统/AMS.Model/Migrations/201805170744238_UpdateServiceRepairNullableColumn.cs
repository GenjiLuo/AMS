namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateServiceRepairNullableColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceRepair", "RepairTypeId", "dbo.RepairType");
            DropForeignKey("dbo.ServiceRepair", "ServiceAdvisorId", "dbo.User");
            DropIndex("dbo.ServiceRepair", new[] { "RepairTypeId" });
            DropIndex("dbo.ServiceRepair", new[] { "ServiceAdvisorId" });
            AlterColumn("dbo.ServiceRepair", "ServiceType", c => c.Int());
            AlterColumn("dbo.ServiceRepair", "RepairTypeId", c => c.Guid());
            AlterColumn("dbo.ServiceRepair", "ServiceAdvisorId", c => c.Guid());
            CreateIndex("dbo.ServiceRepair", "RepairTypeId");
            CreateIndex("dbo.ServiceRepair", "ServiceAdvisorId");
            AddForeignKey("dbo.ServiceRepair", "RepairTypeId", "dbo.RepairType", "Id");
            AddForeignKey("dbo.ServiceRepair", "ServiceAdvisorId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepair", "ServiceAdvisorId", "dbo.User");
            DropForeignKey("dbo.ServiceRepair", "RepairTypeId", "dbo.RepairType");
            DropIndex("dbo.ServiceRepair", new[] { "ServiceAdvisorId" });
            DropIndex("dbo.ServiceRepair", new[] { "RepairTypeId" });
            AlterColumn("dbo.ServiceRepair", "ServiceAdvisorId", c => c.Guid(nullable: false));
            AlterColumn("dbo.ServiceRepair", "RepairTypeId", c => c.Guid(nullable: false));
            AlterColumn("dbo.ServiceRepair", "ServiceType", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceRepair", "ServiceAdvisorId");
            CreateIndex("dbo.ServiceRepair", "RepairTypeId");
            AddForeignKey("dbo.ServiceRepair", "ServiceAdvisorId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceRepair", "RepairTypeId", "dbo.RepairType", "Id", cascadeDelete: true);
        }
    }
}

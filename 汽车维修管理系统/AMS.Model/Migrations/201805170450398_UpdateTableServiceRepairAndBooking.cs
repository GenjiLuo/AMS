namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceRepairAndBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepair", "RepairTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ServiceRepair", "RepairTypeId");
            AddForeignKey("dbo.ServiceRepair", "RepairTypeId", "dbo.RepairType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepair", "RepairTypeId", "dbo.RepairType");
            DropIndex("dbo.ServiceRepair", new[] { "RepairTypeId" });
            DropColumn("dbo.ServiceRepair", "RepairTypeId");
        }
    }
}

namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCash1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepairCashTicket", "ServiceRepairId", c => c.Guid());
            CreateIndex("dbo.ServiceRepairCashTicket", "ServiceRepairId");
            AddForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairId", "dbo.ServiceRepair", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairId", "dbo.ServiceRepair");
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceRepairId" });
            DropColumn("dbo.ServiceRepairCashTicket", "ServiceRepairId");
        }
    }
}

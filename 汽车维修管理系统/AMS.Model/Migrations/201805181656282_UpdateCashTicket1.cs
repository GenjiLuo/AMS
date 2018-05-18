namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCashTicket1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", "dbo.ServiceRepairAccountTicket");
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceRepairAccountTicketId" });
            AlterColumn("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", c => c.Guid());
            CreateIndex("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId");
            AddForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", "dbo.ServiceRepairAccountTicket", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", "dbo.ServiceRepairAccountTicket");
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceRepairAccountTicketId" });
            AlterColumn("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId");
            AddForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", "dbo.ServiceRepairAccountTicket", "Id", cascadeDelete: true);
        }
    }
}

namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCash : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", "dbo.ServiceTicketType");
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceTicketTypeId" });
            AlterColumn("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", c => c.Guid());
            CreateIndex("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId");
            AddForeignKey("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", "dbo.ServiceTicketType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", "dbo.ServiceTicketType");
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceTicketTypeId" });
            AlterColumn("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId");
            AddForeignKey("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", "dbo.ServiceTicketType", "Id", cascadeDelete: true);
        }
    }
}

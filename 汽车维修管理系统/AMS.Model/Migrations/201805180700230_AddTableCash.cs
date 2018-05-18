namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCash : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceRepairCashTicket",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ServiceRepairAccountTicketId = c.Guid(nullable: false),
                        ServiceTicketTypeId = c.Guid(nullable: false),
                        TaxBillNo = c.String(),
                        ShouldPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RealPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BackLittle = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.ServiceRepairAccountTicket", t => t.ServiceRepairAccountTicketId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceTicketType", t => t.ServiceTicketTypeId, cascadeDelete: true)
                .Index(t => t.ServiceRepairAccountTicketId)
                .Index(t => t.ServiceTicketTypeId);
            
            CreateTable(
                "dbo.ServiceRpairPayment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ServiceRepairCashTicketId = c.Guid(nullable: false),
                        PaymentTypeId = c.Guid(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.PaymentType", t => t.PaymentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceRepairCashTicket", t => t.ServiceRepairCashTicketId, cascadeDelete: true)
                .Index(t => t.ServiceRepairCashTicketId)
                .Index(t => t.PaymentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", "dbo.ServiceTicketType");
            DropForeignKey("dbo.ServiceRpairPayment", "ServiceRepairCashTicketId", "dbo.ServiceRepairCashTicket");
            DropForeignKey("dbo.ServiceRpairPayment", "PaymentTypeId", "dbo.PaymentType");
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", "dbo.ServiceRepairAccountTicket");
            DropIndex("dbo.ServiceRpairPayment", new[] { "PaymentTypeId" });
            DropIndex("dbo.ServiceRpairPayment", new[] { "ServiceRepairCashTicketId" });
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceTicketTypeId" });
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceRepairAccountTicketId" });
            DropTable("dbo.ServiceRpairPayment");
            DropTable("dbo.ServiceRepairCashTicket");
        }
    }
}

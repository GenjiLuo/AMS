namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTicket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceRepairAccountTicket",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ServiceRepairId = c.Guid(nullable: false),
                        WorkHourMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartsMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManagementMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WorkHourDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartsDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManagementDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MoveLittle = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShouldPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RealPay = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId, cascadeDelete: true)
                .Index(t => t.ServiceRepairId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepairAccountTicket", "ServiceRepairId", "dbo.ServiceRepair");
            DropIndex("dbo.ServiceRepairAccountTicket", new[] { "ServiceRepairId" });
            DropTable("dbo.ServiceRepairAccountTicket");
        }
    }
}

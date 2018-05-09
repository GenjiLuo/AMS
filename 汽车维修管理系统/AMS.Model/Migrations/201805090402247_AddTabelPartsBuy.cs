namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTabelPartsBuy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsDictionaryId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        PartsBuyId = c.Guid(nullable: false),
                        WarehouseId = c.Guid(),
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
                .ForeignKey("dbo.PartsBuy", t => t.PartsBuyId, cascadeDelete: true)
                .ForeignKey("dbo.PartsDictionary", t => t.PartsDictionaryId, cascadeDelete: true)
                .Index(t => t.PartsDictionaryId)
                .Index(t => t.PartsBuyId);
            
            CreateTable(
                "dbo.PartsBuy",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SupplierName = c.String(),
                        SupplierId = c.Guid(nullable: false),
                        OrderNo = c.String(),
                        BillNo = c.String(),
                        State = c.Int(nullable: false),
                        ApplyUser = c.String(),
                        CheckUser = c.String(),
                        OperationTime = c.DateTime(),
                        CategoryCount = c.Int(),
                        TotalMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReadyToPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WarehouseId = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNum = c.Int(),
                        Description = c.String(),
                        CreateBy = c.Guid(),
                        OperationType = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "PartsDictionaryId", "dbo.PartsDictionary");
            DropForeignKey("dbo.PartsBuy", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.Parts", "PartsBuyId", "dbo.PartsBuy");
            DropIndex("dbo.PartsBuy", new[] { "WarehouseId" });
            DropIndex("dbo.Parts", new[] { "PartsBuyId" });
            DropIndex("dbo.Parts", new[] { "PartsDictionaryId" });
            DropTable("dbo.PartsBuy");
            DropTable("dbo.Parts");
        }
    }
}

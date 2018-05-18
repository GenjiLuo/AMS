namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableWashItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceWashItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WashItemId = c.Guid(nullable: false),
                        ServiceRepairId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.WashItem", t => t.WashItemId, cascadeDelete: true)
                .Index(t => t.WashItemId)
                .Index(t => t.ServiceRepairId);
            
            CreateTable(
                "dbo.WashItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceWashItem", "WashItemId", "dbo.WashItem");
            DropForeignKey("dbo.ServiceWashItem", "ServiceRepairId", "dbo.ServiceRepair");
            DropIndex("dbo.ServiceWashItem", new[] { "ServiceRepairId" });
            DropIndex("dbo.ServiceWashItem", new[] { "WashItemId" });
            DropTable("dbo.WashItem");
            DropTable("dbo.ServiceWashItem");
        }
    }
}

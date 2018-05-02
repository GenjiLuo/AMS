namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableRepairItemAndType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RepairItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SerNum = c.String(),
                        WorkHour = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsHot = c.Boolean(nullable: false),
                        RepairItemTypeId = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNum = c.Int(),
                        Description = c.String(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        CreateBy = c.Guid(),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RepairItemType", t => t.RepairItemTypeId, cascadeDelete: true)
                .Index(t => t.RepairItemTypeId);
            
            CreateTable(
                "dbo.RepairItemType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNum = c.Int(),
                        Description = c.String(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        CreateBy = c.Guid(),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RepairType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNum = c.Int(),
                        Description = c.String(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        CreateBy = c.Guid(),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairItem", "RepairItemTypeId", "dbo.RepairItemType");
            DropIndex("dbo.RepairItem", new[] { "RepairItemTypeId" });
            DropTable("dbo.RepairType");
            DropTable("dbo.RepairItemType");
            DropTable("dbo.RepairItem");
        }
    }
}

namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRepairMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstimateRepairParts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsId = c.Guid(nullable: false),
                        ServiceBookingId = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
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
                        ServiceRepair_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartsId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBookingId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepair_Id)
                .Index(t => t.PartsId)
                .Index(t => t.ServiceBookingId)
                .Index(t => t.ServiceRepair_Id);
            
            CreateTable(
                "dbo.ServiceBooking",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                        CarId = c.Guid(nullable: false),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        ContactAddress = c.String(),
                        ServiceAdvisorId = c.Guid(nullable: false),
                        RepairTypeId = c.Guid(nullable: false),
                        CustomerDescription = c.String(),
                        RepairDescription = c.String(),
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
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.RepairType", t => t.RepairTypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.ServiceAdvisorId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.ServiceAdvisorId)
                .Index(t => t.RepairTypeId);
            
            CreateTable(
                "dbo.ServiceRepairItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RepairItemId = c.Guid(nullable: false),
                        WordHour = c.Single(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MainOperatorId = c.Guid(nullable: false),
                        Name = c.String(),
                        OrderNum = c.Int(),
                        Description = c.String(),
                        CreateBy = c.Guid(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                        ServiceBooking_Id = c.Guid(),
                        ServiceRepair_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.MainOperatorId, cascadeDelete: true)
                .ForeignKey("dbo.RepairItem", t => t.RepairItemId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBooking_Id)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepair_Id)
                .Index(t => t.RepairItemId)
                .Index(t => t.MainOperatorId)
                .Index(t => t.ServiceBooking_Id)
                .Index(t => t.ServiceRepair_Id);
            
            CreateTable(
                "dbo.RepairParts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsId = c.Guid(nullable: false),
                        ServiceRepairId = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parts", t => t.PartsId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId, cascadeDelete: true)
                .Index(t => t.PartsId)
                .Index(t => t.ServiceRepairId);
            
            CreateTable(
                "dbo.ServiceRepair",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarId = c.Guid(nullable: false),
                        ServiceBookingId = c.Guid(),
                        ServiceRepairState = c.Int(nullable: false),
                        ServiceDateTime = c.DateTime(),
                        EstimateLeaveTime = c.DateTime(),
                        LeaveTime = c.DateTime(),
                        ServiceAdvisorId = c.Guid(nullable: false),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        RepairDescription = c.String(),
                        CustomerDescription = c.String(),
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
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.ServiceAdvisorId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBookingId)
                .Index(t => t.CarId)
                .Index(t => t.ServiceBookingId)
                .Index(t => t.ServiceAdvisorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceRepairItem", "ServiceRepair_Id", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepair", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceRepair", "ServiceAdvisorId", "dbo.User");
            DropForeignKey("dbo.RepairParts", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.EstimateRepairParts", "ServiceRepair_Id", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepair", "CarId", "dbo.Car");
            DropForeignKey("dbo.RepairParts", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.ServiceRepairItem", "ServiceBooking_Id", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceRepairItem", "RepairItemId", "dbo.RepairItem");
            DropForeignKey("dbo.ServiceRepairItem", "MainOperatorId", "dbo.User");
            DropForeignKey("dbo.ServiceBooking", "ServiceAdvisorId", "dbo.User");
            DropForeignKey("dbo.ServiceBooking", "RepairTypeId", "dbo.RepairType");
            DropForeignKey("dbo.EstimateRepairParts", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceBooking", "CarId", "dbo.Car");
            DropForeignKey("dbo.EstimateRepairParts", "PartsId", "dbo.Parts");
            DropIndex("dbo.ServiceRepair", new[] { "ServiceAdvisorId" });
            DropIndex("dbo.ServiceRepair", new[] { "ServiceBookingId" });
            DropIndex("dbo.ServiceRepair", new[] { "CarId" });
            DropIndex("dbo.RepairParts", new[] { "ServiceRepairId" });
            DropIndex("dbo.RepairParts", new[] { "PartsId" });
            DropIndex("dbo.ServiceRepairItem", new[] { "ServiceRepair_Id" });
            DropIndex("dbo.ServiceRepairItem", new[] { "ServiceBooking_Id" });
            DropIndex("dbo.ServiceRepairItem", new[] { "MainOperatorId" });
            DropIndex("dbo.ServiceRepairItem", new[] { "RepairItemId" });
            DropIndex("dbo.ServiceBooking", new[] { "RepairTypeId" });
            DropIndex("dbo.ServiceBooking", new[] { "ServiceAdvisorId" });
            DropIndex("dbo.ServiceBooking", new[] { "CarId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceRepair_Id" });
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceBookingId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "PartsId" });
            DropTable("dbo.ServiceRepair");
            DropTable("dbo.RepairParts");
            DropTable("dbo.ServiceRepairItem");
            DropTable("dbo.ServiceBooking");
            DropTable("dbo.EstimateRepairParts");
        }
    }
}

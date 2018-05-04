namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        ModelId = c.Guid(nullable: false),
                        CarFullName = c.String(),
                        VIN = c.String(),
                        PlateNum = c.String(),
                        EngineModelNo = c.String(),
                        EngineNo = c.String(),
                        CarLabel = c.String(),
                        CarImg = c.String(),
                        CarRegisterTime = c.DateTime(),
                        MaintainExpireTime = c.DateTime(),
                        NextMaintainMileage = c.Int(),
                        YearlyCheckTime = c.DateTime(),
                        SecondLevelMaintainTime = c.DateTime(),
                        LevelCheckTime = c.DateTime(),
                        TailCheckTime = c.DateTime(),
                        InsuranceExpireTime = c.DateTime(),
                        InsuranceOrg = c.String(),
                        InsuranceNo = c.String(),
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
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.CarModel", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        ServicePassword = c.String(),
                        ContactName = c.String(),
                        IDCard = c.String(),
                        FixPhone = c.String(),
                        Address = c.String(),
                        WeChat = c.String(),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(),
                        QQ = c.String(),
                        Hobby = c.String(),
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
            
            CreateTable(
                "dbo.CarModel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SeriesId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                        FullName = c.String(),
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
                .ForeignKey("dbo.CarSeries", t => t.SeriesId, cascadeDelete: true)
                .Index(t => t.SeriesId);
            
            CreateTable(
                "dbo.CarSeries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BrandId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.CarBrand", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.CarBrand",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
            
            CreateTable(
                "dbo.Job",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrgId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Organization", t => t.OrgId, cascadeDelete: true)
                .Index(t => t.OrgId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrgHope = c.String(),
                        ParentId = c.Guid(),
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
                .ForeignKey("dbo.Organization", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Account = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        Tel = c.String(),
                        OrgId = c.Guid(),
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
                .ForeignKey("dbo.Organization", t => t.OrgId)
                .Index(t => t.Account, unique: true)
                .Index(t => t.OrgId);
            
            CreateTable(
                "dbo.OperationLog",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ModuleName = c.String(),
                        OperationDesc = c.String(),
                        OperationTime = c.DateTime(nullable: false),
                        IpAddress = c.String(),
                        OperationUserId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.User", t => t.OperationUserId, cascadeDelete: true)
                .Index(t => t.OperationUserId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Icon = c.String(),
                        QuickMenuIcon = c.String(),
                        SelectedIcon = c.String(),
                        Url = c.String(),
                        ParentId = c.Guid(),
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
                .ForeignKey("dbo.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.QuickMenu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        MenuId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
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
            DropForeignKey("dbo.QuickMenu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.User", "OrgId", "dbo.Organization");
            DropForeignKey("dbo.OperationLog", "OperationUserId", "dbo.User");
            DropForeignKey("dbo.Organization", "ParentId", "dbo.Organization");
            DropForeignKey("dbo.Job", "OrgId", "dbo.Organization");
            DropForeignKey("dbo.CarModel", "SeriesId", "dbo.CarSeries");
            DropForeignKey("dbo.CarSeries", "BrandId", "dbo.CarBrand");
            DropForeignKey("dbo.Car", "ModelId", "dbo.CarModel");
            DropForeignKey("dbo.Car", "CustomerId", "dbo.Customer");
            DropIndex("dbo.RepairItem", new[] { "RepairItemTypeId" });
            DropIndex("dbo.QuickMenu", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.OperationLog", new[] { "OperationUserId" });
            DropIndex("dbo.User", new[] { "OrgId" });
            DropIndex("dbo.User", new[] { "Account" });
            DropIndex("dbo.Organization", new[] { "ParentId" });
            DropIndex("dbo.Job", new[] { "OrgId" });
            DropIndex("dbo.CarSeries", new[] { "BrandId" });
            DropIndex("dbo.CarModel", new[] { "SeriesId" });
            DropIndex("dbo.Car", new[] { "ModelId" });
            DropIndex("dbo.Car", new[] { "CustomerId" });
            DropTable("dbo.RepairType");
            DropTable("dbo.RepairItemType");
            DropTable("dbo.RepairItem");
            DropTable("dbo.QuickMenu");
            DropTable("dbo.Menu");
            DropTable("dbo.OperationLog");
            DropTable("dbo.User");
            DropTable("dbo.Organization");
            DropTable("dbo.Job");
            DropTable("dbo.CarBrand");
            DropTable("dbo.CarSeries");
            DropTable("dbo.CarModel");
            DropTable("dbo.Customer");
            DropTable("dbo.Car");
        }
    }
}

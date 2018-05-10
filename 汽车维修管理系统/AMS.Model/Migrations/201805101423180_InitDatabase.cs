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
                        CarOwnerName = c.String(),
                        CarOwnerPhone = c.String(),
                        ModelId = c.Guid(nullable: false),
                        CarFullName = c.String(),
                        VIN = c.String(),
                        PlateNum = c.String(),
                        Color = c.String(),
                        EngineModelNo = c.String(),
                        EngineNo = c.String(),
                        CarLabel = c.String(),
                        CarImg = c.String(),
                        CarRegisterTime = c.DateTime(),
                        MaintainExpireTime = c.DateTime(),
                        CurrentMileage = c.Int(),
                        NextMaintainMileage = c.Int(),
                        YearlyCheckTime = c.DateTime(),
                        SecondLevelMaintainTime = c.DateTime(),
                        LevelCheckTime = c.DateTime(),
                        TailCheckTime = c.DateTime(),
                        InsuranceExpireTime = c.DateTime(),
                        InsuranceOrg = c.String(),
                        InsuranceNo = c.String(),
                        FirstServiceTime = c.DateTime(),
                        LastServiceTime = c.DateTime(),
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
                "dbo.PartsDictionarySuitedCarModel",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsDictionaryId = c.Guid(nullable: false),
                        BrandId = c.Guid(),
                        SeriesId = c.Guid(),
                        ModelId = c.Guid(),
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
                .ForeignKey("dbo.CarBrand", t => t.BrandId)
                .ForeignKey("dbo.CarSeries", t => t.SeriesId)
                .ForeignKey("dbo.CarModel", t => t.ModelId)
                .ForeignKey("dbo.PartsDictionary", t => t.PartsDictionaryId, cascadeDelete: true)
                .Index(t => t.PartsDictionaryId)
                .Index(t => t.BrandId)
                .Index(t => t.SeriesId)
                .Index(t => t.ModelId);
            
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
                "dbo.PartsDictionary",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false),
                        PartsTypeId = c.Guid(nullable: false),
                        MeasurementUnit = c.String(),
                        SupplierPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RetailPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TradePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdjustPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClaimPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BrandName = c.String(),
                        Specifications = c.String(),
                        ProducedAddress = c.String(),
                        Label = c.String(),
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
                .ForeignKey("dbo.PartsType", t => t.PartsTypeId, cascadeDelete: true)
                .Index(t => t.PartsTypeId);
            
            CreateTable(
                "dbo.PartsType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
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
                .ForeignKey("dbo.PartsType", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.EstimateRepairParts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsId = c.Guid(nullable: false),
                        ServiceBookingId = c.Guid(nullable: false),
                        ServiceRepairId = c.Guid(),
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
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBookingId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId)
                .Index(t => t.PartsId)
                .Index(t => t.ServiceBookingId)
                .Index(t => t.ServiceRepairId);
            
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
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        Address = c.String(),
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
                "dbo.RepairType",
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
                "dbo.ServiceRepairItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RepairItemId = c.Guid(nullable: false),
                        ServiceBookingId = c.Guid(),
                        ServiceRepairId = c.Guid(),
                        WordHour = c.Single(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        MainOperatorId = c.Guid(),
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
                .ForeignKey("dbo.User", t => t.MainOperatorId)
                .ForeignKey("dbo.RepairItem", t => t.RepairItemId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBookingId)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId)
                .Index(t => t.RepairItemId)
                .Index(t => t.ServiceBookingId)
                .Index(t => t.ServiceRepairId)
                .Index(t => t.MainOperatorId);
            
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
                        CreateBy = c.Guid(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
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
                        CreateBy = c.Guid(),
                        State = c.Int(nullable: false),
                        OperationType = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        UpdateBy = c.Guid(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Supplier",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(nullable: false),
                        ContactName = c.String(),
                        MobilePhone = c.String(),
                        FixPhone = c.String(),
                        Fax = c.String(),
                        MajorOrigin = c.String(),
                        BankName = c.String(),
                        BankAccount = c.String(),
                        Address = c.String(),
                        Gender = c.Int(),
                        Birthday = c.DateTime(),
                        Wechat = c.String(),
                        QQ = c.String(),
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
            DropForeignKey("dbo.QuickMenu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.ServiceRepairItem", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepair", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceRepair", "ServiceAdvisorId", "dbo.User");
            DropForeignKey("dbo.RepairParts", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.RepairParts", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.EstimateRepairParts", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepair", "CarId", "dbo.Car");
            DropForeignKey("dbo.ServiceRepairItem", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceRepairItem", "RepairItemId", "dbo.RepairItem");
            DropForeignKey("dbo.RepairItem", "RepairItemTypeId", "dbo.RepairItemType");
            DropForeignKey("dbo.ServiceRepairItem", "MainOperatorId", "dbo.User");
            DropForeignKey("dbo.ServiceBooking", "ServiceAdvisorId", "dbo.User");
            DropForeignKey("dbo.User", "OrgId", "dbo.Organization");
            DropForeignKey("dbo.Organization", "ParentId", "dbo.Organization");
            DropForeignKey("dbo.Job", "OrgId", "dbo.Organization");
            DropForeignKey("dbo.OperationLog", "OperationUserId", "dbo.User");
            DropForeignKey("dbo.ServiceBooking", "RepairTypeId", "dbo.RepairType");
            DropForeignKey("dbo.EstimateRepairParts", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceBooking", "CarId", "dbo.Car");
            DropForeignKey("dbo.EstimateRepairParts", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.Parts", "PartsDictionaryId", "dbo.PartsDictionary");
            DropForeignKey("dbo.PartsBuy", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.Parts", "PartsBuyId", "dbo.PartsBuy");
            DropForeignKey("dbo.PartsDictionary", "PartsTypeId", "dbo.PartsType");
            DropForeignKey("dbo.PartsType", "ParentId", "dbo.PartsType");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "PartsDictionaryId", "dbo.PartsDictionary");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "ModelId", "dbo.CarModel");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "SeriesId", "dbo.CarSeries");
            DropForeignKey("dbo.CarModel", "SeriesId", "dbo.CarSeries");
            DropForeignKey("dbo.CarSeries", "BrandId", "dbo.CarBrand");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "BrandId", "dbo.CarBrand");
            DropForeignKey("dbo.Car", "ModelId", "dbo.CarModel");
            DropForeignKey("dbo.Car", "CustomerId", "dbo.Customer");
            DropIndex("dbo.QuickMenu", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.RepairParts", new[] { "ServiceRepairId" });
            DropIndex("dbo.RepairParts", new[] { "PartsId" });
            DropIndex("dbo.ServiceRepair", new[] { "ServiceAdvisorId" });
            DropIndex("dbo.ServiceRepair", new[] { "ServiceBookingId" });
            DropIndex("dbo.ServiceRepair", new[] { "CarId" });
            DropIndex("dbo.RepairItem", new[] { "RepairItemTypeId" });
            DropIndex("dbo.ServiceRepairItem", new[] { "MainOperatorId" });
            DropIndex("dbo.ServiceRepairItem", new[] { "ServiceRepairId" });
            DropIndex("dbo.ServiceRepairItem", new[] { "ServiceBookingId" });
            DropIndex("dbo.ServiceRepairItem", new[] { "RepairItemId" });
            DropIndex("dbo.Job", new[] { "OrgId" });
            DropIndex("dbo.Organization", new[] { "ParentId" });
            DropIndex("dbo.OperationLog", new[] { "OperationUserId" });
            DropIndex("dbo.User", new[] { "OrgId" });
            DropIndex("dbo.User", new[] { "Account" });
            DropIndex("dbo.ServiceBooking", new[] { "RepairTypeId" });
            DropIndex("dbo.ServiceBooking", new[] { "ServiceAdvisorId" });
            DropIndex("dbo.ServiceBooking", new[] { "CarId" });
            DropIndex("dbo.PartsBuy", new[] { "WarehouseId" });
            DropIndex("dbo.Parts", new[] { "PartsBuyId" });
            DropIndex("dbo.Parts", new[] { "PartsDictionaryId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceRepairId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceBookingId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "PartsId" });
            DropIndex("dbo.PartsType", new[] { "ParentId" });
            DropIndex("dbo.PartsDictionary", new[] { "PartsTypeId" });
            DropIndex("dbo.CarSeries", new[] { "BrandId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "ModelId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "SeriesId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "BrandId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "PartsDictionaryId" });
            DropIndex("dbo.CarModel", new[] { "SeriesId" });
            DropIndex("dbo.Car", new[] { "ModelId" });
            DropIndex("dbo.Car", new[] { "CustomerId" });
            DropTable("dbo.Supplier");
            DropTable("dbo.QuickMenu");
            DropTable("dbo.Menu");
            DropTable("dbo.RepairParts");
            DropTable("dbo.ServiceRepair");
            DropTable("dbo.RepairItemType");
            DropTable("dbo.RepairItem");
            DropTable("dbo.ServiceRepairItem");
            DropTable("dbo.Job");
            DropTable("dbo.Organization");
            DropTable("dbo.OperationLog");
            DropTable("dbo.User");
            DropTable("dbo.RepairType");
            DropTable("dbo.ServiceBooking");
            DropTable("dbo.Warehouse");
            DropTable("dbo.PartsBuy");
            DropTable("dbo.Parts");
            DropTable("dbo.EstimateRepairParts");
            DropTable("dbo.PartsType");
            DropTable("dbo.PartsDictionary");
            DropTable("dbo.CarSeries");
            DropTable("dbo.CarBrand");
            DropTable("dbo.PartsDictionarySuitedCarModel");
            DropTable("dbo.CarModel");
            DropTable("dbo.Customer");
            DropTable("dbo.Car");
        }
    }
}

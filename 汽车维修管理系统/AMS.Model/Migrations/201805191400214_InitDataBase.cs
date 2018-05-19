namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillNoSetting",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Prefix = c.String(),
                        DateFormat = c.Int(nullable: false),
                        SerNoLength = c.Int(nullable: false),
                        DailyReset = c.Boolean(nullable: false),
                        BillNoPreview = c.String(),
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
                        NextMaintainDate = c.DateTime(),
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
                        ContactPhone = c.String(),
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
                        Code = c.String(nullable: false, maxLength: 100),
                        PartsTypeId = c.Guid(nullable: false),
                        MeasurementUnit = c.String(),
                        SupplierPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RetailPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TradePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdjustPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClaimPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HighestAlertCount = c.Int(),
                        LowestAlertCount = c.Int(),
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
                .Index(t => t.Code, unique: true)
                .Index(t => t.PartsTypeId);
            
            CreateTable(
                "dbo.PartsIn",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsBuyId = c.Guid(nullable: false),
                        PartsDictionaryId = c.Guid(nullable: false),
                        PartsId = c.Guid(),
                        Count = c.Int(nullable: false),
                        SupplierPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.Parts", t => t.PartsId)
                .ForeignKey("dbo.PartsBuy", t => t.PartsBuyId, cascadeDelete: true)
                .ForeignKey("dbo.PartsDictionary", t => t.PartsDictionaryId, cascadeDelete: true)
                .Index(t => t.PartsBuyId)
                .Index(t => t.PartsDictionaryId)
                .Index(t => t.PartsId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsDictionaryId = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
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
                .ForeignKey("dbo.PartsDictionary", t => t.PartsDictionaryId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId)
                .Index(t => t.PartsDictionaryId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.EstimateRepairParts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsId = c.Guid(nullable: false),
                        ServiceBookingId = c.Guid(),
                        ServiceRepairId = c.Guid(),
                        ServiceAccountTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.ServiceAccountType", t => t.ServiceAccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId)
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBookingId)
                .Index(t => t.PartsId)
                .Index(t => t.ServiceBookingId)
                .Index(t => t.ServiceRepairId)
                .Index(t => t.ServiceAccountTypeId);
            
            CreateTable(
                "dbo.ServiceAccountType",
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
                "dbo.RepairParts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsId = c.Guid(nullable: false),
                        ServiceRepairId = c.Guid(nullable: false),
                        ServiceAccountTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.ServiceAccountType", t => t.ServiceAccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId, cascadeDelete: true)
                .Index(t => t.PartsId)
                .Index(t => t.ServiceRepairId)
                .Index(t => t.ServiceAccountTypeId);
            
            CreateTable(
                "dbo.ServiceRepair",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BillNo = c.String(),
                        BillNoIndex = c.Int(nullable: false),
                        CarId = c.Guid(nullable: false),
                        ServiceBookingId = c.Guid(),
                        ServiceRepairState = c.Int(),
                        ServiceWashState = c.Int(),
                        ServiceType = c.Int(),
                        RepairTypeId = c.Guid(),
                        ServiceDateTime = c.DateTime(),
                        EstimateLeaveTime = c.DateTime(),
                        LeaveTime = c.DateTime(),
                        ServiceAdvisorId = c.Guid(),
                        WashCarMainOperatorId = c.Guid(),
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
                .ForeignKey("dbo.RepairType", t => t.RepairTypeId)
                .ForeignKey("dbo.User", t => t.ServiceAdvisorId)
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBookingId)
                .ForeignKey("dbo.User", t => t.WashCarMainOperatorId)
                .Index(t => t.CarId)
                .Index(t => t.ServiceBookingId)
                .Index(t => t.RepairTypeId)
                .Index(t => t.ServiceAdvisorId)
                .Index(t => t.WashCarMainOperatorId);
            
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
                "dbo.ServiceBooking",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BillNo = c.String(),
                        BillNoIndex = c.Int(nullable: false),
                        BookingCreateTime = c.DateTime(nullable: false),
                        ServiceRepairTime = c.DateTime(nullable: false),
                        CarId = c.Guid(nullable: false),
                        ServiceBookingState = c.Int(nullable: false),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        ContactAddress = c.String(),
                        CompanyName = c.String(),
                        ServiceAdvisorId = c.Guid(nullable: false),
                        RepairTypeId = c.Guid(nullable: false),
                        CustomerDescription = c.String(),
                        RepairDescription = c.String(),
                        Remark = c.String(),
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
                        WorkHour = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        MainOperatorId = c.Guid(),
                        ServiceAccountTypeId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.ServiceAccountType", t => t.ServiceAccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceBooking", t => t.ServiceBookingId)
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId)
                .Index(t => t.RepairItemId)
                .Index(t => t.ServiceBookingId)
                .Index(t => t.ServiceRepairId)
                .Index(t => t.MainOperatorId)
                .Index(t => t.ServiceAccountTypeId);
            
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
            
            CreateTable(
                "dbo.ServiceRepairCashTicket",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ServiceRepairAccountTicketId = c.Guid(),
                        ServiceRepairId = c.Guid(),
                        ServiceTicketTypeId = c.Guid(),
                        TaxBillNo = c.String(),
                        ShouldPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WashCarDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WashCarCreditPay = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.ServiceRepair", t => t.ServiceRepairId)
                .ForeignKey("dbo.ServiceRepairAccountTicket", t => t.ServiceRepairAccountTicketId)
                .ForeignKey("dbo.ServiceTicketType", t => t.ServiceTicketTypeId)
                .Index(t => t.ServiceRepairAccountTicketId)
                .Index(t => t.ServiceRepairId)
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
            
            CreateTable(
                "dbo.PaymentType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IconUrl = c.String(),
                        SelectedIconUrl = c.String(),
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
                "dbo.ServiceTicketType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
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
            
            CreateTable(
                "dbo.PartsOut",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PartsReturnId = c.Guid(nullable: false),
                        PartsId = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
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
                .ForeignKey("dbo.PartsReturn", t => t.PartsReturnId, cascadeDelete: true)
                .Index(t => t.PartsReturnId)
                .Index(t => t.PartsId);
            
            CreateTable(
                "dbo.PartsReturn",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        BillNo = c.String(),
                        BillNoIndex = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        ApplyUser = c.String(),
                        CheckUser = c.String(),
                        OperationTime = c.DateTime(),
                        TotalMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);
            
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
            
            CreateTable(
                "dbo.PartsBuy",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SupplierId = c.Guid(nullable: false),
                        BillNo = c.String(),
                        BillNoIndex = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        ApplyUser = c.String(),
                        CheckUser = c.String(),
                        OperationTime = c.DateTime(),
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
                .ForeignKey("dbo.Supplier", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.SupplierId)
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
                "dbo.ParameterControl",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParameterName = c.String(maxLength: 100),
                        Value1 = c.String(),
                        Value2 = c.String(),
                        Value1Type1 = c.Int(nullable: false),
                        Value1Type2 = c.Int(nullable: false),
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
                .Index(t => t.ParameterName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuickMenu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.PartsDictionary", "PartsTypeId", "dbo.PartsType");
            DropForeignKey("dbo.PartsType", "ParentId", "dbo.PartsType");
            DropForeignKey("dbo.PartsIn", "PartsDictionaryId", "dbo.PartsDictionary");
            DropForeignKey("dbo.PartsReturn", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.PartsBuy", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.Parts", "WarehouseId", "dbo.Warehouse");
            DropForeignKey("dbo.PartsBuy", "SupplierId", "dbo.Supplier");
            DropForeignKey("dbo.PartsIn", "PartsBuyId", "dbo.PartsBuy");
            DropForeignKey("dbo.PartsOut", "PartsReturnId", "dbo.PartsReturn");
            DropForeignKey("dbo.PartsOut", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.PartsIn", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.Parts", "PartsDictionaryId", "dbo.PartsDictionary");
            DropForeignKey("dbo.ServiceRepair", "WashCarMainOperatorId", "dbo.User");
            DropForeignKey("dbo.ServiceWashItem", "WashItemId", "dbo.WashItem");
            DropForeignKey("dbo.ServiceWashItem", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceTicketTypeId", "dbo.ServiceTicketType");
            DropForeignKey("dbo.ServiceRpairPayment", "ServiceRepairCashTicketId", "dbo.ServiceRepairCashTicket");
            DropForeignKey("dbo.ServiceRpairPayment", "PaymentTypeId", "dbo.PaymentType");
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairAccountTicketId", "dbo.ServiceRepairAccountTicket");
            DropForeignKey("dbo.ServiceRepairCashTicket", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepairAccountTicket", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepair", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceRepair", "ServiceAdvisorId", "dbo.User");
            DropForeignKey("dbo.ServiceRepair", "RepairTypeId", "dbo.RepairType");
            DropForeignKey("dbo.ServiceBooking", "ServiceAdvisorId", "dbo.User");
            DropForeignKey("dbo.ServiceRepairItem", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepairItem", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceRepairItem", "ServiceAccountTypeId", "dbo.ServiceAccountType");
            DropForeignKey("dbo.ServiceRepairItem", "RepairItemId", "dbo.RepairItem");
            DropForeignKey("dbo.RepairItem", "RepairItemTypeId", "dbo.RepairItemType");
            DropForeignKey("dbo.ServiceRepairItem", "MainOperatorId", "dbo.User");
            DropForeignKey("dbo.User", "OrgId", "dbo.Organization");
            DropForeignKey("dbo.Organization", "ParentId", "dbo.Organization");
            DropForeignKey("dbo.Job", "OrgId", "dbo.Organization");
            DropForeignKey("dbo.OperationLog", "OperationUserId", "dbo.User");
            DropForeignKey("dbo.ServiceBooking", "RepairTypeId", "dbo.RepairType");
            DropForeignKey("dbo.EstimateRepairParts", "ServiceBookingId", "dbo.ServiceBooking");
            DropForeignKey("dbo.ServiceBooking", "CarId", "dbo.Car");
            DropForeignKey("dbo.RepairParts", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.EstimateRepairParts", "ServiceRepairId", "dbo.ServiceRepair");
            DropForeignKey("dbo.ServiceRepair", "CarId", "dbo.Car");
            DropForeignKey("dbo.RepairParts", "ServiceAccountTypeId", "dbo.ServiceAccountType");
            DropForeignKey("dbo.RepairParts", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.EstimateRepairParts", "ServiceAccountTypeId", "dbo.ServiceAccountType");
            DropForeignKey("dbo.EstimateRepairParts", "PartsId", "dbo.Parts");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "PartsDictionaryId", "dbo.PartsDictionary");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "ModelId", "dbo.CarModel");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "SeriesId", "dbo.CarSeries");
            DropForeignKey("dbo.CarModel", "SeriesId", "dbo.CarSeries");
            DropForeignKey("dbo.CarSeries", "BrandId", "dbo.CarBrand");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "BrandId", "dbo.CarBrand");
            DropForeignKey("dbo.Car", "ModelId", "dbo.CarModel");
            DropForeignKey("dbo.Car", "CustomerId", "dbo.Customer");
            DropIndex("dbo.ParameterControl", new[] { "ParameterName" });
            DropIndex("dbo.QuickMenu", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.PartsType", new[] { "ParentId" });
            DropIndex("dbo.PartsBuy", new[] { "WarehouseId" });
            DropIndex("dbo.PartsBuy", new[] { "SupplierId" });
            DropIndex("dbo.PartsReturn", new[] { "SupplierId" });
            DropIndex("dbo.PartsOut", new[] { "PartsId" });
            DropIndex("dbo.PartsOut", new[] { "PartsReturnId" });
            DropIndex("dbo.ServiceWashItem", new[] { "ServiceRepairId" });
            DropIndex("dbo.ServiceWashItem", new[] { "WashItemId" });
            DropIndex("dbo.ServiceRpairPayment", new[] { "PaymentTypeId" });
            DropIndex("dbo.ServiceRpairPayment", new[] { "ServiceRepairCashTicketId" });
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceTicketTypeId" });
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceRepairId" });
            DropIndex("dbo.ServiceRepairCashTicket", new[] { "ServiceRepairAccountTicketId" });
            DropIndex("dbo.ServiceRepairAccountTicket", new[] { "ServiceRepairId" });
            DropIndex("dbo.RepairItem", new[] { "RepairItemTypeId" });
            DropIndex("dbo.ServiceRepairItem", new[] { "ServiceAccountTypeId" });
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
            DropIndex("dbo.ServiceRepair", new[] { "WashCarMainOperatorId" });
            DropIndex("dbo.ServiceRepair", new[] { "ServiceAdvisorId" });
            DropIndex("dbo.ServiceRepair", new[] { "RepairTypeId" });
            DropIndex("dbo.ServiceRepair", new[] { "ServiceBookingId" });
            DropIndex("dbo.ServiceRepair", new[] { "CarId" });
            DropIndex("dbo.RepairParts", new[] { "ServiceAccountTypeId" });
            DropIndex("dbo.RepairParts", new[] { "ServiceRepairId" });
            DropIndex("dbo.RepairParts", new[] { "PartsId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceAccountTypeId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceRepairId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "ServiceBookingId" });
            DropIndex("dbo.EstimateRepairParts", new[] { "PartsId" });
            DropIndex("dbo.Parts", new[] { "WarehouseId" });
            DropIndex("dbo.Parts", new[] { "PartsDictionaryId" });
            DropIndex("dbo.PartsIn", new[] { "PartsId" });
            DropIndex("dbo.PartsIn", new[] { "PartsDictionaryId" });
            DropIndex("dbo.PartsIn", new[] { "PartsBuyId" });
            DropIndex("dbo.PartsDictionary", new[] { "PartsTypeId" });
            DropIndex("dbo.PartsDictionary", new[] { "Code" });
            DropIndex("dbo.CarSeries", new[] { "BrandId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "ModelId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "SeriesId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "BrandId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "PartsDictionaryId" });
            DropIndex("dbo.CarModel", new[] { "SeriesId" });
            DropIndex("dbo.Car", new[] { "ModelId" });
            DropIndex("dbo.Car", new[] { "CustomerId" });
            DropTable("dbo.ParameterControl");
            DropTable("dbo.QuickMenu");
            DropTable("dbo.Menu");
            DropTable("dbo.PartsType");
            DropTable("dbo.Warehouse");
            DropTable("dbo.PartsBuy");
            DropTable("dbo.Supplier");
            DropTable("dbo.PartsReturn");
            DropTable("dbo.PartsOut");
            DropTable("dbo.WashItem");
            DropTable("dbo.ServiceWashItem");
            DropTable("dbo.ServiceTicketType");
            DropTable("dbo.PaymentType");
            DropTable("dbo.ServiceRpairPayment");
            DropTable("dbo.ServiceRepairCashTicket");
            DropTable("dbo.ServiceRepairAccountTicket");
            DropTable("dbo.RepairItemType");
            DropTable("dbo.RepairItem");
            DropTable("dbo.ServiceRepairItem");
            DropTable("dbo.Job");
            DropTable("dbo.Organization");
            DropTable("dbo.OperationLog");
            DropTable("dbo.User");
            DropTable("dbo.ServiceBooking");
            DropTable("dbo.RepairType");
            DropTable("dbo.ServiceRepair");
            DropTable("dbo.RepairParts");
            DropTable("dbo.ServiceAccountType");
            DropTable("dbo.EstimateRepairParts");
            DropTable("dbo.Parts");
            DropTable("dbo.PartsIn");
            DropTable("dbo.PartsDictionary");
            DropTable("dbo.CarSeries");
            DropTable("dbo.CarBrand");
            DropTable("dbo.PartsDictionarySuitedCarModel");
            DropTable("dbo.CarModel");
            DropTable("dbo.Customer");
            DropTable("dbo.Car");
            DropTable("dbo.BillNoSetting");
        }
    }
}

namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTabelCar_Customer_CustomerCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BrandName = c.String(),
                        SeriesName = c.String(),
                        ModelNo = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FullName = c.String(),
                        Color = c.String(),
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
                "dbo.CustomerCar",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        VIN = c.String(),
                        PlateNum = c.String(),
                        CarId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.Car", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CarId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCar", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.CustomerCar", "CarId", "dbo.Car");
            DropIndex("dbo.CustomerCar", new[] { "CarId" });
            DropIndex("dbo.CustomerCar", new[] { "CustomerId" });
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerCar");
            DropTable("dbo.Car");
        }
    }
}

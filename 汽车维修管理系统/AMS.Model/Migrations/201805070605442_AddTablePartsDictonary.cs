namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePartsDictonary : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartsDictionary", "PartsTypeId", "dbo.PartsType");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "PartsDictionaryId", "dbo.PartsDictionary");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "ModelId", "dbo.CarModel");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "SeriesId", "dbo.CarSeries");
            DropForeignKey("dbo.PartsDictionarySuitedCarModel", "BrandId", "dbo.CarBrand");
            DropIndex("dbo.PartsDictionary", new[] { "PartsTypeId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "ModelId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "SeriesId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "BrandId" });
            DropIndex("dbo.PartsDictionarySuitedCarModel", new[] { "PartsDictionaryId" });
            DropTable("dbo.PartsDictionary");
            DropTable("dbo.PartsDictionarySuitedCarModel");
        }
    }
}

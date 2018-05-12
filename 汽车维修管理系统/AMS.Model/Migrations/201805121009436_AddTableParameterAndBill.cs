namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableParameterAndBill : DbMigration
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
                "dbo.ParameterControll",
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
            DropIndex("dbo.ParameterControll", new[] { "ParameterName" });
            DropTable("dbo.ParameterControll");
            DropTable("dbo.BillNoSetting");
        }
    }
}

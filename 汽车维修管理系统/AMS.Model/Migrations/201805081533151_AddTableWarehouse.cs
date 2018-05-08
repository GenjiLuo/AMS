namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableWarehouse : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Warehouse");
        }
    }
}

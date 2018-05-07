namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableSupplier : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Supplier");
        }
    }
}

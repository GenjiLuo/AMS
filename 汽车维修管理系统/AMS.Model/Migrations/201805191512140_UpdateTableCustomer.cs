namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "PreChargeMoney", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Customer", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "TotalCost");
            DropColumn("dbo.Customer", "PreChargeMoney");
        }
    }
}

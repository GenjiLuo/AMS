namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCashTicket2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepairCashTicket", "WashCarCreditPay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRepairCashTicket", "WashCarCreditPay");
        }
    }
}

namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablePaymentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentType", "IconUrl", c => c.String());
            AddColumn("dbo.PaymentType", "SelectedIconUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentType", "SelectedIconUrl");
            DropColumn("dbo.PaymentType", "IconUrl");
        }
    }
}

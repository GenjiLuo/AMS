namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceBooking1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceBooking", "BillNoIndex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceBooking", "BillNoIndex");
        }
    }
}

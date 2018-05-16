namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceBooking", "BillNo", c => c.String());
            AddColumn("dbo.ServiceBooking", "BookingCreateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceBooking", "ServiceRepairTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.ServiceBooking", "ServiceBookingState", c => c.Int(nullable: false));
            DropColumn("dbo.ServiceBooking", "BookingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceBooking", "BookingTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.ServiceBooking", "ServiceBookingState");
            DropColumn("dbo.ServiceBooking", "ServiceRepairTime");
            DropColumn("dbo.ServiceBooking", "BookingCreateTime");
            DropColumn("dbo.ServiceBooking", "BillNo");
        }
    }
}

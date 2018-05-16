namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceBooking", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceBooking", "Remark");
        }
    }
}

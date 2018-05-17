namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "NextMaintainDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Car", "NextMaintainDate");
        }
    }
}

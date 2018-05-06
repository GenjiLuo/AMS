namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Car", "CarOwnerName", c => c.String());
            AddColumn("dbo.Car", "CarOwnerPhone", c => c.String());
            AddColumn("dbo.Car", "Color", c => c.String());
            AddColumn("dbo.Car", "CurrentMileage", c => c.Int());
            AddColumn("dbo.Car", "FirstServiceTime", c => c.DateTime());
            AddColumn("dbo.Car", "LastServiceTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Car", "LastServiceTime");
            DropColumn("dbo.Car", "FirstServiceTime");
            DropColumn("dbo.Car", "CurrentMileage");
            DropColumn("dbo.Car", "Color");
            DropColumn("dbo.Car", "CarOwnerPhone");
            DropColumn("dbo.Car", "CarOwnerName");
        }
    }
}

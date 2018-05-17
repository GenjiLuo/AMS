namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceRepair2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceRepairItem", "WorkHour", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceRepairItem", "WorkHour", c => c.Single());
        }
    }
}

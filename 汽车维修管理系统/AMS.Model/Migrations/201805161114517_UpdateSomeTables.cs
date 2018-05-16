namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSomeTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepairItem", "WorkHour", c => c.Single());
            DropColumn("dbo.ServiceRepairItem", "WordHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceRepairItem", "WordHour", c => c.Single());
            DropColumn("dbo.ServiceRepairItem", "WorkHour");
        }
    }
}

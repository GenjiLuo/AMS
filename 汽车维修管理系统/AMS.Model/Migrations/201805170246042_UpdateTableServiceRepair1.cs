namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceRepair1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepair", "ServiceWashState", c => c.Int());
            AddColumn("dbo.ServiceRepair", "ServiceType", c => c.Int(nullable: false));
            AlterColumn("dbo.ServiceRepair", "ServiceRepairState", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceRepair", "ServiceRepairState", c => c.Int(nullable: false));
            DropColumn("dbo.ServiceRepair", "ServiceType");
            DropColumn("dbo.ServiceRepair", "ServiceWashState");
        }
    }
}

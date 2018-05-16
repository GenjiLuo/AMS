namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableServiceRepair : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRepair", "BillNo", c => c.String());
            AddColumn("dbo.ServiceRepair", "BillNoIndex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRepair", "BillNoIndex");
            DropColumn("dbo.ServiceRepair", "BillNo");
        }
    }
}

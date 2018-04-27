namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnOrganizationState : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organization", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organization", "State");
        }
    }
}

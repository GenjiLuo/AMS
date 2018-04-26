namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnOrganizationOrgHope : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organization", "OrgHope", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organization", "OrgHope");
        }
    }
}

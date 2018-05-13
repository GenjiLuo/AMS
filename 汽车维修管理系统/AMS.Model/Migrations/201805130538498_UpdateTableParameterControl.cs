namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableParameterControl : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ParameterControll", newName: "ParameterControl");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ParameterControl", newName: "ParameterControll");
        }
    }
}

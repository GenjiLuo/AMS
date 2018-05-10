namespace AMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablePartsBuy : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PartsBuy", "SupplierId");
            AddForeignKey("dbo.PartsBuy", "SupplierId", "dbo.Supplier", "Id", cascadeDelete: true);
            DropColumn("dbo.PartsBuy", "SupplierName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartsBuy", "SupplierName", c => c.String());
            DropForeignKey("dbo.PartsBuy", "SupplierId", "dbo.Supplier");
            DropIndex("dbo.PartsBuy", new[] { "SupplierId" });
        }
    }
}

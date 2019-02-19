namespace EntityRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        CustomerID = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropTable("dbo.Orders");
        }
    }
}

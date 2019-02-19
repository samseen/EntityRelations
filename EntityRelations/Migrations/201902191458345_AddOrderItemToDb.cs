namespace EntityRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderItemToDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrderItems", newName: "OrderItem1");
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        ItemID = c.Guid(nullable: false),
                        OrderID = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.ItemID, t.OrderID })
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ItemID", "dbo.Items");
            DropIndex("dbo.OrderItems", new[] { "OrderID" });
            DropIndex("dbo.OrderItems", new[] { "ItemID" });
            DropTable("dbo.OrderItems");
            RenameTable(name: "dbo.OrderItem1", newName: "OrderItems");
        }
    }
}

namespace EntityRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddACollectionOfItemsToOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Item_ItemID", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "Item_ItemID" });
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Order_OrderID = c.Guid(nullable: false),
                        Item_ItemID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderID, t.Item_ItemID })
                .ForeignKey("dbo.Orders", t => t.Order_OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_ItemID, cascadeDelete: true)
                .Index(t => t.Order_OrderID)
                .Index(t => t.Item_ItemID);
            
            DropColumn("dbo.Orders", "Item_ItemID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Item_ItemID", c => c.Guid());
            DropForeignKey("dbo.OrderItems", "Item_ItemID", "dbo.Items");
            DropForeignKey("dbo.OrderItems", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Item_ItemID" });
            DropIndex("dbo.OrderItems", new[] { "Order_OrderID" });
            DropTable("dbo.OrderItems");
            CreateIndex("dbo.Orders", "Item_ItemID");
            AddForeignKey("dbo.Orders", "Item_ItemID", "dbo.Items", "ItemID");
        }
    }
}

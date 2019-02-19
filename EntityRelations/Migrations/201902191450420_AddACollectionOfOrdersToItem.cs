namespace EntityRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddACollectionOfOrdersToItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Item_ItemID", c => c.Guid());
            CreateIndex("dbo.Orders", "Item_ItemID");
            AddForeignKey("dbo.Orders", "Item_ItemID", "dbo.Items", "ItemID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Item_ItemID", "dbo.Items");
            DropIndex("dbo.Orders", new[] { "Item_ItemID" });
            DropColumn("dbo.Orders", "Item_ItemID");
        }
    }
}

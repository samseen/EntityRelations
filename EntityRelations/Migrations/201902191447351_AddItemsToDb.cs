namespace EntityRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemsToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 128),
                        ReorderQuantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}

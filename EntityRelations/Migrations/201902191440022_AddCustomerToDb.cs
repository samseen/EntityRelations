namespace EntityRelations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}

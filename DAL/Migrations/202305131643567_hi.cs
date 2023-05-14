namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "customer_id", c => c.String());
            AddColumn("dbo.Carts", "Customer_customer_id", c => c.Int());
            AddColumn("dbo.Pays", "orderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "Customer_customer_id");
            CreateIndex("dbo.Pays", "orderId");
            AddForeignKey("dbo.Carts", "Customer_customer_id", "dbo.Customers", "customer_id");
            AddForeignKey("dbo.Pays", "orderId", "dbo.Orders", "orderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "orderId", "dbo.Orders");
            DropForeignKey("dbo.Carts", "Customer_customer_id", "dbo.Customers");
            DropIndex("dbo.Pays", new[] { "orderId" });
            DropIndex("dbo.Carts", new[] { "Customer_customer_id" });
            DropColumn("dbo.Pays", "orderId");
            DropColumn("dbo.Carts", "Customer_customer_id");
            DropColumn("dbo.Carts", "customer_id");
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 100),
                        last_name = c.String(nullable: false, maxLength: 100),
                        phone_number = c.String(nullable: false, maxLength: 14),
                        email = c.String(nullable: false, maxLength: 100),
                        password = c.String(nullable: false, maxLength: 100),
                        gender = c.String(nullable: false, maxLength: 6),
                        dob = c.DateTime(nullable: false),
                        address = c.String(nullable: false, maxLength: 100),
                        picture = c.String(),
                        review = c.String(),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.DeliveryMen",
                c => new
                    {
                        DelId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Gender = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                        Dob = c.DateTime(nullable: false),
                        Zip_Code = c.Int(nullable: false),
                        nid = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DelId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        qty = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        productID = c.Int(nullable: false),
                        orderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        Order_Date = c.DateTime(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        total_price = c.Int(nullable: false),
                        status = c.String(nullable: false),
                        custId = c.Int(nullable: false),
                        DelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        prompid = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                        discount_amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.prompid);
            
            CreateTable(
                "dbo.Searches",
                c => new
                    {
                        search_Id = c.Int(nullable: false, identity: true),
                        cust_id = c.Int(nullable: false),
                        search_text = c.String(),
                    })
                .PrimaryKey(t => t.search_Id)
                .ForeignKey("dbo.Customers", t => t.cust_id, cascadeDelete: true)
                .Index(t => t.cust_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Searches", "cust_id", "dbo.Customers");
            DropIndex("dbo.Searches", new[] { "cust_id" });
            DropTable("dbo.Searches");
            DropTable("dbo.Promotions");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.DeliveryMen");
            DropTable("dbo.Customers");
        }
    }
}

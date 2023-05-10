namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        Image = c.String(),
                        C_Id = c.Int(nullable: false),
                        SellBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.C_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellBy, cascadeDelete: true)
                .Index(t => t.C_Id)
                .Index(t => t.SellBy);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seller_Name = c.String(nullable: false, maxLength: 50),
                        Shop_Name = c.String(nullable: false, maxLength: 50),
                        Seller_Email = c.String(nullable: false),
                        Seller_Password = c.String(nullable: false),
                        Seller_Address = c.String(nullable: false),
                        Seller_Phone = c.String(nullable: false),
                        Seller_JoinDate = c.DateTime(nullable: false),
                        Seller_Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenString = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SellBy", "dbo.Sellers");
            DropForeignKey("dbo.Products", "C_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "SellBy" });
            DropIndex("dbo.Products", new[] { "C_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tokens");
            DropTable("dbo.Sellers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}

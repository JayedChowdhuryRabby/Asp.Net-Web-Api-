namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "OrderId", c => c.Int(nullable: false));
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hjk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pays");
        }
    }
}

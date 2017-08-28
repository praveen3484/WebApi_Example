namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCarStockTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarName = c.String(),
                        CarModel = c.String(),
                        CarColor = c.String(),
                        CarPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarStocks");
        }
    }
}

namespace MyShop.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Add_Basket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BasketId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Basket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.Basket_Id)
                .Index(t => t.Basket_Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "Basket_Id", "dbo.Baskets");
            DropIndex("dbo.BasketItems", new[] { "Basket_Id" });
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}

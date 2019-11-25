namespace JewerlyRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGemstones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gemstones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.Int(nullable: false),
                        Colour = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gemstones", "ProductId", "dbo.Products");
            DropIndex("dbo.Gemstones", new[] { "ProductId" });
            DropTable("dbo.Gemstones");
        }
    }
}

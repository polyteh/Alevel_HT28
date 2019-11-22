namespace JewerlyRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveTypeToTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JewTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "JewTypeId", c => c.Int(nullable: false));

            Sql(
            @"INSERT INTO JewTypes (Name) SELECT pr.Type FROM Products pr group by pr.Type"
            );
            Sql(
            @"UPDATE Products SET JewTypeId=jw.Id FROM Products AS pr INNER JOIN JewTypes AS jw ON pr.Type = jw.Name"
            );

            CreateIndex("dbo.Products", "JewTypeId");
            AddForeignKey("dbo.Products", "JewTypeId", "dbo.JewTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Type", c => c.String());

            Sql(
            @"UPDATE Products SET Type =jw.Name FROM Products AS pr INNER JOIN JewTypes AS jw ON pr.JewTypeId = jw.Id"
            );

            DropForeignKey("dbo.Products", "JewTypeId", "dbo.JewTypes");
            DropIndex("dbo.Products", new[] { "JewTypeId" });
            DropColumn("dbo.Products", "JewTypeId");
            DropTable("dbo.JewTypes");
        }
    }
}

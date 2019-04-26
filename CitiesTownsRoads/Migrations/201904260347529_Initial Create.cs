namespace CitiesTownsRoads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Country_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        City_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roads", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Roads", new[] { "City_Id" });
            DropIndex("dbo.Cities", new[] { "Country_Id" });
            DropTable("dbo.Roads");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}

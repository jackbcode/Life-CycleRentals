namespace Life_CycleRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _AddBike : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Picture = c.String(),
                        StyleId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        YearBuilt = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.Styles",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "StyleId", "dbo.Styles");
            DropIndex("dbo.Bikes", new[] { "StyleId" });
            DropTable("dbo.Styles");
            DropTable("dbo.Bikes");
        }
    }
}

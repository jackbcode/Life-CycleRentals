namespace Life_CycleRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Style : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Styles (Id, Name) VALUES (1, 'Road')");
            Sql("INSERT INTO Styles (Id, Name) VALUES (2, 'Adventure Road')");
            Sql("INSERT INTO Styles (Id, Name) VALUES (3, 'Hybrid')");
            Sql("INSERT INTO Styles (Id, Name) VALUES (4, 'Mountain')");
            Sql("INSERT INTO Styles (Id, Name) VALUES (5, 'BMX')");
        }
        
        public override void Down()
        {
        }
    }
}

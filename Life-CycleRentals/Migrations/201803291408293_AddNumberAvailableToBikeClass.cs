namespace Life_CycleRentals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToBikeClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bikes", "NumberAvailable", c => c.Byte(nullable: false));

            Sql("UPDATE Bikes SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bikes", "NumberAvailable");
        }
    }
}

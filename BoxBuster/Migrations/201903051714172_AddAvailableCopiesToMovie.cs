namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableCopiesToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableCopies", c => c.Byte(nullable: false));

            Sql("UPDATE Movies SET AvailableCopies = Stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableCopies");
        }
    }
}

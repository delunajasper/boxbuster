namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieRentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieRentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.MovieRentals", new[] { "Movie_Id" });
            DropIndex("dbo.MovieRentals", new[] { "Customer_Id" });
            DropTable("dbo.MovieRentals");
        }
    }
}

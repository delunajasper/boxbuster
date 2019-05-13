namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Cartoon')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Sci-Fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Indie')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}

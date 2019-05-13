namespace BoxBuster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "PictureId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Picture_id", c => c.Int());
            CreateIndex("dbo.Movies", "Picture_id");
            AddForeignKey("dbo.Movies", "Picture_id", "dbo.Pictures", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Picture_id", "dbo.Pictures");
            DropIndex("dbo.Movies", new[] { "Picture_id" });
            DropColumn("dbo.Movies", "Picture_id");
            DropColumn("dbo.Movies", "PictureId");
        }
    }
}

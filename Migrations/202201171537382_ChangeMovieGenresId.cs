namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieGenresId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.MovieGenres");
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.MovieGenres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.MovieGenres", "Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.MovieGenres");
            AlterColumn("dbo.MovieGenres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.MovieGenres", "Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
    }
}

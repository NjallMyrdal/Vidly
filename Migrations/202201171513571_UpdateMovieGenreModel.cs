namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieGenreModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieGenres", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieGenres", "Name", c => c.String());
        }
    }
}

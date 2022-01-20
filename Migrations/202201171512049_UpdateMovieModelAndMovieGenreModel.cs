namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieModelAndMovieGenreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.MovieGenres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.MovieGenres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "AddedDate");
            DropTable("dbo.MovieGenres");
        }
    }
}

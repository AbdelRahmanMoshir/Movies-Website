namespace EXercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesPackage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genreMovies_Id", "dbo.GenreMovies");
            DropIndex("dbo.Movies", new[] { "genreMovies_Id" });
            DropPrimaryKey("dbo.GenreMovies");
            AlterColumn("dbo.Movies", "genreMovies_Id", c => c.Byte());
            AlterColumn("dbo.GenreMovies", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.GenreMovies", "Id");
            CreateIndex("dbo.Movies", "genreMovies_Id");
            AddForeignKey("dbo.Movies", "genreMovies_Id", "dbo.GenreMovies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreMovies_Id", "dbo.GenreMovies");
            DropIndex("dbo.Movies", new[] { "genreMovies_Id" });
            DropPrimaryKey("dbo.GenreMovies");
            AlterColumn("dbo.GenreMovies", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Movies", "genreMovies_Id", c => c.Int());
            AddPrimaryKey("dbo.GenreMovies", "Id");
            CreateIndex("dbo.Movies", "genreMovies_Id");
            AddForeignKey("dbo.Movies", "genreMovies_Id", "dbo.GenreMovies", "Id");
        }
    }
}

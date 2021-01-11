namespace EXercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdfore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreMovies_Id", "dbo.GenreMovies");
            DropIndex("dbo.Movies", new[] { "GenreMovies_Id" });
            RenameColumn(table: "dbo.Movies", name: "GenreMovies_Id", newName: "GenreMoviesId");
            AlterColumn("dbo.Movies", "GenreMoviesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreMoviesId");
            AddForeignKey("dbo.Movies", "GenreMoviesId", "dbo.GenreMovies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreMoviesId", "dbo.GenreMovies");
            DropIndex("dbo.Movies", new[] { "GenreMoviesId" });
            AlterColumn("dbo.Movies", "GenreMoviesId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "GenreMoviesId", newName: "GenreMovies_Id");
            CreateIndex("dbo.Movies", "GenreMovies_Id");
            AddForeignKey("dbo.Movies", "GenreMovies_Id", "dbo.GenreMovies", "Id");
        }
    }
}

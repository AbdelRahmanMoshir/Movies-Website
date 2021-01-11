namespace EXercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreMovies_Id", c => c.Int());
            CreateIndex("dbo.Movies", "GenreMovies_Id");
            AddForeignKey("dbo.Movies", "GenreMovies_Id", "dbo.GenreMovies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreMovies_Id", "dbo.GenreMovies");
            DropIndex("dbo.Movies", new[] { "GenreMovies_Id" });
            DropColumn("dbo.Movies", "GenreMovies_Id");
        }
    }
}

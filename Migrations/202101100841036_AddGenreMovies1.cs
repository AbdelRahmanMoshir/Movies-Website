namespace EXercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreMovies1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "genreMovies_Id", c => c.Int());
            CreateIndex("dbo.Movies", "genreMovies_Id");
            AddForeignKey("dbo.Movies", "genreMovies_Id", "dbo.GenreMovies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genreMovies_Id", "dbo.GenreMovies");
            DropIndex("dbo.Movies", new[] { "genreMovies_Id" });
            DropColumn("dbo.Movies", "genreMovies_Id");
            DropTable("dbo.GenreMovies");
        }
    }
}

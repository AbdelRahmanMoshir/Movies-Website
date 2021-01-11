namespace EXercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreMovies2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GenreMovies");
            AlterColumn("dbo.GenreMovies", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GenreMovies", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.GenreMovies");
            AlterColumn("dbo.GenreMovies", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.GenreMovies", "Id");
        }
    }
}

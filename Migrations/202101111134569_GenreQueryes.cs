namespace EXercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreQueryes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GenreMovies (Name) VALUES ('Comedy') ");
            Sql("INSERT INTO GenreMovies (Name) VALUES ('Action') ");
            Sql("INSERT INTO GenreMovies (Name) VALUES ('Family') ");
            Sql("INSERT INTO GenreMovies (Name) VALUES ('Romance') ");
            Sql("INSERT INTO GenreMovies (Name) VALUES ('Drama') ");
            Sql("INSERT INTO GenreMovies (Name) VALUES ('Horror') ");

        }

        public override void Down()
        {
        }
    }
}

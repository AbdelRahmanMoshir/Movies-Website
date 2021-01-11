using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXercises.Models
{
    public class Movies
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStocks { get; set; }
      public GenreMovies GenreMovies { get; set; }
     
         public int GenreMoviesId { get; set; }


    }
}
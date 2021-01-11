using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EXercises.Models;
namespace EXercises.ViewModels
{
    public class NewMoviesViewModels
    {
        public  IEnumerable<GenreMovies> genreMovies { get; set; }
        public Movies movies { get; set; }
    }
}
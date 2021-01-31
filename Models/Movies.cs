using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EXercises.Models
{
    public class Movies
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1,20)]
        [Required]
        public int NumberInStocks { get; set; }
        [Required]
      public GenreMovies GenreMovies { get; set; }
     [Display(Name ="Genre Of Movies" )]
         public int GenreMoviesId { get; set; }


    }
}
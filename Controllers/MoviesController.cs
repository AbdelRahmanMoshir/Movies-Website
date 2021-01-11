using System.Collections.Generic;
using System.Web.Mvc;
using EXercises.Models;
using EXercises.ViewModels;
using System.Data.Entity;
using System.Linq;
using System;

namespace EXercises.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.movies.Include(m => m.GenreMovies).ToList();

            return View(movies);
        }
        public ActionResult New()
        {
            var GenreMovies = _context.genreMovies.ToList();
            var viewModel = new NewMoviesViewModels
            {
                genreMovies = GenreMovies

            };
            return View("MoviesForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movies movies)
        {
            if (movies.Id == 0)
            {
                movies.DateAdded = DateTime.Now;
                _context.movies.Add(movies);
            }
            else
            {
                var MoviesInDb = _context.movies.Single(c => c.Id == movies.Id);
                MoviesInDb.Name = movies.Name;
                MoviesInDb.ReleaseDate = movies.ReleaseDate;
                MoviesInDb.GenreMoviesId = movies.GenreMoviesId;
                MoviesInDb.NumberInStocks = movies.NumberInStocks;
            }
           
                _context.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }


        // GET: Movies/Random
        public ActionResult Details(int id)
        {
            var movies = _context.movies.Include(c => c.GenreMovies).SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }
        public ActionResult Edit(int Id)
        {
            var movies = _context.movies.SingleOrDefault(c => c.Id == Id);

            if (movies == null)
                return HttpNotFound();

            var viewModel = new NewMoviesViewModels
            {
                movies = movies,
                genreMovies = _context.genreMovies.ToList()
            };

            return View("MoviesForm", viewModel);
        }
    }
}
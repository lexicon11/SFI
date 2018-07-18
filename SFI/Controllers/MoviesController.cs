using System.Collections.Generic;
using System.Web.Mvc;
using SFI.Models;
using SFI.ViewModels;
using System.Linq;
using SFI.Context;

namespace SFI.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController()
        {
        }
        // GET: Movies List
        public ActionResult Index(Movie movie)
        {
            MovieContext _context = new MovieContext();
            var movies = _context.Movie.ToList();
            return View(movies);

        }
       
        // Calling Adding View Page
        public ActionResult Add()
        {
            return View("Add");
        }

        // Saving Data Adding new Movie into database with model binding 
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View("Add",movie);
            }
            MovieContext _context = new MovieContext();
            if (movie.Id == 0)
                _context.Movie.Add(movie);
            else
            {
                var movieInDb = _context.Movie.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Type = movie.Type;
            }
            _context.SaveChanges();
            
            return RedirectToAction("Index","Movies");
        }

        // Get View List
        public ActionResult Details(int id)
        {
            MovieContext _context = new MovieContext();
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        // Edit Movie Record 
        public ActionResult Edit(int id)
        {
            MovieContext _context = new MovieContext();
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
                    
            return View("Add",movie);
        }

        // Delete Movie Record 
        public ActionResult Delete(int id)
        {
            MovieContext _context = new MovieContext();
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            _context.Movie.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }



    }

  
}
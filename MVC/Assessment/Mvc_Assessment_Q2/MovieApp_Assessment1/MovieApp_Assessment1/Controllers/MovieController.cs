using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_Movie_Assessment1;
using MVC_Movie_Assessment1.Models;
using MVC_Movie_Assessment1.Models.Repository;


namespace MVC_Asses1CodeFirst.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository<Movie> _movierepo = null;
        public MovieController()
        {
            _movierepo = new MoviesRepository<Movie>();
        }
        // GET: Movie
        public ActionResult Index()
        {
            var movies = _movierepo.GetAll();
            return View(movies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movierepo.Insert(movie);
                _movierepo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _movierepo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movierepo.Update(movie);
                _movierepo.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = _movierepo.GetById(id);
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _movierepo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _movierepo.Delete(id);
            _movierepo.Save();
            return RedirectToAction("Index");
        }
    }
}

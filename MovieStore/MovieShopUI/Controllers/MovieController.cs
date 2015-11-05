using MovieShopDAL;
using MovieShopDAL.Repository;
using MovieShopUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieShopUI.Controllers
{
    public class MovieController : Controller
    {
        MovieShopDAL.Facade Facade = new MovieShopDAL.Facade();

        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> Movies = Facade.GetMovieRepository().ReadAll();
            return View(Movies);
        }

        public ActionResult Details(int id)
        {
            return View(Facade.GetMovieRepository().Read(id));

        }

        public ActionResult Create()
        {
            MovieViewModel view = new MovieViewModel();
            view.GenreList = Facade.GetGenreRepository().ReadAll();
            return View(view);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie Movie, string[] GenreID)
        {
            if (ModelState.IsValid)
            {
                if (GenreID != null)
                {
                    Movie.Genres = new List<Genres>();
                    foreach (String genreId in GenreID)
                    {
                        int id = int.Parse(genreId);
                        Genres genre = new Genres() { GenreId = id };
                        Movie.Genres.Add(genre);
                    }
                }
              
                Facade.GetMovieRepository().Create(Movie);
                return RedirectToAction("Index");
            }

            MovieViewModel view = new MovieViewModel();
            view.GenreList = Facade.GetGenreRepository().ReadAll();
            view.Movie = Movie;
            return View(view);
        }

        public ActionResult Delete(int id)
        {
            return View(Facade.GetMovieRepository().Read(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, MovieShopDAL.Movie Movie)
        {
            try
            {
                Facade.GetMovieRepository().Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MovieViewModel view = new MovieViewModel();
            view.GenreList = Facade.GetGenreRepository().ReadAll();
            view.Movie = Facade.GetMovieRepository().Read((int)id);

            return View(view);
        }

        [HttpPost]
        public ActionResult Edit(MovieShopDAL.Movie Movie, string[] GenreId)
        {
            if (ModelState.IsValid)
            {
                if (GenreId != null)
                {
                    Movie.Genres.Clear();
                    foreach (string genreId in GenreId)
                    {
                        Movie.Genres.Add(new Genres() { GenreId = int.Parse(genreId) });
                    }
                }

                Facade.GetMovieRepository().Update(Movie);
                return RedirectToAction("Index");
            }

            MovieViewModel view = new MovieViewModel();
            view.GenreList = Facade.GetGenreRepository().ReadAll();
            view.Movie = Movie;

            return View(view);
        }

        public ActionResult FrontPage(int? genre)
        {
            if(genre == null)
            {
             return View(Facade.GetMovieRepository().ReadAll());
            }


            return View(Facade.GetGenreSearch().search((int)genre));

        }
    }
}
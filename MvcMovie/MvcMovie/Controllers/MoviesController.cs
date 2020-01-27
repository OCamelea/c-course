using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        public static List<Movie> Movies = new List<Movie>();

        // GET: Movies
        public ActionResult Index()
        {
            return View(Movies);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = Movies.FirstOrDefault(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create(Movie movie)
        {
            return View(movie);
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Movie movie = new Movie();
                movie.Price = collection[4].AsDecimal();
                movie.Title = collection[1];
                movie.ReleaseDate = Convert.ToDateTime(collection[2]);
                movie.Genre = collection[3];
                Movies.Add(movie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = Movies.FirstOrDefault(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {

            if (ModelState.IsValid)
            {

                Movie m = Movies.FirstOrDefault(me => me.ID == movie.ID);
                m.Title = movie.Title;
                m.Price = movie.Price;
                m.Genre = movie.Genre;
                m.ReleaseDate = movie.ReleaseDate;
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Movie movie = Movies.FirstOrDefault(m => m.ID == id);
                collection.Remove(movie.Title);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

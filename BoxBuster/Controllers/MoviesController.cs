using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using BoxBuster.Models;
using BoxBuster.ViewModels;
using Microsoft.Owin.Security.Provider;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Web.Razor;


namespace BoxBuster.Controllers
{
    public class MoviesController : Controller
    {

        //accessing movie db

        private ApplicationDbContext _BbDbContext;

        public MoviesController()
        {
            _BbDbContext = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _BbDbContext.Dispose();
        }




        public ViewResult Index()
        {
            //admin rights for movies.
            //if(User.IsInRole("ManageDb"))
            //return View("Index");

            //else
            {
                //return View("StaffIndex");
            }
            return View("Index");
        }

        //[Authorize(Roles = "ManageDb")]
        public ViewResult New()
        {
            var genres = _BbDbContext.Genres.ToList();

            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }


        //edit movie
        //[Authorize(Roles = "ManageDb")]
        public ActionResult Edit(int id)
        {
            var movie = _BbDbContext.Movies.SingleOrDefault(c => c.Id == id);


            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewMovieViewModel(movie)
            {
              
                Genres = _BbDbContext.Genres.ToList()
            };



            return View("MovieForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            var movie = _BbDbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


        //add movie to db

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "ManageDb")]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    Genres = _BbDbContext.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

           



            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;

                _BbDbContext.Movies.Add(movie);
            }

            else
            {
                var Dbmovie = _BbDbContext.Movies.Single(m => m.Id == movie.Id);
                Dbmovie.Name = movie.Name;
                Dbmovie.GenreId = movie.GenreId;
                Dbmovie.Stock = movie.Stock;
                Dbmovie.Release = movie.Release;
                Dbmovie.PictureId = movie.PictureId;
            }

            _BbDbContext.SaveChanges();

            
        
            return RedirectToAction("Index", "Movies");
        }

       /* public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                    Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Movies");
        }
        */






        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Star Wars"
            };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 2" },
                new Customer {Name = "Customer 3" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}
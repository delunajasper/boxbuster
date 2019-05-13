using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web.Http;
using BoxBuster.Dtos;
using BoxBuster.Models;

namespace BoxBuster.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        private ApplicationDbContext _BbDbContext;

        public MovieRentalsController()
        {
            _BbDbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateMovieRentals(MovieRentalDto movieRental)
        {
          
            //get customer from DB
            //cstomr not valid
            var customer = _BbDbContext.Customers.SingleOrDefault(c => c.Id == movieRental.CustomerId);

            
            //get movies from DB
            //similar to sql select * from movies where Id in (1,2,3)
            //iterate over movies
            //customer rents movie decrease by 1; upon return increase by 1.
            //initialize availablecopies in column by injecting sql to migration.
            //create rental object setting MovieREntal props
            var movies = _BbDbContext.Movies.Where(m => movieRental.MovieId.Contains(m.Id)).ToList();
      

            foreach (var movie in movies)
            {
                //if no copies left; invoke badreqest.
                if (movie.Stock == 0)
                    return BadRequest("Movie not available");
                
                //stock decreases when someone rents them.
                movie.Stock--;

                var rental = new MovieRental
                {
                    Customer = customer,
                    Movie = movie,
                    RentDate = DateTime.Now
                };

                _BbDbContext.MovieRentals.Add(rental);
            }

            _BbDbContext.SaveChanges();

            return Ok();




        }
    }
}

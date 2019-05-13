using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BoxBuster.Dtos;
using BoxBuster.Models;
using System.Data.Entity;

namespace BoxBuster.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _BbDbContext;

        public MoviesController()
        {
            _BbDbContext = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _BbDbContext.Movies
                .Include(m => m.Genre).Where(m => m.Stock > 0);

                if(!String.IsNullOrWhiteSpace(query))
                    moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
                return moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

               
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _BbDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = "ManageDb")]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //automp:(sourcetype, destinationtype(sourceobjct)
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movie.DateAdded = DateTime.Now;

            _BbDbContext.Movies.Add(movie);
            _BbDbContext.SaveChanges();

            //get id movie created by db and assign to moviedto
            movieDto.Id = movie.Id;

            //httpactionresult return URI newly created object
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = "ManageDb")]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieDb = _BbDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieDb == null)
                return NotFound();
            //automp:(srceobject, destinationobjt)
            Mapper.Map(movieDto, movieDb);

            _BbDbContext.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Authorize(Roles = "ManageDb")]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieDb = _BbDbContext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieDb == null)
                return NotFound();

            _BbDbContext.Movies.Remove(movieDb);
            _BbDbContext.SaveChanges();

            return Ok();
        }


    }
}

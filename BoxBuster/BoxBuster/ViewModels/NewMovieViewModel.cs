using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BoxBuster.Models;

namespace BoxBuster.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //represents state
        public int? Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }



        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Required]
        public DateTime? Release { get; set; }

        [Range(1, 10)]
        [Required]
        public byte? Stock { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }

        //this will set initial state, default ctor for creating new movie
        //set id = 0; Id will be hiden in movie form
        public NewMovieViewModel()
        {
            Id = 0;
        }

        //takes movie object
        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Release = movie.Release;
            Stock = movie.Stock;
            GenreId = movie.GenreId;
        }

    }



}
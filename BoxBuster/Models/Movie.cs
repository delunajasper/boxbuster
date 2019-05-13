using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxBuster.Models
{
    public class Movie
    {
        //represents state
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

       
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime Release { get; set; }

        [Range(1,10)]
        public byte Stock { get; set; }

        public byte AvailableCopies { get; set; }

        public Picture Picture { get; set; }

        public byte PictureId { get; set; }
    }
}
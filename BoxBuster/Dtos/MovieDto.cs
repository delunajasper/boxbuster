using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BoxBuster.Models;

namespace BoxBuster.Dtos
{
    public class MovieDto
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }


        [Required]
        public byte GenreId { get; set; }


        public GenreDto Genre { get; set; }



        public DateTime DateAdded { get; set; }

        public DateTime Release { get; set; }

        [Range(1, 10)]
        public byte Stock { get; set; }
    }
}
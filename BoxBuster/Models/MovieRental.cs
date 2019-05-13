using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxBuster.Models
{
    public class MovieRental
    {
        public int Id { get; set; }

        //Movie Fk
        [Required]
        public Movie Movie { get; set; }

        //customer fk
        [Required]
        public Customer Customer { get; set; }

        public DateTime RentDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
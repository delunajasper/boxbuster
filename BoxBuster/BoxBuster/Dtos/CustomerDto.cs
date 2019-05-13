using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using BoxBuster.Models;

namespace BoxBuster.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        //[AgeRestriction] validation pay once = must be above 16 years old
        public DateTime? DoB { get; set; }

        public bool Subscription { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

       
    }
}
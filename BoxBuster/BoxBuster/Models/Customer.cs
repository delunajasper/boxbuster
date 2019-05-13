using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxBuster.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(200)]
        public string Name { get; set; }

        public bool Subscription { get; set; }

        //navigation property. from customer to membershiptype; 
        //useful for reloading related object from DB

        public MembershipType MembershipType { get; set; }

        //foreign key
        [Display(Name = "Memberships")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [AgeRestriction]
        public DateTime? DoB { get; set; }
    }
}
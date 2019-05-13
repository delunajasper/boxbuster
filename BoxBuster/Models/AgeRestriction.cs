using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoxBuster.Models
{
    public class AgeRestriction : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //access to containing class; 
            var customer = (Customer) validationContext.ObjectInstance;

            //if membershp type is 1(pay as you go);or user does not select membershipt 
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            //this creates an error
            if (customer.DoB == null)
            {
                return new ValidationResult("Required Birthdate");
            }

            var age = DateTime.Today.Year - customer.DoB.Value.Year;
            {
                if (age >= 16)
                    return ValidationResult.Success;
            }
            

            return new ValidationResult("Customer should be 16 years old");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EXercises.Models
{
    public class Min18YearIfAMenmber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            
            if (customer.MembershipTypeId == MembershipType.UnKnown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGO)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");


            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                :new ValidationResult("Customer Should be at least 18 to go on membership");

        }
    }
}
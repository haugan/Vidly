using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MinimumAgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // TODO: Build support for CustomerDTO type!
            var customer = (Customer) validationContext.ObjectInstance;

            // NO AGE REQUIREMENT
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            // NO BIRTH DATE IN FIELD
            if (customer.BirthDate == null)
                return new ValidationResult("Birth date is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Must be at least 18 years old for membership type.");
        }
    }
}
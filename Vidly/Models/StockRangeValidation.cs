using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class StockRangeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            return (movie.Stock >= 0 && movie.Stock <= 20)
                ? ValidationResult.Success
                : new ValidationResult("Stock must be between 0 and 20.");
        }
    }
}
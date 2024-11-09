using System.ComponentModel.DataAnnotations;

namespace Backend.Validation
{
    public class BDValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {               
                if (date >= DateTime.Today)
                {
                    return new ValidationResult("A születésnap nem lehet a jövőben!");
                }
            }
            return ValidationResult.Success!;
        }     
    }
}

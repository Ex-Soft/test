using System;
using System.ComponentModel.DataAnnotations;

namespace AnyTest.Models.ValidationAttributes
{
    public class CustomDateValidationAttribute : ValidationAttribute
    {
        public CustomDateValidationAttribute(int year) => Year = year;
        
        public int Year { get; }

        public string GetErrorMessage() => "Invalid date";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext is { ObjectInstance: RequestWithValidation requestWithValidation })
            {
                System.Diagnostics.Debug.WriteLine(requestWithValidation);
            }

            if (value == null)
                return null;

            if (value is not DateTimeOffset date)
                return new ValidationResult(GetErrorMessage());

            return (date.Second + Year) % 2 == 0 ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
        }
    }
}

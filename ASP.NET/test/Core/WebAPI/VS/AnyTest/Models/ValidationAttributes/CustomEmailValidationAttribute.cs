using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnyTest.Models.ValidationAttributes
{
    public class CustomEmailValidationAttribute : ValidationAttribute
    {
        private static readonly Regex EmailRegex = new("^(?<localPart>[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*)@(?<domain>(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)(?:\\.(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+))$", RegexOptions.Compiled);

        public string GetErrorMessage() => "Invalid email";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext is { ObjectInstance: RequestWithValidation requestWithValidation })
            {
                System.Diagnostics.Debug.WriteLine(requestWithValidation);
            }

            if (value == null)
                return null;

            if (value is not string email)
                return new ValidationResult(GetErrorMessage());

            Match match = EmailRegex.Match(email);

            return match.Success
                && match.Groups.Count == 3
                && match.Groups[0].Length < 255
                && match.Groups["localPart"].Length < 65
                && match.Groups["domain"].Length < 253
                && match.Groups["domain"].Value.Split(".").SkipLast(1).All(subDomain => subDomain.Length < 64)
                ?
                ValidationResult.Success
                :
                new ValidationResult(GetErrorMessage());
        }
    }
}

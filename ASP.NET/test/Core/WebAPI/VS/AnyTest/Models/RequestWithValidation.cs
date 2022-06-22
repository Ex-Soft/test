using System;
using AnyTest.Models.ValidationAttributes;

namespace AnyTest.Models
{
    public class RequestWithValidation
    {
        [CustomEmailValidation]
        public string Email { get; set; }

        [CustomDateValidation(2)]
        public DateTimeOffset? Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace PartyInvites.Models
{
    public class GuestResponse : IDataErrorInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
        public string Error { get { return null; } }
        public string this[string propName]
        {
            get
            {
                if ((propName == "Name") && string.IsNullOrEmpty(Name))
                    return "Please enter your name";
                if ((propName == "Email") && (string.IsNullOrEmpty(Email) || !Regex.IsMatch(Email, ".+\\@.+\\..+")))
                    return "Please enter a valid email address";
                if ((propName == "Phone") && string.IsNullOrEmpty(Phone))
                    return "Please enter your phone number";
                if ((propName == "WillAttend") && !WillAttend.HasValue)
                    return "Please specify whether you'll attend";

                return null;
            }
        }

        public void Submit()
        {
            EnsureCurrentlyValid();
        }

        private void EnsureCurrentlyValid()
        {
            var
                propsToValidate = new[] { "Name", "Email", "Phone", "WillAttend" };

            bool
                isValid = propsToValidate.All(x => this[x] == null);

            if (!isValid)
                throw new InvalidOperationException("Can't submit invalid GuestResponse");
        }
    }
}
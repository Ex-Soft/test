using System.Collections.Generic;

namespace ClassLibrary
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; }

        public Customer()
        {
            Addresses = new List<Address>();    
        }
    }
}

using System;
using System.Collections.Generic;
using WebApp.Demo.Domain;

namespace WebApp.Demo.Repository
{
    public interface ICustomerRepository
    {
        Customer SaveCustomer(Customer customer);
        IEnumerable<Customer> Getcustomers();
    }

    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> Getcustomers()
        {
            return Customers;
        }

        public Customer SaveCustomer(Customer customer)
        {
            customer.Id = 1;

            return customer;
        }

        private List<Customer> Customers => new List<Customer>
        {
            new Customer
            {
                Id=1,
                Name="Aditya",
                LastName="Magotra"
            },
            new Customer
            {
                Id=2,
                Name="Ankit",
                LastName="Magotra"
            },
            new Customer
            {
                Id=3,
                Name="Rupali",
                LastName="Magotra"
            }
        };
    }
}

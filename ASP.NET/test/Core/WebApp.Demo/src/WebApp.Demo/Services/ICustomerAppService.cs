using System;
using System.Collections.Generic;
using WebApp.Demo.Domain;
using WebApp.Demo.Repository;

namespace WebApp.Demo.Services
{
    public interface ICustomerAppService
    {
        IEnumerable<Customer> GetCustomers();

        Customer SaveCustomer(Customer customer);
    }

    public class CustomerAppService : ICustomerAppService
    {
        private ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.Getcustomers();
        }

        public Customer SaveCustomer(Customer customer)
        {
            return _customerRepository.SaveCustomer(customer);
        }
    }
}

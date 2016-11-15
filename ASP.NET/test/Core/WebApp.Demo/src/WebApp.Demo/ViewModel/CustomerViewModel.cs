using System.Collections.Generic;
using WebApp.Demo.Common;
using WebApp.Demo.Domain;

namespace WebApp.Demo.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }

        public string GreetingMessage { get; set; }

        public static List<CustomerViewModel> Translate(IEnumerable<Customer> customers)
        {
            var customerViewModels = new List<CustomerViewModel>();

            foreach(var customer in customers)
            {
                customerViewModels.Add(customer);
            }

            return customerViewModels;
        }

        public static implicit operator CustomerViewModel(Customer customer)
        {
            var customerViewModel = new CustomerViewModel();
            customerViewModel.Customer = customer;
            customerViewModel.GreetingMessage = new GenericBuilder()["greeting"];
            return customerViewModel;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Demo.Services;
using WebApp.Demo.ViewModel;

namespace WebApp.Demo.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public IActionResult Index()
        {
            var customers = _customerAppService.GetCustomers();

            var customerViewModels = CustomerViewModel.Translate(customers);

            return View(customerViewModels);
        }
    }
}

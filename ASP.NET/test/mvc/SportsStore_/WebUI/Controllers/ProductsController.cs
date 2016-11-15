using System;
using System.Linq;
using System.Web.Mvc;
using DomainModel.Abstract;
using DomainModel.Concrete;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;

        public int PageSize=2;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public ViewResult List(int page)
        {
            int numProducts = productsRepository.Products.Count();
            ViewData["TotalPages"] = (int)Math.Ceiling((double)numProducts / PageSize);
            ViewData["CurrentPage"] = page;
            return View(productsRepository.Products
                        .Skip((page-1)*PageSize)
                        .Take(PageSize)
                        .ToList()
                    );
        }
    }
}

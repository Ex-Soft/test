using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using DomainModel.Abstract;
using DomainModel.Entities;
using WebUI.Controllers;

namespace Tests
{
    [TestFixture]
    public class ProductsControllerTests
    {
        [Test]
        public void List_Presents_Correct_Page_Of_Products()
        {
            IProductsRepository repository = MockProductsRepository(
                new Product { Name = "P1" },
                new Product { Name = "P2" },
                new Product { Name = "P3" },
                new Product { Name = "P4" },
                new Product { Name = "P5" }
                );

            ProductsController controller = new ProductsController(repository);
            controller.PageSize = 3;

            var result = controller.List(2);

            Assert.IsNotNull(result, "Didn't render view");

            var products = result.ViewData.Model as IList<Product>;

            Assert.AreEqual(2, products.Count, "Got wrong number of products");
            Assert.AreEqual(2, (int)result.ViewData["CurrentPage"], "Wrong page number");
            Assert.AreEqual(2, (int)result.ViewData["TotalPages"], "Wrong page count");

            Assert.AreEqual("P4", products[0].Name);
            Assert.AreEqual("P5", products[1].Name);
        }

        static IProductsRepository MockProductsRepository(params Product[] prods)
        {
            var mockProductsRepos = new Moq.Mock<IProductsRepository>();
            mockProductsRepos.Setup(x => x.Products).Returns(prods.AsQueryable());
            return mockProductsRepos.Object;
        }
    }
}

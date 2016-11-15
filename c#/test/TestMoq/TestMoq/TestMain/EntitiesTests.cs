using System.Collections.Generic;
using System.Linq;
using Main.Controllers;
using Main.DomainModel.Abstract;
using Main.DomainModel.Entities;
using NUnit.Framework;
using Moq;

namespace TestMain
{
	[TestFixture]
	public class EntitiesTests
	{
		[Test]
		public void ListPresentsCorrectPageOfEntities()
		{
			IEntitiesRepository repository = MockEntitiesRepository(
				new Entity { Name = "P1" },
				new Entity { Name = "P2" },
				new Entity { Name = "P3" },
				new Entity { Name = "P4" },
				new Entity { Name = "P5" }
				);

			EntitiesController controller = new EntitiesController(repository);
			controller.PageSize = 3;

			var result = controller.List(2);

			Assert.IsNotNull(result, "Didn't render view");

			var entities = result.Entities as IList<Entity>;

			Assert.AreEqual(2, entities.Count, "Got wrong number of products");
			Assert.AreEqual(2, result.CurrentPage, "Wrong page number");
			Assert.AreEqual(2, result.TotalPages, "Wrong page count");

			Assert.AreEqual("P4", entities[0].Name);
			Assert.AreEqual("P5", entities[1].Name);
		}

		static IEntitiesRepository MockEntitiesRepository(params Entity[] entities)
		{
			var mockEntitiesRepository = new Mock<IEntitiesRepository>();
			mockEntitiesRepository.Setup(x => x.Entities).Returns(entities.AsQueryable());
			return mockEntitiesRepository.Object;
		}
	}
}

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WinFormsApp.Domain;

namespace WinFormsApp.Test
{
    [TestClass]
    public class MainForm
    {
        static MainForm()
        {
            CompositionRoot.Wire(new ApplicationModule());
        }

        [TestMethod]
        public void TestSmthEntitiesSetEntitiesNull()
        {
            ISmthEntities entities = CompositionRoot.Resolve<ISmthEntities>();

            entities.SetEntities(null);

            Assert.AreEqual(0, entities.GetEntities().Count());
        }

        [TestMethod]
        public void TestSmthEntitiesSetEntitiesNotNull()
        {
            ISmthEntities entities = CompositionRoot.Resolve<ISmthEntities>();

            entities.SetEntities(new[] { new SmthEntity(), new SmthEntity(), new SmthEntity() });

            Assert.AreEqual(3, entities.GetEntities().Count());
        }

        [TestMethod]
        public void TestSmthEntitiesGetEntitiesNotNullMoq()
        {
            Mock<ISmthEntities> entities = new Mock<ISmthEntities>();
            entities.Setup(m => m.GetEntities()).Returns(new[] { new SmthEntity(), new SmthEntity(), new SmthEntity() });
            Assert.AreEqual(3, entities.Object.GetEntities().Count());
        }
    }
}

using ClassLibrary.Db;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class EnumsUnitTest
    {
        [TestInitialize]
        public void MyClassInitialize()
        {
            XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());

            using (var session = new Session())
            {
                session.BeginTransaction();

                var enums = new Enums(session);
                enums.CodeKey = "#1";
                enums.Save();
                session.Save(enums);

                session.CommitTransaction();
            }
        }

        [TestMethod]
        public void TestExists()
        {
            Enums enums;

            using (var session = new Session())
            {
                enums = session.GetObjectByKey<Enums>(1);
            }

            Assert.IsNotNull(enums);
        }
    }
}

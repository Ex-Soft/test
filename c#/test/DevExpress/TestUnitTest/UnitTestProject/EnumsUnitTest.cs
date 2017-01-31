//#define USE_TESTINITIALIZE

using ClassLibrary.Db;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class EnumsUnitTest
    {
        #if USE_TESTINITIALIZE
        [TestInitialize]
        public void MyClassInitialize()
        #else
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        #endif
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

//#define TEST_CREATE
//#define TEST_LOAD
//#define TEST_SET
//#define TEST_REMOVE
#define TEST_MODIFY

using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using TestCollection.Db;

namespace TestCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");
            //XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("NOZHENKO-I-XP\\SQLEXPRESS", "testdb");

            Session
                sessionI = new Session(),
                sessionII;

            UnitOfWork
                unitOfWorkI;

            XPCollection
                xpCollectionI,
                xpCollectionII;

            CriteriaOperator
                criteria;

            TestMaster
                tmpTestMaster,
                tmpTestMasterII;

            TestDetail
                tmpTestDetail,
                tmpTestDetailII;

            TestDE
                tmpTestDE = null,
                tmpTestDEII = null;

            int
                tmpInt;

            string
                tmpString;

            XPClassInfo
                testMasterClassInfo = sessionI.GetClassInfo<TestMaster>(),
                testDetailClassInfo = sessionI.GetClassInfo<TestDetail>();

            #if TEST_MODIFY
                using (unitOfWorkI = new UnitOfWork())
                {
                    xpCollectionI = new XPCollection(unitOfWorkI, typeof(TestDE));
                    xpCollectionII = new XPCollection(unitOfWorkI, typeof(TestDE));

                    criteria = new BinaryOperator(new OperandProperty("id"), new OperandValue(1L), BinaryOperatorType.Equal);

                    xpCollectionI.Filter = criteria;
                    xpCollectionII.Filter = criteria;

                    if (xpCollectionI.Count != 0)
                        tmpTestDE = xpCollectionI[0] as TestDE;
                    if (xpCollectionII.Count != 0)
                        tmpTestDEII = xpCollectionI[0] as TestDE;

                    if (tmpTestDE != null)
                    {
                        tmpTestDE.f1 = tmpTestDE.f1.HasValue ? tmpTestDE.f1.Value + 1 : 1;
                        tmpTestDE.Save();
                    }

                    if (tmpTestDEII != null)
                    {
                        tmpTestDEII.f1 = tmpTestDEII.f1.HasValue ? tmpTestDEII.f1.Value + 1 : 1;
                        tmpTestDEII.Save();
                    }

                    unitOfWorkI.CommitChanges();
                }
            #endif

            #if TEST_LOAD
                var listOfTestMaster = sessionI.GetObjects(testMasterClassInfo, new BinaryOperator("Name", "TEST An item with the same key has already been added 1:1", BinaryOperatorType.Equal), null, 0, 0, true, true).OfType<TestMaster>().ToList();

                if (listOfTestMaster.Count > 0)
                {
                    tmpTestMaster = listOfTestMaster[0];

                    if(tmpTestMaster.Details.Count > 0)
                        tmpString = tmpTestMaster.Details[0].Name;
                }

            #endif

            #if TEST_An_item_with_the_same_key_has_already_been_added
                var listOfTestMaster = sessionI.GetObjects(testMasterClassInfo, new BinaryOperator("Name", "TEST An item with the same key has already been added 1:N", BinaryOperatorType.Equal), null, 0, 0, true, true).OfType<TestMaster>().ToList();

                if (listOfTestMaster.Count > 0)
                {
                    tmpTestMaster = listOfTestMaster[0];
                    tmpString = tmpTestMaster.DetailVal;
                }
            #endif

            #if TEST_CREATE
                if ((tmpTestMaster = testMasterClassInfo.CreateNewObject(sessionI) as TestMaster) != null)
                {
                    tmpTestMaster.Name = DateTime.Now.Ticks.ToString();

                    tmpTestMaster.Details.AddRange(new[]
                    {
                        testDetailClassInfo.CreateNewObject(sessionI) as TestDetail,
                        testDetailClassInfo.CreateNewObject(sessionI) as TestDetail,
                        testDetailClassInfo.CreateNewObject(sessionI) as TestDetail
                    });

                    tmpTestMaster.Details.ToList().ForEach(item => item.Name = DateTime.Now.Ticks.ToString());

                    sessionI.Save(tmpTestMaster);
                }
            #endif

            #if TEST_SET
                tmpTestMaster = sessionI.GetObjectByKey<TestMaster>(1L);
                tmpInt = tmpTestMaster.Details.Count;

                sessionII = new Session();
                tmpTestMasterII = sessionII.GetObjectByKey<TestMaster>(2L);
                tmpTestDetailII = sessionII.GetObjectByKey<TestDetail>(2L);
                tmpTestDetailII.Master = tmpTestMasterII;
                sessionII.Save(tmpTestDetailII);

                tmpInt = tmpTestMaster.Details.Count;
            #endif

            #if TEST_REMOVE
                tmpTestMaster = sessionI.GetObjectByKey<TestMaster>(1L);
                tmpInt = tmpTestMaster.Details.Count;

                sessionII = new Session();
                tmpTestMasterII = sessionII.GetObjectByKey<TestMaster>(1L);
                tmpTestDetailII = sessionII.GetObjectByKey<TestDetail>(2L);
                tmpTestMasterII.Details.Remove(tmpTestDetailII);
                sessionII.Save(new XPCustomObject[] { tmpTestMasterII, tmpTestDetailII });

                tmpInt = tmpTestMaster.Details.Count;
            #endif
        }
    }
}

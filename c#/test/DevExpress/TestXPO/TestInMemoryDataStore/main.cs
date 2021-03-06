﻿#define TEST_OWN_TABLE
//#define TEST_MAPINHERITANCETYPE_PARENTTABLE

using System;
using System.Diagnostics;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using TestDB;
using TestDB.TestInheritance;
using TestDB.TestMasterDetail;
using TestDB.TestOwnTable;

namespace TestInMemoryDataStore
{
	class Program
	{
		static void Main(string[] args)
		{
		    try
		    {
		        XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());

                #if TEST_OWN_TABLE
                    using (var unitOfWork = new UnitOfWork())
                    {
                        #region Person

                        var dataPerson = new[]
                        {
                            new { Id = 1, Name = "Person" }
                        };

                        foreach (var rec in dataPerson)
                        {
                            var entity = InMemoryDataStoreHelper.CreateSimpleEntity(typeof(Person), rec, unitOfWork);

                            if (entity == null)
                                continue;

                            unitOfWork.Save(entity);
                        }

                        unitOfWork.CommitChanges();

                        InMemoryDataStoreHelper.ShowExistingData(typeof(Person), o => o is Person item ? $"{{Id:{item.Id}, Name:\"{item.Name}\"}}" : string.Empty);

                        #endregion

                        #region Employee

                        var dataEmployee = new[]
                        {
                            new { Id = 2, Name = "Employee" }
                        };

                        foreach (var rec in dataEmployee)
                        {
                            var entity = InMemoryDataStoreHelper.CreateSimpleEntity(typeof(Employee), rec, unitOfWork);

                            if (entity == null)
                                continue;

                            unitOfWork.Save(entity);
                        }

                        unitOfWork.CommitChanges();

                        InMemoryDataStoreHelper.ShowExistingData(typeof(Person), o => o is Person item ? $"{{Id:{item.Id}, Name:\"{item.Name}\"}}" : string.Empty);
                        InMemoryDataStoreHelper.ShowExistingData(typeof(Employee), o => o is Employee item ? $"{{Id:{item.Id}, Name:\"{item.Name}\", Salary:{item.Salary}}}" : string.Empty);

                        #endregion

                        #region Executive

                        var executive = new Executive(unitOfWork);
                        executive.Id = 3;
                        executive.Name = "Executive";
                        executive.Salary = 456;
                        executive.Bonus = 789;

                        var person = unitOfWork.GetObjectByKey<Person>(3);
                        var employee = unitOfWork.GetObjectByKey<Employee>(3);
                        var executive2 = unitOfWork.GetObjectByKey<Executive>(3);

                        unitOfWork.Save(executive);
                        unitOfWork.CommitChanges();

                        #endregion
                    }
                #endif

                #if TEST_MAPINHERITANCETYPE_PARENTTABLE
		            using (var unitOfWork = new UnitOfWork())
		            {
		                var entity1 = new Entity1(unitOfWork);
		                entity1.Id = 1;
		                entity1.Value = "Entity1";
		                entity1.Entity3Derived1.AddRange(new[] {new Entity3Derived1(unitOfWork), new Entity3Derived1(unitOfWork)});
		                for (var i = 0; i < entity1.Entity3Derived1.Count; ++i)
		                    ((Entity3Derived1) entity1.Entity3Derived1[i]).Value = $"Entity3Derived1 #{i + 1} (\"{entity1.Value}\")";

		                var entity2 = new Entity2(unitOfWork);
		                entity2.Id = 2;
		                entity2.Value = "Entity2";
		                entity2.Entity3Derived2.AddRange(new[] {new Entity3Derived2(unitOfWork), new Entity3Derived2(unitOfWork)});
		                for (var i = 0; i < entity2.Entity3Derived2.Count; ++i)
		                    ((Entity3Derived2) entity2.Entity3Derived2[i]).Value = $"Entity3Derived2 #{i + 1} (\"{entity2.Value}\")";

		                unitOfWork.CommitChanges();

		                foreach (var entity in new XPCollection<Entity3Base>(unitOfWork).OrderBy(item => item.Id))
		                {
		                    var entity3Derived1 = entity as Entity3Derived1;
		                    var entity3Derived2 = entity as Entity3Derived2;
		                    var elementId = entity3Derived1?.Element.Id ?? entity3Derived2?.Element.Id;
		                    var elementValue = entity3Derived1?.Element.Value ?? entity3Derived2?.Element.Value;
		                    Debug.WriteLine($"Id:{entity.Id}, Value:{entity.Value}, Element.Id:{elementId?.ToString() ?? "NULL"}, Element.Value:{elementValue ?? "NULL"}");
		                }
		            }
                #endif

		        Session
		            session = new Session(),
		            sessionII = new Session(),
		            sessionIII = new Session();

		        XPClassInfo
		            classInfoTestMaster = session.GetClassInfo(typeof (TestMaster)),
		            classInfoTestDetail = session.GetClassInfo(typeof (TestDetail));

		        TestMaster
		            testMaster;

		        testMaster = new TestMaster(sessionII);
		        testMaster.Val = "testMaster (sessionII)";
		        sessionII.Save(testMaster);

		        testMaster = new TestMaster(sessionIII);
		        testMaster.Val = "testMaster (sessionIII)";
		        sessionIII.Save(testMaster);

		        var criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionII)"),
		            BinaryOperatorType.Equal);
		        if ((testMaster = session.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = sessionII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = sessionIII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!

		        criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionIII)"),
		            BinaryOperatorType.Equal);
		        if ((testMaster = session.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = sessionII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = sessionIII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!

		        UnitOfWork
		            uow = new UnitOfWork(),
		            uowII = new UnitOfWork(),
		            uowIII = new UnitOfWork();

		        testMaster = new TestMaster(uowII);
		        testMaster.Val = "testMaster (uowII)";
		        uowII.Save(testMaster);

		        testMaster = new TestMaster(uowIII);
		        testMaster.Val = "testMaster (uowIII)";
		        uowIII.Save(testMaster);

		        var objToSave = uow.GetObjectsToSave(); // Count = 0
		        var objToSaveII = uowII.GetObjectsToSave(); // Count = 1
		        var objToSaveIII = uowIII.GetObjectsToSave(); // Count = 1

		        criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"),
		            BinaryOperatorType.Equal);
		        if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); // null
		        if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); // null
		        if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); // null

		        criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"),
		            BinaryOperatorType.Equal);
		        if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); // null
		        if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); // null
		        if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); // nul

		        // https://documentation.devexpress.com/#CoreLibraries/CustomDocument2111
		        var collection = new XPCollection<TestMaster>(uow);
		        Console.WriteLine(collection.Count);
		        collection = new XPCollection<TestMaster>(uowII);
		        Console.WriteLine(collection.Count);
		        collection = new XPCollection<TestMaster>(uowIII);
		        Console.WriteLine(collection.Count);
		        collection = new XPCollection<TestMaster>(PersistentCriteriaEvaluationBehavior.InTransaction, uow, null);
		        Console.WriteLine(collection.Count);
		        collection = new XPCollection<TestMaster>(PersistentCriteriaEvaluationBehavior.InTransaction, uowII, null);
		        Console.WriteLine(collection.Count);
		        collection = new XPCollection<TestMaster>(PersistentCriteriaEvaluationBehavior.InTransaction, uowIII, null);
		        Console.WriteLine(collection.Count);

		        uowII.CommitChanges();
		        criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"),
		            BinaryOperatorType.Equal);
		        if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!

		        uowIII.CommitChanges();
		        criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"),
		            BinaryOperatorType.Equal);
		        if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!
		        if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val); //	oB!

		        objToSave = uow.GetObjectsToSave(); // Count = 0
		        objToSaveII = uowII.GetObjectsToSave(); // Count = 0
		        objToSaveIII = uowIII.GetObjectsToSave(); // Count = 0

		        uow.Dispose();
		        uowII.Dispose();
		        uowIII.Dispose();

		        for (var i = 0; i < 3; ++i)
		        {
		            testMaster = new TestMaster(session);
		            testMaster.Val = i.ToString();

		            for (var j = 0; j < 3; ++j)
		            {
		                testMaster.Details.Add(new TestDetail(session));
		                testMaster.Details[j].Val = string.Format("{0}.{1}", i, j);
		            }

		            session.Save(testMaster);
		        }

		        if (
		            (testMaster =
		                session.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("1"),
		                    BinaryOperatorType.Equal))) != null)
		        {
		            Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Val);

		            foreach (var detail in testMaster.Details)
		                Console.WriteLine("TestDetail: {{Id:{0}, Master.Id:{1}, Name:\"{2}\"}}", detail.Id, detail.Master.Id,
		                    detail.Val);
		        }

		        var resultOfSelectData = session.SelectData(
		            classInfoTestMaster,
		            new CriteriaOperatorCollection {new OperandProperty("Id")},
		            CriteriaOperator.Or(
		                new BinaryOperator(new OperandProperty("Name"), new OperandValue("1"), BinaryOperatorType.Equal),
		                new BinaryOperator(new OperandProperty("Name"), new OperandValue("2"), BinaryOperatorType.Equal)
		                ),
		            false,
		            0,
		            null).ToArray();

		        var resultOfGetObjects = session.GetObjects(
		            classInfoTestMaster,
		            CriteriaOperator.Or(
		                new BinaryOperator(new OperandProperty("Name"), new OperandValue("1"), BinaryOperatorType.Equal),
		                new BinaryOperator(new OperandProperty("Name"), new OperandValue("2"), BinaryOperatorType.Equal)
		                ),
		            null,
		            0,
		            false,
		            true).OfType<TestMaster>().ToArray();

		        using (uow = new UnitOfWork())
		        {
		            for (var i = 3; i < 6; ++i)
		            {
		                testMaster = new TestMaster(uow);
		                testMaster.Val = i.ToString();

		                for (var j = 0; j < 3; ++j)
		                {
		                    testMaster.Details.Add(new TestDetail(uow));
		                    testMaster.Details[j].Val = string.Format("{0}.{1}", i, j);
		                }

		                uow.CommitChanges();
		            }
		        }

		        resultOfSelectData = session.SelectData(
		            classInfoTestMaster,
		            new CriteriaOperatorCollection {new OperandProperty("Id")},
		            CriteriaOperator.Or(
		                new BinaryOperator(new OperandProperty("Name"), new OperandValue("4"), BinaryOperatorType.Equal),
		                new BinaryOperator(new OperandProperty("Name"), new OperandValue("5"), BinaryOperatorType.Equal)
		                ),
		            false,
		            0,
		            null).ToArray();

		        var res = (from _testMaster_ in new XPQuery<TestMaster>(session)
		            join _testDetail_ in new XPQuery<TestDetail>(session) on _testMaster_.Id equals _testDetail_.Master.Id
		            where
		                _testDetail_.Val == "1.1" /*&& _testDetail_.PhysicalPerson.id == processedUser.id*/&&
		                _testDetail_.Master.Id == 6
		            select new
		            {
		                TestMasterId = _testMaster_.Id,
		                TestDetailId = _testDetail_.Id
		            }).ToList();
		    }
		    catch (Exception eException)
		    {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
	}
}

using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using TestInMemoryDataStore.Db;

namespace TestInMemoryDataStore
{
	class Program
	{
		static void Main(string[] args)
		{
			XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());

            Session
                session = new Session(),
				sessionII = new Session(),
				sessionIII = new Session();

			XPClassInfo
				classInfoTestMaster = session.GetClassInfo(typeof(TestMaster)),
				classInfoTestDetail = session.GetClassInfo(typeof(TestDetail));

			TestMaster
				testMaster;

			testMaster = new TestMaster(sessionII);
			testMaster.Name = "testMaster (sessionII)";
			sessionII.Save(testMaster);

			testMaster = new TestMaster(sessionIII);
			testMaster.Name = "testMaster (sessionIII)";
			sessionIII.Save(testMaster);

			var criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionII)"), BinaryOperatorType.Equal);
			if ((testMaster = session.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = sessionII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = sessionIII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!

			criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionIII)"), BinaryOperatorType.Equal);
			if ((testMaster = session.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = sessionII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = sessionIII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!

			UnitOfWork
				uow = new UnitOfWork(),
				uowII = new UnitOfWork(),
				uowIII = new UnitOfWork();

			testMaster = new TestMaster(uowII);
			testMaster.Name = "testMaster (uowII)";
			uowII.Save(testMaster);

			testMaster = new TestMaster(uowIII);
			testMaster.Name = "testMaster (uowIII)";
			uowIII.Save(testMaster);

			var objToSave = uow.GetObjectsToSave();			// Count = 0
			var objToSaveII = uowII.GetObjectsToSave();		// Count = 1
			var objToSaveIII = uowIII.GetObjectsToSave();	// Count = 1

			criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal);
			if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	// null
			if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	// null
			if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	// null

			criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"), BinaryOperatorType.Equal);
			if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	// null
			if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	// null
			if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	// nul

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
			criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal);
			if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!

			uowIII.CommitChanges();
			criteria = new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal);
			if ((testMaster = uow.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = uowII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!
			if ((testMaster = uowIII.FindObject<TestMaster>(criteria)) != null)
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);	//	oB!

			objToSave = uow.GetObjectsToSave();			// Count = 0
			objToSaveII = uowII.GetObjectsToSave();		// Count = 0
			objToSaveIII = uowIII.GetObjectsToSave();	// Count = 0

			uow.Dispose();
			uowII.Dispose();
			uowIII.Dispose();

			for (var i = 0; i < 3; ++i)
			{
				testMaster = new TestMaster(session);
				testMaster.Name = i.ToString();

				for (var j = 0; j < 3; ++j)
				{
					testMaster.Details.Add(new TestDetail(session));
					testMaster.Details[j].Name = string.Format("{0}.{1}", i, j);
				}

				session.Save(testMaster);
			}

			if ((testMaster = session.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("1"), BinaryOperatorType.Equal))) != null)
			{
				Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);

				foreach (var detail in testMaster.Details)
					Console.WriteLine("TestDetail: {{Id:{0}, Master.Id:{1}, Name:\"{2}\"}}", detail.Id, detail.Master.Id, detail.Name);
			}
			
			var resultOfSelectData = session.SelectData(
				classInfoTestMaster,
				new CriteriaOperatorCollection { new OperandProperty("Id") },
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
                    testMaster.Name = i.ToString();

                    for (var j = 0; j < 3; ++j)
                    {
                        testMaster.Details.Add(new TestDetail(uow));
                        testMaster.Details[j].Name = string.Format("{0}.{1}", i, j);
                    }

                    uow.CommitChanges();
                }
		    }

            resultOfSelectData = session.SelectData(
				classInfoTestMaster,
				new CriteriaOperatorCollection { new OperandProperty("Id") },
				CriteriaOperator.Or(
					new BinaryOperator(new OperandProperty("Name"), new OperandValue("4"), BinaryOperatorType.Equal),
					new BinaryOperator(new OperandProperty("Name"), new OperandValue("5"), BinaryOperatorType.Equal)
				),
				false,
				0,
				null).ToArray();

            var res = (from _testMaster_ in new XPQuery<TestMaster>(session)
                       join _testDetail_ in new XPQuery<TestDetail>(session) on _testMaster_.Id equals _testDetail_.Master.Id
                       where _testDetail_.Name == "1.1"  /*&& _testDetail_.PhysicalPerson.id == processedUser.id*/ && _testDetail_.Master.Id == 6
                       select new
                       {
                           TestMasterId = _testMaster_.Id,
                           TestDetailId = _testDetail_.Id
                       }).ToList();
		}
	}
}

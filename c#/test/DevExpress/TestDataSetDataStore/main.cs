//#define SET_RELATIONS
//#define TEST_DATA

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Reflection;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using TestDataSetDataStore.Db;

namespace TestDataSetDataStore
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				DataSet ds;
				XpoDefault.DataLayer = new SimpleDataLayer(new DataSetDataStore(ds = CreateDataSet(Assembly.GetExecutingAssembly(), typeof(XPCustomObject)), AutoCreateOption.DatabaseAndSchema));

				Session
					session = new Session(),
					sessionII = new Session(),
					sessionIII = new Session();

				var testMasterAll = new XPCollection(session, typeof(TestMaster));
				foreach (TestMaster master in testMasterAll)
				{
					Console.WriteLine("TestMaster: {{Id:{0}, Name: \"{1}\"}}", master.Id, master.Name);
					foreach (TestDetail detail in master.Details)
						Console.WriteLine("TestDetail: {{Id:{0}, Master.Id:{1}, Name:\"{2}\"}}", detail.Id, detail.Master.Id, detail.Name);
				}

                var criteria = CriteriaOperator.Parse("Details[Name == ?]", "1.1");
				var arrayOfTestMaster = new XPCollection(session, typeof(TestMaster), criteria).OfType<TestMaster>().ToArray();

                criteria = CriteriaOperator.Parse("Details.Single() is not null");
                arrayOfTestMaster = new XPCollection(session, typeof(TestMaster), criteria).OfType<TestMaster>().ToArray();

				var res = (from _testMaster_ in new XPQuery<TestMaster>(session)
						   join _testDetail_ in new XPQuery<TestDetail>(session) on _testMaster_.Id equals _testDetail_.Master.Id
						   where _testDetail_.Name == "1.1" // /*&& _testDetail_.PhysicalPerson.id == processedUser.id*/ && _testDetail_.Master.Id == 1
						   select new
						   {
							   TestMasterId = _testMaster_.Id,
							   //TestDetailId = _testDetail_.Id
						   }).ToList();

			    criteria = CriteriaOperator.And(
			        new BinaryOperator(new OperandProperty("Id"), new OperandValue(1), BinaryOperatorType.Equal),
			        new BinaryOperator(new OperandProperty("View.Val"), new OperandValue("ViewFake"), BinaryOperatorType.Equal)
		        );

                var collection = new XPCollection(session, typeof(TableWithView), criteria, null);
				foreach(TableWithView item in collection)
					Console.WriteLine("{{Id:{0}, Val: \"{1}\", View.Id: {2}, View.Val: \"{3}\"}}", item.Id, item.Val, item.View.Id, item.View.Val);

                var tableWithView = session.GetObjects(session.GetClassInfo(typeof(TableWithView)), criteria, null, 0, false, true).OfType<TableWithView>().FirstOrDefault();
				if (tableWithView != null)
					Console.WriteLine("{{Id:{0}, Val: \"{1}\", View.Id: {2}, View.Val: \"{3}\"}}", tableWithView.Id, tableWithView.Val, tableWithView.View.Id, tableWithView.View.Val);

				XPClassInfo
					classInfoTestMaster = session.GetClassInfo(typeof(TestMaster)),
					classInfoTestDetail = session.GetClassInfo(typeof(TestDetail));

				TestMaster
					testMaster;

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

				UnitOfWork
					uow,
					uowII,
					uowIII;

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

				testMaster = new TestMaster(sessionII);
				testMaster.Name = "testMaster (sessionII)";
				sessionII.Save(testMaster);

				testMaster = new TestMaster(sessionIII);
				testMaster.Name = "testMaster (sessionIII)";
				sessionIII.Save(testMaster);

				if ((testMaster = session.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = sessionII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = sessionIII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);

				if ((testMaster = session.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = sessionII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = sessionIII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (sessionIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);

				uow = new UnitOfWork();
				uowII = new UnitOfWork();
				uowIII = new UnitOfWork();

				testMaster = new TestMaster(uowII);
				testMaster.Name = "testMaster (uowII)";
				uowII.Save(testMaster);

				testMaster = new TestMaster(uowIII);
				testMaster.Name = "testMaster (uowIII)";
				uowIII.Save(testMaster);

				var objToSave = uow.GetObjectsToSave();
				var objToSaveII = uowII.GetObjectsToSave();
				var objToSaveIII = uowIII.GetObjectsToSave();

				if ((testMaster = uow.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowIII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);

				if ((testMaster = uow.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowIII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);

				Console.WriteLine("DataSet.HasChanges() = {0}", ds.HasChanges());
				Console.WriteLine("DataSet.Tables[\"TestMaster\"].Rows.Count = {0}", ds.Tables["TestMaster"].Rows.Count);
				Console.WriteLine("DataSet.Tables[\"TestDetail\"].Rows.Count = {0}", ds.Tables["TestDetail"].Rows.Count);

				uowII.CommitChanges();
				if ((testMaster = uow.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowIII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);

				Console.WriteLine("DataSet.Tables[\"TestMaster\"].Rows.Count = {0}", ds.Tables["TestMaster"].Rows.Count);
				Console.WriteLine("DataSet.Tables[\"TestDetail\"].Rows.Count = {0}", ds.Tables["TestDetail"].Rows.Count);

				uowIII.CommitChanges();
				if ((testMaster = uow.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);
				if ((testMaster = uowIII.FindObject<TestMaster>(new BinaryOperator(new OperandProperty("Name"), new OperandValue("testMaster (uowIII)"), BinaryOperatorType.Equal))) != null)
					Console.WriteLine("TestMaster: {{Id:{0}, Name:\"{1}\"}}", testMaster.Id, testMaster.Name);

				Console.WriteLine("DataSet.HasChanges() = {0}", ds.HasChanges());
				Console.WriteLine("DataSet.Tables[\"TestMaster\"].Rows.Count = {0}", ds.Tables["TestMaster"].Rows.Count);
				Console.WriteLine("DataSet.Tables[\"TestDetail\"].Rows.Count = {0}", ds.Tables["TestDetail"].Rows.Count);

				objToSave = uow.GetObjectsToSave();
				objToSaveII = uowII.GetObjectsToSave();
				objToSaveIII = uowIII.GetObjectsToSave();

				uow.Dispose();
				uowII.Dispose();
				uowIII.Dispose();

				var currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

				if (currentDirectory.IndexOf("bin") != -1)
					currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

				var outputFileName = Path.Combine(currentDirectory, "DataSet.xml");

				if (File.Exists(outputFileName))
					File.Delete(outputFileName);

				ds.WriteXml(outputFileName);
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
		}

		static DataSet CreateDataSet(Assembly assembly, Type baseType)
		{
			var ds = new DataSet();
			
			var persistentEntities = GetPersistentEntities(assembly, baseType);

			for (var i = 0; i < persistentEntities.Length; ++i)
				CreateTable(ds, persistentEntities[i], persistentEntities, baseType);

            #if SET_RELATIONS
            
            for (var i = 0; i < persistentEntities.Length; ++i)
                SetRelations(ds, persistentEntities[i], persistentEntities, baseType);

            #endif

			FillDataSet(ds);

            #if SET_RELATIONS && TEST_DATA

			var parent = ds.Tables["TestMaster"].AsEnumerable().FirstOrDefault(r => !r.IsNull("id") && Convert.ToInt64(r["id"]) == 1);
			if (parent != null)
			{
				Console.WriteLine("{{Id:{0}, Val: \"{1}\"}}", parent["Id"], parent["Val"]);

				var relation = ds.Relations["TestMasterId_TestDetailTestMasterId"];
				var childRows = parent.GetChildRows(relation);
				foreach (var row in childRows)
					Console.WriteLine("{{Id:{0}, TestMasterId: {1}, Val: \"{2}\"}}", row["Id"], row["TestMasterId"], row["Val"]);
			}
			Console.WriteLine();

			var child = ds.Tables["TestDetail"].AsEnumerable().FirstOrDefault(r => !r.IsNull("id") && Convert.ToInt64(r["id"]) == 5);
			if (child != null)
			{
				Console.WriteLine("{{Id:{0}, TestMasterId: {1}, Val: \"{2}\"}}", child["Id"], child["TestMasterId"], child["Val"]);

				var relation = ds.Relations["TestMasterId_TestDetailTestMasterId"];
				var parents = child.GetParentRows(relation);
				foreach (var row in parents)
					Console.WriteLine("{{Id:{0}, Val: \"{1}\"}}", row["Id"], row["Val"]);
			}
			Console.WriteLine();

			child = ds.Tables["TableWithView"].AsEnumerable().FirstOrDefault(r => !r.IsNull("id") && Convert.ToInt64(r["id"]) == 1);
			if (child != null)
			{
				Console.WriteLine("{{Id:{0}, Val: \"{1}\", idView: {2}}}", child["Id"], child["Val"], child["idView"]);

				var relation = ds.Relations["ViewFakeId_TableWithViewidView"];
				var parents = child.GetParentRows(relation);
				foreach (var row in parents)
					Console.WriteLine("{{Id:{0}, Val: \"{1}\"}}", row["Id"], row["Val"]);
			}
			Console.WriteLine();
            
            #endif

            return ds;
		}

		static Type[] GetPersistentEntities(Assembly assembly, Type baseType)
		{
			return assembly.GetTypes().Where(t => baseType.IsAssignableFrom(t) && t.GetCustomAttributes(typeof(PersistentAttribute), false).Length > 0).ToArray();
		}

		static PropertyInfo[] GetPersistentProperties(Type type)
		{
			return type.GetProperties().Where(p => p.GetCustomAttributes(typeof(PersistentAttribute), true).Length > 0).ToArray();
		}

		static void CreateTable(DataSet dataSet, Type persistentEntity, Type[] persistentEntities, Type baseType)
		{
			PersistentAttribute persistentEntityPersistentAttribute;
			string tableName;

			if ((persistentEntityPersistentAttribute = persistentEntity.GetCustomAttribute(typeof(PersistentAttribute), false) as PersistentAttribute) == null
				|| string.IsNullOrWhiteSpace(tableName = persistentEntityPersistentAttribute.MapTo)
				|| dataSet.Tables.Contains(tableName))
				return;

			var table = new DataTable(tableName);
			dataSet.Tables.Add(table);

			var persistentProperties = GetPersistentProperties(persistentEntity);
			for (var i = 0; i < persistentProperties.Length; ++i)
				CreateColumn(table, persistentProperties[i], persistentEntities, baseType);

			table.Columns.Add("OptimisticLockField", typeof(int));
			table.Columns.Add("GCRecord", typeof(int));
			table.Columns.Add("verstamp", typeof(byte[]));
		}

		static void CreateColumn(DataTable table, PropertyInfo persistentProperty, IEnumerable<Type> persistentEntities, Type baseType)
		{
			var persistentPropertyPersistentAttribute = persistentProperty.GetCustomAttribute(typeof(PersistentAttribute), false) as PersistentAttribute;
			if (persistentPropertyPersistentAttribute == null)
				return;

			var column = table.Columns.Add(persistentPropertyPersistentAttribute.MapTo, GetColumnType(persistentProperty, persistentEntities, baseType));

			var persistentPropertyDisplayNameAttribute = persistentProperty.GetCustomAttribute(typeof(DisplayNameAttribute), false) as DisplayNameAttribute;
			if (persistentPropertyDisplayNameAttribute != null)
				column.Caption = persistentPropertyDisplayNameAttribute.DisplayName;

			var persistentPropertyKeyAttribute = persistentProperty.GetCustomAttribute(typeof(KeyAttribute), false) as KeyAttribute;
			if (persistentPropertyKeyAttribute == null)
				return;

			column.AllowDBNull = false;
			column.Unique = true;
			table.PrimaryKey = new[] { column };

			if (!persistentPropertyKeyAttribute.AutoGenerate)
				return;

			column.AutoIncrement = true;
			column.AutoIncrementSeed = 1;
			column.AutoIncrementStep = 1;
		}

		static Type GetColumnType(PropertyInfo persistentProperty, IEnumerable<Type> persistentEntities, Type baseType)
		{
			Type
				result,
				associationEntity;

			PropertyInfo keyProperty;

			result = baseType.IsAssignableFrom(persistentProperty.PropertyType)
				&& (associationEntity = persistentEntities.FirstOrDefault(t => t == persistentProperty.PropertyType)) != null
				&& (keyProperty = GetPersistentProperties(associationEntity).FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Length > 0)) != null
				?
				keyProperty.PropertyType
				:
				persistentProperty.PropertyType;

			return result.IsGenericType && result.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(result) : result;
		}

		static void SetRelations(DataSet dataSet, Type persistentEntity, Type[] persistentEntities, Type baseType)
		{
			var persistentEntityPersistentAttribute = persistentEntity.GetCustomAttribute<PersistentAttribute>();
			var persistentProperties = GetPersistentProperties(persistentEntity);
			if (persistentEntityPersistentAttribute == null || persistentProperties.Length == 0)
				return;

			for (var i = 0; i < persistentProperties.Length; ++i)
			{
				Type associationEntity;

				PersistentAttribute
					persistentPropertyPersistentAttribute,
					associationEntityPersistentAttribute;

				PropertyInfo keyProperty;

				if (!baseType.IsAssignableFrom(persistentProperties[i].PropertyType)
					|| (persistentPropertyPersistentAttribute = persistentProperties[i].GetCustomAttribute<PersistentAttribute>()) == null
					|| string.IsNullOrWhiteSpace(persistentPropertyPersistentAttribute.MapTo)
					|| (associationEntity = persistentEntities.FirstOrDefault(t => t == persistentProperties[i].PropertyType)) == null
					|| (associationEntityPersistentAttribute = associationEntity.GetCustomAttribute<PersistentAttribute>()) == null
					|| (keyProperty = GetPersistentProperties(associationEntity).FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Length > 0)) == null)
					continue;

				var master = dataSet.Tables[associationEntityPersistentAttribute.MapTo];
				var detail = dataSet.Tables[persistentEntityPersistentAttribute.MapTo];
				var masterKeyPropertyName = keyProperty.Name;
				var detailKeyPropertyName = persistentPropertyPersistentAttribute.MapTo;
				var relationName = string.Format("{0}{1}_{2}{3}", master.TableName, masterKeyPropertyName, detail.TableName, detailKeyPropertyName);

				detail.Constraints.Add(new ForeignKeyConstraint("fk" + relationName, master.Columns[masterKeyPropertyName], detail.Columns[detailKeyPropertyName]));
				dataSet.Relations.Add(new DataRelation(relationName, master.Columns[masterKeyPropertyName], detail.Columns[detailKeyPropertyName]));
			}
		}

		static void FillDataSet(DataSet dataSet)
		{
			var testMaster = dataSet.Tables["TestMaster"];
			var testDetail = dataSet.Tables["TestDetail"];

			DataRow
				rowI,
				rowII;

			for (var i = 0; i < 3; ++i)
			{
				rowI = testMaster.NewRow();
				rowI["Val"] = i;
				testMaster.Rows.Add(rowI);

				for (var j = 0; j < 3; ++j)
				{
					rowII = testDetail.NewRow();
					rowII["TestMasterId"] = rowI["Id"];
					rowII["Val"] = string.Format("{0}.{1}", i, j);
					testDetail.Rows.Add(rowII);
				}
			}

			rowI = dataSet.Tables["ViewFake"].NewRow();
			rowI["Id"] = 1;
			rowI["Val"] = "ViewFake";
			dataSet.Tables["ViewFake"].Rows.Add(rowI);

			rowI = dataSet.Tables["TableWithView"].NewRow();
			rowI["Id"] = 1;
			rowI["Val"] = "TableWithView";
			rowI["idView"] = 1;
			dataSet.Tables["TableWithView"].Rows.Add(rowI);

			if (dataSet.HasChanges())
				dataSet.AcceptChanges();
		}
	}
}

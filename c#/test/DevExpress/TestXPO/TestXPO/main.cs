﻿//#define TEST_DETAIL_WITH_NULLABLE_ID_MASTER
//#define TEST_Session_CrossThreadFailureDetected
//#define TEST_DELAYED_PROPERTY
//#define TEST_LINQ_TO_XPO
//#define TEST_SELECT_DATA
//#define TEST_LINQ
//#define TEST_LockingException
#define TEST_XP_INFO
//#define TEST_DISPOSE
//#define TEST_CRITERIA
//#define TEST_CRITERIA_VISITOR
//#define TEST_VARBINARY
//#define TEST_CLASS_INFO
//#define TEST_LOAD_REFERENCE
//#define TEST_DifferentObjectsWithSameKeyException
//#define TEST_LIFECYCLE
//#define TEST_OBJECT_SET
//#define TEST_CUSTOM_SESSION
//#define TEST_SESSION_TRANSACTION

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.Xpo.Exceptions;
using DevExpress.Xpo.Generators;
using DevExpress.Xpo.Helpers;
using DevExpress.Xpo.Metadata;
using TestDB;
using TestDB.TestMasterDetail;
using TestDB.TestXPO;

using static System.Console;

namespace TestXPO
{
	#if TEST_CUSTOM_SESSION
		public class CustomSession : Session
		{
			protected override IList BeginFlushChanges()
			{
				System.Diagnostics.Debug.WriteLine("Session: BeginFlushChanges() (call PreProcessSavedList())");
				return base.BeginFlushChanges();
			}

			public override void CommitTransaction()
			{
				System.Diagnostics.Debug.WriteLine("Session: CommitTransaction()");
				base.CommitTransaction();
			}
		}

	#endif

    class Program
    {
        private static void CommitCallback(Exception e)
        {
            Debug.WriteLine("CommitCallback()");
        }

        static void Main(string[] args)
        {
            try
            {
                //throw new LockingException();

                //XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");
                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("(localdb)\\MSSQLLocalDB", "testdb");

                Session
                    session = new
						#if TEST_CUSTOM_SESSION
							CustomSession()
						#else
							Session()
						#endif
						;

	            XPClassInfo
		            classInfo = null;

	            XPMemberInfo
		            memberInfo = null;

	            TestMaster
		            testMaster;

                TestDetail
                    testDetail;

                TestDE
                    testDE;

	            XPCollection
		            xpCollection;

                ICollection
                    iCollection;

                CriteriaOperator
                    criteria,
                    criteriaII;

                #if TEST_DETAIL_WITH_NULLABLE_ID_MASTER
                    xpCollection = new XPCollection(session, typeof(TestDetailWithNullableIdMaster));
                    foreach (TestDetailWithNullableIdMaster item in xpCollection)
                        WriteLine($"{{Id: {item.Id}, Val: \"{item.Val}\", IdMaster: {item.IdMaster}}}"); // default(long) -> 0 for long / null for long?
                #endif

                #if TEST_Session_CrossThreadFailureDetected
                    if ((testMaster = session.GetObjectByKey<TestMaster>(1L)) != null)
                    {
                        const int tasksMax = 10;
                        Task[] tasks = new Task[tasksMax];

                        try
                        {
                            for (int i = 0; i < tasksMax; ++i)
                                tasks[i] = Task.Run(() => LoadDetails(testMaster));

                            Task.WaitAll(tasks);
                        }
                        catch (AggregateException eAggregateException)
                        {
                            Debug.WriteLine("AggregateException");
                            for (var j = 0; j < eAggregateException.InnerExceptions.Count; j++)
                                Debug.WriteLine($"\t{eAggregateException.InnerExceptions[j]}");
                        }
                        catch (TargetInvocationException eTargetInvocationException)
                        {
                            Debug.WriteLine($"TargetInvocationException: \"{eTargetInvocationException.Message}\"");
                        }
                        catch (InvalidAsynchronousStateException eInvalidAsynchronousStateException)
                        {
                            Debug.WriteLine($"InvalidAsynchronousStateException: \"{eInvalidAsynchronousStateException.Message}\"");
                        }
                        catch (InvalidOperationException eInvalidOperationException)
                        {
                            Debug.WriteLine($"InvalidOperationException: \"{eInvalidOperationException.Message}\"");
                        }
                        catch (Exception eException)
                        {
                            Debug.WriteLine(eException.Message);
                        }
                    }
                #endif

                #if TEST_DELAYED_PROPERTY
                    var testTable4TestPIVOTList = session.GetObjectByKey<TestTable4TestPIVOTList>(1);
                    Debug.WriteLine($"{{Id={testTable4TestPIVOTList.Id}, Product.Id={testTable4TestPIVOTList.Product.Id}, Store.Id={testTable4TestPIVOTList.Store.Id}, Cnt={testTable4TestPIVOTList.Cnt}}}");
                    testTable4TestPIVOTList = session.GetObjectByKey<TestTable4TestPIVOTList>(8);
                    Debug.WriteLine($"{{Id={testTable4TestPIVOTList.Id}, Product.Id={testTable4TestPIVOTList.Product.Id}, Store.Id={testTable4TestPIVOTList.Store.Id}, Cnt={testTable4TestPIVOTList.Cnt}}}");
                #endif

                #if TEST_LINQ_TO_XPO
                    XPQuery<TestTable4TestPIVOTProduct> products = session.Query<TestTable4TestPIVOTProduct>();
                    XPQuery<TestTable4TestPIVOTList> lists = session.Query<TestTable4TestPIVOTList>();

                    var lefJoinResultByLambdaSyntax = products
                        .GroupJoin(lists, product => product, list => list.Product, (outerListProducts, innerListLists) => new { outerListProducts.Name, ListId = innerListLists.Select(list => list.Id) })
                        .SelectMany(groupJoinItem => groupJoinItem.ListId.DefaultIfEmpty(), (groupJoinItem, ListId) => new { groupJoinItem.Name, ListId }).ToArray();

                    var lefJoinResultByQuerySyntax = (from product in products
                        join list in lists on product equals list.Product into resultAkaList
                        from tmpList in resultAkaList.DefaultIfEmpty()
                        select new { product, tmpList }).ToList();

                    var xpQueryTestDetail = new XPQuery<TestDetail>(session);
                    var masterIds = xpQueryTestDetail.Where(item => item.Master.Id == 1).Select(item => item.Master.Id).Distinct().ToArray();
                #endif

                #if TEST_SELECT_DATA
                    var properties = new CriteriaOperatorCollection { new OperandProperty("Id"), new OperandProperty("Salary") };
                    criteria = new OperandProperty("Dep") == new OperandValue(1);
                    var resultOfSelectData = session.SelectData(
                        session.GetClassInfo<Staff>(),
                        properties,
                        criteria,
                        false, 0, null);

                    ShowResultOfSelectData(resultOfSelectData, properties);

                    properties = new CriteriaOperatorCollection { new OperandProperty("Master.Id") };
                    criteria = new OperandProperty("Master.Id") == new OperandValue(1);
                    resultOfSelectData = session.SelectData(
                        session.GetClassInfo<TestDetail>(),
                        properties,
                        criteria,
                        false, 0, null);

                    ShowResultOfSelectData(resultOfSelectData, properties);

                    properties = new CriteriaOperatorCollection { new OperandProperty("Master.Id") };
                    criteria = new OperandProperty("Master.Id") == new OperandValue(1);
                    var groupProperties = new CriteriaOperatorCollection { new OperandProperty("Master.Id") };
                    resultOfSelectData = session.SelectData(
                        session.GetClassInfo<TestDetail>(),
                        properties,
                        criteria,
                        groupProperties,
                        null,
                        false, 0, null);

                    ShowResultOfSelectData(resultOfSelectData, properties);
                #endif

                #if TEST_LINQ
                    var testMasters = new XPCollection<TestMaster>(session);
                    testDetail = session.GetObjectByKey<TestDetail>(1L);
                    session.PreFetch(testMasters, "Details");
                    var result = testMasters.Where(master => master.Details.All(itemDetail => itemDetail.Name != "1.1")).ToArray();

                    var dep = from s in session.Query<Staff>() where s.Dep == 2 select s;
                    //var expected1 = (from s in session.Query<Staff>() select s).ToList();
                    var expected1 = (from s in session.Query<Staff>() where dep.Contains(s) select s).ToList();
                    expected1 = session.Query<Staff>().Where(s => dep.Contains(s)).ToList();
                    expected1 = session.Query<Staff>().Intersect(dep).ToList();
                    expected1 = dep.Intersect(session.Query<Staff>()).ToList();

                    var detail = session.Query<TestMaster>().Where(m => m.Id == 1).SelectMany(m => m.Details);
                    // select * from "dbo"."TestDetail" N0 where (N0."GCRecord" is null and exists(select * from "dbo"."TestDetail" N1 where (N1."GCRecord" is null and (N1."IdMaster" = @p0) and not (N1."IdMaster" is null) and (N1."Id" = N0."Id"))))

                    //var detail = session.Query<TestMaster>().Where(m => m.Id == 1).SelectMany(m => m.Details).ToList();
                    // select * from "dbo"."TestDetail" N0 where (N0."GCRecord" is null and N0."Id" in (@p0,@p1,@p2))

                    //var detail = from itemOfMaster in session.Query<TestMaster>() where itemOfMaster.Id == 1 from itemOfDetail in itemOfMaster.Details select itemOfDetail; // throw new NotSupportedException(Res.GetString("LinqToXpo_X0WithSoManyParametersIsNotSupported"), "SelectMany")

                    var expected2 = (from d in session.Query<TestDetail>() where detail.Contains(d) select d).ToList();
                    expected2 = session.Query<TestDetail>().Where(d => detail.Contains(d)).ToList();
                    expected2 = session.Query<TestDetail>().Intersect(detail).ToList();
                    expected2 = detail.Intersect(session.Query<TestDetail>()).ToList();

                    var entityB = (from b in session.Query<EntityB>()
                        where b.Id == 10
                        select b).First();

                    var queryableEntitiesA = from c in session.Query<EntityC>()
                        where c.EntityB.Id == entityB.Id
                        select c.EntityA;

                    var listEntitiesA = (from c in session.Query<EntityC>()
                        where c.EntityB.Id == entityB.Id
                        select c.EntityA).ToList();

                    var queryableExpected = (from a in session.Query<EntityA>()
                        where queryableEntitiesA.Contains(a.Main)
                        select a.Id).ToList();
/*
exec sp_executesql N'select N0."Id" from "dbo"."EntityA" N0
where exists(select * from "dbo"."EntityC" N1 where((N1."EntityBId" = @p0) and(N1."Id" = N0."MainId")))',N'@p0 int',@p0=10

exec sp_executesql N'select N0."Id" from "dbo"."EntityA" N0
where exists(select * from "dbo"."EntityC" N1 where((N1."EntityBId" = @p0) and(N1."EntityAId" = N0."MainId")))',N'@p0 int',@p0=10
*/
                    var listExpected = (from a in session.Query<EntityA>()
                        where listEntitiesA.Contains(a.Main)
                        select a.Id).ToList();
/*
exec sp_executesql N'select N0."Id" from "dbo"."EntityA" N0
where N0."MainId" in (@p0,@p1)',N'@p0 int,@p1 int',@p0=1,@p1=4
*/
                #endif

                #if TEST_LockingException
                    try
                    {
					    if ((testMaster = session.GetObjectByKey<TestMaster>(1L)) != null)
					    {
						    testMaster.Name = "Test LockingException";
                            testMaster.Save();

                            // update TestMaster set OptimisticLockField = OptimisticLockField + 1 where Id = 1
                            testMaster.Name = "Test LockingException II";
                            testMaster.Save();
                        }
                    }
                    catch(LockingException e)
                    {
                    }
                #endif

				#if TEST_XP_INFO
					classInfo = session.GetClassInfo<TestMaster>();
					memberInfo = classInfo.PersistentProperties.OfType<XPMemberInfo>().FirstOrDefault(m => m.MappingField == "Val");
					memberInfo = classInfo.FindMember("Name"); // memberInfo.Name == "Name"; memberInfo.DisplayName == "Val"; memberInfo.MappingField == "Val";

					if ((testMaster = session.GetObjectByKey<TestMaster>(1L)) != null)
					{
						testMaster.Val = "blah-blah-blah";
					}
				#endif


				#if TEST_DISPOSE
					testMaster = session.GetObjectByKey<TestMaster>(1L);
					session.Dispose();
                    
                    try
                    {
					    if (testMaster.Session != null)
						    Debug.Write("testMaster.Session != null");
                    }
                    catch (ObjectDisposedException e)
                    {
                        Debug.Write(e);
                    }
				#endif

                #if TEST_CRITERIA_VISITOR
                    var dates = new [] { new DateTime(2017, 12, 19), new DateTime(2017, 12, 20) };
                    //criteria = CriteriaOperator.Parse("Date in (?, ?)", dates[0], dates[1]);
                    criteria = new InOperator("Date", dates);
                    criteriaII = new InOperator(new OperandProperty("Date"), dates.Select(item => new OperandValue(item)));
                    
                    InOperator
                        inOperator123 = new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 1L, 2L, 3L }.Select(item => new OperandValue(item))),
                        inOperator321 = new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 3L, 2L, 1L }.Select(item => new OperandValue(item))),
                        inOperator12 = new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 1L, 2L }.Select(item => new OperandValue(item))),
                        inOperator23 = new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 2L, 3L }.Select(item => new OperandValue(item)));

                    AggregateOperand
                        aggregateOperand1 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 1L, 2L, 3L }.Select(item => new OperandValue(item)))),
                        aggregateOperand2 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 3L, 2L, 1L }.Select(item => new OperandValue(item)))),
                        aggregateOperand3 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 1L, 2L, 3L }.Select(item => new OperandValue(item)))),
                        aggregateOperand4 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 3L, 2L, 1L }.Select(item => new OperandValue(item)))),
                        aggregateOperand5 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 3L, 2L, 1L }.Select(item => new OperandValue(item)))),
                        aggregateOperand6 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 2L, 1L }.Select(item => new OperandValue(item)))),
                        aggregateOperand7 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 3L, 2L }.Select(item => new OperandValue(item)))),
                        aggregateOperand8 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 1L, 2L, 3L, 4L }.Select(item => new OperandValue(item)))),
                        aggregateOperand9 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Id)), new[] { 5L, 6L, 7L }.Select(item => new OperandValue(item)))),
                        aggregateOperand10 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Val)), new[] { "1st", "2nd", "3rd" }.Select(item => new OperandValue(item)))),
                        aggregateOperand11 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new InOperator(new OperandProperty(nameof(TestDetail.Val)), new[] { "1st", "2nd", "3rd" }.Select(item => new OperandValue(item)))),
                        aggregateOperand12 = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, CriteriaOperator.And(inOperator123, inOperator321, inOperator12, inOperator23));

                    var visitor = new CustomCriteriaVisitor();

                    aggregateOperand12.Accept(visitor);

                    var dictionary = new Dictionary<AggregateOperand, InOperator>();
                    if (!dictionary.ContainsKey(aggregateOperand1))
                        dictionary.Add(aggregateOperand1, aggregateOperand1.Condition as InOperator);
                    if (!dictionary.ContainsKey(aggregateOperand2))
                        dictionary.Add(aggregateOperand2, aggregateOperand2.Condition as InOperator);
                    if (!dictionary.ContainsKey(aggregateOperand3))
                        dictionary.Add(aggregateOperand3, aggregateOperand3.Condition as InOperator);
                    if (!dictionary.ContainsKey(aggregateOperand4))
                        dictionary.Add(aggregateOperand4, aggregateOperand4.Condition as InOperator);
                    if (!dictionary.ContainsKey(aggregateOperand5))
                        dictionary.Add(aggregateOperand5, aggregateOperand5.Condition as InOperator);

                    Debug.WriteLine(aggregateOperand2.Equals(aggregateOperand4));
                    Debug.WriteLine(aggregateOperand4.Equals(aggregateOperand2));
                    Debug.WriteLine($"{aggregateOperand2.GetHashCode()} {(aggregateOperand2.GetHashCode() == aggregateOperand4.GetHashCode() ? "=" : "!")}= {aggregateOperand4.GetHashCode()}");

                    Debug.WriteLine(aggregateOperand3.Equals(aggregateOperand4));
                    Debug.WriteLine(aggregateOperand4.Equals(aggregateOperand3));
                    Debug.WriteLine($"{aggregateOperand3.GetHashCode()} {(aggregateOperand3.GetHashCode() == aggregateOperand4.GetHashCode() ? "=" : "!")}= {aggregateOperand4.GetHashCode()}");

                    xpCollection = new XPCollection(typeof(TestMaster), aggregateOperand1);
                    foreach (TestMaster item in xpCollection)
                        WriteLine("{{Id: {0}}}", item.Id);
                    
                    CriteriaOperator
                        criteriaOperatorAnd1 = CriteriaOperator.And(aggregateOperand1, aggregateOperand2, aggregateOperand5, aggregateOperand6, aggregateOperand7, aggregateOperand8, aggregateOperand9, aggregateOperand10, aggregateOperand11),
                        criteriaOperatorAnd2 = CriteriaOperator.And(aggregateOperand3, aggregateOperand4);

                    criteria = CriteriaOperator.Or(criteriaOperatorAnd1, criteriaOperatorAnd2);

                    //if (criteriaOperatorAnd1 is GroupOperator groupOperator1 && groupOperator1.Operands.Count > 0)
                    //    groupOperator1.Operands.RemoveAt(0);
                    
                    //if (criteriaOperatorAnd2 is GroupOperator groupOperator2 && groupOperator2.Operands.Count > 0)
                    //    groupOperator2.Operands.RemoveAt(0);
                    
                    xpCollection = new XPCollection(typeof(TestMaster), criteria);
                    foreach (TestMaster item in xpCollection)
                        WriteLine("{{Id: {0}}}", item.Id);

                    criteria.Accept(visitor);
                    foreach(var operands in visitor.InOperators)
                        Debug.WriteLine(operands);
                #endif

				#if TEST_CRITERIA
                    criteria = CriteriaOperator.And(CriteriaOperator.Parse("Id in (1L, 2L)"), CriteriaOperator.Parse("Id in (3L, 4L)"));
                    xpCollection = new XPCollection(typeof(TestMaster), criteria);
                    foreach (TestTable4TestPIVOTProduct item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.And(CriteriaOperator.Parse("Id = 1L"), CriteriaOperator.Parse("Id = 3L"));
                    xpCollection = new XPCollection(typeof(TestMaster), criteria);
                    foreach (TestTable4TestPIVOTProduct item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.Parse("5 = 6");
                    xpCollection = new XPCollection(typeof(TestMaster), criteria);
                    foreach (TestTable4TestPIVOTProduct item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.Parse("Name = 'спички' and List[Store.Name = 'балкон' and Id = Product.Id]");
                    xpCollection = new XPCollection(typeof(TestTable4TestPIVOTProduct), criteria);
                    foreach (TestTable4TestPIVOTProduct item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.And(null, null);
                    criteria = CriteriaOperator.And(new BinaryOperator(new OperandProperty("Left"), new ConstantValue("L"), BinaryOperatorType.Equal), null);
                    criteria = CriteriaOperator.And(null, new BinaryOperator(new OperandProperty("Right"), new ConstantValue("R"), BinaryOperatorType.Equal));
                    criteria = CriteriaOperator.And(new BinaryOperator(new OperandProperty("Left"), new ConstantValue("L"), BinaryOperatorType.Equal), new BinaryOperator(new OperandProperty("Right"), new ConstantValue("R"), BinaryOperatorType.Equal));
                    criteria = CriteriaOperator.Or(null, null);
                    criteria = CriteriaOperator.Or(new BinaryOperator(new OperandProperty("Left"), new ConstantValue("L"), BinaryOperatorType.Equal), null);
                    criteria = CriteriaOperator.Or(null, new BinaryOperator(new OperandProperty("Right"), new ConstantValue("R"), BinaryOperatorType.Equal));
                    criteria = CriteriaOperator.Or(new BinaryOperator(new OperandProperty("Left"), new ConstantValue("L"), BinaryOperatorType.Equal), new BinaryOperator(new OperandProperty("Right"), new ConstantValue("R"), BinaryOperatorType.Equal));
                    
                    criteriaII = CriteriaOperator.Parse($"{nameof(TestDetail.Master)}.{nameof(TestMaster.Id)} = 1L");
                    criteria = new BinaryOperator(new OperandProperty($"{nameof(TestDetail.Master)}.{nameof(TestMaster.Id)}"), new ConstantValue(1L), BinaryOperatorType.Equal);
                    Debug.WriteLine($"{(criteria.Equals(criteriaII) ? "" : "!")}criteria.Equals(criteriaII)"); // criteria.Equals(criteriaII)
                    Debug.WriteLine($"{(criteriaII.Equals(criteria) ? "" : "!")}criteriaII.Equals(criteria)"); // criteriaII.Equals(criteria)
                    xpCollection = new XPCollection(typeof(TestDetail), criteria);
                    foreach (TestDetail item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.Parse("Details[Id in (1L, 3L)]");
                    xpCollection = new XPCollection(typeof(TestMaster), criteria);
                    foreach (TestMaster item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    var details = new[] {session.GetObjectByKey<TestDetail>(1L), session.GetObjectByKey<TestDetail>(3L)};
                    criteriaII = new AggregateOperand(new OperandProperty("Details"), null, Aggregate.Exists, new InOperator(new OperandProperty("Id"), details.Select(item => new ConstantValue(item.Id))));
                    Debug.WriteLine(string.Format("{0}criteria.Equals(criteriaII)", criteria.Equals(criteriaII) ? "" : "!")); // criteria.Equals(criteriaII)
                    Debug.WriteLine(string.Format("{0}criteriaII.Equals(criteria)", criteriaII.Equals(criteria) ? "" : "!")); // criteriaII.Equals(criteria)

                    xpCollection = new XPCollection(typeof(TestMaster), criteriaII);
                    foreach (TestMaster item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.Parse($"{nameof(TestMaster.Details)}[{nameof(TestDetail.Val)} == '1.1']");
                    criteriaII = new AggregateOperand(new OperandProperty(nameof(TestMaster.Details)), null, Aggregate.Exists, new BinaryOperator(new OperandProperty(nameof(TestDetail.Val)), new ConstantValue("1.1"), BinaryOperatorType.Equal));
                    Debug.WriteLine(string.Format("{0}criteria.Equals(criteriaII)", criteria.Equals(criteriaII) ? "" : "!")); // criteria.Equals(criteriaII)
                    Debug.WriteLine(string.Format("{0}criteriaII.Equals(criteria)", criteriaII.Equals(criteria) ? "" : "!")); // criteriaII.Equals(criteria)
                    xpCollection = new XPCollection(typeof(TestMaster), criteria);
                    foreach (TestMaster item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    // agregateOperand {[Details][[Val] = '1.1'].Count([Val] = '1.1')}
                    var agregateOperand = new AggregateOperand(new OperandProperty("Details"), new BinaryOperator(new OperandProperty(nameof(TestDetail.Val)), new ConstantValue("1.1"),  BinaryOperatorType.Equal), Aggregate.Count, new BinaryOperator(new OperandProperty(nameof(TestDetail.Val)), new ConstantValue("1.1"), BinaryOperatorType.Equal));
/*
select N0."Id",N0."Val",N0."OptimisticLockField",N0."GCRecord" from "dbo"."TestMaster" N0
where (N0."GCRecord" is null and ((select count(case when (N1."Val" = N'1.1') then 1 else 0 end) as Res from "dbo"."TestDetail" N1 where ((N0."Id" = N1."IdMaster") and N1."GCRecord" is null and (N1."Val" = N'1.1'))) = 1))
*/
                    xpCollection = new XPCollection(typeof(TestMaster), agregateOperand);
                    foreach (TestMaster item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    //agregateOperand {[Details][].Count([Val] = '1.1')}
                    agregateOperand = new AggregateOperand(new OperandProperty("Details"), new BinaryOperator(new OperandProperty("Name"), new ConstantValue("1.1"),  BinaryOperatorType.Equal), Aggregate.Count, null);
/*
select N0."Id",N0."Val",N0."OptimisticLockField",N0."GCRecord" from "dbo"."TestMaster" N0
where(N0."GCRecord" is null and((select count(case when(N1."Val" = N'1.1') then 1 else 0 end) as Res from "dbo"."TestDetail" N1 where((N0."Id" = N1."IdMaster") and N1."GCRecord" is null)) = 1))
*/
                    xpCollection = new XPCollection(typeof(TestMaster), agregateOperand);
                    foreach (TestMaster item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    //agregateOperand {[Details][[Val] = '1.1'].Count()}
                    agregateOperand = new AggregateOperand(new OperandProperty("Details"), null, Aggregate.Count, new BinaryOperator(new OperandProperty("Name"), new ConstantValue("1.1"), BinaryOperatorType.Equal));
/*
select N0."Id",N0."Val",N0."OptimisticLockField",N0."GCRecord" from "dbo"."TestMaster" N0
where(N0."GCRecord" is null and((select count(*) as Res from "dbo"."TestDetail" N1 where((N0."Id" = N1."IdMaster") and N1."GCRecord" is null and(N1."Val" = N'1.1'))) = 1))
*/
                    xpCollection = new XPCollection(typeof(TestMaster), agregateOperand);
                    foreach (TestMaster item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.Parse("Len(FNVarChar) != 0");
                    xpCollection = new XPCollection(typeof(TestTable4Types), criteria);
                    foreach (TestDetail item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    criteria = CriteriaOperator.Parse("Len(IsNull(FNVarChar, '')) != 0");
                    xpCollection = new XPCollection(typeof(TestTable4Types), criteria);
                    foreach (TestTable4Types item in xpCollection)
                        Console.WriteLine("{{Id: {0}}}", item.Id);

                    iCollection = session.GetObjectsByKey(session.GetClassInfo<TestDetail>(), new[] {1L, 3L}, false);
                    iCollection = session.GetObjectsByKey(session.GetClassInfo<TestDetail>(), new[] {1L, 2L, 3L}, false);

                    criteria = new InOperator("Master.Id", new[] { 1L, 3L });
                    xpCollection = new XPCollection(typeof(TestDetail), criteria);
                    foreach (TestDetail item in xpCollection)
                        Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

                    criteria = new InOperator("Master.Id", new[] { 1L, 2L, 3L });
                    xpCollection = new XPCollection(typeof(TestDetail), criteria);
                    foreach (TestDetail item in xpCollection)
                        Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

                    criteria = new InOperator("Master", new[] {1L, 2L, 3L});
                    xpCollection = new XPCollection(typeof(TestDetail), criteria);
                    foreach (TestDetail item in xpCollection)
                        Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

                    criteria = new BinaryOperator(new OperandProperty("Id"), new OperandValue(1), BinaryOperatorType.Equal);
                    criteriaII = new BinaryOperator(new OperandProperty("Id"), new OperandValue(1), BinaryOperatorType.Equal);
                    Debug.WriteLine(string.Format("criteria {0}= criteriaII", criteria == criteriaII ? "=" : "!")); // criteria != criteriaII
                    Debug.WriteLine(string.Format("{0}criteria.Equals(criteriaII)", criteria.Equals(criteriaII) ? "" : "!")); // criteria.Equals(criteriaII)
                    criteriaII = new BinaryOperator(new OperandProperty("Id"), new OperandValue(2), BinaryOperatorType.Equal);
                    Debug.WriteLine(string.Format("{0}criteria.Equals(criteriaII)", criteria.Equals(criteriaII) ? "" : "!")); // criteria.Equals(criteriaII)

                    GroupOperator groupOperator = CriteriaOperator.And(criteria, criteriaII, new BinaryOperator(new OperandProperty("Id"), new OperandValue(3), BinaryOperatorType.Equal), new BinaryOperator(new OperandProperty("Id"), new OperandValue(4), BinaryOperatorType.Equal), new BinaryOperator(new OperandProperty("Id"), new OperandValue(4), BinaryOperatorType.Equal)) as GroupOperator;
                    if (!ReferenceEquals(groupOperator, null))
                    {
                        foreach (var operand in groupOperator.Operands)
                            Debug.WriteLine(string.Format("{0}operand.Equals(criteria)", operand.Equals(criteria) ? "" : "!"));

                        var newGroupOperator = CriteriaOperator.And(groupOperator.Operands.Distinct());
                        var exists = groupOperator.Operands.Exists(item => item.Equals(criteria));
                    }

                    try
                    {
						criteria = CriteriaOperator.Parse("Id == ?", 1);
                        criteria = CriteriaOperator.Parse("Details[Id == ? && Name == ?]", "1.1");
                        criteria = CriteriaOperator.Parse("Details[Name == ?]", "1.1", "1.2");
                        criteria = CriteriaOperator.Parse("Master.Id == ? && Master.Name = ?", "1.1");
                        criteria = CriteriaOperator.Parse("Master.Id == ?", "1.1", "1.2");
                    }
                    catch(Exception eException)
                    {
                    }

                    criteria = CriteriaOperator.Parse("Details[Val == ?]", "1.1");
					xpCollection = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in xpCollection)
						Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

                    criteria = CriteriaOperator.Parse("Details[StartsWith(Val, ?)].Count > 1", "1");
                    xpCollection = new XPCollection(typeof(TestMaster), criteria);
                    foreach (TestMaster item in xpCollection)
                        Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

					criteria = CriteriaOperator.Parse("Details.Sum(Master.Id) = ?", 12);
					xpCollection = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in xpCollection)
						Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

					//criteria = CriteriaOperator.Parse("Details.Single() is not null");
					//resultOfTestCriteria = new XPCollection(typeof(TestMaster), criteria);
					//foreach (TestMaster item in resultOfTestCriteria)
					//	Console.WriteLine("{{Id: {0}, Name: \"{1}\"}}", item.Id, item.Name);

					criteria = CriteriaOperator.Parse("Details.Single([Val]) = ?", "1.1");
					xpCollection = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in xpCollection)
						Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

					criteria = CriteriaOperator.Parse("Id = ?", 12);
					xpCollection = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in xpCollection)
						Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

					criteria = CriteriaOperator.Parse("Id = ?", 12);
					xpCollection = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in xpCollection)
						Console.WriteLine("{{Id: {0}, Val: \"{1}\"}}", item.Id, item.Val);

					xpCollection = new XPCollection(typeof(TestDetail));
					foreach (TestDetail item in xpCollection)
						Console.WriteLine("{{Id: {0}, Val: \"{2}\", Master.Id: {1}}}", item.Id, item.Val, item.Master.Id);

					var res = (from _testMaster_ in new XPQuery<TestMaster>(session)
							   join _testDetail_ in new XPQuery<TestDetail>(session) on _testMaster_.Id equals _testDetail_.Master.Id
							   where _testDetail_.Val == "1.1"  /*&& _testDetail_.PhysicalPerson.id == processedUser.id*/ && _testDetail_.Master.Id == 1
							   select new
							   {
								   TestMasterId = _testMaster_.Id,
								   TestDetailId = _testDetail_.Id
							   }).ToList();
				#endif

                #if TEST_VARBINARY
                    xpCollection = new XPCollection(session, typeof(TestTable4Types));
                    foreach (TestTable4Types item in xpCollection)
                        Console.WriteLine("{{Id: {0}, FVarBinary28Length: {1}, FVarBinaryMaxLength: {2}}}", item.Id, item.FVarBinary28Length, item.FVarBinaryMaxLength);

                    var id = 1;
                    //var varBinary28 = new byte[] { 0, 1, 2 };
                    //var varBinary28 = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
                    //var varBinary28 = new byte[] { 1, 5, 0, 0, 0, 0, 0, 5, 21, 0, 0, 0, 122, 155, 34, 156, 79, 125, 126, 51, 25, 91, 53, 59, 65, 8, 0, 0 };   // 0x0105000000000005150000007A9B229C4F7D7E33195B353B41080000
                    var varBinary28 = new byte[] { 1, 5, 0, 0, 0, 0, 0, 5, 21, 0, 0, 0, 101, 118, 212, 31, 24, 238, 2, 119, 80, 160, 235, 162, 155, 4, 0, 0 };  // 0x0105000000000005150000006576D41F18EE027750A0EBA29B040000

                    var resultTestVarBinary = session.SelectData(
                        session.GetClassInfo(typeof(TestTable4Types)),
                        new CriteriaOperatorCollection { new OperandProperty("Id") },
                        CriteriaOperator.And(
                            new BinaryOperator(new OperandProperty("Id"), new OperandValue(id), BinaryOperatorType.NotEqual),
                            new BinaryOperator(new OperandProperty("VarBinary28"), new OperandValue(varBinary28), BinaryOperatorType.Equal)
                        ),
                        false,
                        0,
                        null).ToArray();
                #endif

				#if TEST_CLASS_INFO
					try
					{
						classInfo = session.GetClassInfo(typeof(TestMaster));
						memberInfo = classInfo.FindMember("NonExistentMember");
						memberInfo = classInfo.GetMember("NonExistentMember");
					}
					catch(PropertyMissingException ePropertyMissingException)
					{
					}
					catch (Exception eException)
					{
					}

					classInfo = session.GetClassInfo(typeof(TestMaster));
					memberInfo = classInfo.GetMember("Details");
					testMaster = new TestMaster(session);
                    testMaster.Val = "Name";
					var xpCollectionOfTestDetail = (XPCollection<TestDetail>)memberInfo.GetValue(testMaster);
				#endif

                #if TEST_LOAD_REFERENCE
                    TestDetailWOFK
                        tmpTestDetailWOFK;

                    if ((tmpTestDetailWOFK = session.GetObjectByKey<TestDetailWOFK>(1L)) != null)
                    {
                        TestMasterWOFK tmpMasterWOFK = tmpTestDetailWOFK.Master;
                    }
                #endif

                #if TEST_DifferentObjectsWithSameKeyException

                    session.BeginTransaction();

                    TestTableWOIdentity
                        testTableWoIdentityI = session.GetObjectByKey<TestTableWOIdentity>(1L),
                        testTableWoIdentityII = new TestTableWOIdentity(session);

                    //testTableWoIdentityI.Name += " update";
                    //testTableWoIdentityI.Save();

                    testTableWoIdentityII.Id = 1;
                    testTableWoIdentityII.Name = "testTableWoIdentityII";
                    testTableWoIdentityII.Save();

                    System.Diagnostics.Debug.WriteLine(string.Format("{0}ReferenceEquals(testTableWoIdentityI, testTableWoIdentityII)", ReferenceEquals(testTableWoIdentityI, testTableWoIdentityII) ? string.Empty : "!"));

                    var objectsToSave = session.GetObjectsToSave().OfType<XPCustomObject>().ToList();
                    foreach (var objectToSave in objectsToSave)
                    {
                        classInfo = objectToSave.ClassInfo;
                        var key = classInfo.GetId(objectToSave);

                        PersistentBase
                            doubleObj;

                        if ((doubleObj = objectsToSave.FirstOrDefault(o => ReferenceEquals(classInfo, o.ClassInfo) && !ReferenceEquals(objectToSave, o) && Equals(key, classInfo.GetId(o)))) != null)
                            System.Diagnostics.Debug.WriteLine(string.Format("Double is found: key = {0}; ClassInfo = {1};", key, classInfo));

                        if ((doubleObj = SessionIdentityMap.GetLoadedObjectByKey(session, classInfo, key) as PersistentBase) != null)
                            System.Diagnostics.Debug.WriteLine(string.Format("Double is found: key = {0}; ClassInfo = {1};", key, classInfo));
                    }

                    session.CommitTransaction();
                    //session.RollbackTransaction();

                #endif

                #if TEST_LIFECYCLE
					AddEventsListeners(session);

					#if TEST_SESSION_TRANSACTION
						session.BeginTransaction();
					#endif

                    testDE = session.GetObjectByKey<TestDE>(1L);
                    //testDE = new TestDE(session);

                    AddEventsListeners(testDE);

                    testDE.f1 = 1;
                    testDE.f2 = 2;
                    testDE.f3 = 3;

                    testDE.Save();

					System.Diagnostics.Debug.WriteLine(new string('-', 60));

					#if TEST_SESSION_TRANSACTION
						session.CommitTransaction();
					#endif

                    RemoveEventsListeners(testDE);

                    testDE = session.FindObject<TestDE>(1L);

					using (var uow = new UnitOfWork())
					{
						AddEventsListeners(uow);

						var criteriaForCollectionsForTestLifecycle = CriteriaOperator.Parse("f2 = 2");
						var filterForCollectionsForTestLifecycle = CriteriaOperator.Parse("f3 = 3");

						XPCollection
							collectionsForTestLifecycle = new XPCollection(uow, typeof(TestDE), criteriaForCollectionsForTestLifecycle),
							collectionsForTestLifecycleII;

						TestDE
							testDEII;

						AddEventsListeners(collectionsForTestLifecycle);
						collectionsForTestLifecycle.Filter = filterForCollectionsForTestLifecycle;
						System.Diagnostics.Debug.WriteLine("collection.Count: {0}", collectionsForTestLifecycle.Count);

						using (var nuow = uow.BeginNestedUnitOfWork())
						{
							AddEventsListeners(nuow);

							collectionsForTestLifecycleII = new XPCollection(nuow, typeof(TestDE), criteriaForCollectionsForTestLifecycle);
							AddEventsListeners(collectionsForTestLifecycleII);
							collectionsForTestLifecycleII.Filter = filterForCollectionsForTestLifecycle;
							
							System.Diagnostics.Debug.WriteLine("collection.Count: {0}", collectionsForTestLifecycleII.Count);

							testDE = collectionsForTestLifecycleII.Count > 0 ? (TestDE)collectionsForTestLifecycleII[0] : null;
							if (testDE != null)
								testDE.f3 *= 2;

							System.Diagnostics.Debug.WriteLine("collection.Count: {0}", collectionsForTestLifecycleII.Count);
							testDEII = collectionsForTestLifecycleII.Count > 0 ? (TestDE)collectionsForTestLifecycleII[0] : null;
							if (testDEII != null)
								testDEII.f3 *= 2;
							System.Diagnostics.Debug.WriteLine("collection.Count: {0}", collectionsForTestLifecycleII.Count);

							if(testDE != null)
								testDE.Save();

							if(testDEII != null)
								testDEII.Save();

							System.Diagnostics.Debug.WriteLine(new string('-', 60));

							nuow.CommitChanges();
							RemoveEventsListeners(nuow);
						}

						uow.CommitChanges();

						RemoveEventsListeners(collectionsForTestLifecycle);
						RemoveEventsListeners(collectionsForTestLifecycleII);

						RemoveEventsListeners(uow);
					}

                    RemoveEventsListeners(session);

                #endif

                #if TEST_OBJECT_SET

                    XPClassInfo
                        classInfoTestMaster = session.GetClassInfo(typeof(TestMaster)),
                        classInfoTestDetail = session.GetClassInfo(typeof(TestDetail));

                    var collection = session.GetObjectsByKey(classInfoTestMaster, new[] { 1L, 2L }, true);
                    var set = new ObjectSet(10);
                    foreach (var obj in collection)
                        set.Add(obj);
                    foreach (var obj in collection)
                        set.Add(obj);

                #endif
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        #if TEST_Session_CrossThreadFailureDetected
            static void LoadDetails(TestMaster testMaster)
            {
                try
                {
                    var testDetails = testMaster.Details.FirstOrDefault();
                    Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId} {testDetails?.Id.ToString() ?? "null"}");
                }
                catch (AggregateException eAggregateException)
                {
                    Debug.WriteLine("AggregateException");
                    for (var j = 0; j < eAggregateException.InnerExceptions.Count; j++)
                        Debug.WriteLine($"\t{eAggregateException.InnerExceptions[j]}");
                }
                catch (TargetInvocationException eTargetInvocationException)
                {
                    Debug.WriteLine($"TargetInvocationException: \"{eTargetInvocationException.Message}\"");
                }
                catch (InvalidAsynchronousStateException eInvalidAsynchronousStateException)
                {
                    Debug.WriteLine($"InvalidAsynchronousStateException: \"{eInvalidAsynchronousStateException.Message}\"");
                }
                catch (InvalidOperationException eInvalidOperationException)
                {
                    Debug.WriteLine($"InvalidOperationException: \"{eInvalidOperationException.Message}\"");
                }
                catch (Exception eException)
                {
                    Debug.WriteLine(eException.Message);
                }
            }
        #endif

        #if TEST_LIFECYCLE
		static void AddEventsListeners(XPCollection xpCollection)
		{
			xpCollection.CollectionChanged += XPCollectionCollectionChanged;
			xpCollection.ListChanged += XPCollectionListChanged;
		}
		static void RemoveEventsListeners(XPCollection xpCollection)
		{
			xpCollection.CollectionChanged -= XPCollectionCollectionChanged;
			xpCollection.ListChanged -= XPCollectionListChanged;
		}

        static void AddEventsListeners(XPBaseObject xpBaseObject)
        {
            xpBaseObject.Changed += XPBaseObjectChanged;
        }

        static void RemoveEventsListeners(XPBaseObject xpBaseObject)
        {
            xpBaseObject.Changed -= XPBaseObjectChanged;
        }

        static void AddEventsListeners(Session session)
        {
            session.AfterBeginTrackingChanges += SessionAfterBeginTrackingChanges;
            session.AfterBeginTransaction += SessionAfterBeginTransaction;
            session.AfterCommitNestedUnitOfWork += SessionAfterCommitNestedUnitOfWork;
            session.AfterCommitTransaction += SessionAfterCommitTransaction;
            session.AfterConnect += SessionAfterConnect;
            session.AfterDisconnect += SessionAfterDisconnect;
            session.AfterDropChanges += SessionAfterDropChanges;
            session.AfterFlushChanges += SessionAfterFlushChanges;
            session.AfterRollbackTransaction += SessionAfterRollbackTransaction;
            session.BeforeBeginTrackingChanges += SessionBeforeBeginTrackingChanges;
            session.BeforeBeginTransaction += SessionBeforeBeginTransaction;
            session.BeforeCommitNestedUnitOfWork += SessionBeforeCommitNestedUnitOfWork;
            session.BeforeCommitTransaction += SessionBeforeCommitTransaction;
            session.BeforeConnect += SessionBeforeConnect;
            session.BeforeDisconnect += SessionBeforeDisconnect;
            session.BeforeDropChanges += SessionBeforeDropChanges;
            session.BeforeFlushChanges += SessionBeforeFlushChanges;
            session.BeforePreProcessCommitedList += SessionBeforePreProcessCommitedList;
            session.BeforeRollbackTransaction += SessionBeforeRollbackTransaction;
            session.FailedCommitTransaction += SessionFailedCommitTransaction;
            session.FailedFlushChanges += SessionFailedFlushChanges;
            session.ObjectChanged += SessionObjectChanged;
            session.ObjectDeleted += SessionObjectDeleted;
            session.ObjectDeleting += SessionObjectDeleting;
            session.ObjectLoaded += SessionObjectLoaded;
            session.ObjectLoading += SessionObjectLoading;
            session.ObjectSaved += SessionObjectSaved;
            session.ObjectSaving += SessionObjectSaving;
            session.ObjectsLoaded += SessionObjectsLoaded;
            session.ObjectsSaved += SessionObjectsSaved;
            session.DataLayer.SchemaInit += DataLayerSchemaInit;
        }

        static void RemoveEventsListeners(Session session)
        {
            session.DataLayer.SchemaInit -= DataLayerSchemaInit;
            session.AfterBeginTrackingChanges -= SessionAfterBeginTrackingChanges;
            session.AfterBeginTransaction -= SessionAfterBeginTransaction;
            session.AfterCommitNestedUnitOfWork -= SessionAfterCommitNestedUnitOfWork;
            session.AfterCommitTransaction -= SessionAfterCommitTransaction;
            session.AfterConnect -= SessionAfterConnect;
            session.AfterDisconnect -= SessionAfterDisconnect;
            session.AfterDropChanges -= SessionAfterDropChanges;
            session.AfterFlushChanges -= SessionAfterFlushChanges;
            session.AfterRollbackTransaction -= SessionAfterRollbackTransaction;
            session.BeforeBeginTrackingChanges -= SessionBeforeBeginTrackingChanges;
            session.BeforeBeginTransaction -= SessionBeforeBeginTransaction;
            session.BeforeCommitNestedUnitOfWork -= SessionBeforeCommitNestedUnitOfWork;
            session.BeforeCommitTransaction -= SessionBeforeCommitTransaction;
            session.BeforeConnect -= SessionBeforeConnect;
            session.BeforeDisconnect -= SessionBeforeDisconnect;
            session.BeforeDropChanges -= SessionBeforeDropChanges;
            session.BeforeFlushChanges -= SessionBeforeFlushChanges;
            session.BeforePreProcessCommitedList -= SessionBeforePreProcessCommitedList;
            session.BeforeRollbackTransaction -= SessionBeforeRollbackTransaction;
            session.FailedCommitTransaction -= SessionFailedCommitTransaction;
            session.FailedFlushChanges -= SessionFailedFlushChanges;
            session.ObjectChanged -= SessionObjectChanged;
            session.ObjectDeleted -= SessionObjectDeleted;
            session.ObjectDeleting -= SessionObjectDeleting;
            session.ObjectLoaded -= SessionObjectLoaded;
            session.ObjectLoading -= SessionObjectLoading;
            session.ObjectSaved -= SessionObjectSaved;
            session.ObjectSaving -= SessionObjectSaving;
            session.ObjectsLoaded -= SessionObjectsLoaded;
            session.ObjectsSaved -= SessionObjectsSaved;
        }

		static void XPCollectionCollectionChanged(object sender, XPCollectionChangedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("XPCollection: CollectionChanged()");
		}

		static void XPCollectionListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("XPCollection: ListChanged() Count:{0} ListChangedType:{1} OldIndex:{2} NewIndex:{3} PropertyDescriptor:{4} NestedUnitOfWork:{5} UnitOfWork:{6}", ((XPCollection)sender).Count, e.ListChangedType, e.OldIndex, e.NewIndex, e.PropertyDescriptor, ((XPCollection)sender).Session is NestedUnitOfWork, ((XPCollection)sender).Session is UnitOfWork);
		}

        static void XPBaseObjectChanged(object sender, ObjectChangeEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("XPBaseObject: OnChanged");
        }

        static void DataLayerSchemaInit(object sender, SchemaInitEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DataLayer: SchemaInit()");
        }

        static void SessionObjectsSaved(object sender, ObjectsManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectsSaved()");
        }

        static void SessionObjectsLoaded(object sender, ObjectsManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectsLoaded()");
        }

        static void SessionObjectSaving(object sender, ObjectManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectSaving()");
        }

        static void SessionObjectSaved(object sender, ObjectManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectSaved()");
        }

        static void SessionObjectLoading(object sender, ObjectManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectLoading()");
        }

        static void SessionObjectLoaded(object sender, ObjectManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectLoaded()");
        }

        static void SessionObjectDeleting(object sender, ObjectManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectDeleting()");
        }

        static void SessionObjectDeleted(object sender, ObjectManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectDeleted()");
        }

        static void SessionObjectChanged(object sender, ObjectChangeEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: ObjectChanged()");
        }

        static void SessionFailedFlushChanges(object sender, SessionOperationFailEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: FailedFlushChanges()");
        }

        static void SessionFailedCommitTransaction(object sender, SessionOperationFailEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: FailedCommitTransaction()");
        }


        static void SessionBeforeRollbackTransaction(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeRollbackTransaction()");
        }

        static void SessionBeforePreProcessCommitedList(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforePreProcessCommitedList()");
        }

        static void SessionBeforeFlushChanges(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeFlushChanges()");
        }

        static void SessionBeforeDropChanges(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeDropChanges()");
        }

        static void SessionBeforeDisconnect(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeDisconnect()");
        }

        static void SessionBeforeConnect(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeConnect()");
        }

        static void SessionBeforeCommitTransaction(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeCommitTransaction()");
        }

        static void SessionBeforeCommitNestedUnitOfWork(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeCommitNestedUnitOfWork()");
        }

        static void SessionBeforeBeginTransaction(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeBeginTransaction()");
        }

        static void SessionBeforeBeginTrackingChanges(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: BeforeBeginTrackingChanges()");
        }

        static void SessionAfterRollbackTransaction(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterRollbackTransaction()");
        }

        static void SessionAfterFlushChanges(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterFlushChanges()");
        }

        static void SessionAfterDropChanges(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterDropChanges()");
        }

        static void SessionAfterDisconnect(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterDisconnect()");
        }

        static void SessionAfterConnect(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterConnect()");
        }

        static void SessionAfterCommitTransaction(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterCommitTransaction()");
        }

        static void SessionAfterCommitNestedUnitOfWork(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterCommitNestedUnitOfWork()");
        }

        static void SessionAfterBeginTransaction(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterBeginTransaction()");
        }

        static void SessionAfterBeginTrackingChanges(object sender, SessionManipulationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Session: AfterBeginTrackingChanges()");
        }

        #endif

        #if TEST_SELECT_DATA
            private static void ShowResultOfSelectData(IEnumerable<object[]> resultOfSelectData, CriteriaOperatorCollection properties)
            {
                foreach (object[] item in resultOfSelectData)
                {
                    var tmpString = string.Empty;
                    for (var i = 0; i < item.Length; ++i)
                    {
                        if (!string.IsNullOrWhiteSpace(tmpString))
                            tmpString += " ";

                        tmpString += $"\"{(i < properties.Count ? ((OperandProperty)properties[i]).PropertyName : string.Empty)}\"={item[i]}";
                    }
                }
            }
        #endif
    }

    #if TEST_CRITERIA_VISITOR

        class CustomCriteriaVisitor : IClientCriteriaVisitor
        {
            public Dictionary<InOperator, CriteriaOperatorCollection> InOperators = new Dictionary<InOperator, CriteriaOperatorCollection>();

            #region ICriteriaVisitor

            public void Visit(BetweenOperator theOperator)
            {
                throw new NotImplementedException();
            }

            public void Visit(BinaryOperator theOperator)
            {
                throw new NotImplementedException();
            }

            public void Visit(UnaryOperator theOperator)
            {
                throw new NotImplementedException();
            }

            public void Visit(InOperator theOperator)
            {
                Debug.WriteLine(theOperator.LeftOperand);

                for (var i = 0; i < theOperator.Operands.Count; ++i)
                    Debug.WriteLine(theOperator.Operands[i]);

                InOperators[theOperator] = theOperator.Operands;
            }

            public void Visit(GroupOperator theOperator)
            {
                Debug.WriteLine(theOperator.OperatorType);

                if (theOperator.OperatorType == GroupOperatorType.And)
                {
                    RemoveIntersections(theOperator, theOperator.Operands
                        .OfType<AggregateOperand>()
                        .Where(aggregateOperand => aggregateOperand.AggregateType == Aggregate.Exists && aggregateOperand.Condition is InOperator)
                        .Select(aggregateOperand => new CriteriaOperatorWithInOperatorOperands(aggregateOperand, ((InOperator)aggregateOperand.Condition).Operands.OfType<OperandValue>().Select(item => item.Value).ToArray()))
                        .GroupBy(item => new { ((AggregateOperand)item.Operator).CollectionProperty, ((InOperator)((AggregateOperand)item.Operator).Condition).LeftOperand }));

                    RemoveIntersections(theOperator, theOperator.Operands
                        .OfType<InOperator>()
                        .Select(inOperator => new CriteriaOperatorWithInOperatorOperands(inOperator, inOperator.Operands.OfType<OperandValue>().Select(item => item.Value).ToArray()))
                        .GroupBy(item => ((InOperator)item.Operator).LeftOperand));

                    var operands = theOperator.Operands.OfType<AggregateOperand>().Where(operand => operand.AggregateType == Aggregate.Exists && operand.Condition is InOperator).GroupBy(operand => new { operand.CollectionProperty, ((InOperator)operand.Condition).LeftOperand }).ToArray();

                    foreach (var operand in operands)
                    {
                        Debug.WriteLine($"Key:{{{operand.Key.CollectionProperty}, {operand.Key.LeftOperand}}}");
                        foreach (var aggregateOperator in operand)
                            Debug.WriteLine($"{aggregateOperator.Condition} => {aggregateOperator.Condition.GetHashCode()}");

                        var idxToRemove = new List<int>();
                        var toRemove = new List<CriteriaOperator>();
                        var aggregateOperands = operand.ToArray();
                        for (var i = 0; i < aggregateOperands.Length; ++i)
                        {
                            if (idxToRemove.Contains(i))
                                continue;

                            var current = ((InOperator)aggregateOperands[i].Condition).Operands.OfType<OperandValue>().Select(item => item.Value).ToArray();
                            for (var j = 0; j < aggregateOperands.Length; ++j)
                            {
                                if (i == j || idxToRemove.Contains(j))
                                    continue;

                                var candidate = ((InOperator)aggregateOperands[j].Condition).Operands.OfType<OperandValue>().Select(item => item.Value).ToArray();
                                if (candidate.Except(current).Any())
                                    continue;

                                idxToRemove.Add(j);
                                toRemove.Add(aggregateOperands[j]);
                            }
                        }
                        
                        toRemove.ForEach(item => theOperator.Operands.Remove(item));

                        /*var permutations2 = aggregateOperands.SelectMany(item => aggregateOperands, (operandLeft, operandRight) => new AggregateOperandAggregateOperandPair(operandLeft, operandRight)).Where(pair => !Equals(pair.AggregateOperandLeft, pair.AggregateOperandRight)).Distinct(new AggregateOperandAggregateOperandPairComparer()).ToArray();

                        var permutations = from operandLeft in operand
                                           from operandRight in operand
                                           where !Equals(operandLeft, operandRight)
                                           select new AggregateOperandAggregateOperandPair(operandLeft, operandRight);

                        foreach (var p in permutations.Distinct(new AggregateOperandAggregateOperandPairComparer()))
                        {
                            Debug.WriteLine($"{p.AggregateOperandLeft.Condition} {p.AggregateOperandRight.Condition}");

                            long[]
                                left = ((InOperator)p.AggregateOperandLeft.Condition).Operands.OfType<OperandValue>().Select(item => (long)item.Value).ToArray(),
                                right = ((InOperator)p.AggregateOperandRight.Condition).Operands.OfType<OperandValue>().Select(item => (long)item.Value).ToArray();

                            if (!left.Except(right).Any())
                                theOperator.Operands.Remove(p.AggregateOperandLeft);
                            else if (!right.Except(left).Any())
                                theOperator.Operands.Remove(p.AggregateOperandRight);
                        }*/
                    }

                    var operands2 = theOperator.Operands.OfType<InOperator>().GroupBy(operand => operand.LeftOperand).ToArray();
                    foreach (var inOperand in operands2)
                    {
                        var idxToRemove = new List<int>();
                        var toRemove = new List<CriteriaOperator>();
                        var inOperands = inOperand.ToArray();
                        for (var i = 0; i < inOperands.Length; ++i)
                        {
                            if (idxToRemove.Contains(i))
                                continue;

                            var current = inOperands[i].Operands.OfType<OperandValue>().Select(item => item.Value).ToArray();
                            for (var j = 0; j < inOperands.Length; ++j)
                            {
                                if (i == j || idxToRemove.Contains(j))
                                    continue;

                                var candidate = inOperands[j].Operands.OfType<OperandValue>().Select(item => item.Value).ToArray();
                                if (candidate.Except(current).Any())
                                    continue;

                                idxToRemove.Add(j);
                                toRemove.Add(inOperands[j]);
                            }
                        }

                        toRemove.ForEach(item => theOperator.Operands.Remove(item));
                    }
                }

                for (var i = 0; i < theOperator.Operands.Count; ++i)
                {
                    Debug.WriteLine(theOperator.Operands[i].ToString());
                    theOperator.Operands[i].Accept(this);
                }
            }

            public void Visit(OperandValue theOperand)
            {
                throw new NotImplementedException();
            }

            public void Visit(FunctionOperator theOperator)
            {
                throw new NotImplementedException();
            }

            #endregion

            #region IClientCriteriaVisitor

            public void Visit(AggregateOperand theOperand)
            {
                Debug.WriteLine(theOperand.AggregateType);
                Debug.WriteLine(theOperand.AggregateType);
                Debug.WriteLine(theOperand.CollectionProperty);
                Debug.WriteLine(theOperand.Condition);
                theOperand.Condition.Accept(this);
            }

            public void Visit(OperandProperty theOperand)
            {
                throw new NotImplementedException();
            }

            public void Visit(JoinOperand theOperand)
            {
                throw new NotImplementedException();
            }

        #endregion

        void RemoveIntersections(GroupOperator theOperator, IEnumerable<IGrouping<object, CriteriaOperatorWithInOperatorOperands>> operators)
        {
            foreach (var @operator in operators)
            {
                var operands = @operator.ToArray();
                if (operands.Length <= 1)
                    continue;

                var idxToRemove = new List<int>();
                var toRemove = new List<CriteriaOperator>();

                for (var i = 0; i < operands.Length; ++i)
                {
                    if (idxToRemove.Contains(i))
                        continue;

                    for (var j = 0; j < operands.Length; ++j)
                    {
                        if (i == j || idxToRemove.Contains(j) || operands[i].Operands.Intersect(operands[j].Operands).Count() != operands[i].Operands.Length)
                            continue;

                        idxToRemove.Add(j);
                        toRemove.Add(operands[j].Operator);
                    }
                }

                toRemove.ForEach(item => theOperator.Operands.Remove(item));
            }
        }
    }

    class AggregateOperandAggregateOperandPair
        {
            public AggregateOperand AggregateOperandLeft { get; set; }
            public AggregateOperand AggregateOperandRight { get; set; }

            public AggregateOperandAggregateOperandPair(AggregateOperand aggregateOperandLeft, AggregateOperand aggregateOperandRight)
            {
                AggregateOperandLeft = aggregateOperandLeft;
                AggregateOperandRight = aggregateOperandRight;
            }
        }

        class AggregateOperandAggregateOperandPairComparer : IEqualityComparer<AggregateOperandAggregateOperandPair>
        {
            public bool Equals(AggregateOperandAggregateOperandPair x, AggregateOperandAggregateOperandPair y)
            {
                if (ReferenceEquals(x, y))
                    return true;

                if (x is null || y is null)
                    return false;

                return x.AggregateOperandLeft.Equals(y.AggregateOperandLeft) && x.AggregateOperandRight.Equals(y.AggregateOperandRight) || x.AggregateOperandLeft.Equals(y.AggregateOperandRight) && x.AggregateOperandRight.Equals(y.AggregateOperandLeft);
            }

            public int GetHashCode(AggregateOperandAggregateOperandPair s)
            {
                return 0;
            }
        }

        class CriteriaOperatorWithInOperatorOperands
        {
            public CriteriaOperator Operator { get; set; }
            public object[] Operands { get; set; }

            public CriteriaOperatorWithInOperatorOperands(CriteriaOperator @operator, object[] operands)
            {
                Operator = @operator;
                Operands = operands;
            }
        }

    #endif
}

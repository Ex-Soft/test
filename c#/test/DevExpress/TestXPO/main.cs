#define TEST_LockingException
//#define TEST_XP_INFO
//#define TEST_DISPOSE
//#define TEST_CRITERIA
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
using System.Diagnostics;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Exceptions;
using DevExpress.Xpo.Exceptions;
using DevExpress.Xpo.Generators;
using DevExpress.Xpo.Helpers;
using DevExpress.Xpo.Metadata;
using TestXPO.Db;

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
        static void Main(string[] args)
        {
            try
            {
                //throw new LockingException();

                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");

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

	            XPCollection
		            xpCollection;

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
						testMaster.Name = "blah-blah-blah";
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

				#if TEST_CRITERIA
                    CriteriaOperator
                        criteria,
                        criteriaII;

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

					criteria = CriteriaOperator.Parse("Details[Name == ?]", "1.1");
					var resultOfTestCriteria = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in resultOfTestCriteria)
						Console.WriteLine("{{Id: {0}, Name: \"{1}\"}}", item.Id, item.Name);

					criteria = CriteriaOperator.Parse("Details.Sum(Master.Id) = ?", 12);
					resultOfTestCriteria = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in resultOfTestCriteria)
						Console.WriteLine("{{Id: {0}, Name: \"{1}\"}}", item.Id, item.Name);

					//criteria = CriteriaOperator.Parse("Details.Single() is not null");
					//resultOfTestCriteria = new XPCollection(typeof(TestMaster), criteria);
					//foreach (TestMaster item in resultOfTestCriteria)
					//	Console.WriteLine("{{Id: {0}, Name: \"{1}\"}}", item.Id, item.Name);

					criteria = CriteriaOperator.Parse("Details.Single([Name]) = ?", "1.1");
					resultOfTestCriteria = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in resultOfTestCriteria)
						Console.WriteLine("{{Id: {0}, Name: \"{1}\"}}", item.Id, item.Name);

					criteria = CriteriaOperator.Parse("Id = ?", 12);
					resultOfTestCriteria = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in resultOfTestCriteria)
						Console.WriteLine("{{Id: {0}, Name: \"{1}\"}}", item.Id, item.Name);

					criteria = CriteriaOperator.Parse("Id = ?", 12);
					resultOfTestCriteria = new XPCollection(typeof(TestMaster), criteria);
					foreach (TestMaster item in resultOfTestCriteria)
						Console.WriteLine("{{Id: {0}, Name: \"{1}\"}}", item.Id, item.Name);

					resultOfTestCriteria = new XPCollection(typeof(TestDetail));
					foreach (TestDetail item in resultOfTestCriteria)
						Console.WriteLine("{{Id: {0}, Name: \"{2}\", Master.Id: {1}}}", item.Id, item.Name, item.Master.Id);

					var res = (from _testMaster_ in new XPQuery<TestMaster>(session)
							   join _testDetail_ in new XPQuery<TestDetail>(session) on _testMaster_.Id equals _testDetail_.Master.Id
							   where _testDetail_.Name == "1.1"  /*&& _testDetail_.PhysicalPerson.id == processedUser.id*/ && _testDetail_.Master.Id == 1
							   select new
							   {
								   TestMasterId = _testMaster_.Id,
								   TestDetailId = _testDetail_.Id
							   }).ToList();
				#endif

                #if TEST_VARBINARY
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
                    testMaster.Name = "Name";
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

                    var testDE = session.GetObjectByKey<TestDE>(1L); //new TestDE(session);

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
    }
}
	
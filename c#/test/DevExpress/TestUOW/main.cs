//#define TEST_DUPLICATES
#define TEST_UOW_EVENTS
//#define TEST_NESTED_UOW
//#define TEST_NESTED_UOW_2
//#define TEST_NESTED_UOW_WITH_NEW

using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using TestUOW.Db;

namespace TestUOW
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");
                //XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("NOZHENKO-I-XP\\SQLEXPRESS", "testdb");
                
                using (var unitOfWork = new UnitOfWork())
                {
					#if TEST_UOW_EVENTS
						AddEventsListeners(unitOfWork);
					#endif

					TestDE
                        testDE,
                        testDEII;
					
					#if TEST_UOW_EVENTS
						testDE = new TestDE(unitOfWork);
						AddEventsListeners(testDE);
                        testDE.f1 = int.MaxValue;
						testDE.Save();
						unitOfWork.Save(testDE);
						unitOfWork.CommitChanges();
					#endif

					long id;

					#if TEST_NESTED_UOW

						TestMaster testMaster;

						#if TEST_NESTED_UOW_WITH_NEW
							testMaster = new TestMaster(unitOfWork);
							testMaster.Name = "NewTestMaster";
							testMaster.Details.Add(new TestDetail(unitOfWork));
							testMaster.Details.Add(new TestDetail(unitOfWork));
							testMaster.Details.Add(new TestDetail(unitOfWork));
							testMaster.Details[0].Name = "NewTestDetail# 0";
							testMaster.Details[1].Name = "NewTestDetail# 1";
							testMaster.Details[2].Name = "NewTestDetail# 2";
						#else
							id = 1;
							testMaster = unitOfWork.FindObject<TestMaster>(CriteriaOperator.Parse("Id = ?", id));
						#endif

						if (testMaster != null)
						{
							testMaster.Details.CollectionChanged += CollectionOnCollectionChanged;
							testMaster.Details.ListChanged += CollectionOnListChanged;

							using (var nestedUOW = unitOfWork.BeginNestedUnitOfWork())
							{
								var nestedTestMaster = nestedUOW.GetNestedObject(testMaster);

								Console.WriteLine("testMaster.GetHashCode() = {0}", testMaster.GetHashCode());
								Console.WriteLine("nestedTestMaster.GetHashCode() = {0}", nestedTestMaster.GetHashCode());
								Console.WriteLine();

								var collection = nestedTestMaster.GetMemberValue("Details") as XPCollection<TestDetail>;

								collection.ListChanged += CollectionOnListChanged;
								collection.CollectionChanged += CollectionOnCollectionChanged;

								Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(b4 Remove())", testMaster.Details.Count);
								Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(b4 Remove())", nestedTestMaster.Details.Count);
								Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(b4 Remove())", collection.Count);
								Console.WriteLine("Remove()");
								//collection.Remove(testMaster.Details[0]); // doesn't work
								//collection.Remove(nestedTestMaster.Details[0]);
								collection.Remove(collection[0]);
								Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(after Remove())", collection.Count);
								Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(after Remove())", nestedTestMaster.Details.Count);
								Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(after Remove())", testMaster.Details.Count);
								Console.WriteLine();

								#if TEST_NESTED_UOW_2

									using (var nestedUOW2 = nestedUOW.BeginNestedUnitOfWork())
									{
										var nestedTestMaster2 = nestedUOW2.GetNestedObject(nestedTestMaster);

										Console.WriteLine("testMaster.GetHashCode() = {0}", testMaster.GetHashCode());
										Console.WriteLine("nestedTestMaster.GetHashCode() = {0}", nestedTestMaster.GetHashCode());
										Console.WriteLine("nestedTestMaster2.GetHashCode() = {0}", nestedTestMaster2.GetHashCode());
										Console.WriteLine();

										var collection2 = nestedTestMaster2.GetMemberValue("Details") as XPCollection<TestDetail>;

										collection2.ListChanged += CollectionOnListChanged;
										collection2.CollectionChanged += CollectionOnCollectionChanged;

										Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(b4 Remove())", testMaster.Details.Count);
										Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(b4 Remove())", nestedTestMaster.Details.Count);
										Console.WriteLine("nestedUOW2\tnestedTestMaster2.Details.Count\t= {0}\t(b4 Remove())", nestedTestMaster2.Details.Count);
										Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(b4 Remove())", collection.Count);
										Console.WriteLine("nestedUOW2\tcollection2.Count\t\t= {0}\t(b4 Remove())", collection2.Count);
										Console.WriteLine("Remove()");
										//collection2.Remove(testMaster.Details[0]); // doesn't work
										//collection2.Remove(nestedTestMaster.Details[0]);  // doesn't work
										//collection2.Remove(nestedTestMaster2.Details[0]);
										collection2.Remove(collection2[0]);
										Console.WriteLine("nestedUOW2\tcollection2.Count\t\t= {0}\t(after Remove())", collection2.Count);
										Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(after Remove())", collection.Count);
										Console.WriteLine("nestedUOW2\tnestedTestMaster2.Details.Count\t= {0}\t(after Remove())", nestedTestMaster2.Details.Count);
										Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(after Remove())", nestedTestMaster.Details.Count);
										Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(after Remove())", testMaster.Details.Count);
										Console.WriteLine();

										Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(b4 CommitChanges())", testMaster.Details.Count);
										Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(b4 CommitChanges())", nestedTestMaster.Details.Count);
										Console.WriteLine("nestedUOW2\tnestedTestMaster2.Details.Count\t= {0}\t(b4 CommitChanges())", nestedTestMaster2.Details.Count);
										Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(b4 CommitChanges())", collection.Count);
										Console.WriteLine("nestedUOW2\tcollection2.Count\t\t= {0}\t(b4 CommitChanges())", collection2.Count);
										Console.WriteLine("CommitChanges()");
										nestedUOW2.CommitChanges();
										Console.WriteLine("nestedUOW2\tcollection2.Count\t\t= {0}\t(after CommitChanges())", collection2.Count);
										Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(after CommitChanges())", collection.Count);
										Console.WriteLine("nestedUOW2\tnestedTestMaster2.Details.Count\t= {0}\t(after CommitChanges())", nestedTestMaster2.Details.Count);
										Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(after CommitChanges())", nestedTestMaster.Details.Count);
										Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(after CommitChanges())", testMaster.Details.Count);
										Console.WriteLine();

										collection2.CollectionChanged -= CollectionOnCollectionChanged;
										collection2.ListChanged -= CollectionOnListChanged;
									}

								#endif

								Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(b4 CommitChanges())", testMaster.Details.Count);
								Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(b4 CommitChanges())", nestedTestMaster.Details.Count);
								Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(b4 CommitChanges())", collection.Count);
								Console.WriteLine("CommitChanges()");
								nestedUOW.CommitChanges();
								Console.WriteLine("nestedUOW\tcollection.Count\t\t= {0}\t(after CommitChanges())", collection.Count);
								Console.WriteLine("nestedUOW\tnestedTestMaster.Details.Count\t= {0}\t(after CommitChanges())", nestedTestMaster.Details.Count);
								Console.WriteLine("unitOfWork\ttestMaster.Details.Count\t= {0}\t(after CommitChanges())", testMaster.Details.Count);
								Console.WriteLine();

								collection.CollectionChanged -= CollectionOnCollectionChanged;
								collection.ListChanged -= CollectionOnListChanged;
							}

							Console.WriteLine("unitOfWork testMaster.Details.Count\t= {0}", testMaster.Details.Count);

							testMaster.Details.CollectionChanged -= CollectionOnCollectionChanged;
							testMaster.Details.ListChanged -= CollectionOnListChanged;

							unitOfWork.RollbackTransaction();
						}

					#endif

                    #if TEST_DUPLICATES
                        var listOfTestDE = new List<TestDE>
                        {
                            new TestDE(unitOfWork, 1, 1, 1),
                            new TestDE(unitOfWork, 2, 2, 2)
                        };

                        listOfTestDE.ForEach(item => item.id = 13);

                        foreach (var obj in listOfTestDE)
                        {
                            var cInfo = obj.ClassInfo;
                            var key = cInfo.GetId(obj);
                            var doubleObj = listOfTestDE.FirstOrDefault(o => ReferenceEquals(cInfo, o.ClassInfo) && !ReferenceEquals(obj, o) && Equals(key, cInfo.GetId(o)));
                            if (doubleObj == null) continue;

                            System.Diagnostics.Debug.WriteLine("Double is found: key = {0}; ClassInfo = {1}; {2} -> {3}", key, cInfo, obj, doubleObj);
                        }
                    #endif

                    id = -1;
                    testDE = unitOfWork.GetObjectByKey<TestDE>(id);
                    if (testDE == null)
                    {
                        testDE = new TestDE(unitOfWork);
                        testDE.id = id;

                        testDEII = unitOfWork.GetObjectByKey<TestDE>(id); // null

                        testDE.Save();
                        testDEII = unitOfWork.GetObjectByKey<TestDE>(id); // null
                    }


	                id = 3;

                    if ((testDE = unitOfWork.FindObject<TestDE>(CriteriaOperator.Parse("id=?", id))) == null)
                    {
                        testDE = new TestDE(unitOfWork, 1, 1, 1);
                        testDE.Save();
                    }

                    testDE.f2 *= 2;
                    
                    id = 4;
                    if ((testDE = unitOfWork.FindObject<TestDE>(CriteriaOperator.Parse("id=?", id))) == null)
                    {
                        testDE = new TestDE(unitOfWork, 1, 1, 1);
                        testDE.Save();
                    }

                    testDE.f2 *= 2;

                    System.Diagnostics.Debug.WriteLine("unitOfWork.BeginNestedUnitOfWork()");

                    using (var nestedUOW = unitOfWork.BeginNestedUnitOfWork())
                    {
                        TestDE
                            nestedTestDE;

                        if ((nestedTestDE = unitOfWork.FindObject<TestDE>(CriteriaOperator.Parse("id=?", id))) == null)
                        {
                            nestedTestDE = new TestDE(nestedUOW, 1, 1, 1);
                            nestedTestDE.Save();
                        }

                        Console.WriteLine(testDE.ToString());

                        nestedTestDE.f3 *= 3;

                        Console.WriteLine(testDE.ToString());

                        nestedUOW.CommitChanges();
                        System.Diagnostics.Debug.WriteLine("nestedUOW.CommitChanges()");
                    }

                    unitOfWork.CommitChanges();

                    #if TEST_UOW_EVENTS
						RemoveEventsListeners(unitOfWork);
                    #endif
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

		#if TEST_NESTED_UOW || TEST_NESTED_UOW_2

			static void CollectionOnCollectionChanged(object sender, XPCollectionChangedEventArgs e)
			{
				var collection = sender as XPCollection<TestDetail>;
				System.Diagnostics.Debug.WriteLine(e.ChangedObject);
			}

			static void CollectionOnListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
			{
				var collection = sender as XPCollection<TestDetail>;
				System.Diagnostics.Debug.WriteLine(e.ListChangedType);
			}

		#endif

        #if TEST_UOW_EVENTS
			static void AddEventsListeners(XPBaseObject xpBaseObject)
			{
				xpBaseObject.Changed += XPBaseObjectChanged;
			}

			static void RemoveEventsListeners(XPBaseObject xpBaseObject)
			{
				xpBaseObject.Changed -= XPBaseObjectChanged;
			}

			static void AddEventsListeners(UnitOfWork unitOfWork)
			{
				unitOfWork.AfterBeginTrackingChanges += UnitOfWorkAfterBeginTrackingChanges;
				unitOfWork.AfterBeginTransaction += UnitOfWorkAfterBeginTransaction;
				unitOfWork.AfterCommitNestedUnitOfWork += UnitOfWorkAfterCommitNestedUnitOfWork;
				unitOfWork.AfterCommitTransaction += UnitOfWorkAfterCommitTransaction;
				unitOfWork.AfterConnect += UnitOfWorkAfterConnect;
				unitOfWork.AfterDisconnect += UnitOfWorkAfterDisconnect;
				unitOfWork.AfterDropChanges += UnitOfWorkAfterDropChanges;
				unitOfWork.AfterFlushChanges += UnitOfWorkAfterFlushChanges;
				unitOfWork.AfterRollbackTransaction += UnitOfWorkAfterRollbackTransaction;
				unitOfWork.BeforeBeginTrackingChanges += UnitOfWorkBeforeBeginTrackingChanges;
				unitOfWork.BeforeBeginTransaction += UnitOfWorkBeforeBeginTransaction;
				unitOfWork.BeforeCommitNestedUnitOfWork += UnitOfWorkBeforeCommitNestedUnitOfWork;
				unitOfWork.BeforeCommitTransaction += UnitOfWorkBeforeCommitTransaction;
				unitOfWork.BeforeConnect += UnitOfWorkBeforeConnect;
				unitOfWork.BeforeDisconnect += UnitOfWorkBeforeDisconnect;
				unitOfWork.BeforeDropChanges += UnitOfWorkBeforeDropChanges;
				unitOfWork.BeforeFlushChanges += UnitOfWorkBeforeFlushChanges;
				unitOfWork.BeforePreProcessCommitedList += UnitOfWorkBeforePreProcessCommitedList;
				unitOfWork.BeforeRollbackTransaction += UnitOfWorkBeforeRollbackTransaction;
				//unitOfWork.BeforeSave += UnitOfWorkBeforeSave; // obsolete

				unitOfWork.ObjectChanged += UnitOfWorkObjectChanged;
				unitOfWork.ObjectDeleted += UnitOfWorkObjectDeleted;
				unitOfWork.ObjectDeleting += UnitOfWorkObjectDeleting;
				unitOfWork.ObjectLoaded += UnitOfWorkObjectLoaded;
				unitOfWork.ObjectLoading += UnitOfWorkObjectLoading;
				unitOfWork.ObjectSaved += UnitOfWorkObjectSaved;
				unitOfWork.ObjectSaving += UnitOfWorkObjectSaving;
				unitOfWork.ObjectsLoaded += UnitOfWorkObjectsLoaded;
				unitOfWork.ObjectsSaved += UnitOfWorkObjectsSaved;
			}

			static void RemoveEventsListeners(UnitOfWork unitOfWork)
			{
				unitOfWork.AfterBeginTrackingChanges -= UnitOfWorkAfterBeginTrackingChanges;
				unitOfWork.AfterBeginTransaction -= UnitOfWorkAfterBeginTransaction;
				unitOfWork.AfterCommitNestedUnitOfWork -= UnitOfWorkAfterCommitNestedUnitOfWork;
				unitOfWork.AfterCommitTransaction -= UnitOfWorkAfterCommitTransaction;
				unitOfWork.AfterConnect -= UnitOfWorkAfterConnect;
				unitOfWork.AfterDisconnect -= UnitOfWorkAfterDisconnect;
				unitOfWork.AfterDropChanges -= UnitOfWorkAfterDropChanges;
				unitOfWork.AfterFlushChanges -= UnitOfWorkAfterFlushChanges;
				unitOfWork.AfterRollbackTransaction -= UnitOfWorkAfterRollbackTransaction;
				unitOfWork.BeforeBeginTrackingChanges -= UnitOfWorkBeforeBeginTrackingChanges;
				unitOfWork.BeforeBeginTransaction -= UnitOfWorkBeforeBeginTransaction;
				unitOfWork.BeforeCommitNestedUnitOfWork -= UnitOfWorkBeforeCommitNestedUnitOfWork;
				unitOfWork.BeforeCommitTransaction -= UnitOfWorkBeforeCommitTransaction;
				unitOfWork.BeforeConnect -= UnitOfWorkBeforeConnect;
				unitOfWork.BeforeDisconnect -= UnitOfWorkBeforeDisconnect;
				unitOfWork.BeforeDropChanges -= UnitOfWorkBeforeDropChanges;
				unitOfWork.BeforeFlushChanges -= UnitOfWorkBeforeFlushChanges;
				unitOfWork.BeforePreProcessCommitedList -= UnitOfWorkBeforePreProcessCommitedList;
				unitOfWork.BeforeRollbackTransaction -= UnitOfWorkBeforeRollbackTransaction;
				//unitOfWork.BeforeSave -= UnitOfWorkBeforeSave; // obsolete

				unitOfWork.ObjectChanged -= UnitOfWorkObjectChanged;
				unitOfWork.ObjectDeleted -= UnitOfWorkObjectDeleted;
				unitOfWork.ObjectDeleting -= UnitOfWorkObjectDeleting;
				unitOfWork.ObjectLoaded -= UnitOfWorkObjectLoaded;
				unitOfWork.ObjectLoading -= UnitOfWorkObjectLoading;
				unitOfWork.ObjectSaved -= UnitOfWorkObjectSaved;
				unitOfWork.ObjectSaving -= UnitOfWorkObjectSaving;
				unitOfWork.ObjectsLoaded -= UnitOfWorkObjectsLoaded;
				unitOfWork.ObjectsSaved -= UnitOfWorkObjectsSaved;
			}

			static void XPBaseObjectChanged(object sender, ObjectChangeEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("XPBaseObject: OnChanged");
			}
			static void UnitOfWorkAfterBeginTrackingChanges(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterBeginTrackingChanges()");
			}

			static void UnitOfWorkAfterBeginTransaction(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterBeginTransaction()");
			}
			static void UnitOfWorkAfterCommitNestedUnitOfWork(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterCommitNestedUnitOfWork()");
			}
			static void UnitOfWorkAfterCommitTransaction(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterCommitTransaction()");
			}
			static void UnitOfWorkAfterConnect(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterConnect()");
			}
			static void UnitOfWorkAfterDisconnect(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterDisconnect()");
			}
			static void UnitOfWorkAfterDropChanges(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterDropChanges()");
			}
			static void UnitOfWorkAfterFlushChanges(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterFlushChanges()");
			}
			static void UnitOfWorkAfterRollbackTransaction(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkAfterRollbackTransaction()");
			}
			static void UnitOfWorkBeforeBeginTrackingChanges(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeBeginTrackingChanges()");
			}
            static void UnitOfWorkBeforeBeginTransaction(object sender, SessionManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeBeginTransaction()");
            }
            static void UnitOfWorkBeforeCommitNestedUnitOfWork(object sender, SessionManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeCommitNestedUnitOfWork()");
            }
            static void UnitOfWorkBeforeCommitTransaction(object sender, SessionManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeCommitTransaction()");
            }
			static void UnitOfWorkBeforeConnect(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeConnect()");
			}
			static void UnitOfWorkBeforeDisconnect(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeDisconnect()");
			}
			static void UnitOfWorkBeforeDropChanges(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeDropChanges()");
			}
            static void UnitOfWorkBeforeFlushChanges(object sender, SessionManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeFlushChanges()");
            }
			static void UnitOfWorkBeforePreProcessCommitedList(object sender, SessionManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforePreProcessCommitedList()");
            }
			static void UnitOfWorkBeforeRollbackTransaction(object sender, SessionManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeRollbackTransaction()");
			}
			static void UnitOfWorkBeforeSave(object sender, ObjectManipulationEventArgs e)
			{
				System.Diagnostics.Debug.WriteLine("UnitOfWorkBeforeSave()");
			}

            static void UnitOfWorkObjectChanged(object sender, ObjectChangeEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkObjectChanged()");
            }

            static void UnitOfWorkObjectDeleting(object sender, ObjectManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkObjectDeleting()");
            }

            static void UnitOfWorkObjectDeleted(object sender, ObjectManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkObjectDeleted()");
            }

            static void UnitOfWorkObjectLoading(object sender, ObjectManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkObjectLoading()");
            }

            static void UnitOfWorkObjectLoaded(object sender, ObjectManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkObjectLoaded()");
            }

            static void UnitOfWorkObjectSaving(object sender, ObjectManipulationEventArgs e)
            {
                var testDE = e.Object as TestDE;
                System.Diagnostics.Debug.WriteLine(string.Format("UnitOfWorkObjectSaving({0})", testDE != null ? testDE.ToString() : "null"));
            }

            static void UnitOfWorkObjectSaved(object sender, ObjectManipulationEventArgs e)
            {
                var testDE = e.Object as TestDE;
                System.Diagnostics.Debug.WriteLine(string.Format("UnitOfWorkObjectSaved({0})", testDE != null ? testDE.ToString() : "null"));
            }

            static void UnitOfWorkObjectsLoaded(object sender, ObjectsManipulationEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("UnitOfWorkObjectsLoaded()");
            }

            static void UnitOfWorkObjectsSaved(object sender, ObjectsManipulationEventArgs e)
            {
                var objects = string.Empty;

                if (e != null && e.Objects != null)
                    objects = e.Objects.OfType<TestDE>().Aggregate(string.Empty, (str, next) => { if (!string.IsNullOrWhiteSpace(str)) str += ", "; return str + next.ToString(); });

                System.Diagnostics.Debug.WriteLine(string.Format("UnitOfWorkObjectsSaved({0})", objects));
            }
        #endif

    }
}

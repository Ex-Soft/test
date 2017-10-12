//#define TEST_DELETE_REFERENCE_OBJECT
//#define TEST_GET
//#define TEST_EXCEPTION_IN_ONSAVING
//#define TEST_EXCEPTION_IN_ONSAVING_IN_TRANSACTION
#define TEST_TRANSACTION
//#define TEST_DISPOSE
//#define TEST_IS_NEW_AND_IS_TO_SAVE

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using TestSession.Db;

namespace TestSession
{
    class Program
    {
        static void Main(string[] args)
        {
            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");

            string
                ConnectionString = "Server=.;Database=testdb;User ID=sa;Password=123",
                tmpString;

            int
                tmpInt;

            Table4TestTransaction
                forTestTransaction = null;

            TestMaster
                testMaster1;

            TestDetail
                testDetail1;

            bool
                isNewObject,
                isObjectToSave;


            #if TEST_DISPOSE
                try
                {
                    tmpString = GetMasterName(1);
                    Console.WriteLine("MasterName = \"{0}\"", tmpString);
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            #endif

            Session
                session = new Session();

            #if TEST_DELETE_REFERENCE_OBJECT
                session.BeginTransaction();
                testMaster1 = new TestMaster(session);
                testMaster1.Name = "Master (deleted)";
                testDetail1 = new TestDetail(session);
                testDetail1.Name = "Detail";
                testDetail1.Master = testMaster1;
                testMaster1.Save();

                isNewObject = session.IsNewObject(testMaster1);
                isObjectToSave = session.IsObjectToSave(testMaster1);
                session.RemoveFromSaveList(testMaster1);
                isNewObject = session.IsNewObject(testMaster1);
                isObjectToSave = session.IsObjectToSave(testMaster1);
                isNewObject = session.IsNewObject(testDetail1.Master);
                isObjectToSave = session.IsObjectToSave(testDetail1.Master);

                session.RollbackTransaction();
            #endif

			#if TEST_GET
				var testMaster = session.GetObjectByKey(typeof(TestMaster), 55L);
				testMaster = session.GetObjectByKey(session.GetClassInfo(typeof(TestMaster)), 55L);
				var details = session.GetObjects(session.GetClassInfo(typeof(TestDetail)), null, null, 0, true, false);
			#endif

            #if TEST_EXCEPTION_IN_ONSAVING
                session.FailedFlushChanges += SessionFailedFlushChanges;
                session.FailedCommitTransaction += SessionFailedCommitTransaction;

                try
                {
                    #if TEST_EXCEPTION_IN_ONSAVING_IN_TRANSACTION
                        session.BeginTransaction();
                    #endif

                    if ((forTestTransaction = session.GetObjectByKey<Table4TestTransaction>(1L)) != null)
                    {
                        var tmpDateTime = DateTime.Now;
                        forTestTransaction.Value = string.Format("update {0}:{1}:{2}.{3}", tmpDateTime.Hour, tmpDateTime.Minute, tmpDateTime.Second, tmpDateTime.Millisecond);
                        forTestTransaction.Save();
                    }

                    #if TEST_EXCEPTION_IN_ONSAVING_IN_TRANSACTION
                        session.CommitTransaction();
                    #endif
                }
                catch (Exception eException)
                {
                    if (session.InTransaction)
                        session.RollbackTransaction();
                }
                finally
                {
                    session.FailedFlushChanges -= SessionFailedFlushChanges;
                    session.FailedCommitTransaction -= SessionFailedCommitTransaction;
                }

            #endif

            #if TEST_TRANSACTION
                SqlConnection connection = null;

                try
                {
                    if ((forTestTransaction = session.GetObjectByKey<Table4TestTransaction>(3L)) == null)
                        forTestTransaction = new Table4TestTransaction(session);

                    var tmpDateTime = DateTime.Now;
                    forTestTransaction.Value = string.Format("update {0}:{1}:{2}.{3}", tmpDateTime.Hour, tmpDateTime.Minute, tmpDateTime.Second, tmpDateTime.Millisecond);
                    forTestTransaction.Save();

                    session.BeginTransaction();

                    forTestTransaction = session.GetObjectByKey<Table4TestTransaction>(1L);
                    tmpDateTime = DateTime.Now;
                    forTestTransaction.Value = string.Format("update {0}:{1}:{2}.{3}", tmpDateTime.Hour, tmpDateTime.Minute, tmpDateTime.Second, tmpDateTime.Millisecond);
                    forTestTransaction.Save();

                    connection = new SqlConnection(ConnectionString);
                    connection.Open();

                    SqlCommand cmd = connection.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "TestProcedureWTransaction";

                    SqlCommandBuilder.DeriveParameters(cmd);
                    if (cmd.Parameters[tmpString = "@spid"].Direction != ParameterDirection.Output)
                        cmd.Parameters[tmpString].Direction = ParameterDirection.Output;
                    if (cmd.Parameters[tmpString = "@trancount"].Direction != ParameterDirection.Output)
                        cmd.Parameters[tmpString].Direction = ParameterDirection.Output;

                    cmd.Parameters["@id"].Value = 2;
                    cmd.Parameters["@value"].Value = forTestTransaction.Value;
                    cmd.Parameters["@beginTransaction"].Value = true;
                    cmd.Parameters["@rollbackTransaction"].Value = false;

                    tmpInt = cmd.ExecuteNonQuery();

                    if (cmd.Parameters[tmpString = "@spid"].Value != null && !Convert.IsDBNull(cmd.Parameters[tmpString].Value))
                        tmpInt = Convert.ToInt32(cmd.Parameters[tmpString].Value);
                    if (cmd.Parameters[tmpString = "@trancount"].Value != null && !Convert.IsDBNull(cmd.Parameters[tmpString].Value))
                        tmpInt = Convert.ToInt32(cmd.Parameters[tmpString].Value);

                    session.CommitTransaction();
                    //session.RollbackTransaction();
                }
                catch(Exception eException)
                {
                    if (session.InTransaction)
                        session.RollbackTransaction();
                }
                finally
                { 
                    if (connection != null && connection.State == ConnectionState.Open)
                        connection.Close();
                }
            #endif

            XPClassInfo
                classInfoTestMaster = session.GetClassInfo(typeof(TestMaster));

            var collection = session.GetObjectsByKey(classInfoTestMaster, new[] { 33L, 99L }, true);
            var listOfTypeObjects = collection.OfType<object>().ToList();
            var listCastObjects = collection.Cast<object>().ToList();
            var arrayOfTypeObjects = listOfTypeObjects.ToArray();
            var arrayCastObjects = listCastObjects.ToArray();

            TestMaster
                tmpTestMaster,
                tmpTestMasterII;

            tmpTestMaster = session.GetObjectByKey<TestMaster>(1L, false);

            tmpInt = tmpTestMaster.Details.Count;

            Session sessionII = new Session();

            TestDetail
                tmpTestDetail;

            tmpTestDetail = sessionII.GetObjectByKey<TestDetail>(2L);
            tmpTestMasterII = sessionII.GetObjectByKey<TestMaster>(2L);
            tmpTestDetail.Master = tmpTestMasterII;
            tmpTestDetail.Save();
            sessionII.Save(tmpTestDetail);

            tmpInt = tmpTestMaster.Details.Count;

            #if TEST_IS_NEW_AND_IS_TO_SAVE
                session.BeginTransaction();
                tmpTestMaster = new TestMaster(session) { Name = string.Format("Test {0}", DateTime.Now.Ticks)};
                isNewObject = session.IsNewObject(tmpTestMaster);
                isObjectToSave = session.IsObjectToSave(tmpTestMaster);
                tmpTestMaster.Save();
                isNewObject = session.IsNewObject(tmpTestMaster);
                isObjectToSave = session.IsObjectToSave(tmpTestMaster);
                session.CommitTransaction();
                isNewObject = session.IsNewObject(tmpTestMaster);
                isObjectToSave = session.IsObjectToSave(tmpTestMaster);

                session.BeginTransaction();
                tmpTestMaster = new TestMaster(session) { Name = string.Format("Test {0}", DateTime.Now.Ticks) };
                isNewObject = session.IsNewObject(tmpTestMaster);
                isObjectToSave = session.IsObjectToSave(tmpTestMaster);
                tmpTestMaster.Save();
                isNewObject = session.IsNewObject(tmpTestMaster);
                isObjectToSave = session.IsObjectToSave(tmpTestMaster);
                session.RollbackTransaction();
                isNewObject = session.IsNewObject(tmpTestMaster);
                isObjectToSave = session.IsObjectToSave(tmpTestMaster);
            #endif

            //session.IdentityMapBehavior = IdentityMapBehavior.Default;
            session.ObjectLoaded += SessionObjectLoaded;

            XPClassInfo
                classInfoTestDetail = session.GetClassInfo(typeof(TestDetail));

            session.GetObjectsByKey(classInfoTestDetail, new List<object> { 4L, 5L/*, 6L, 7L*/ }, true);

            tmpTestMaster = session.GetObjectByKey<TestMaster>(2L, false);

            //testMasterII = session.GetObjectByKey<TestMaster>(4L, false);

            tmpString = tmpTestMaster.Details[1].Name;

            //session.PreFetch(new[] { testMaster, testMasterII }, "Details");

            foreach (TestDetail testDetail in tmpTestMaster.Details)
                tmpString = testDetail.Name;
        }

        #if TEST_EXCEPTION_IN_ONSAVING

        static void SessionFailedFlushChanges(object sender, SessionOperationFailEventArgs e)
        {
            e.Handled = true;
        }

        static void SessionFailedCommitTransaction(object sender, SessionOperationFailEventArgs e)
        {
            e.Handled = true;
        }

        #endif

        static void SessionObjectLoaded(object sender, ObjectManipulationEventArgs e)
        {
            if(e != null && e.Object != null)
                Console.WriteLine("SessionObjectLoaded: {0}", e.Object);
        }

        #if TEST_DISPOSE
            static TestMaster GetMaster(long id, Session externalSession = null)
            {
                TestMaster result;
                var internalSession = externalSession ?? new Session();

                try
                {
                    result = (TestMaster)internalSession.FindObject(typeof(TestMaster), CriteriaOperator.Parse("Id = ?", id.ToString()));
                }
                finally
                {
                    if(externalSession == null)
                        internalSession.Dispose();
                }

                return result;
            }

            static string GetMasterName(long id)
            {
                var currentMaster = GetMaster(id);
                XPCollection<TestDetail> details;

                try
                {
                    details = currentMaster.Details;
                }
                catch (ObjectDisposedException eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }

                return currentMaster != null ? currentMaster.Name : string.Empty;
            }
        #endif
    }
}

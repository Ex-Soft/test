#define TEST_N_N
#define INSERT_DATA
//#define TEST_NON_PERSISTENT

using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using TestAssociation.Db;

namespace TestAssociation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");

                Session session = new Session();

                object tmpObject;

                #if TEST_N_N
                    TableLeft left;
                    TableRight right;

                    #if INSERT_DATA
                        left = new TableLeft(session);
                        left.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableLeft")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                        left.Val = $"Left ({left.Id})";    
                        left.Save();

                        for (var i = 0; i < 3; ++i)
                        {
                            right = new TableRight(session);
                            right.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableRight")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                            right.Val = $"Right ({right.Id})";
                            right.Save();
                        
                            left.AssociativeTable.Add(new AssociativeTable(session) { Left = left, Right = right });
                        }
                        left.Save();

                        right = new TableRight(session);
                        right.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableRight")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                        right.Val = $"Right ({right.Id})";
                        right.Save();

                        for (var i = 0; i < 3; ++i)
                        {
                            left = new TableLeft(session);
                            left.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableLeft")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                            left.Val = $"Left ({left.Id})";    
                            left.Save();

                            right.AssociativeTable.Add(new AssociativeTable(session) { Left = left, Right = right });
                        }
                        right.Save();
                    #endif

                    if ((left = session.GetObjectByKey<TableLeft>(1)) != null)
                    {
                        if (left.AssociativeTable.Count > 0)
                            right = left.AssociativeTable[left.AssociativeTable.Count - 1].Right;
                    }

                    if ((right = session.GetObjectByKey<TableRight>(4)) != null)
                    {
                        if (right.AssociativeTable.Count > 0)
                            left = right.AssociativeTable[right.AssociativeTable.Count - 1].Left;
                    }
                #endif

                #if TEST_NON_PERSISTENT

                    var master = new NonPersistentMaster(session);
                    master.Val = "master";

                    for (var i = 0; i < 3; ++i)
                    {
                        master.Details.Add(new NonPersistentDetail(session));
                        master.Details[i].Val = i.ToString();
                    }

                #endif
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
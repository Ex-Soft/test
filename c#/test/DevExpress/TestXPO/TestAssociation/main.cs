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

                var master = new NonPersistentMaster(session);
                master.Val = "master";

                for (var i = 0; i < 3; ++i)
                {
                    master.Details.Add(new NonPersistentDetail(session));
                    master.Details[i].Val = i.ToString();
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}
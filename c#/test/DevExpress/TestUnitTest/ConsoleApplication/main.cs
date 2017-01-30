using System.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using ClassLibrary.Db;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());

            Write();
            Read();
        }

        private static void Write()
        {
            using (var session = new Session())
            {
                session.BeginTransaction();

                var enums = new Enums(session);
                enums.CodeKey = "#1";
                enums.Save();
                session.Save(enums);

                session.CommitTransaction();
            }
        }

        private static void Read()
        {
            using (var session = new Session())
            {
                var enums = new XPCollection<Enums>(session).ToArray();
            }
        }
    }
}

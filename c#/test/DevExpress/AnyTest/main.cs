using System;
using AnyTest.Db;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace AnyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XpoDefault.DataLayer = new SimpleDataLayer(new InMemoryDataStore());

                var session = new Session();

                var entityA = new EntityA(session)
                {
                    Id = 3,
                    Name = "EntityA(3)"
                };
                entityA.Save();

                var entityB = new EntityB(session)
                {
                    Id = 9,
                    Name = "EntityB(9)"
                };
                entityB.Save();

                entityA.PropertyObject = "PropertyObject(EntityA)";
                entityB.PropertyObject = "PropertyObject(EntityB)";

                entityA.PropertyEntityA = "PropertyEntityA";
                entityB.PropertyEntityB = "PropertyEntityB";
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}

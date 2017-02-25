using System;
using System.Diagnostics;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Exceptions;
using PolymorphicAssociations.Db;

namespace PolymorphicAssociations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DevExpress.Xpo.Metadata.ReflectionClassInfo.SuppressSuspiciousMemberInheritanceCheck = true;

                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");

                using (var session = new Session())
                {
                    var testDetailWithPolymorphicAssociations = session.GetObjectByKey<TestDetailWithPolymorphicAssociations>(2);

                    var criteria = new OperandProperty("MasterType") == new OperandValue("X");
                    var collectionOfTestDetailWithPolymorphicAssociations = new XPCollection<TestDetailWithPolymorphicAssociations>(session, criteria);
                    foreach (var item in collectionOfTestDetailWithPolymorphicAssociations)
                    {
                        Debug.WriteLine($"{{Id:{item.Id}, MasterType:\"{item.MasterType}\", TestMasterX.Id:{item.TestMasterX.Id}, Val:\"{item.Val}\"}}");
                    }

                    var collectionOfTestMasterX = new XPCollection<TestMasterX>(session);
                    foreach (var item in collectionOfTestMasterX)
                    {
                        Debug.WriteLine($"{{Id:{item.Id}, Val:\"{item.Val}\"}}");
                        foreach (TestDetailWithPolymorphicAssociations _item_ in item.TestDetailWithPolymorphicAssociations)
                            Debug.WriteLine($"{{Id:{_item_.Id}, MasterType:\"{_item_.MasterType}\", TestMasterX.Id:{_item_.TestMasterX.Id}, Val:\"{_item_.Val}\"}}");
                    }

                    var testMasterX = new TestMasterX(session);
                    testMasterX.Save();
                    testMasterX.Val = testMasterX.Id.ToString();
                    testDetailWithPolymorphicAssociations = new TestDetailWithPolymorphicAssociations(session);
                    testDetailWithPolymorphicAssociations.MasterType = "X";
                    testDetailWithPolymorphicAssociations.Val = $"{testDetailWithPolymorphicAssociations.MasterType}({testMasterX.Id})";
                    testMasterX.TestDetailWithPolymorphicAssociations.Add(testDetailWithPolymorphicAssociations);
                    testMasterX.Save();
                }
            }
            catch (CannotLoadObjectsException eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}

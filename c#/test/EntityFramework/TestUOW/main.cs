using System;
using TestUOW.DAL;
using TestUOW.Models;

namespace TestUOW
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork uow = null;

            try
            {
                uow = new UnitOfWork();

                var staff = uow.StaffRepository.Get((item) => item.Name.Contains("Ленин"));

                TestMaster testMaster;

                if ((testMaster = uow.TestMasterRepository.GetTestMasterByID(1)) != null)
                    foreach (var testDetail in testMaster.TestDetails)
                        System.Diagnostics.Debug.WriteLine("TestDetail: {{ Id: {0} }}", testDetail.Id);
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            finally
            {
                uow?.Dispose();
            }
        }
    }
}

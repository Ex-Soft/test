//runas /user:softline.main\tester1 "c:\\Users\\tester1\\Documents\\WhoAmI.exe false"

using System;
using System.Security.Principal;

namespace WhoAmI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool
                    ifImpersonating = false;

                if (args.Length > 0)
                    bool.TryParse(args[0], out ifImpersonating);

                WindowsIdentity
                    wi = WindowsIdentity.GetCurrent(ifImpersonating);

                Console.WriteLine(string.Format("{0}", wi != null ? wi.Name : "null"));
            }
            catch (Exception eException)
            {

                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            Console.ReadLine();
        }
    }
}

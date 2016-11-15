using System;
using System.Data.SqlTypes;

namespace TestTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[]
                bytes = null;

            SqlBinary
                sqlBinary = null;

            try
            {
                sqlBinary = new SqlBinary(bytes);
            }
            catch(Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}

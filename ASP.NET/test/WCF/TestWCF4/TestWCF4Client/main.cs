using System;
using TestWCF4Client.TestWCF4Service;

using static System.Console;

namespace TestWCF4Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new TestServiceClient();

                client.Open();

                string tmpString;
                int tmpInt;

                tmpString = client.GetData(13);
                WriteLine($"\"{tmpString}\"");

                tmpInt = client.Sum(2, 3);
                WriteLine(tmpInt);
                tmpInt = client.Subtract(25, 5);
                WriteLine(tmpInt);
                tmpInt = client.Multiply(2, 3);
                WriteLine(tmpInt);
                tmpInt = client.Divide(25, 5);
                WriteLine(tmpInt);

                CompositeType compositeType = client.GetDataUsingDataContract(new CompositeType { BoolValue = true, StringValue = "ClientStringValue" });
                WriteLine($"{{BoolValue:{compositeType.BoolValue}, StringValue:\"{compositeType.StringValue}\"}}");

                client.Close();
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}

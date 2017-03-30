using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using TestJson.Common;

namespace TestJavaScriptSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            JavaScriptSerializer
                javaScriptSerializer = new JavaScriptSerializer();

            TestObject
                testObject4Serialize = new TestObject()
                {
                    FBool = true,
                    FString = "string\\string\\string\nnew line\rnew line\r\nnew line\n\rnew line\ttab\"quot\"solidus/solidus",
                    FInt = 1,
                    FFloat = 1.1f,
                    FDouble = 11.11,
                    FDecimal = 111.111m,
                    FDateTime = DateTime.Now,
                    FObject = new { FA = 1, FB = 2 },
                    FArrayBytes = new byte[] { 1, 2, 3, 4, 5 },
                    FArrayInts = new[] { 1, 2, 3, 4, 5 },
                    FListInts = new List<int>(new[] { 11, 22, 33, 44, 55 }),
                    FArrayTestObjects = new TestObject[] {
                        new TestObject() { FInt=1 },
                        new TestObject() { FInt=2 },
                        new TestObject() { FInt=3 }
                    },
                    FListTestObjects = new List<TestObject>(new TestObject[] {
                        new TestObject() { FInt=11, FTestEnum = TestEnum.First },
                        new TestObject() { FInt=22, FTestEnum = TestEnum.Second },
                        new TestObject() { FInt=33, FTestEnum = TestEnum.Third }
                    }),
                    FTestEnum = TestEnum.Second
                };

            string
                currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                outputFileName,
                tmpString = javaScriptSerializer.Serialize(testObject4Serialize);

            Console.WriteLine(tmpString);

            var hashAlgorithm = new SHA512Managed();
            var hash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(tmpString));

            if (File.Exists(outputFileName = currentDirectory + "output.json"))
                File.Delete(outputFileName);

            File.WriteAllText(outputFileName, tmpString);

            TestObject
                testObject4Deserialize = javaScriptSerializer.Deserialize<TestObject>(tmpString);

            var regex = new Regex("(?<=\"FTestEnum\":).*?(?=})");
            var match = regex.Match(tmpString);
            if (match.Success)
            {
                tmpString = regex.Replace(tmpString, "13");
                testObject4Deserialize = javaScriptSerializer.Deserialize<TestObject>(tmpString); // FTestEnum == 13
                Console.WriteLine("testObject4Deserialize.FTestEnum = {0} {1}IsDefined()", testObject4Deserialize.FTestEnum, Enum.IsDefined(typeof (TestEnum), testObject4Deserialize.FTestEnum) ? string.Empty : "!");
            }

            regex = new Regex(",\\s*?\"FTestEnum\":.*?(?=})");
            match = regex.Match(tmpString);
            if (match.Success)
            {
                tmpString = regex.Replace(tmpString, string.Empty);
                testObject4Deserialize = javaScriptSerializer.Deserialize<TestObject>(tmpString); // FTestEnum == Zero
                Console.WriteLine("testObject4Deserialize.FTestEnum = {0} {1}IsDefined()", testObject4Deserialize.FTestEnum, Enum.IsDefined(typeof(TestEnum), testObject4Deserialize.FTestEnum) ? string.Empty : "!");
            }
        }
    }
}

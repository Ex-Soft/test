using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TestJsonNET
{
    class Program
    {
        static void Main(string[] args)
        {
            TestObject
                testObject4Serialize = new TestObject()
                {
                    FBool = true,
                    FString = "string\\string\\string",
                    FInt = 1,
                    FFloat = 1.1f,
                    FDouble = 11.11,
                    FDecimal = 111.111m,
                    FDateTime = DateTime.Now,
                    FArrayInts = new int[] { 1, 2, 3, 4, 5 },
                    FListInts = new List<int>(new int[] { 11, 22, 33, 44, 55 }),
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
                    FTestEnum = TestEnum.Second,
                    FGenderEnum = GenderEnum.Male
                };

            string
                currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                outputFileName,
                tmpString = JsonConvert.SerializeObject(testObject4Serialize);

            Console.WriteLine(tmpString);

            if (File.Exists(outputFileName = currentDirectory + "output.json"))
                File.Delete(outputFileName);

            File.WriteAllText(outputFileName, tmpString);

            TestObject
                testObject4Deserialize = JsonConvert.DeserializeObject<TestObject>(tmpString);

            Console.ReadLine();
        }
    }
}

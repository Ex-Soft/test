//#define TEST_CLASS_WITH_OBJECT_PROPERTY
#define TEST_DATE

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestJsonNET
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                tmpString;

            try
            {
                #if TEST_DATE
                    // http://www.newtonsoft.com/json/help/html/DatesInJSON.htm

                    ClassWithDates classWithDates = new ClassWithDates { FDateOnly = new DateTime(2016, 2, 29), FDateTime = new DateTime(2016, 2, 29, 23, 53, 38), FDateTimeOffset = new DateTimeOffset(2016, 2, 29, 23, 53, 38, new TimeSpan(0, 3, 0)) };
                    tmpString = JsonConvert.SerializeObject(classWithDates); // {"FDateOnly":"2016-02-29T00:00:00", "FDateTime":"2016-02-29T23:53:38", "FDateTimeOffset":"2016-02-29T23:53:38+00:03"}
                    var classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);

                    JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
                    tmpString = JsonConvert.SerializeObject(classWithDates, microsoftDateFormatSettings); // {"FDateOnly":"\/Date(1456696800000+0200)\/", "FDateTime":"\/Date(1456782818000+0200)\/", "FDateTimeOffset":"\/Date(1456789838000+0003)\/"}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);

                    tmpString = JsonConvert.SerializeObject(classWithDates, new JavaScriptDateTimeConverter()); // {"FDateOnly":new Date(1456696800000), "FDateTime":new Date(1456782818000), "FDateTimeOffset":new Date(1456789838000)}
                    //classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);
                #endif

                #if TEST_CLASS_WITH_OBJECT_PROPERTY
                    var raw = "{\"Code\":20002,\"Data\":28147497734082}";
                    var classWithObjectProperty = JsonConvert.DeserializeObject<ClassWithObjectProperty>(raw);
                    tmpString = JsonConvert.SerializeObject(classWithObjectProperty);
                    raw = "{\"Code\":20004,\"Data\":null}";
                    classWithObjectProperty = JsonConvert.DeserializeObject<ClassWithObjectProperty>(raw);
                    tmpString = JsonConvert.SerializeObject(classWithObjectProperty);
                #endif

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
                        FObject = new {FA = 1, FB = 2},
                        FArrayBytes = new byte[] {1, 2, 3, 4, 5},
                        FArrayInts = new int[] {1, 2, 3, 4, 5},
                        FListInts = new List<int>(new int[] {11, 22, 33, 44, 55}),
                        FArrayTestObjects = new TestObject[]
                        {
                            new TestObject() {FInt = 1},
                            new TestObject() {FInt = 2},
                            new TestObject() {FInt = 3}
                        },
                        FListTestObjects = new List<TestObject>(new TestObject[]
                        {
                            new TestObject() {FInt = 11, FTestEnum = TestEnum.First},
                            new TestObject() {FInt = 22, FTestEnum = TestEnum.Second},
                            new TestObject() {FInt = 33, FTestEnum = TestEnum.Third}
                        }),
                        FTestEnum = TestEnum.Second,
                        FGenderEnum = GenderEnum.Male
                    };

                string
                    currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

                if (currentDirectory.IndexOf("bin") != -1)
                    currentDirectory = currentDirectory.Substring(0,
                        currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                string
                    outputFileName;

                tmpString = JsonConvert.SerializeObject(testObject4Serialize);

                Console.WriteLine(tmpString);

                if (File.Exists(outputFileName = currentDirectory + "output.json"))
                    File.Delete(outputFileName);

                File.WriteAllText(outputFileName, tmpString);

                TestObject
                    testObject4Deserialize = JsonConvert.DeserializeObject<TestObject>(tmpString);

                Console.ReadLine();
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}

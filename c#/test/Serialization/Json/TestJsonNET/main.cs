#define TEST_CLASS_WITH_OBJECT_PROPERTY
//#define TEST_DATE
//#define TEST_POST

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;

namespace TestJsonNET
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                tmpString;

            int
                tmpInt;

            DateTime
                dateTime1,
                dateTime2;

            DateTimeOffset
                dateTimeOffset1,
                dateTimeOffset2;

            JArray
                jArray;

            JObject
                jObject;

            JToken
                jToken;

            JProperty
                jProperty;

            try
            {
                #if TEST_POST
                    tmpString = "[ { \"f_string\": \"string\", \"f_int\": 5, \"f_bit\": true, \"id\": 1 }, { \"f_int\": 8, \"id\": 2 } ]";
                    jObject = JsonConvert.DeserializeObject(tmpString) as JObject;
                    if (jObject != null)
                    {
                    }

                    jArray = JsonConvert.DeserializeObject(tmpString) as JArray;
                    if (jArray != null)
                    {
                        for (var i = 0; i < jArray.Count; ++i)
                        {
                            jToken = jArray[i];
                            for (var _jTocken_ = jToken.First; _jTocken_ != null; _jTocken_ = _jTocken_.Next)
                            {
                                jProperty = _jTocken_.ToObject<JProperty>();
                                Debug.WriteLine($"{{Name:\"{jProperty.Name}\", Value.Type:{jProperty.Value.Type}, Value:{jProperty.Value}}}");
                            }

                            dynamic idValue = jToken["id"];
                            if (idValue == null)
                                continue;

                            dynamic value = idValue.Value;
                            tmpInt = idValue.ToObject(typeof(int));
                        }
                    }
                #endif

                #if TEST_DATE
                    // http://www.newtonsoft.com/json/help/html/DatesInJSON.htm

                    //tmpString = "{\"gmt\":\"\\/Date(1508310210135)\\/\"}";
                    tmpString = "{\"FDateTimeOffset\":\"\\/Date(1508321380535+0300)\\/\"}";
                    //tmpString = "{\"FDateTimeOffset\":\"\\/Date(1508325572835+0300)\\/\"}";

                    Newtonsoft.Json.Linq.JObject jObject = JsonConvert.DeserializeObject(tmpString) as Newtonsoft.Json.Linq.JObject;
                    Newtonsoft.Json.Linq.JToken jToken;
                
                    if(jObject != null && jObject.TryGetValue("FDateTimeOffset", out jToken))
                    {
                        dateTime1 = (DateTime)jToken;
                        dateTimeOffset1 = (DateTimeOffset)jToken;
                    }
                    var classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);

                    dateTime1 = DateTime.UtcNow;
                    dateTime2 = DateTime.Now;
                    dateTimeOffset1 = DateTimeOffset.UtcNow;
                    dateTimeOffset2 = DateTimeOffset.Now;

                    JsonSerializerSettings microsoftDateFormatSettings = new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };

                    ClassWithDates classWithDates = new ClassWithDates { FDateOnly = dateTime1.Date, FDateTime = dateTime1, FDateTimeOffset = dateTimeOffset1 };
                    tmpString = JsonConvert.SerializeObject(classWithDates);
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);
                    tmpString = JsonConvert.SerializeObject(classWithDates, microsoftDateFormatSettings);
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);

                    classWithDates = new ClassWithDates { FDateOnly = dateTime2.Date, FDateTime = dateTime2, FDateTimeOffset = dateTimeOffset2 };
                    tmpString = JsonConvert.SerializeObject(classWithDates); // {"FDateOnly":"2016-02-29T00:00:00", "FDateTime":"2016-02-29T23:53:38", "FDateTimeOffset":"2016-02-29T23:53:38+00:03"}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);
                    tmpString = JsonConvert.SerializeObject(classWithDates, microsoftDateFormatSettings); // {"FDateOnly":"\/Date(1456696800000+0200)\/", "FDateTime":"\/Date(1456782818000+0200)\/", "FDateTimeOffset":"\/Date(1456789838000+0003)\/"}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);

                    classWithDates = new ClassWithDates { FDateOnly = new DateTime(2017, 10, 18), FDateTime = new DateTime(2017, 10, 18, 10, 03, 30), FDateTimeOffset = new DateTimeOffset(2017, 10, 18, 10, 03, 30, 135, new TimeSpan(3, 0, 0)) };
                    tmpString = JsonConvert.SerializeObject(classWithDates); // {"FDateOnly":"2016-02-29T00:00:00", "FDateTime":"2016-02-29T23:53:38", "FDateTimeOffset":"2016-02-29T23:53:38+00:03"}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);
                    tmpString = JsonConvert.SerializeObject(classWithDates, microsoftDateFormatSettings); // {"FDateOnly":"\/Date(1456696800000+0200)\/", "FDateTime":"\/Date(1456782818000+0200)\/", "FDateTimeOffset":"\/Date(1456789838000+0003)\/"}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);

                    classWithDates = new ClassWithDates { FDateOnly = new DateTime(2016, 2, 29), FDateTime = new DateTime(2016, 2, 29, 23, 53, 38), FDateTimeOffset = new DateTimeOffset(2016, 2, 29, 23, 53, 38, new TimeSpan(0, 3, 0)) };
                    tmpString = JsonConvert.SerializeObject(classWithDates); // {"FDateOnly":"2016-02-29T00:00:00", "FDateTime":"2016-02-29T23:53:38", "FDateTimeOffset":"2016-02-29T23:53:38+00:03"}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);
                    tmpString = JsonConvert.SerializeObject(classWithDates, microsoftDateFormatSettings); // {"FDateOnly":"\/Date(1456696800000+0200)\/", "FDateTime":"\/Date(1456782818000+0200)\/", "FDateTimeOffset":"\/Date(1456789838000+0003)\/"}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);
                    tmpString = JsonConvert.SerializeObject(classWithDates, new JavaScriptDateTimeConverter()); // {"FDateOnly":new Date(1456696800000), "FDateTime":new Date(1456782818000), "FDateTimeOffset":new Date(1456789838000)}
                    classWithDatesOut = JsonConvert.DeserializeObject<ClassWithDates>(tmpString);
                #endif

                #if TEST_CLASS_WITH_OBJECT_PROPERTY
                    var raw = "{\"LicenseKey\":{\"ExpirationDate\":\"2017-10-17T13:13:13.1313131Z\", \"ExpirationDateTimeOffset\":\"2017-10-17T13:13:13.1313131Z\"}}"; // https://www.w3.org/TR/NOTE-datetime
                    var licenseObject = JsonConvert.DeserializeObject<LicenseObject>(raw);
                    var licenseKey = licenseObject.LicenseKey as Newtonsoft.Json.Linq.JObject;

                    //Newtonsoft.Json.Linq.JToken jToken;
                    if (licenseKey.TryGetValue("ExpirationDate", out jToken))
                    {
                        DateTime dateTime = (DateTime)licenseKey["ExpirationDate"]; // Kind == Utc
                        dateTime = licenseKey.Value<DateTime>("ExpirationDate"); // Kind == Utc
                        dateTime = (DateTime)jToken; // Kind == Utc
                    }

                    if (licenseKey.TryGetValue("ExpirationDateTimeOffset", out jToken))
                    {
                        DateTimeOffset dateTimeOffset = (DateTimeOffset)licenseKey["ExpirationDateTimeOffset"]; // Kind == Unspecified, Local - oB! (Utc + REAL Offset), Offset == 00:00:00
                        //dateTimeOffset = licenseKey.Value<DateTimeOffset>("ExpirationDateTimeOffset"); // System.InvalidCastException "Invalid cast from 'System.DateTime' to 'System.DateTimeOffset'."
                        dateTimeOffset = (DateTimeOffset)jToken; // Kind == Unspecified, Local - oB! (Utc + REAL Offset), Offset == 00:00:00 
                    }

                    raw = "{\"Code\":20002,\"Data\":28147497734082}";
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

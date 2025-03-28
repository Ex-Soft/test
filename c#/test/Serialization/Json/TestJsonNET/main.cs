﻿#define TEST_DICTIONARY
//#define TEST_MIX
//#define TEST_CLASS_WITH_OBJECT_PROPERTY
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

using static System.Console;

namespace TestJsonNET
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                tmpString,
                tmpString2;

            int
                tmpInt;

            DateTime
                dateTime1 = default,
                dateTime2;

            DateTimeOffset
                dateTimeOffset1 = default,
                dateTimeOffset2;

            object
                tmpObject1;

            MultiLanguagesText
                multiLanguagesText1;

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
                string
                    currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

                if (currentDirectory.IndexOf("bin") != -1)
                    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

                string
                    outputFileName;

                #if TEST_DICTIONARY
                    Dictionary<string, string> dictionary1 = new Dictionary<string, string>
                    {
                        { "FiRsT", "1st" },
                        { "sEcOnD", "2nd" },
                        { "ThIrD", "3rd"}
                    };

                    tmpString = JsonConvert.SerializeObject(dictionary1);

                    Dictionary<string, string> dictionary2 = new Dictionary<string, string>(JsonConvert.DeserializeObject<Dictionary<string, string>>(tmpString), StringComparer.OrdinalIgnoreCase);
                    tmpString2 = "fIrSt";
                    if (dictionary2.ContainsKey(tmpString2))
                        Console.WriteLine($"[\"{tmpString2}\"] = \"{dictionary2[tmpString2]}\"");
                #endif

                #if TEST_MIX
                    multiLanguagesText1 = new MultiLanguagesText
                    {
                        En = "{\"en\":\"\"English\" string with path \"c:\\windows\\system32\\drivers\\etc\\hosts\"\"}",
                        De = "{\"en\":\"\"Deutsche\" Zeichenfolge mit URL \"http://www.lmgtfy.com/?q=json+escape\"\"}"
                    };
                    WriteLine(multiLanguagesText1.En);
                    WriteLine(multiLanguagesText1.De);
                    tmpString = multiLanguagesText1.ToJson();

                    if (File.Exists(outputFileName = Path.Combine(currentDirectory, "MultiLanguagesText.json")))
                        File.Delete(outputFileName);

                    File.WriteAllText(outputFileName, tmpString);

                    multiLanguagesText1 = null;
                    multiLanguagesText1 = JsonConvert.DeserializeObject<MultiLanguagesText>(tmpString);

                    tmpString = "{ \"en\": \"english\", \"de\": \"german\" }";
                    tmpObject1 = JsonConvert.DeserializeObject<object>(tmpString);

                    try
                    {
                        jObject = tmpObject1 as JObject;
                        multiLanguagesText1 = jObject.Root.ToObject<MultiLanguagesText>();
                    }
                    catch (Exception eException)
                    {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message);
                    }

                    tmpString = "{ \"en\": \"english\" }";
                    tmpObject1 = JsonConvert.DeserializeObject<object>(tmpString);

                    try
                    {
                        jObject = tmpObject1 as JObject;
                        if (jObject != null && jObject.TryGetValue("en", out jToken))
                        {
                            tmpString2 = (string)jToken;
                        }
                    }
                    catch (Exception eException)
                    {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message);
                    }

                #endif

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

                    jObject = JsonConvert.DeserializeObject(tmpString) as Newtonsoft.Json.Linq.JObject;
                    
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
                        FGenderEnum = GenderEnum.Male,
                        FType = typeof(TestObject)
                    };

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

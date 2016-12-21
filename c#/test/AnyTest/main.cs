//#define TEST_BIT_CONVERTER
//#define TEST_DOUBLE
//#define TEST_DECIMAL
//#define TEST_RECTANGLE
//#define TEST_FILE_TIME
//#define TEST_OPERATOR
//#define TEST_STRING_BUILDER
//#define TEST_HASH_CODE
//#define TEST_GUID
//#define TEST_REFERENCE_EQUALS
//#define TEST_DEFAULT
#define TEST_SYSTEM_OBJECT
//#define TEST_COLOR
//#define TEST_FILE
//#define TEST_CLONE
//#define ANY_TEST
//#define TEST_TYPES
//#define TEST_OPERATOR_PRECEDENCE
//#define TEST_INITIALIZATION
//#define TEST_STRING
//#define TEST_STRUCT
//#define TEST_ARRAY
//#define TEST_AD
//#define TEST_PARAMS
//#define TEST_THERMO
//#define TEST_DATE_TIME
//#define TEST_SPLIT
//#define TEST_ENUM
//#define TEST_GET_STRING
//#define TEST_BIG_ENDIAN
//#define TEST_BIT_OPERATIONS
//#define TEST_TRY_PARSE
//#define TEST_ASSERT
//#define TEST_NULLABLE_TYPES
//#define TEST_CONVERT
//#define TEST_YIELD
//#define TEST_COMPARE
//#define TEST_INDEX_OF
//#define TEST_FOR
//#define TEST_REF
//#define TEST_PATH
//#define TEST_FORMAT

using System;
using System.Globalization;
using System.Security;
using System.Security.AccessControl;
using System.Threading;
using System.Drawing;
using System.Data;
using System.IO;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Security.Permissions;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace AnyTest
{
    #if TEST_YIELD
        class A
        {
            public string Level;
            public A Parent;

            public A(A obj) : this(obj.Level, obj.Parent)
            {}

            public A(string level="", A parent=null)
            {
                Level = level;
                Parent = parent;
            }
        }
    #endif

    class Program
    {
        #if TEST_CLONE
            public class ClassWithString
            {
                public string s;
            }
        #endif

        #if TEST_STRUCT
            struct TestStruct
            {
                public int
                    a, b;
            }

            class TestClass
            {
                public int
                    a, b;
            }
        #endif

		#if TEST_ENUM
			enum TestEnum
			{
				Zero /*= 0*/,
				First,
				Second,
				Third,
				Fourth,
				Fifth,
				Ten = 10,
				Thirteen = 13,
				Fifteen = 15
			}

            enum SmthEnum : long
            {
                First = 1L,
                Second,
                Third = 3L
            }
		#endif

		#if TEST_YIELD
			public static IEnumerable Power(int number, int exponent)
			{
				int
					counter = 0,
					result = 1;

				while (counter++ < exponent)
				{
					result = result * number;
					yield return result;
				}
			}

            public static IEnumerable<int> GetFibonachiSequence()
            {
                yield return 1;
                yield return 2;
                yield return 3;
                yield return 5;
            }

            public static IEnumerable<int> GetInts()
            {
                foreach (int i in new int[] { 1, 2, 3, 5, 8 })
                    yield return i;
            }

            public static IEnumerable<A> GetParents(A obj)
            {
                Console.WriteLine("GetParents({0}) enter", obj.Level);

                if(obj.Parent==null)
                    yield break;

                if (obj.Parent.Parent != null)
                {
                    foreach (var _obj_ in GetParents(obj.Parent))
                    {
                        Console.WriteLine("b4 yield return _obj_ ({0})", _obj_.Level);
                        yield return _obj_;
                        Console.WriteLine("after yield return _obj_ ({0})", _obj_.Level);
                    }
                }

                Console.WriteLine("b4 yield return obj.Parent ({0})", obj.Parent.Level);
                yield return obj.Parent;
                Console.WriteLine("after yield return obj.Parent ({0})", obj.Parent.Level);
            }

            public static IEnumerable<A> GetParentsII(A obj)
            {
                Console.WriteLine("GetParentsII({0}) enter", obj.Level);

                if (obj.Parent != null)
                {
                    A parent = obj.Parent;

                    while (parent != null)
                    {
                        Console.WriteLine("b4 yield return parent ({0})", parent.Level);
                        yield return parent;
                        Console.WriteLine("after yield return parent ({0})", parent.Level);
                        parent = parent.Parent;
                    }
                }
            }
		#endif

		#if TEST_ARRAY
            static void SetArray(int[] ai, int value)
            {
                ai[1] = value;

                ai = new int[] { 11, 22, 33 };
            }

            static void SetArray(ref int[] ai, int value)
            {
                ai[1] = value;

                ai = new int[] { 11, 22, 33 };
            }
		#endif

		#if TEST_INITIALIZATION
            public static int foo(int param)
            {
                Console.WriteLine("foo({0})", param);

                return param;
            }
		#endif

        static void Main(string[] args)
        {
			string
				currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location,
				tmpString=string.Empty,
				tmpStringII=string.Empty,
                tmpStringIII=string.Empty;

			string[]
				tmpStrings;

			decimal
				tmpDecimal,
                tmpDecimalII;

			double
				tmpDouble;

			int
				tmpInt,
                tmpIntII,
                tmpIntIII;

			bool
				tmpBool,
                tmpBoolII,
                tmpBoolIII;

			object
				tmpObject,
                tmpObjectII;

			DateTime
				tmpDateTime,
				tmpDateTimeI;

            DateTime?
                tmpDateTimeNullable,
                tmpDateTimeNullableII;

            DateTimeOffset
                tmpDateTimeOffset;

			long
				tmpLong;

            long?
                tmpLongNullable;

			TimeSpan
				tmpTimeSpan;

			byte[]
				bytes,
                bytesII;

			int[]
				ints,
                intsII;

            object[]
                objects,
                objectsII,
                objectsIII;

            Guid
                tmpGuid;

            Type
                tmpType,
                tmpTypeII,
                tmpTypeIII;

            Type[]
                tmpTypes;

            TypeCode
                tmpTypeCode;

            StringBuilder
                tmpStringBuilder;

            byte
                tmpByte;

            ulong
                tmpULong;

			if (currentDirectory.IndexOf("bin", StringComparison.Ordinal) != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1, StringComparison.Ordinal));

            #if TEST_BIT_CONVERTER
                tmpInt = 361439624;
                bytes = BitConverter.GetBytes(tmpInt);
                bytesII = new byte[] { 0, 0, 0, 45, 136, 33, 138, 177 };
                tmpIntII = BitConverter.ToInt32(bytesII, 4);
                bytes = BitConverter.GetBytes(tmpIntII);
                tmpLong = BitConverter.ToInt64(bytesII, 0);
                bytes = BitConverter.GetBytes(tmpLong);
                tmpULong = BitConverter.ToUInt64(bytesII, 0);
                bytes = BitConverter.GetBytes(tmpULong);
            #endif

            #if TEST_DECIMAL
                tmpDecimal = 1.123456789010000m;
                tmpDecimalII = 1.12345678901m;
                tmpString = tmpDecimal.ToString();
                tmpStringII = tmpDecimalII.ToString();
                tmpString = tmpDecimal.ToString("G29");
                tmpStringII = tmpDecimalII.ToString("G29");
                tmpString = tmpDecimal.ToString("0.###############");
                tmpStringII = tmpDecimalII.ToString("0.###############");

                Console.WriteLine("tmpDecimal {0}= tmpDecimalII", tmpDecimal == tmpDecimalII ? "=" : "!");
                Console.WriteLine("{0}decimal.Equals(tmpDecimal, tmpDecimalII)", decimal.Equals(tmpDecimal, tmpDecimalII) ? string.Empty : "!");
                ShowScale(tmpDecimal);
                ShowScale(tmpDecimalII);

                tmpDecimal = decimal.Parse("1.1234567890100000");
                tmpDecimalII = decimal.Parse("1.123456789010");
                tmpString = tmpDecimal.ToString();
                tmpStringII = tmpDecimalII.ToString();
                Console.WriteLine("tmpDecimal {0}= tmpDecimalII", tmpDecimal == tmpDecimalII ? "=" : "!");
                Console.WriteLine("{0}decimal.Equals(tmpDecimal, tmpDecimalII)", decimal.Equals(tmpDecimal, tmpDecimalII) ? string.Empty : "!");
                ShowScale(tmpDecimal);
                ShowScale(tmpDecimalII);

                tmpDecimal = decimal.Parse(tmpDecimal.ToString().TrimEnd(new[] {'0'}));
                ShowScale(tmpDecimal);

                tmpDecimal = new decimal(0x2ad45650, 0x3fdc7, 0, false, 15);
                tmpDecimalII = new decimal(0x28530435, 26, 0, false, 11);
                ShowScale(tmpDecimal);
                ShowScale(tmpDecimalII);

                tmpDecimal = 1m;
                ShowScale(tmpDecimal);
                tmpDecimalII = tmpDecimal.Normalize();
                ShowScale(tmpDecimalII);

                tmpDecimal = 1.0m;
                ShowScale(tmpDecimal);

                tmpDecimal = decimal.Parse("1.");
                ShowScale(tmpDecimal);

                tmpDecimal = 1.1234567890100000m;
                tmpDecimalII = tmpDecimal.Normalize();
                ShowScale(tmpDecimal);
                ShowScale(tmpDecimalII);

                tmpDecimal += 0.1m;
                ShowScale(tmpDecimal);

                tmpDecimal = 1m;
                ShowScale(tmpDecimal);
                tmpDecimal += 0.1m;
                ShowScale(tmpDecimal);

                tmpDecimal = 0.0001m;
                ShowScale(tmpDecimal);
                tmpString = 0.0001m.ToString("G29");
                tmpString = tmpDecimal.ToString("G29");
                tmpString = string.Format("{0:G29}", tmpDecimal);
                tmpString = 0.0001m.ToString("0.###############");
                tmpString = tmpDecimal.ToString("0.###############");
                tmpString = string.Format("{0:0.###############}", tmpDecimal);

                tmpDecimal = 0.00001m;
                ShowScale(tmpDecimal);
                tmpString = 0.00001m.ToString("G29");
                tmpString = tmpDecimal.ToString("G29");
                tmpString = string.Format("{0:G29}", tmpDecimal);
                tmpString = 0.00001m.ToString("0.###############");
                tmpString = tmpDecimal.ToString("0.###############");
                tmpString = string.Format("{0:0.###############}", tmpDecimal);

                tmpDecimal = 0.000001m;
                ShowScale(tmpDecimal);
                tmpString = tmpDecimal.ToString("G29");
                tmpString = string.Format("{0:G29}", tmpDecimal);
                tmpString = 0.000001m.ToString("0.###############");
                tmpString = tmpDecimal.ToString("0.###############");
                tmpString = string.Format("{0:0.###############}", tmpDecimal);

                tmpDecimal = 999999999999999m;
                ShowScale(tmpDecimal);

                tmpDecimal = 79228162514264.337593543950335m;
                ShowScale(tmpDecimal);

                tmpDecimal = -79228162514264.337593543950335m;
                ShowScale(tmpDecimal);

                tmpDecimal = new Decimal(new[] {-1, -1, -1, 0});
                ShowScale(tmpDecimal);

                ShowScale(decimal.MinValue);
                ShowScale(decimal.MaxValue);
            #endif

            #if TEST_RECTANGLE
                Rectangle tmpRectangleI = new Rectangle(50, 100, 150, 200);
                tmpRectangleI.Offset(0, -30);
            #endif

            #if TEST_FILE_TIME
				if (File.Exists(tmpString = Path.Combine(currentDirectory, "new.txt")))
					File.Delete(tmpString);

				File.WriteAllText(tmpString, DateTime.Now.ToString(CultureInfo.InvariantCulture), Encoding.UTF8);

                tmpDateTime = File.GetCreationTime(tmpString);
				tmpDateTime = File.GetCreationTimeUtc(tmpString);
                tmpDateTime = File.GetLastAccessTime(tmpString);
				tmpDateTime = File.GetLastAccessTimeUtc(tmpString);
                tmpDateTime = File.GetLastWriteTime(tmpString);
				tmpDateTime = File.GetLastWriteTimeUtc(tmpString);

				if (!File.Exists(tmpString = Path.Combine(currentDirectory, "updated.txt")))
					File.WriteAllText(tmpString, DateTime.Now.ToString(CultureInfo.InvariantCulture), Encoding.UTF8);

				tmpStringII = File.ReadAllText(tmpString, Encoding.UTF8);
				tmpStringII += Environment.NewLine + DateTime.Now.ToString(CultureInfo.InvariantCulture);
				File.WriteAllText(tmpString, tmpStringII, Encoding.UTF8);

				tmpDateTime = File.GetCreationTime(tmpString);
				tmpDateTime = File.GetCreationTimeUtc(tmpString);
				tmpDateTime = File.GetLastAccessTime(tmpString);
				tmpDateTime = File.GetLastAccessTimeUtc(tmpString);
				tmpDateTime = File.GetLastWriteTime(tmpString);
				tmpDateTime = File.GetLastWriteTimeUtc(tmpString);
            #endif

            #if TEST_OPERATOR
                tmpObject = null;
                tmpObjectII = tmpObject ?? null;
                tmpObject = 1;
                tmpObjectII = tmpObject ?? null;
            #endif

            #if TEST_STRING_BUILDER
                tmpStringBuilder = new StringBuilder();

                tmpStringBuilder.AppendLine("Line #1");
                tmpStringBuilder.AppendLine("Line #2");
                tmpStringBuilder.AppendLine("Line #3");
                tmpString = tmpStringBuilder.ToString();

                tmpStringBuilder = new StringBuilder();
                tmpStringBuilder.Append("Line #1");
                tmpStringBuilder.Append("Line #2");
                tmpStringBuilder.Append("Line #3");
                tmpString = tmpStringBuilder.ToString();
            #endif

            #if TEST_HASH_CODE
                tmpString = "_тест_вкод";

                tmpInt = (2251799820215827L).GetHashCode() ^ (tmpString != null ? tmpString.GetHashCode() : "".GetHashCode());
                Console.WriteLine(tmpInt);
                tmpLong = 2251799820215827L;
                tmpIntII = tmpLong.GetHashCode();
                tmpIntIII = tmpString != null ? tmpString.GetHashCode() : "".GetHashCode();
                tmpInt = tmpIntII ^ tmpIntIII;
                Console.WriteLine(tmpInt);
                tmpInt = tmpLong.GetHashCode() ^ (tmpString != null ? tmpString.GetHashCode() : "".GetHashCode());
                Console.WriteLine(tmpInt);

                tmpInt = (562954286566094L).GetHashCode() ^ (tmpString != null ? tmpString.GetHashCode() : "".GetHashCode());
                Console.WriteLine(tmpInt);
                tmpLong = 562954286566094L;
                tmpIntII = tmpLong.GetHashCode();
                tmpIntIII = tmpString != null ? tmpString.GetHashCode() : "".GetHashCode();
                tmpInt = tmpIntII ^ tmpIntIII;
                Console.WriteLine(tmpInt);
                tmpInt = tmpLong.GetHashCode() ^ (tmpString != null ? tmpString.GetHashCode() : "".GetHashCode());
                Console.WriteLine(tmpInt);
            #endif

            #if TEST_GUID
                tmpString = Guid.NewGuid().ToString().Replace("-", "");
            #endif

            #if TEST_REFERENCE_EQUALS
                tmpString = null;
                tmpStringII = null;
                Console.WriteLine("{0}ReferenceEquals(string(null), string(null))", ReferenceEquals(tmpString, tmpStringII) ? "" : "!"); // ReferenceEquals

                Image
                    image1 = null,
                    image2 = null;

                Console.WriteLine("{0}ReferenceEquals(image(null), image(null))", ReferenceEquals(image1, image2) ? "" : "!"); // ReferenceEquals
            #endif

            #if TEST_DEFAULT
                tmpDateTime = default(DateTime);
                tmpObject = default(object);
                tmpInt = default(int);
            #endif

            #if TEST_SYSTEM_OBJECT
				tmpObject = (string)null;
				tmpString = Convert.ToString(tmpObject); // ""
                tmpObject = new Object();
				tmpString = Convert.ToString(tmpObject); // "System.Object"
				tmpString = tmpObject.ToString(); // "System.Object"
                tmpObjectII = new Object();
                Console.WriteLine("Object.ReferenceEquals(null, null) = {0}", Object.ReferenceEquals(null, null)); // true
                Console.WriteLine("Object.ReferenceEquals(object, null) = {0}", Object.ReferenceEquals(tmpObject, null)); // false
                Console.WriteLine("Object.ReferenceEquals(null, object) = {0}", Object.ReferenceEquals(null, tmpObject)); // false
                Console.WriteLine("Object.ReferenceEquals(object, object) = {0}", Object.ReferenceEquals(tmpObject, tmpObject)); // true
                Console.WriteLine("Object.ReferenceEquals(object1, object2) = {0}", Object.ReferenceEquals(tmpObject, tmpObjectII)); // false

				tmpObject = 13L;
				tmpObjectII = 13L;

				Console.WriteLine("tmpObject {0}= tmpObjectII", tmpObject == tmpObjectII ? "=" : "!"); // tmpObject != tmpObjectII
				Console.WriteLine("tmpObject.Equals(tmpObjectII) = {0}", tmpObject.Equals(tmpObjectII)); // true
				Console.WriteLine("Object.Equals(tmpObject, tmpObjectII) = {0}", Object.Equals(tmpObject, tmpObjectII)); // true
            #endif

            #if TEST_COLOR
                Color
                    tmpColor = Color.FromArgb(255, 247, 165);
            #endif

            #if TEST_FILE
                tmpString = Directory.GetCurrentDirectory();
                tmpString = tmpString.Substring(0, tmpString.LastIndexOf("bin", tmpString.Length - 1)) + "empty.txt";

                bytes = null;
                bytes = File.ReadAllBytes(tmpString);
                if(bytes!=null)
                    Console.WriteLine(bytes.Length);
            #endif

            #if TEST_CLONE
                bytes = new byte[] {0, 1, 2, 3, 4};
                bytesII = (byte[])bytes.Clone();

                ints = new int[] {10, 11, 12, 13, 14};
                intsII = new int[ints.Length*2];
                ints.CopyTo(intsII, 2);

                objects = new object[] { "one", 2, "three", 4, "really big number", 2324573984927361 };
                objectsII = new object[objects.Length];
                objects.CopyTo(objectsII, 0);

                objectsIII = (object[])objects.Clone();
                objects[0] = 0;

                Console.WriteLine(objects[0]); // 0
                Console.WriteLine(objectsII[0]); // "one"
                Console.WriteLine(objectsIII[0]); // "one"

                ClassWithString[]
                    classWithStrings = new ClassWithString[1],
                    classWithStringsII = new ClassWithString[1],
                    classWithStringsIII;

                classWithStrings[0] = new ClassWithString();
                classWithStrings[0].s = "ORIGINAL";

                classWithStrings.CopyTo(classWithStringsII, 0);
                classWithStringsIII = (ClassWithString[]) classWithStrings.Clone();

                Console.WriteLine("classWithStrings[0].s = " + classWithStrings[0].s);
                Console.WriteLine("classWithStringsII[0].s = " + classWithStringsII[0].s);
                Console.WriteLine("classWithStringsIII[0].s = " + classWithStringsIII[0].s);

                classWithStringsII[0].s = "CHANGED";

                Console.WriteLine("classWithStrings[0].s = " + classWithStrings[0].s);
                Console.WriteLine("classWithStringsII[0].s = " + classWithStringsII[0].s);
                Console.WriteLine("classWithStringsIII[0].s = " + classWithStringsIII[0].s);
            #endif

            #if ANY_TEST
                tmpString = null;

                switch (tmpString)
                {
                    case "1":
                    {
                        tmpStringII = "1";
                        break;
                    }
                    default:
                    {
                        tmpStringII = "default";
                        break;
                    }
                }

                //List<int> _listOfInt_;
                //Console.WriteLine("uninitialized {0}= null", _listOfInt_ == null ? "=" : "!"); // Error	31	Use of unassigned local variable '_listOfInt_'

                tmpString = GetHash("1");

                for(var totalCount = 0; totalCount < 7; ++totalCount)
                {
                    var numberOfTasks = 5;

                    if (numberOfTasks > totalCount)
                        numberOfTasks = totalCount;

                    if(numberOfTasks == 0)
                        continue;

                    var batchSize = (int)Math.Ceiling((decimal)totalCount/numberOfTasks);

                    Console.Write("{0}\t{1}\t{2}", numberOfTasks, totalCount, batchSize);

                    Console.Write("\t");

                    for(var i = 0; i < numberOfTasks; ++i)
                        Console.Write("{0}\t", (i*batchSize));

                    Console.WriteLine();
                }

                int[] visit = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

                for (var i = 0; i < visit.Length; ++i)
                {
                    var weekNo = visit[i]/7 + (visit[i]%7 != 0 ? 1 : 0);
                    var dayNo = visit[i] - 7*(weekNo - 1);
                    Console.WriteLine("{0}\t=>\t{1}\t{2}", visit[i], weekNo, dayNo);
                }

                List<string> _keys = new List<string>(new string[] {"1", "2", "3" , "4", "5"});
                int LIMIT = 6;
                int remainder;
                var count = Math.DivRem(_keys.Count, LIMIT, out remainder);

                if (remainder > 0)
                    count++;

                for (var i = 0; i < count; i++)
                {
                    var startIndex = i * LIMIT;
                    var range = _keys.GetRange(startIndex, LIMIT > _keys.Count - startIndex ? _keys.Count - startIndex : LIMIT);
                }
            #endif

            #if TEST_TYPES
                try
                {
                    tmpType = Type.GetType("System.Int32");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                tmpDecimal = 13m;
                tmpObject = tmpDecimal;
                if(tmpObject is decimal)
                    Console.WriteLine("decimal");
                if(tmpObject.GetType() == typeof(decimal))
                    Console.WriteLine("decimal");

                if (Decimal.TryParse(tmpObject.ToString(), out tmpDecimal))
                    tmpString = tmpDecimal.ToString(new NumberFormatInfo() {NumberDecimalSeparator = "."});

                tmpDecimal = 13.13m;
                tmpObject = tmpDecimal;
                if (Decimal.TryParse(tmpObject.ToString(), out tmpDecimal))
                    tmpString = tmpDecimal.ToString(new NumberFormatInfo() { NumberDecimalSeparator = "." });

                tmpLong = 1L;
                tmpObject = tmpLong;
                tmpType = tmpObject.GetType();
                if(tmpType == typeof(long))
                    Console.WriteLine("Int64");
                if(tmpObject is Int64)
                    Console.WriteLine("Int64");

                tmpType = tmpString.GetType();
                if (tmpType == typeof(string))
                    Console.WriteLine("String");
                tmpString = tmpType.Name;
                tmpStringII = tmpType.FullName;

                tmpTypeCode = Type.GetTypeCode(tmpString.GetType());
                if(tmpTypeCode==TypeCode.String)
                    Console.WriteLine("TypeCode.String");
            #endif

            #if TEST_OPERATOR_PRECEDENCE
                // http://msdn.microsoft.com/en-us/library/vstudio/azk8zbxd%28v=vs.110%29.aspx C Sequence Points
                // http://msdn.microsoft.com/en-us/library/vstudio/2bxt6kc4%28v=vs.110%29.aspx Precedence and Order of Evaluation
                tmpBool = true;
                tmpBoolII = true;
                tmpBoolIII = false;

                if ((tmpBool && BF1(tmpBoolII)) || tmpBoolII)
                    BF2(tmpBoolIII);

                tmpBool = false;
                tmpBoolII = true;
                tmpBoolIII = true;

                if (!tmpBool || (tmpBool && tmpBoolII))
                    Console.WriteLine("oB!");

                if (tmpBool && tmpBoolII || tmpBoolIII)
                    // false && false || false == false
                    // false && false || true == true
                    // false && true || false == false
                    // false && true || true == true
                    // true && false || false == false
                    // true && false || true == true
                    // true && true || false == true
                    // true && true || true == true
                    Console.WriteLine("oB!");

                if (tmpBool || tmpBoolII && tmpBoolIII)
                    // false || false && false == false
                    // false || false && true == false
                    // false || true && false == false
                    // false || true && true == true
                    // true || false && false == true
                    // true || false && true == true
                    // true || true && false == true
                    // true || true && true == true
                    Console.WriteLine("oB!");
            #endif

            #if TEST_STRING
                tmpString = string.Join("\r\n", new[] { "Line #1", "Line #2", "Line #3" });
                tmpString = string.Join("\r\n", new[] { "Line #1" });
                tmpString = string.Join("\r\n", new string[0]);

                tmpString = "tmpString.";
                tmpStrings = tmpString.Split('.');

                tmpString = null;
                tmpStringII = null;
                Console.WriteLine("string(null) {0}= string(null)", tmpString == tmpStringII ? "=" : "!"); // ==
                Console.WriteLine("{0}ReferenceEquals(string(null), string(null))", ReferenceEquals(tmpString, tmpStringII) ? "" : "!"); // ReferenceEquals
                tmpStringII = string.Empty;
                Console.WriteLine("string(null) {0}= string(string.Empty)", tmpString == tmpStringII ? "=" : "!"); // !=
                tmpStringII = "";
                Console.WriteLine("string(null) {0}= string(\"\")", tmpString == tmpStringII ? "=" : "!"); // !=

                tmpString = "fileName.ext";
                tmpStringII = ".ext";
                tmpString = tmpString.Remove(tmpString.LastIndexOf(tmpStringII));

                tmpString = "blah-blah-blah";
                tmpStringII = "blah-blah-blah123";
                tmpStringIII = tmpStringII.Substring(tmpString.Length);

                tmpString = null;
                tmpStringII = (string)tmpString;

                tmpObject = null;
                //tmpString = tmpObject.ToString(); // System.NullReferenceException

                tmpStringII = ", ";
                tmpString = "blah-blah-blah" + tmpStringII;
                tmpString = tmpString.Remove(tmpString.Length - tmpStringII.Length);

                tmpString = "AAA";
                tmpStringII = tmpString;
                Console.WriteLine(object.ReferenceEquals(tmpString, tmpStringII)); // True
                tmpString = "BBB";
                Console.WriteLine("tmpStringII=" + tmpStringII); // AAA
                Console.WriteLine("tmpString=" + tmpString); // BBB
                Console.WriteLine(object.ReferenceEquals(tmpString, tmpStringII)); // False
                tmpString = "mystr";
                tmpStringII = "mystr";
                Console.WriteLine(object.ReferenceEquals(tmpString, tmpStringII)); // True

                // http://blogs.msdn.com/b/ruericlippert/archive/2009/09/28/string-empty.aspx Если у вас есть два идентичных строковых литерала в одной единице компиляции, то код, который мы генерируем, гарантирует, что только один объект строки создаётся CLR для всех экземпляров этого литерала в пределах сборки. Эта оптимизация называется «интернированием строк».
                tmpObject = "Int32";
                tmpString = "Int32";
                tmpStringII = typeof(int).Name;
                Console.WriteLine(tmpObject == tmpString); // true Warning	15	Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'string' «возможно непреднамеренное сравнение ссылок»
                Console.WriteLine(tmpString == tmpStringII); // true
                Console.WriteLine(tmpObject == tmpStringII); // false !? Warning	15	Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'string' «возможно непреднамеренное сравнение ссылок»

                tmpString = null;
                tmpObject = tmpString;
                Console.WriteLine(tmpObject == null);

                tmpString = "";
                tmpObject = tmpString;
                Console.WriteLine(tmpObject == null);

                tmpObject = "";
                tmpString = "";
                tmpStringII = string.Empty;
                Console.WriteLine(tmpObject == tmpString); // true Warning	15	Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'string' «возможно непреднамеренное сравнение ссылок»
                Console.WriteLine(tmpString == tmpStringII); // true
                Console.WriteLine(tmpObject == tmpStringII); // иногда true, иногда false !? Warning	15	Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'string' «возможно непреднамеренное сравнение ссылок»
            #endif

            #if TEST_INITIALIZATION
                int
                    idx;

                int[]
                    arr = new int[10];

                arr[idx=3] = foo(idx);
                //arr[idx] = foo(idx = 5); // Use of unassigned local variable 'idx'

                for (int i = 0; i < arr.Length; ++i)
                    Console.WriteLine("[{0}]={1}", i, arr[i]); 
            #endif

            #if TEST_STRUCT
                TestStruct
                    a, b;

                a.a = 1;
                a.b = 11;
                b.a = 2;
                b.b = 22;
                Console.WriteLine("{0},{1},{2},{3}", a.a, a.b, b.a, b.b);
                a = b;
                Console.WriteLine("{0},{1},{2},{3}", a.a, a.b, b.a, b.b);
                b.b = 33;
                Console.WriteLine("{0},{1},{2},{3}", a.a, a.b, b.a, b.b);

                TestClass
                    aa = new TestClass(),
                    bb = new TestClass();

                aa.a = 1;
                aa.b = 11;
                bb.a = 2;
                bb.b = 22;
                Console.WriteLine("{0},{1},{2},{3}", aa.a, aa.b, bb.a, bb.b);
                aa = bb;
                Console.WriteLine("{0},{1},{2},{3}", aa.a, aa.b, bb.a, bb.b);
                bb.b = 33;
                Console.WriteLine("{0},{1},{2},{3}", aa.a, aa.b, bb.a, bb.b);
            #endif

            #if TEST_ARRAY
                int[]
                    AI = new int[] { 1, 2, 3 };

                SetArray(AI, 10);

                for (int i = 0; i < AI.Length; ++i)
                    Console.WriteLine(AI[i]);

                SetArray(ref AI, 100);
                for (int i = 0; i < AI.Length; ++i)
                    Console.WriteLine(AI[i]);
            #endif

            #if TEST_AD
                TestAD();
            #endif

            #if TEST_PARAMS
                tmpInt = FuncWithParams("string", DateTime.Now, 1, 2, 3, 4, 5);
                tmpInt = FuncWithParams("string", DateTime.Now, new int[] {1, 2, 3, 4, 5});
                //tmpInt = FuncWithoutParams("string", DateTime.Now, 1, 2, 3, 4, 5); // No overload for method 'FuncWithoutParams' takes '7' arguments
                tmpInt = FuncWithoutParams("string", DateTime.Now, new int[] { 1, 2, 3, 4, 5 });
                tmpInt = FuncWithParams();
                tmpInt = FuncWithParams(null);
                DisplayTypes(new Object(), new Random(), "string", 5);
            #endif

            #if TEST_THERMO
                TestThermo();
            #endif

			#if TEST_DATE_TIME
                tmpDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                tmpDateTimeI = tmpDateTime.AddMilliseconds(1456272000000);

                tmpDateTime = DateTime.Now;
                tmpDateTimeI = DateTime.UtcNow;

                var tz = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
                tmpDateTime = TimeZoneInfo.ConvertTime(tmpDateTime, tz);

                tmpObject = Convert.ChangeType("8.906", typeof(DateTime));
                if (tmpObject != null)
                    tmpDateTime = (DateTime)tmpObject;

                try
                {
                    tmpObject = null;
                    tmpDateTime = (DateTime)tmpObject;
                }
                catch (NullReferenceException eException)
                { 
                    Console.WriteLine(eException.Message);
                }

                tmpDateTime = DateTime.Now;
                DateTime.TryParse("0.55084490740740744", out tmpDateTime); // 01.01.0001 00:00:00
                tmpDateTimeI = DateTime.FromOADate(0.55084490740740744); // 30.12.1899 13:13:13

                tmpObject = Convert.ChangeType("8.906", typeof(DateTime));
                if (tmpObject != null)
                    tmpDateTime = (DateTime)tmpObject;

                tmpBool = DateTime.TryParse("8-906", out tmpDateTimeI);

                tmpString = string.Format("DateTimeFormatInfo.CurrentInfo.ShortDatePattern: \"{0}\"", DateTimeFormatInfo.CurrentInfo.ShortDatePattern);
                tmpString = string.Format("System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern: \"{0}\" ({1}) {2}", Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern, Thread.CurrentThread.CurrentCulture.Name, Thread.CurrentThread.ManagedThreadId);

                var currentInfo = DateTimeFormatInfo.CurrentInfo;

                tmpString = DateTime.Now.ToShortDateString();

                tmpDateTime = new DateTime(1899, 12, 31);
                tmpDateTimeI = tmpDateTime.AddDays(39800);
                tmpDateTimeI = tmpDateTime.AddDays(41728);

                tmpDateTime = new DateTime(1900, 1, 1);
                tmpDateTimeI = tmpDateTime.AddDays(39800);
                tmpDateTimeI = tmpDateTime.AddDays(41728);

                tmpDateTime = new DateTime(1900, 1, 1, 13, 13, 13);
                tmpDateTimeI = new DateTime(1900, 1, 1);

                Console.WriteLine("{0} {1}= {2}", tmpDateTime, tmpDateTime.Date==tmpDateTimeI ? "=" : "!", tmpDateTimeI);
                Console.WriteLine("{0} {1}= {2}", tmpDateTime, tmpDateTime.TimeOfDay==TimeSpan.Zero ? "=" : "!", TimeSpan.Zero);
                Console.WriteLine("{0} {1}= {2}", tmpDateTimeI, tmpDateTimeI.TimeOfDay == TimeSpan.Zero ? "=" : "!", TimeSpan.Zero);

                tmpObject = null;
                tmpDateTimeNullable = (DateTime?) tmpObject;
                tmpDateTimeNullableII = null;

                Console.WriteLine("tmpDateTimeNullable {0}= tmpDateTimeNullableII", tmpDateTimeNullable==tmpDateTimeNullableII ? "=" : "!");

                tmpDateTimeNullable = DateTime.Now;
                Console.WriteLine("tmpDateTimeNullable {0}= tmpDateTimeNullableII", tmpDateTimeNullable == tmpDateTimeNullableII ? "=" : "!");

                tmpDateTime = DateTime.FromOADate(0.5625);

                tmpDateTimeI = new DateTime(1, 1, 1, 13, 13, 13);
                tmpTimeSpan = new TimeSpan(tmpDateTimeI.Hour, tmpDateTimeI.Minute, tmpDateTimeI.Second);    
                tmpDateTime = DateTime.Now;
                tmpDateTime = tmpDateTime.Date + tmpTimeSpan;
                tmpDateTime = DateTime.Now;
                tmpDateTime = tmpDateTime.Date.Add(tmpTimeSpan);
                tmpTimeSpan = tmpDateTimeI.TimeOfDay;
                tmpDateTime = DateTime.Now;
                tmpDateTime = tmpDateTime.Date.Add(tmpTimeSpan);

				tmpDateTime = new DateTime(2011, 8, 5, 13, 0, 0);
				tmpDateTimeI = new DateTime(2011, 8, 5, 13, 1, 0);
				tmpTimeSpan = tmpDateTimeI - tmpDateTime;
				tmpInt = tmpTimeSpan.Minutes;
				tmpTimeSpan = tmpDateTime - tmpDateTimeI;
				tmpInt = tmpTimeSpan.Minutes;

				tmpDateTime = new DateTime(2011, 8, 5, 13, 0, 0);
				tmpDateTimeI = new DateTime(2011, 8, 5, 14, 0, 0);
				tmpTimeSpan = tmpDateTimeI - tmpDateTime;
				tmpDouble = tmpTimeSpan.TotalMinutes;
				tmpTimeSpan = tmpDateTime - tmpDateTimeI;
				tmpDouble = tmpTimeSpan.TotalMinutes;

				tmpDateTime = new DateTime(2011, 7, 27);
				tmpDateTime = tmpDateTime.AddDays(-7750);
				tmpDateTime = new DateTime(2011, 7, 27);
				tmpDateTime = tmpDateTime.AddDays(-7479);

                tmpString = "2012-03-01 00:00:00+05:00";
                tmpDateTime = DateTime.Parse(tmpString);
                tmpDateTimeOffset = DateTimeOffset.Parse(tmpString);
                tmpString = tmpDateTime.ToString("o");
                if (tmpDateTime.Date != tmpDateTimeOffset.Date)
                    tmpString = string.Format("{0:dd.MM.yyyy} {1:dd.MM.yyyy}", tmpDateTime, tmpDateTimeOffset);

                tmpDateTime = new DateTime(2005, 10, 10, 11, 53, 38);
                tmpDateTimeI = DateTime.Now.Date;
                tmpInt = (tmpDateTimeI - tmpDateTime).Days;
                tmpDouble = (tmpDateTimeI - tmpDateTime).TotalDays;

                tmpDateTime = new DateTime(2005, 10, 10);
                tmpDateTimeI = DateTime.Now.Date;
                tmpInt = (tmpDateTimeI - tmpDateTime).Days;
                tmpDouble = (tmpDateTimeI - tmpDateTime).TotalDays;

                tmpDateTime = new DateTime(2005, 10, 10, 11, 53, 38);
                tmpDateTimeI = DateTime.Now.Date;
                tmpInt = (tmpDateTimeI - tmpDateTime).Days % (1 * 7) + 1;

                tmpDateTime = new DateTime(2005, 10, 10);
                tmpDateTimeI = DateTime.Now.Date;
                tmpInt = (tmpDateTimeI - tmpDateTime).Days % (1 * 7) + 1;
			#endif

			#if TEST_SPLIT
				tmpString = "0;1;2;3;4;5";
				tmpStrings = tmpString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string s in tmpStrings)
					Console.WriteLine("\"{0}\"", s);

				tmpString = "0;1;2;3;4;5;";
				tmpStrings = tmpString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
				foreach (string s in tmpStrings)
					Console.WriteLine("\"{0}\"", s);

				tmpStringII = "{0} {1} {2} {3} {4} {0}";
				for (int i = 0; i < tmpStrings.Length; ++i)
				{
					tmpString = string.Format("{{{0}}}", i);
					tmpStringII = tmpStringII.Replace(tmpString, tmpStrings[i]);
				}
			#endif

			#if TEST_ENUM
				tmpStrings=Enum.GetNames(typeof(TestEnum));

				TestEnum
					TestEnum;

				foreach(string str in tmpStrings)
					TestEnum=(TestEnum)Enum.Parse(typeof(TestEnum),str);

				TestEnum = (TestEnum)13;
                Console.WriteLine("TestEnum=\"{0}\" TestEnum.ToString()=\"{1}\"", TestEnum, TestEnum.ToString());
				TestEnum = (TestEnum)14;
				Console.WriteLine("{0}{1}{2}", TestEnum.ToString(), TestEnum > TestEnum.Fifteen ? ">" : "<=", TestEnum.Fifteen.ToString());

                Console.WriteLine((double)SmthEnum.Second);
                Console.WriteLine((int)TestEnum.Zero);

                SmthEnum
                    smthEnum;

                smthEnum = (SmthEnum)Enum.Parse(typeof(SmthEnum), "First");
                smthEnum = (SmthEnum)0L;
			#endif

			#if TEST_GET_STRING
				bytes = new byte[] { 0x53, 0x4d, 0x0 };

				tmpString = Encoding.ASCII.GetString(bytes, 0, 3);
				tmpStringII = Encoding.ASCII.GetString(bytes, 0, 2);

				Console.WriteLine("{1}{0}{2}", Environment.NewLine, tmpString.Length, tmpStringII.Length);
			#endif

			#if TEST_BIG_ENDIAN
				tmpString = "Тест";

				bytes = Encoding.ASCII.GetBytes(tmpString);
				Console.WriteLine(bytes.Length);

				bytes = Encoding.UTF7.GetBytes(tmpString);
				Console.WriteLine(bytes.Length);

				bytes = Encoding.UTF8.GetBytes(tmpString);
				Console.WriteLine(bytes.Length);

				bytes = Encoding.UTF32.GetBytes(tmpString);
				Console.WriteLine(bytes.Length);

				bytes = Encoding.Unicode.GetBytes(tmpString);
				Console.WriteLine(bytes.Length);

				bytes = Encoding.BigEndianUnicode.GetBytes(tmpString);
				Console.WriteLine(bytes.Length);
			#endif

			#if TEST_BIT_OPERATIONS
				tmpLong = 5;
				tmpLong |= 2;
				tmpLong ^= 1;
				tmpLong = 7;
				tmpLong ^= 2;

				tmpBool = false;
				tmpBool &= true;
				tmpBool = true;
				tmpBool &= false;

				tmpBool = false;
				tmpBool |= true;
				tmpBool |= false;

				tmpInt = 13 ^ 0x59C771CD; // 1011001110001110111000111001101b
				tmpInt = tmpInt ^ 0x59C771CD;
			#endif

			#if TEST_TRY_PARSE
                Console.WriteLine("CultureInfo.CurrentCulture.Name={0}\r\nCultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator=\"{1}\"", CultureInfo.CurrentCulture.Name, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                tmpString = null;
                bool.TryParse(tmpString, out tmpBool);

                tmpString = string.Empty;
                bool.TryParse(tmpString, out tmpBool);

                tmpString = "true";
                bool.TryParse(tmpString, out tmpBool);

                tmpString = "tRuE";
                bool.TryParse(tmpString, out tmpBool);

                tmpString = "blah-blah-blah";
				tmpLong = long.MinValue;
				long.TryParse(tmpString, out tmpLong);

				tmpString = null;
				tmpLong = long.MinValue;
				long.TryParse(tmpString, out tmpLong);

				tmpString = "9:00";
				tmpString = "blah-blah-blah";
				TimeSpan.TryParse(tmpString, out tmpTimeSpan);

				tmpDateTime = DateTime.Now;
				Console.WriteLine("{0}{1}{2}", tmpDateTime.TimeOfDay, tmpDateTime.TimeOfDay > tmpTimeSpan ? ">" : "<=", tmpTimeSpan);

				tmpString = "23:59:59";
				TimeSpan.TryParse(tmpString, out tmpTimeSpan);
				Console.WriteLine("{0}{1}{2}", tmpDateTime.TimeOfDay, tmpDateTime.TimeOfDay > tmpTimeSpan ? ">" : "<=", tmpTimeSpan);

                if (DateTime.TryParse(null, out tmpDateTime))
                    Console.WriteLine("\"{0}\" -> {1} ({2})", tmpString, tmpDateTime, tmpDateTime.Kind);
                else
                    Console.WriteLine("Unable to parse \"null\"");

                tmpString = "";
                if (DateTime.TryParse(tmpString, out tmpDateTime))
                    Console.WriteLine("\"{0}\" -> {1} ({2})", tmpString, tmpDateTime, tmpDateTime.Kind);
                else
                    Console.WriteLine("Unable to parse \"{0}\"", tmpString);

				tmpString = "04.08.2011 10:20";
				if(DateTime.TryParse(tmpString, out tmpDateTime))
					Console.WriteLine("\"{0}\" -> {1} ({2})", tmpString, tmpDateTime, tmpDateTime.Kind);
				else
					Console.WriteLine("Unable to parse \"{0}\"", tmpString);

				tmpString = "12/31/2011 10:20 am";
				if (DateTime.TryParse(tmpString, out tmpDateTime))
					Console.WriteLine("\"{0}\" -> {1} ({2})", tmpString, tmpDateTime, tmpDateTime.Kind);
				else
					Console.WriteLine("Unable to parse \"{0}\"", tmpString);

				if (DateTime.TryParse(tmpString, CultureInfo.CreateSpecificCulture("en-US"), DateTimeStyles.None, out tmpDateTime))
					Console.WriteLine("\"{0}\" -> {1} ({2})", tmpString, tmpDateTime, tmpDateTime.Kind);
				else
					Console.WriteLine("Unable to parse \"{0}\"", tmpString);

                tmpString = "2011-12-31";
                if (DateTime.TryParse(tmpString, out tmpDateTime))
                    Console.WriteLine("\"{0}\" -> {1} ({2})", tmpString, tmpDateTime, tmpDateTime.Kind);
                else
                    Console.WriteLine("Unable to parse \"{0}\"", tmpString);

				tmpString = "2011-12-31T23:59:59+03:00";
				if (DateTime.TryParse(tmpString, out tmpDateTime))
					Console.WriteLine("\"{0}\" -> {1} ({2})", tmpString, tmpDateTime, tmpDateTime.Kind);
				else
					Console.WriteLine("Unable to parse \"{0}\"", tmpString);

                tmpString = "0.5625";
                if(double.TryParse(tmpString, out tmpDouble))
                    Console.WriteLine("\"{0}\" -> {1}", tmpString, tmpDouble);
                else
                    Console.WriteLine("Unable to parse \"{0}\"", tmpString);

                if (double.TryParse(tmpString, NumberStyles.Any, CultureInfo.InvariantCulture, out tmpDouble))
                    Console.WriteLine("\"{0}\" -> {1}", tmpString, tmpDouble);
                else
                    Console.WriteLine("Unable to parse \"{0}\"", tmpString);

                tmpString = "0,5625";
                if (double.TryParse(tmpString, out tmpDouble))
                    Console.WriteLine("\"{0}\" -> {1}", tmpString, tmpDouble);
                else
                    Console.WriteLine("Unable to parse \"{0}\"", tmpString);

                tmpString = "1.1000000000000001";
                if (double.TryParse(tmpString, NumberStyles.Any, CultureInfo.InvariantCulture, out tmpDouble))
                    Console.WriteLine("\"{0}\" -> {1}", tmpString, tmpDouble);
                else
                    Console.WriteLine("Unable to parse \"{0}\"", tmpString);

                tmpObject = tmpString;
                if (double.TryParse(tmpStringII=tmpObject.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out tmpDouble))
                    Console.WriteLine("\"{0}\" -> {1}", tmpString, tmpDouble);
                else
                    Console.WriteLine("Unable to parse \"{0}\"", tmpString);
			#endif

			#if TEST_ASSERT
				tmpObject = null;
				Debug.Assert(tmpObject == null, "tmpObject!=null");
				Debug.Assert(tmpObject != null, "tmpObject==null"); // fire

				tmpObject = 1;
				Debug.Assert(tmpObject == null, "tmpObject!=null"); // fire
				Debug.Assert(tmpObject != null, "tmpObject==null");
			#endif

			#if TEST_NULLABLE_TYPES
                int?
                    tmpIntNullableI = null,
                    tmpIntNullableII = null;

                Console.WriteLine("int?(null) {0}= int?(null)", tmpIntNullableI == tmpIntNullableII ? "=" : "!"); // true ==

                tmpIntNullableI = 1;
                Console.WriteLine("int?(1) {0}= int?(null)", tmpIntNullableI == tmpIntNullableII ? "=" : "!"); // false !=

                tmpIntNullableI = null;
                tmpIntNullableII = 1;
                Console.WriteLine("int?(null) {0}= int?(1)", tmpIntNullableI == tmpIntNullableII ? "=" : "!"); // false !=

                tmpIntNullableI = 1;
                tmpIntNullableII = 1;
                Console.WriteLine("int?(1) {0}= int?(1)", tmpIntNullableI == tmpIntNullableII ? "=" : "!"); // true ==

                tmpObject = null;
                tmpLongNullable = Convert.ToInt64(tmpObject); // 0
                tmpLongNullable = (long?)tmpObject; // null
                tmpInt = 1;
                tmpObject = tmpInt;
                tmpLongNullable = tmpObject as long?; // null
                //tmpLongNullable = (long?)tmpObject; // InvalidCastException
                tmpLongNullable = (long?)Convert.ToInt64(tmpObject);

                // http://weblogs.asp.net/grantbarrington/archive/2009/03/17/using-reflection-to-determine-whether-an-type-is-nullable-and-get-the-underlying-type.aspx

                tmpType = typeof(DateTime?);
                if (tmpType.IsGenericType)
                {
                    tmpTypeII = tmpType.GetGenericTypeDefinition();
                    if (tmpTypeII == typeof (Nullable<>))
                    {
                        tmpTypeIII = Nullable.GetUnderlyingType(tmpType);
                        tmpTypes = tmpType.GetGenericArguments();
                    }
                }
                
                Guid?
                    guid_nullable=null;

                if(!guid_nullable.HasValue)
                    guid_nullable=new Guid();

                if (guid_nullable.Value == Guid.Empty)
                    guid_nullable = Guid.NewGuid();

				int?
					i_nullable = null,
					y_nullable;

				tmpString = i_nullable.HasValue.ToString().ToLower(); // false
				//tmpString = y_nullable.HasValue.ToString().ToLower(); // Error: Use of unassigned local variable 'y_nullable'

				tmpInt = i_nullable ?? int.MinValue; // int.MinValue
				tmpInt = i_nullable ?? default(int); // 0
				tmpInt = i_nullable.GetValueOrDefault(); // 0
				if (i_nullable.HasValue)
					tmpInt = i_nullable.Value;

				//i = y_nullable ?? int.MinValue; // Error: Use of unassigned local variable 'y_nullable'
				//i = y_nullable ?? default(int); // Error: Use of unassigned local variable 'y_nullable'
				//i = y_nullable.GetValueOrDefault(); // Error: Use of unassigned local variable 'y_nullable'

				i_nullable = 123456789;
				tmpString = i_nullable.HasValue.ToString().ToLower(); // true
				tmpInt = i_nullable ?? int.MinValue;
				tmpInt = i_nullable ?? default(int);
				tmpInt = i_nullable.GetValueOrDefault();
				if (i_nullable.HasValue)
					tmpInt = i_nullable.Value;

				int
					tmpTmpInt;

				i_nullable = null;
				tmpTmpInt = 10;
				tmpInt = tmpTmpInt + i_nullable ?? 0;
				tmpInt = i_nullable ?? 0 + tmpTmpInt;
				tmpInt = tmpTmpInt + (i_nullable ?? 0);
				tmpInt = (i_nullable ?? 0) + tmpTmpInt;
				tmpObject = tmpTmpInt + i_nullable;

				DateTime?
					NullableDateTime1,
					NullableDateTime2;

                tmpObject = null;
                NullableDateTime1 = tmpObject as DateTime?;
                tmpDateTime = NullableDateTime1.HasValue ? NullableDateTime1.Value : new DateTime(2014, 3, 11);
                tmpDateTimeI = NullableDateTime1 ?? new DateTime(2014, 3, 12);

                tmpObject = new DateTime(2014, 3, 13);
                NullableDateTime1 = tmpObject as DateTime?;
                tmpDateTime = NullableDateTime1.HasValue ? NullableDateTime1.Value : new DateTime(2014, 3, 11);
                tmpDateTimeI = NullableDateTime1 ?? new DateTime(2014, 3, 12);

				NullableDateTime1 = null;
				NullableDateTime2 = null;
				Console.WriteLine("NullableDateTime1==NullableDateTime2: {0}", NullableDateTime1 == NullableDateTime2);
                tmpString = string.Format("{0:D}", NullableDateTime1);
                tmpString = string.Format("{0:d}", NullableDateTime1);

				NullableDateTime1 = null;
				NullableDateTime2 = DateTime.Now;
				Console.WriteLine("NullableDateTime1==NullableDateTime2: {0}", NullableDateTime1 == NullableDateTime2);

				NullableDateTime1 = DateTime.Now;
				NullableDateTime2 = null;
				Console.WriteLine("NullableDateTime1==NullableDateTime2: {0}", NullableDateTime1 == NullableDateTime2);
                tmpString = string.Format("{0:D}", NullableDateTime1);
                tmpString = string.Format("{0:d}", NullableDateTime1);

				NullableDateTime1 = NullableDateTime2 = DateTime.Now;
				Console.WriteLine("NullableDateTime1==NullableDateTime2: {0}", NullableDateTime1 == NullableDateTime2);
			#endif

			#if TEST_CONVERT
                try
                {
                    tmpInt = Convert.ToInt32((1L + int.MaxValue).ToString());
                }
                catch (Exception eException)
                {
                    Console.WriteLine("Значение было недопустимо малым или недопустимо большим для Int32. ({0}: {1})", eException.GetType().FullName, eException.Message);
                }

				try
				{
					tmpString = Convert.ToString(null); // oB! tmpString == null
				}
				catch (Exception eException)
				{
					Console.WriteLine("Unable to convert null to a String. ({0}: {1})", eException.GetType().FullName, eException.Message);
				}

				try
				{
					tmpString = Convert.ToString(DBNull.Value); // oB! tmpString == ""
				}
				catch (Exception eException)
				{
					Console.WriteLine("Unable to convert DBNull.Value to a String. ({0}: {1})", eException.GetType().FullName, eException.Message);
				}

                #region ToBoolen
   				try { tmpBool = Convert.ToBoolean(tmpString = null); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }     // oB!
				try { tmpBool = Convert.ToBoolean(tmpString = ""); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }       // FormatException
                try { tmpBool = Convert.ToBoolean(tmpString = "0"); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }      // FormatException
                try { tmpBool = Convert.ToBoolean(tmpString = "1"); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }      // FormatException
                try { tmpBool = Convert.ToBoolean(tmpString = "true"); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }   // oB!
                try { tmpBool = Convert.ToBoolean(tmpString = "false"); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }  // oB!
                try { tmpBool = Convert.ToBoolean(tmpString = "TrUe"); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }   // oB!
                try { tmpBool = Convert.ToBoolean(tmpString = "FaLsE"); } catch (FormatException) { Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString); }  // oB!
                #endregion

                tmpInt = int.MinValue;
                tmpString = "blah-blah-blah";
                int.TryParse(tmpString, out tmpInt);
                if(tmpInt==default(int))
                    Console.WriteLine("Unable to convert \"{0}\" to a int.", tmpString);

				try
				{
					tmpString = DateTime.Now.ToString("o");
					tmpDateTime = Convert.ToDateTime(tmpString);

					tmpDateTime = DateTime.Now;
					tmpString = "2010-02-31T00:00:00";
					DateTime.TryParse(tmpString, out tmpDateTime);
                    if(tmpDateTime==default(DateTime))
                        Console.WriteLine("Unable to convert \"{0}\" to a DateTime.", tmpString);

                    try
                    {
                        tmpString = "2010-10-06T00:00:00";
                        tmpDateTime = DateTime.Parse(tmpString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal);
                        tmpDateTime = DateTime.ParseExact(tmpString, "O", System.Globalization.CultureInfo.InvariantCulture);
                        if (!DateTime.TryParse(tmpString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out tmpDateTime))
                            Console.WriteLine("Unable to convert \"{0}\" to a DateTime.", tmpString);

                        tmpString = "2010-11-06T00:00:00";
                        tmpDateTime = DateTime.Parse(tmpString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal);
                        tmpDateTime = DateTime.ParseExact(tmpString, "O", System.Globalization.CultureInfo.InvariantCulture);
                        if (!DateTime.TryParse(tmpString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out tmpDateTime))
                            Console.WriteLine("Unable to convert \"{0}\" to a DateTime.", tmpString);
                    }
                    catch (Exception eException)
                    {
                        Console.WriteLine("Unable to convert \"{2}\" to a DateTime. ({0}: {1})", eException.GetType().FullName, eException.Message, tmpString);
                    }

				    tmpString = "2012-02-29 23:59:59";
                    if(!DateTime.TryParse(tmpString,out tmpDateTime))
                        Console.WriteLine("Unable to convert \"{0}\" to a DateTime.", tmpString);
                    if (!DateTime.TryParse(tmpString, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out tmpDateTime))
                        Console.WriteLine("Unable to convert \"{0}\" to a DateTime.", tmpString);
                }
				catch (Exception eException)
				{
					Console.WriteLine("Unable to convert \"{2}\" to a DateTime. ({0}: {1})", eException.GetType().FullName, eException.Message, tmpString);
				}
			#endif

			#if TEST_YIELD
				foreach (int i in Power(2, 8))
					Console.Write("{0} ", i);
                Console.WriteLine();

                A
                    l0 = new A("level #0"),
                    l1 = new A("level #1", l0),
                    l2 = new A("level #2", l1),
                    l3 = new A("level #3", l2),
                    arg;

                arg = l3;

                List<A> parents = GetParents(arg).ToList();
                parents.ForEach(a => Console.WriteLine(a.Level));

                parents = GetParentsII(arg).ToList();
                parents.ForEach(a => Console.WriteLine(a.Level));
			#endif

			#if TEST_FORMAT
                objects = new[] { (object)1, 2, 3 };
                tmpString = string.Format("{0} {1} {2}", objects);
                var listOfObject = new List<object> { 11, 22, 33 };
                tmpString = string.Format("{0} {1}", listOfObject.ToArray());

                tmpTimeSpan = new TimeSpan(1, 2, 3, 4, 5);
                tmpString = tmpTimeSpan.ToString();

                tmpDecimal = 1.123456789010000m;
                tmpObject = tmpDecimal;
                tmpString = tmpObject.ToString();
                tmpString = string.Format("{0:n}", tmpDecimal);

                tmpDecimal = 111111.9m;
                tmpString = string.Format("{0:### ###0}", tmpDecimal);
                tmpDecimal = 1.9m;
                tmpString = string.Format("{0:### ###0}", tmpDecimal);

                tmpString = string.Format("{{{{\"{0}\": \"{{0}}\"}}}}", "Code");
                tmpStringII = string.Format(tmpString, "0123456789");
                Console.WriteLine(tmpStringII);

                tmpDecimal = 18m;
                tmpString = string.Format("{0:p}", tmpDecimal);
                tmpString = string.Format("{0:P}", tmpDecimal);
                tmpString = string.Format("{0:p4}", tmpDecimal);
                tmpString = string.Format("{0:P4}", tmpDecimal);
                tmpString = string.Format("{0:####,0.00%}", tmpDecimal);
                tmpString = string.Format("{0:####,0.00%%}", tmpDecimal);

                tmpString = "Ru\\s\\sian Alco\\hol - Pilo\\t Januar\\y\\/uploa\\d\\/yyyy-MM-dd\\/yyyy-MM-dd";
                tmpStringII = DateTime.Now.ToString(tmpString);    

                tmpStringII = null;
                tmpString = string.Format("{0}", tmpStringII);

				tmpDateTime = DateTime.Now;
                tmpString = string.Format("{0:O}", tmpDateTime); // "2016-03-01T12:37:59.5813583+02:00"
                tmpString = string.Format("{0:o}", tmpDateTime); // "2016-03-01T12:37:59.5813583+02:00"
                tmpString = string.Format("{0:s}", tmpDateTime); // "2016-03-01T12:41:06"
                tmpString = string.Format("{0:D}", tmpDateTime);
                tmpString = string.Format("{0:d}", tmpDateTime);
                tmpString = tmpDateTime.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
                tmpString = tmpDateTime.ToShortDateString();
				tmpString = string.Format("{0:dd.MM.yyyy}", tmpDateTime);
                tmpString = string.Format("{0:dd.MM.yyyy HH:mm:ss.fffffff}", tmpDateTime);
				tmpTimeSpan = DateTime.Now.TimeOfDay;
				tmpString = string.Format("{0:d2}:{1:d2}", tmpTimeSpan.Hours, tmpTimeSpan.Minutes);

				tmpDateTime = DateTime.Now;
				tmpDateTime = DateTime.MinValue;
				tmpString = tmpDateTime.ToString("dd/MM/yy");
				tmpString = tmpDateTime.ToString("dd/MM/yyyy");

                tmpDouble = 9223372036854775807L;
                tmpString = tmpDouble.ToString();
                tmpString = tmpDouble.ToString("###################");
                tmpString = string.Format("{0:###################}", tmpDouble);

                tmpLong = 9223372036854775807L;
                tmpString = tmpLong.ToString();
                tmpString = tmpLong.ToString("D");
                tmpString = string.Format("{0:D}", tmpLong);

				tmpInt = 1;

				tmpString = string.Format("{0:x4}",tmpInt);
				tmpString = string.Format("{0:X4}", tmpInt);
				tmpString = tmpInt.ToString("x4");
				tmpString = tmpInt.ToString("X4");
				tmpString = tmpInt.ToString("D2");
				tmpString = tmpInt.ToString("#,###");
				tmpString = tmpInt.ToString("{0:#,###0}");
				tmpString = string.Format("#,###", tmpInt);
				tmpString = string.Format("{0:#,###0}", tmpInt);
				tmpInt = 0x0fffffff;
				tmpString = tmpInt.ToString("d");
				tmpString = tmpInt.ToString("D");
				tmpString = tmpInt.ToString("n");
				tmpString = tmpInt.ToString("N");
				tmpString = tmpInt.ToString("g");
				tmpString = tmpInt.ToString("G");
				tmpString = tmpInt.ToString("#,###");
				tmpString = tmpInt.ToString("{0:#,###0}");
				tmpString = string.Format("#,###", tmpInt);
				tmpString = string.Format("{0:#,###0}", tmpInt);

				tmpDecimal = 0.88m;
				tmpString = tmpDecimal.ToString("#.00");
				tmpString = tmpDecimal.ToString("#0.00");

				tmpDecimal = 88m;
				tmpString = tmpDecimal.ToString("#.00");

				tmpDouble = 0.88;
				tmpString = tmpDouble.ToString("#.00");
				tmpString = tmpDouble.ToString("#0.00");

				tmpDouble = 88;
				tmpString = tmpDouble.ToString("#.00");
				tmpString = tmpDouble.ToString("#0.00");

				tmpDecimal = 1.5m;
				//tmpString=tmpDecimal.ToString("p");
				tmpString = tmpDecimal.ToString("#%");

				tmpDouble = 1.5;
				//tmpString=tmpDouble.ToString("p");
				tmpString = tmpDouble.ToString("#.00%");

				tmpDecimal = 8123456789.2225m;
				tmpString = tmpDecimal.ToString();
				tmpString = tmpDecimal.ToString("F");
				tmpString = tmpDecimal.ToString("F6");
				tmpString = Convert.ToString(tmpDecimal);
				tmpDecimal = 0.0000002225m;
				tmpString = tmpDecimal.ToString();
				tmpString = tmpDecimal.ToString("F");
				tmpString = tmpDecimal.ToString("F6");
				tmpString = Convert.ToString(tmpDecimal);

				tmpDouble = 8123456789.2225;
				tmpString = tmpDouble.ToString();
				tmpString = tmpDouble.ToString("F");
				tmpString = tmpDouble.ToString("F6");
				tmpString = Convert.ToString(tmpDouble);
				tmpDouble = 0.00002225;
				tmpString = tmpDouble.ToString();
				tmpString = tmpDouble.ToString("F");
				tmpString = tmpDouble.ToString("F6");
				tmpString = Convert.ToString(tmpDouble); 
			#endif

			#if TEST_PATH
                Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

                tmpString = System.Reflection.Assembly.GetCallingAssembly().GetName() + " " + System.Reflection.Assembly.GetCallingAssembly().Location;
                Console.WriteLine(tmpString);
                Console.WriteLine(Directory.GetCurrentDirectory());
                tmpString = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
				tmpString = System.Reflection.Assembly.GetExecutingAssembly().Location;
				Console.WriteLine(Path.GetDirectoryName(tmpString));
				Console.WriteLine(Path.GetExtension(tmpString));
				Console.WriteLine(Path.GetFileName(tmpString));
				Console.WriteLine(Path.GetFileNameWithoutExtension(tmpString));
				Console.WriteLine(Path.GetFullPath(tmpString));
				Console.WriteLine(Path.GetPathRoot(tmpString));
				Console.WriteLine(Path.ChangeExtension(tmpString,".pdf"));
				tmpString = Path.GetDirectoryName(tmpString) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(tmpString);
				Console.WriteLine(Path.GetRandomFileName());
				Console.WriteLine(Path.GetTempFileName());
				Console.WriteLine(Path.GetTempPath());
				Console.WriteLine(Environment.CurrentDirectory);
                tmpString = Path.GetDirectoryName("aaa.txt"); // ""
                tmpStringII = Path.GetDirectoryName("bbb.txt"); // ""
                Console.WriteLine(string.Equals(tmpString, tmpStringII, StringComparison.InvariantCultureIgnoreCase) ? "string.Equals" : "!string.Equals"); // string.Equals
                tmpString = Path.GetFileName("c:\\aaa\\bbb"); // bbb
                tmpString = Path.GetFileName("c:\\aaa\\bbb\\"); // ""
                tmpString = Path.GetDirectoryName("\\\\i-nozhenko\\exchange\\PhotoReports\\TestImageI.jpg"); // \\i-nozhenko\exchange\PhotoReports
                tmpString = Path.GetPathRoot("\\\\i-nozhenko\\exchange\\PhotoReports\\TestImageI.jpg"); // \\i-nozhenko\exchange
                tmpString = Path.GetFullPath("\\\\i-nozhenko\\exchange\\PhotoReports\\TestImageI.jpg"); // \\i-nozhenko\exchange\PhotoReports\TestImageI.jpg
                tmpString = "http://89.249.23.82:88/api/image/TestImageI.jpg";
                tmpStringII = Path.GetFileName(tmpString); // TestImageI.jpg
                tmpStringII = Path.GetFileNameWithoutExtension(tmpString); // TestImageI
                tmpStringII = Path.GetExtension(tmpString); // .jpg
                tmpString = "http://89.249.23.82:88/api/image/TestImageI";
                tmpStringII = Path.GetFileName(tmpString); // TestImageI
                tmpStringII = Path.GetFileNameWithoutExtension(tmpString); // TestImageI
                tmpStringII = Path.GetExtension(tmpString); // ""
                tmpString = Path.GetFileName("89.249.23.82:88/api/image/TestImageI.jpg"); // TestImageI.jpg
                tmpString = Path.GetFileNameWithoutExtension("http://89.249.23.82:88/api/image/TestImageI.jpg"); // TestImageI
                tmpString = Path.GetPathRoot("http://89.249.23.82:88/api/image/TestImageI.jpg"); // ""
                tmpString = Path.GetExtension("http://st-drive.systtech.ru\\photo_201_140919134552001.jpg"); // ".jpg"

                var tmpChars = Path.GetInvalidFileNameChars();

                DirectoryInfo
                    di;

                DirectorySecurity
                    ds;

                FileInfo
                    fi;

                FileSecurity
                    fs;

                FileIOPermission
                    fiop;

                AuthorizationRuleCollection
                    arc;

                FileSystemAccessRule
                    currentRule;

                AccessControlType
                    accessType;

                bool
                    allOk;

                try
                {
                    //tmpString = "c:\\System Volume Information"; // Directory.Exists DirectoryInfo.Exists DirectoryInfo.GetAccessControl()->UnauthorizedAccessException DirectoryInfo.GetAccessControl(AccessControlSections.All)->PrivilegeNotHeldException
                    //tmpString = "c:\\Windows\\System32\\Drivers\\ets"; // !Directory.Exists !DirectoryInfo.Exists
                    //tmpString = "d:\\test     "; // Directory.Exists DirectoryInfo.Exists DirectoryInfo.GetAccessControl()->UnauthorizedAccessException DirectoryInfo.GetAccessControl(AccessControlSections.All)->PrivilegeNotHeldException
                    tmpString = "d:\\temp     ";
                    //tmpString = "d:\\blah-blah-blah";

                    Console.WriteLine("{0}Directory.Exists(\"{1}\")", !Directory.Exists(tmpString) ? "!" : string.Empty, tmpString);
                    di = new DirectoryInfo(tmpString);
                    if (di.Exists)
                    {
                        ds = di.GetAccessControl();
                        //ds = di.GetAccessControl(AccessControlSections.All);

                        arc = ds.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                        allOk = false;
                        foreach (var asl in arc)
                        {
                            currentRule = (FileSystemAccessRule)asl;
                            accessType = currentRule.AccessControlType;

                            if ((currentRule.FileSystemRights & FileSystemRights.ListDirectory) != FileSystemRights.ListDirectory)
                                continue;

                            if((currentRule.FileSystemRights & FileSystemRights.Read) != FileSystemRights.Read)
                                continue;

                            if (accessType == AccessControlType.Deny)
                                continue;

                            if (accessType == AccessControlType.Allow)
                                allOk = true;
                        }
                        Console.WriteLine("\"{0}\": {1}", tmpString, allOk);

                        arc = ds.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                        allOk = false;
                        foreach (var asl in arc)
                        {
                            currentRule = (FileSystemAccessRule)asl;
                            accessType = currentRule.AccessControlType;

                            if ((currentRule.FileSystemRights & FileSystemRights.ListDirectory) != FileSystemRights.ListDirectory)
                                continue;

                            if ((currentRule.FileSystemRights & FileSystemRights.Read) != FileSystemRights.Read)
                                continue;

                            if (accessType == AccessControlType.Deny)
                                continue;

                            if (accessType == AccessControlType.Allow)
                                allOk = true;
                        }
                        Console.WriteLine("\"{0}\": {1}", tmpString, allOk);

                        //var files = di.GetFiles();
                        //var files = di.GetFiles("????-??-??_??-??-??.xml");
                        var files = di.GetFiles("blah-blah-blah");
                        var fileNames = files.Where(file => Regex.IsMatch(file.Name, "\\d{4}-\\d{2}-\\d{2}_\\d{2}-\\d{2}-\\d{2}\\.xml")).Select(file => file.FullName).OrderBy(name => name).ToArray();

                        foreach (var file in files)
                        {
                            
                        }
                    }

                    tmpString = Path.Combine(tmpString, "aaa_");

                    Console.WriteLine("{0}File.Exists(\"{1}\")", !File.Exists(tmpString) ? "!" : string.Empty, tmpString);
                    fi = new FileInfo(tmpString);
                    //if (fi.Exists)
                    {
                        fs = fi.GetAccessControl(/*AccessControlSections.All*/);

                        arc = fs.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));
                        allOk = false;
                        foreach (var asl in arc)
                        {
                            currentRule = (FileSystemAccessRule)asl;
                            accessType = currentRule.AccessControlType;

                            if ((currentRule.FileSystemRights & FileSystemRights.ListDirectory) != FileSystemRights.ListDirectory)
                                continue;

                            if ((currentRule.FileSystemRights & FileSystemRights.Read) != FileSystemRights.Read)
                                continue;

                            if (accessType == AccessControlType.Deny)
                                continue;

                            if (accessType == AccessControlType.Allow)
                                allOk = true;
                        }
                        Console.WriteLine("\"{0}\": {1}", tmpString, allOk);

                        arc = fs.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                        allOk = false;
                        foreach (var asl in arc)
                        {
                            currentRule = (FileSystemAccessRule)asl;
                            accessType = currentRule.AccessControlType;

                            if ((currentRule.FileSystemRights & FileSystemRights.ListDirectory) != FileSystemRights.ListDirectory)
                                continue;

                            if ((currentRule.FileSystemRights & FileSystemRights.Read) != FileSystemRights.Read)
                                continue;

                            if (accessType == AccessControlType.Deny)
                                continue;

                            if (accessType == AccessControlType.Allow)
                                allOk = true;
                        }
                        Console.WriteLine("\"{0}\": {1}", tmpString, allOk);
                    }

                    fiop = new FileIOPermission(FileIOPermissionAccess.Read, tmpString);
                    fiop.Demand();
                }
                catch (PrivilegeNotHeldException e)
                {
                    Console.WriteLine("{0}: \"{1}\"", e.GetType().Name, e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine("{0}: \"{1}\"", e.GetType().Name, e.Message);
                }
                catch (SecurityException e)
                {
                    Console.WriteLine("{0}: \"{1}\"", e.GetType().Name, e.Message);
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("{0}: \"{1}\"", e.GetType().Name, e.Message);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine("{0}: \"{1}\"", e.GetType().Name, e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}: \"{1}\"", e.GetType().Name, e.Message);
                }
                
			#endif

			#if TEST_REF
				tmpString = "tmpString";

				Console.WriteLine(tmpString);
				FWORefString(tmpString);
				Console.WriteLine(tmpString);

				Console.WriteLine(tmpString);
				FWRefString(ref tmpString);
				Console.WriteLine(tmpString);

				DataTable
					tmpDataTable = new DataTable("Main");

				tmpDataTable.Columns.Add("Main",typeof(string));
				FWORefI(tmpDataTable);
				FWORefII(tmpDataTable);
				FWRefI(ref tmpDataTable);
				FWRefII(ref tmpDataTable);

                List<int>
                    tmpList = new List<int> { 1, 2, 3};

                FWORefList(tmpList);

                tmpList = new List<int> { 1, 2, 3 };
                FWORefList(tmpList, true);

                tmpList = new List<int> { 1, 2, 3 };
                FWRefList(ref tmpList);

                tmpList = new List<int> { 1, 2, 3 };
                FWRefList(ref tmpList, true);
			#endif

			#if TEST_COMPARE
				object x = "10";
				object y = "10";
				bool a = x == y;
				bool b = x.Equals(y);

				y = "20";
				a = x == y;
				b = x.Equals(y);

				object int_x = 10;
				object int_y = 10;

				a = int_x == int_y;
				b = int_x.Equals(int_y);

				tmpInt=0;

				string
					string_a = "0",
					string_b = tmpInt.ToString();

				a = string_a == string_b;
				b = string_a.Equals(string_b);

                tmpString = string.Format("tmpInt {0}= null", tmpInt==null ? "=" : "!");
			#endif

			#if TEST_INDEX_OF
				string
					ErrorSignature = "ora-20000",
					tmpString = "ora-20000 blah-blah-blah ora-20001 blah-blah-blah";

				int
					begin,
					end;

				if ((begin = tmpString.IndexOf(ErrorSignature)) != -1
					&& (end = tmpString.IndexOf("ora", begin + ErrorSignature.Length)) != -1)
					tmpString = tmpString.Substring(begin + ErrorSignature.Length, end - ErrorSignature.Length).Trim();
			#endif

			#if TEST_FOR
				int
					Sum = 100;

				int[]
					inpt = new int[] { 5, 10, 15, 20 },
					output = new int[inpt.Length];

				//for (int i = inpt.Length - 1; i >= 0; --i, Sum -= inpt[i])
				//for (int i = inpt.Length - 1; i >= 0; i--, Sum -= inpt[i])

				//for (int i = inpt.Length - 1; i >= 0; Sum -= inpt[i], --i)
				//for (int i = inpt.Length - 1; i >= 0; Sum -= inpt[i], i--)

				//for (int i = inpt.Length - 1; i >= 0; Sum -= inpt[--i])
				for (int i = inpt.Length - 1; i >= 0; Sum -= inpt[i--])
					output[i] = Sum;
			#endif
        }

        #if TEST_OPERATOR_PRECEDENCE
            public static bool BF1(bool value)
            {
                Console.WriteLine("BF1({0})", value);

                return value;
            }

            public static bool BF2(bool value)
            {
                Console.WriteLine("BF2({0})", value);

                return value;
            }
        #endif

		#if TEST_REF
			static void FWORefString(string str)
			{
				str = "FWORefString";
			}

			static void FWRefString(ref string str)
			{
				str = "FWRefString";
			}

            static void FWORefList(List<int> list, bool createNew = false)
            {
                int[]
                    tmpInts = { 10, 20, 30, 40, 50 };

                if(createNew)
                    list = new List<int>(tmpInts);
                else
                    list.AddRange(tmpInts);
            }

            static void FWRefList(ref List<int> list, bool createNew = false)
            {
                int[]
                    tmpInts = { 10, 20, 30, 40, 50 };

                if (createNew)
                    list = new List<int>(tmpInts);
                else
                    list.AddRange(tmpInts);
            }

			static void FWORefI(DataTable t)
			{
				t.Columns.Add("FWORefI", typeof(string));
			}

			static void FWORefII(DataTable t)
			{
				t = new DataTable("FWORefII");
				t.Columns.Add("FWORefII", typeof(string));
			}

			static void FWRefI(ref DataTable t)
			{
				t.Columns.Add("FWRefI", typeof(string));
			}

			static void FWRefII(ref DataTable t)
			{
				t = new DataTable("FWRefII");
				t.Columns.Add("FWRefII", typeof(string));
			}
		#endif

        #if TEST_THERMO
            static void TestThermo()
            {
                int
                    All = 15;

                double
                    checkPointStep = 10,
                    delta = All/checkPointStep,
                    checkPoint = delta;

                for(int i=1; i<=All; ++i)
                {
                    if (i >= checkPoint)
                    {
                        checkPoint += delta;
                        Console.WriteLine("{0} ({1:p})", i, (double)i/All);
                    }
                }
                Console.WriteLine();

                int[]
                    ints = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 17};

                checkPoint = delta = ints.Length / checkPointStep;
                for (int i = 0; i < ints.Length; ++i)
                {
                    if ((i+1) >= checkPoint)
                    {
                        checkPoint += delta;
                        Console.WriteLine("{0} ({1:p})", i + 1, (double) (i + 1)/ints.Length);
                    }
                }
                Console.WriteLine();

                Console.ReadLine();
            }
        #endif

        #if TEST_PARAMS
            static int FuncWithParams(params int[] ints)
            {
                string
                    methodName = "FuncWithParams(params int[] ints)";

                Console.WriteLine(methodName);

                int
                    sum = 0;

                if (ints != null)
                    for (int i = 0; i < ints.Length; ++i)
                        sum += ints[i];

                return sum;
            }

            static int FuncWithParams(string arg1, DateTime arg2, params int[] ints)
            {
                string
                    methodName = "FuncWithParams(string arg1, DateTime arg2, params int[] ints)";

                Console.WriteLine(methodName);

                int
                    sum = 0;

                if (ints != null)
                    for (int i = 0; i < ints.Length; ++i)
                        sum += ints[i];

                return sum;
            }

            static int FuncWithoutParams(string arg1, DateTime arg2, int[] ints)
            {
                string
                    methodName = "FuncWithParams(string arg1, DateTime arg2, int[] ints)";

                Console.WriteLine(methodName);

                int
                    sum = 0;

                if(ints!=null)
                    for (int i = 0; i < ints.Length; ++i)
                        sum += ints[i];

                return sum;
            }

            static void DisplayTypes(params Object[] objects)
            {
                if (objects != null)
                    foreach (Object o in objects)
                        Console.WriteLine(o.GetType());
            }
        #endif

        #if TEST_AD
            static void TestAD()
            {
                try
                {
                    System.DirectoryServices.AccountManagement.UserPrincipal
                        userPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.Current;

                    System.Security.Principal.WindowsIdentity
                        wi = System.Security.Principal.WindowsIdentity.GetCurrent();

                    string[]
                        a = wi.Name.Split('\\');

                    System.DirectoryServices.DirectoryEntry
                        ADEntry = new System.DirectoryServices.DirectoryEntry("WinNT://" + a[0] + "/" + a[1]);

                    string
                        Name = ADEntry.Properties["FullName"].Value.ToString();
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        #endif

        #if ANY_TEST
            static string GetHash(string password)
            {
                var byteConverter = new UnicodeEncoding();
                var dataToEncrypt = byteConverter.GetBytes(password);
                return GetHashCode(dataToEncrypt);
            }

            static string GetHashCode(byte[] bytes)
            {
                return GetHexString(new SHA1CryptoServiceProvider().ComputeHash(bytes));
            }

            static string GetHexString(byte[] bytes)
            {
                var stringBuilder = new StringBuilder();
                for (var i = 0; i < bytes.Length; ++i)
                {
                    var str = bytes[i].ToString("X");
                    if (str.Length < 2)
                        stringBuilder.Append("0");

                    stringBuilder.Append(str);
                }

                return stringBuilder.ToString();
            }
        #endif

        #if TEST_DECIMAL
            static void ShowScale(decimal value)
            {
                int[] parts = decimal.GetBits(value);
                bool sign = (parts[3] & 0x80000000) != 0;
                byte scale = (byte)((parts[3] >> 16) & 0x7F);

                Console.WriteLine("{0} {1}", value, scale);
            }

        #endif
	}

    #if TEST_DECIMAL

        static class DecimalExtensions
        {
            public static decimal Normalize(this decimal value)
            {
                if (value == 0)
                    return value;

                var parts = Decimal.GetBits(value);

                if ((byte)((parts[3] >> 16) & 0x7F) == 0)
                    return value;

                var valueStr = value.ToString(CultureInfo.InvariantCulture);

                //if (valueStr.IndexOf(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator, StringComparison.InvariantCulture) == -1)
                //    return value;

                var regex = new Regex(string.Format("(?<={0}\\d+)0+$", Regex.Escape(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator)));

                return regex.IsMatch(valueStr) ? decimal.Parse(regex.Replace(valueStr, string.Empty), CultureInfo.InvariantCulture) : value;
            }
        }

    #endif
}

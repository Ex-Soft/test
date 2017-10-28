// http://msdn.microsoft.com/en-us/library/hh534540.aspx [CallerMemberName]/[CallerFilePath]/[CallerLineNumber] 4.5

//#define TEST_CONVERT
//#define TEST_PARAMETERS
//#define TEST_NAMED_PARAMETERS
#define TEST_DYNAMIC
//#define TEST_COVARIANCE

using System;

#if TEST_COVARIANCE
    using System.Collections.Generic;
#endif

namespace AnyTest4
{
    #if TEST_PARAMETERS
        public interface ITest
        {
            int F1(int a, int b);
            int F2(int a=3, int b=3);
        }

        public class A : ITest
        {
            public int F1(int a=1, int b=1)
            {
                Console.WriteLine(string.Format("a = {0}, b = {1}", a, b));
                return a + b;
            }

            public int F2(int a = 13, int b = 13)
            {
                Console.WriteLine(string.Format("a = {0}, b = {1}", a, b));
                return a + b;
            }
        }

        public class B : ITest
        {
            public int F1(int a=2, int b=2)
            {
                Console.WriteLine(string.Format("a = {0}, b = {1}", a, b));
                return a + b;
            }

            public int F2(int a, int b)
            {
                Console.WriteLine(string.Format("a = {0}, b = {1}", a, b));
                return a + b;
            }
        }
    #endif

	class Program
	{
		static void Main(string[] args)
		{
		    string
		        tmpString=string.Empty;

		    bool
		        tmpBool;

			try
			{
                #if TEST_CONVERT
				    try
				    {
					    tmpBool = Convert.ToBoolean(tmpString = "0");
				    }
				    catch (FormatException)
				    {
					    Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
				    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "1");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "true");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "false");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "TrUe");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }

                    try
                    {
                        tmpBool = Convert.ToBoolean(tmpString = "FaLsE");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Unable to convert \"{0}\" to a Boolean.", tmpString);
                    }
                #endif

				#if TEST_PARAMETERS
					Console.WriteLine(F1());

                    A
                        a = new A();

                    B
                        b = new B();

                    a.F1();
                    a.F2();
                    b.F1();
                    //b.F2(); // Error	1	No overload for method 'F2' takes 0 arguments
                    b.F2(23, 23);
				#endif

                #if TEST_NAMED_PARAMETERS
			        Console.WriteLine(F1(b:10, a:1));
                    Console.WriteLine(F1(b:10));
                    Console.WriteLine(F1(a:1));
                #endif

                #if TEST_DYNAMIC
			        dynamic
			            a = 1;

			        a++;

			        Console.WriteLine(a);

			        a = DateTime.Now;
			        a = a.AddYears(1);
                    Console.WriteLine(a);
                #endif

                #if TEST_COVARIANCE
                    IEnumerable<string>
                        listString = new List<string>();

			        IEnumerable<object>
			            listObject = listString;

                    object[]
                        array = new string[10];
                #endif
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
		}

        #if TEST_PARAMETERS ||TEST_NAMED_PARAMETERS
            static int F1(int a = 3, int b = 4)
		    {
                Console.WriteLine(string.Format("a = {0}, b = {1}", a, b));
			    return a + b;
		    }
		#endif
	}
}

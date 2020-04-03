// http://minddotout.wordpress.com/2012/12/27/the-c-using-statement-breaks-exception-handling/
// http://www.digitallycreated.net/Blog/51/c%23-using-blocks-can-swallow-exceptions
#define TEST_FINALLY
//#define TEST_USING
//#define TEST_THROW

using System;

namespace ExceptionI
{
    #if TEST_USING
        class CrashingDisposable : IDisposable
        {
            public void Dispose()
            {
                throw new Exception("Inside Dispose");
            }
        }
    #endif

	class Program
	{
		static void Main(string[] args)
		{
            #if TEST_FINALLY
                TestFinaly();

		        try
		        {
		            for (var i = 0; i < 5; ++i)
		            {
		                Console.WriteLine("i = {0}", i);

		                if (i > 1)
		                    break;
		            }
		        }
		        finally
		        {
		            Console.WriteLine("finally");
		        }

                for (var i = 0; i < 5; ++i)
                {
                    try
                    {
                        Console.WriteLine("i = {0}", i);

                        if (i > 1)
                            break;
                    }
                    finally
                    {
                        Console.WriteLine("finally");
                    }
                }

            #endif

            #if TEST_USING
                try
                {
                    using (CrashingDisposable fake = new CrashingDisposable())
                    {
                        throw new Exception("Inside using block");
                    }
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            #endif

			int
				a = 10,
				b = 0,
				c;

		    string
		        separator = new string('-', 60);

            Console.WriteLine(separator);
			try
			{
				try
				{
					c = a / b;
				}
				finally
				{
					Console.WriteLine("finally");
                    Console.WriteLine();
				}
			}
			catch (Exception eException)
			{
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
            Console.WriteLine(separator);
            Console.WriteLine();

            Console.WriteLine(separator);
            try
            {
                try
                {
                    c = a / b;
                }
                finally
                {
                    Console.WriteLine("finally");
                    Console.WriteLine();
                    throw new ArgumentException();
                }
            }
            catch (Exception eException) // ArgumentException
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            Console.WriteLine(separator);
            Console.WriteLine();

            Console.WriteLine(separator);
			try
			{
				try
				{
					try
					{
						c = a / b;
					}
					catch (Exception eException)
					{
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                        Console.WriteLine();
						throw;
					}
				}
				catch (Exception eException)
				{
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                    Console.WriteLine();
					throw;
				}
			}
			catch (Exception eException)
			{
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
            Console.WriteLine(separator);
            Console.WriteLine();

            string
                t = "Line# 1",
                s = null;

            try
            {
                try
                {
                    Test(out s);
                }
                finally
                {
                    t = s;
                }
            }
            catch
            {
                Console.WriteLine(t);
            }

		    t = "Line# 1";
            s = null;
            try
            {
                try
                {
                    Test2(out s);
                }
                finally
                {
                    t = s;
                }
            }
            catch
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            #if TEST_THROW
                Console.WriteLine(separator);
		        try
		        {
		            try
		            {
		                Test();
		            }
		            catch (Exception eException)
		            {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                        Console.WriteLine();
		                throw;
		            }
		        }
		        catch (Exception eException)
		        {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
		        }
                Console.WriteLine(separator);
                Console.WriteLine();

                Console.WriteLine(separator);
                try
                {
                    try
                    {
                        Test();
                    }
                    catch (Exception eException)
                    {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                        Console.WriteLine();
                        throw eException;
                    }
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
                Console.WriteLine(separator);
                Console.WriteLine();

                Console.WriteLine(separator);
                try
                {
                    try
                    {
                        Test();
                    }
                    catch (Exception eException)
                    {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                        Console.WriteLine();
                        throw new ApplicationException("Exception.Message");
                    }
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
                Console.WriteLine(separator);
                Console.WriteLine();

                Console.WriteLine(separator);
                try
                {
                    try
                    {
                        Test();
                    }
                    catch (Exception eException)
                    {
                        Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                        Console.WriteLine();
                        throw new ApplicationException("Exception.Message", eException);
                    }
                }
                catch (Exception eException)
                {
                    Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
                Console.WriteLine(separator);
                Console.WriteLine();
            #endif
        }

        static void Test(out string msg)
        {
            msg = "Line# 2";
            throw new InvalidOperationException();
        }

        static void Test2(out string msg)
        {
            try
            {
                msg = "Line# 2";
                throw new InvalidOperationException();
            }
            finally
            {
                msg = "Line# 3";
            }
        }

        static void Test()
        {
            throw new NotImplementedException();
        }

        #if TEST_FINALLY
            static void TestFinaly()
            {
                try
                {
                    try
                    {
                        throw new Exception("1");
                    }
                    finally
                    {
                        throw new Exception("2");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        #endif
    }
}

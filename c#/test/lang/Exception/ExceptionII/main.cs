using System;

namespace ExceptionII
{
	class Program
	{
		static void Main(string[] args)
		{
		    try
		    {
                throw new System.IO.IOException("IOException.Message");
		        //throw new Exception("Exception.Message");
		    }
            catch (System.IO.IOException ioException)
            {
                Console.WriteLine(ioException.Message);
            }
		    catch (Exception eException)
		    {
		        Console.WriteLine(eException.Message);
		    }
		}
	}
}

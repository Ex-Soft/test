using System;

using static System.Console;

namespace TestTypeCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            object tmpObject = (object)13;
            int tmpInt = (int)tmpObject;

            try
            {
                float tmpFloat = (float)tmpObject;
                double tmpDouble = (double)tmpObject;
                decimal tmpDecimal = (decimal)tmpObject;
            }
            catch (InvalidCastException e)
            {
                WriteLine(e.Message);
            }
        }
    }
}

using System;
using FluentValidation;

using static System.Console;

namespace FluentValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var c = new Class1 { PString3 = "12345678901" };
                var v = new Class1Validator();
                var r = v.Validate(c);
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
        }
    }
}

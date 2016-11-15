using System;
using System.Collections.Generic;
using System.Text;
using Pluggin;

namespace TestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> users =Builder.GetUsers();
            foreach (string user in users)
            {
                Console.WriteLine(user);
            }
            Console.ReadKey();
        }
    }
}

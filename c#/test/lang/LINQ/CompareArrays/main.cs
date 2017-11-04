using System;
using System.Linq;

namespace CompareArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[]
                a1 = new byte[] { 1, 2, 3 },
                a2 = new byte[] { 1, 2, 3 };

            Console.WriteLine(a1.SequenceEqual(a2));

            a2 = null;
            //Console.WriteLine(a1.SequenceEqual(a2)); //System.ArgumentNullException

            a2=new byte[0];
            Console.WriteLine(a1.SequenceEqual(a2));
        }
    }
}

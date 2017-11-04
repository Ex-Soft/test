using System;
using System.Collections.Generic;

namespace TestHashSet
{
    class Program
    {
        static void Main(string[] args)
        {
            bool
                tmpBool;

            HashSet<int>
                testHashSet = new HashSet<int>(new int[] {1, 2, 3, 4, 5, 4, 3, 2, 1});

            tmpBool = testHashSet.Add(5);

            Console.WriteLine(testHashSet.Count);
        }
    }
}

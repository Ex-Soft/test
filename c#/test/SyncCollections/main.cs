using System;
using System.Collections.Generic;
using System.Linq;

namespace SyncCollections
{
    class A
    {
        public string
            F1,
            F2;

        public A(string f1=null, string f2=null)
        {
            F1 = f1;
            F2 = f2;
        }

        public A(A obj) : this(obj.F1, obj.F2)
        {}

        public override string ToString()
        {
            return string.Format("{{F1:\"{0}\", F2:\"{1}\"}}", F1, F2);
        }
        
    }

    class AComparer : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.F2 == y.F2;
        }

        public int GetHashCode(A obj)
        {
            return obj.F2.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<A>
                org = new List<A>(new[] { new A("1", "123"), new A("2", "102030"), new A("3", "100200300")}),
                newValues = new List<A>(),
                oldValues = new List<A>();

            org.ForEach(item => newValues.Add(new A(item)));
            org.ForEach(item => oldValues.Add(new A(item)));

            newValues.Add(new A("4", "100020003000"));
            newValues[1].F2 = "302010";
            newValues[2].F1 = "30";

            for (var i = newValues.Count - 1; i >= 0; --i)
            {
                var tmpItem = newValues[i];
                var isExist = false;
                for (var ii = oldValues.Count - 1; ii >= 0; --ii)
                {
                    if (isExist = tmpItem.F2 == oldValues[ii].F2)
                    {
                        if (tmpItem.F1 != oldValues[ii].F1)
                            tmpItem.F1 = oldValues[ii].F1;
                        break;
                    }
                }

                if(!isExist)
                    newValues.RemoveAt(i);
            }

            newValues.ForEach(Console.WriteLine);
            Console.WriteLine();

            for (var i = oldValues.Count - 1; i >= 0; --i)
            {
                var tmpItem = oldValues[i];
                if(!newValues.Any(item => item == tmpItem))
                    Console.WriteLine(tmpItem);
            }

            var toAdd = new List<A>();

            for (var i = oldValues.Count - 1; i >= 0; --i)
            {
                var tmpItem = oldValues[i];
                var isExist = false;

                for (var ii = newValues.Count - 1; ii >= 0; --ii)
                    if (isExist = tmpItem.F2 == newValues[ii].F2)
                        break;

                if (!isExist)
                    toAdd.Add(tmpItem);
            }

            if(toAdd.Count>0)
                newValues.AddRange(toAdd);

            newValues.ForEach(Console.WriteLine);
            Console.WriteLine();
        }
    }
}

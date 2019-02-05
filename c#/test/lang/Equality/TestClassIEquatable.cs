using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using static System.Console;

namespace Equality
{
    public class TestClassIEquatable : IEquatable<TestClassIEquatable>
    {
        public int? PInt1 { get; set; }
        public int? PInt2 { get; set; }
        public int? PInt3 { get; set; }

        public bool Equals(TestClassIEquatable other)
        {
            string msg;
            WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}");
            Debug.WriteLine(msg);

            if (other == null) return false;
            if (ReferenceEquals(this, other)) return true;
            return PInt1 == other.PInt1 && PInt2 == other.PInt2 && PInt3 == other.PInt3;
        }

        public override int GetHashCode()
        {
            string msg;
            WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}");
            Debug.WriteLine(msg);

            unchecked
            {
                var hashCode = PInt1 != null ? PInt1.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (PInt2 != null ? PInt2.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PInt3 != null ? PInt3.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(TestClassIEquatable left, TestClassIEquatable right)
        {
            string msg;
            WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}");
            Debug.WriteLine(msg);

            return Equals(left, right);
        }

        public static bool operator !=(TestClassIEquatable left, TestClassIEquatable right)
        {
            string msg;
            WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}");
            Debug.WriteLine(msg);

            return !Equals(left, right);
        }
    }

    public class TestClassIEquatableComparer : IComparer<TestClassIEquatable>
    {
        public int Compare(TestClassIEquatable x, TestClassIEquatable y)
        {
            string msg;
            WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}");
            Debug.WriteLine(msg);

            var compare = NullComparer<int?>.Compare(x.PInt1, y.PInt1);
            if (compare != 0) return compare;

            compare = NullComparer<int?>.Compare(x.PInt2, y.PInt2);
            if (compare != 0) return compare;

            return NullComparer<int?>.Compare(x.PInt3, y.PInt3);
        }

        public static class NullComparer<T>
        {
            public static int Compare(T o1, T o2)
            {
                string msg;
                WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}");
                Debug.WriteLine(msg);

                if (o1 == null && o2 != null)
                    return 1;

                if (o1 != null && o2 == null)
                    return -1;

                return 0;
            }
        }
    }

    public static class ListExtensions
    {
        public static void Insert<T>(this List<T> @this, T item) where T : IComparable<T>
        {
            @this.Insert(item, Comparer<T>.Default);
        }

        /// <see cref="http://stackoverflow.com/questions/12172162/how-to-insert-item-into-list-in-order"/>
        public static void Insert<T>(this List<T> @this, T item, IComparer<T> comparer)
        {
            if (@this.Count == 0)
            {
                @this.Add(item);
                return;
            }

            if (comparer.Compare(@this[@this.Count - 1], item) <= 0)
            {
                @this.Add(item);
                return;
            }

            if (comparer.Compare(@this[0], item) >= 0)
            {
                @this.Insert(0, item);
                return;
            }

            var index = @this.BinarySearch(item, comparer);

            if (index < 0)
                index = ~index;

            @this.Insert(index, item);
        }
    }
}

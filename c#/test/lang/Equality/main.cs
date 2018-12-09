using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Equality
{
    public class SimpleClass
    {
        public int FInt { get; set; }
    }

    public class TestClassIComparableFull : IComparable
    {
        public int FieldInt;

        public TestClassIComparableFull(TestClassIComparableFull aObj) : this(aObj.FieldInt)
        {
            Debug.WriteLine($"TestClassIComparableFull(TestClassIComparableFull {aObj})");
        }

        public TestClassIComparableFull(int fieldInt = 0)
        {
            Debug.WriteLine($"TestClassIComparableFull(int fieldInt = {fieldInt})");
            FieldInt = fieldInt;
        }

        public static bool operator == (TestClassIComparableFull left, TestClassIComparableFull right)
        {
            Debug.WriteLine($"operator == (TestClassIComparableFull {left}, TestClassIComparableFull {right})");

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.FieldInt == right.FieldInt;
        }

        public static bool operator != (TestClassIComparableFull left, TestClassIComparableFull right)
        {
            Debug.WriteLine($"operator != (TestClassIComparableFull {left}, TestClassIComparableFull {right})");
            return !(left == right);
        }

        public static bool operator == (TestClassIComparableFull left, int right)
        {
            Debug.WriteLine($"operator == (TestClassIComparableFull {left}, int {right})");

            if (ReferenceEquals(left, null))
                return false;

            return left.FieldInt == right;
        }

        public static bool operator != (TestClassIComparableFull left, int right)
        {
            Debug.WriteLine($"operator != (TestClassIComparableFull {left}, int {right})");
            return !(left == right);
        }

        public static bool operator == (int left, TestClassIComparableFull right)
        {
            Debug.WriteLine($"operator == (int {left}, TestClassIComparableFull {right})");

            if (ReferenceEquals(right, null))
                return false;

            return left == right.FieldInt;
        }

        public static bool operator != (int left, TestClassIComparableFull right)
        {
            Debug.WriteLine($"operator != (int {left}, TestClassIComparableFull {right})");
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            Debug.WriteLine($"override bool Equals(object {obj})");

            if (ReferenceEquals(this, obj))
                return true;

            if (ReferenceEquals(obj, null))
                return false;

            bool result;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Int32:
                {
                    result = FieldInt == Convert.ToInt32(obj);
                    break;
                }
                default:
                {
                    result = this == (TestClassIComparableFull)obj;
                    break;
                }
            }

            return result;
        }

        public override int GetHashCode()
        {
            Debug.WriteLine($"override int GetHashCode({FieldInt})");
            return FieldInt.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Debug.WriteLine($"int CompareTo(object {obj})");

            int result;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.String:
                {
                    result = FieldInt.CompareTo(Convert.ToInt32(obj));
                    break;
                }
                default:
                {
                    result = FieldInt.CompareTo(((TestClassIComparableFull)obj).FieldInt);
                    break;
                }
            }

            return result;
        }

        public override string ToString()
        {
            return $"{{FiledInt: {FieldInt}}}";
        }
    }

    public class Comparer : IEqualityComparer<TestClassIComparableFull>
    {
        public bool Equals(TestClassIComparableFull x, TestClassIComparableFull y)
        {
            Debug.WriteLine($"Comparer.Equals(TestClassIComparableFull {x}, TestClassIComparableFull {y})");

            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.FieldInt == y.FieldInt;
        }

        public int GetHashCode(TestClassIComparableFull obj)
        {
            Debug.WriteLine($"Comparer.GetHashCode(TestClassIComparableFull {obj})");
            return obj.FieldInt.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleClass
                simpleClassLeft = new SimpleClass {FInt = 13},
                simpleClassRight = simpleClassLeft;

            Debug.WriteLine($"simpleClassLeft {(simpleClassLeft == simpleClassRight ? "=" : "!") }= simpleClassRight");
            Debug.WriteLine($"{(simpleClassLeft.Equals(simpleClassRight) ? string.Empty : "!") }simpleClassLeft.Equals(simpleClassRight)");

            simpleClassRight = new SimpleClass {FInt = 13};
            Debug.WriteLine($"simpleClassLeft {(simpleClassLeft == simpleClassRight ? "=" : "!") }= simpleClassRight");
            Debug.WriteLine($"{(simpleClassLeft.Equals(simpleClassRight) ? string.Empty : "!") }simpleClassLeft.Equals(simpleClassRight)");

            TestClassIComparableFull
                left = new TestClassIComparableFull(13),
                right = new TestClassIComparableFull(left);

            var resultBool = ReferenceEquals(left, left);
            Debug.WriteLine($"ReferenceEquals(left, left) = {resultBool}");

            resultBool = ReferenceEquals(left, right);
            Debug.WriteLine($"ReferenceEquals(left, right) = {resultBool}");

            resultBool = Equals(left, right);
            Debug.WriteLine($"Equals(left, right) = {resultBool}");

            var dictionary = new Dictionary<TestClassIComparableFull, string>
            {
                { new TestClassIComparableFull(13), "13" }
            };

            dictionary[left] = "1313";

            List<TestClassIComparableFull>
                listLeft = new List<TestClassIComparableFull>
                {
                    new TestClassIComparableFull(13),
                    new TestClassIComparableFull(1),
                    new TestClassIComparableFull(99)        
                },
                listRight = new List<TestClassIComparableFull>
                {
                    new TestClassIComparableFull(69),
                    new TestClassIComparableFull(33),
                    new TestClassIComparableFull(13)
                },
                result;

            result = listLeft.Intersect(listRight, new Comparer()).ToList();
            result = listLeft.Except(listRight, new Comparer()).ToList();
            result = listRight.Except(listLeft, new Comparer()).ToList();
        }
    }
}

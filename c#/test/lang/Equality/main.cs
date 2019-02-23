#define TEST_PERFORMANCE

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
            int?
                tmpIntNullable1,
                tmpIntNullable2;

            int
                compareResult;

            tmpIntNullable1 = null;
            tmpIntNullable2 = null;
            compareResult = Nullable.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = Nullable.Compare(tmpIntNullable2, tmpIntNullable1);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable2, tmpIntNullable1);

            tmpIntNullable1 = 1;
            tmpIntNullable2 = null;
            compareResult = Nullable.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = Nullable.Compare(tmpIntNullable2, tmpIntNullable1);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable2, tmpIntNullable1);

            tmpIntNullable1 = null;
            tmpIntNullable2 = 2;
            compareResult = Nullable.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = Nullable.Compare(tmpIntNullable2, tmpIntNullable1);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable2, tmpIntNullable1);

            tmpIntNullable1 = 1;
            tmpIntNullable2 = 2;
            compareResult = Nullable.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable1, tmpIntNullable2);
            compareResult = Nullable.Compare(tmpIntNullable2, tmpIntNullable1);
            compareResult = TestClassIEquatableComparer.NullComparer<int?>.Compare(tmpIntNullable2, tmpIntNullable1);

            List<TestClassIEquatable>
                listTestClassIEquatable = new List<TestClassIEquatable>();

            TestClassIEquatableComparer
                testClassIEquatableComparer = new TestClassIEquatableComparer();

            listTestClassIEquatable.Insert(new TestClassIEquatable(), testClassIEquatableComparer);
            listTestClassIEquatable.Insert(new TestClassIEquatable { PInt3 = 1 }, testClassIEquatableComparer);
            listTestClassIEquatable.Insert(new TestClassIEquatable { PInt2 = 1, PInt3 = 1 }, testClassIEquatableComparer);
            listTestClassIEquatable.Insert(new TestClassIEquatable { PInt1 = 1, PInt2 = 1, PInt3 = 1 }, testClassIEquatableComparer);

            TestClassIEquatable
                testClassIEquatable1 = new TestClassIEquatable { PInt2 = 1, PInt3 = 1 },
                testClassIEquatable2;

            testClassIEquatable2 = listTestClassIEquatable.FirstOrDefault(item => IsMatch(testClassIEquatable1, item));

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

            #if TEST_PERFORMANCE

                var array = new[] {
                    new TestClassIComparableFull(5),
                    new TestClassIComparableFull(-1),
                    new TestClassIComparableFull(0),
                    new TestClassIComparableFull(3),
                    new TestClassIComparableFull(5),
                    new TestClassIComparableFull(2)
                };

                //Debug.WriteLine("sort");
                //var sort = array.OrderByDescending(item => item).ToArray();
                Debug.WriteLine("sort -> distinct");
                var sortDistinct = array.OrderByDescending(item => item).Distinct().ToArray();
                /*
                sort -> distinct

                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: -1})
                int CompareTo(object {FiledInt: 2})
                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: 3})
                int CompareTo(object {FiledInt: 3})
                int CompareTo(object {FiledInt: -1})
                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: 3})
                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: 5})

                override int GetHashCode(5)
                override int GetHashCode(5)
                override bool Equals(object {FiledInt: 5})
                operator == (TestClassIComparableFull {FiledInt: 5}, TestClassIComparableFull {FiledInt: 5})
                override int GetHashCode(3)
                override int GetHashCode(2)
                override int GetHashCode(0)
                override int GetHashCode(-1)

                */

                //Debug.WriteLine("distinct");
                //var distinct = array.Distinct().ToArray();
                Debug.WriteLine("distinct -> sort");
                var distinctSort = array.Distinct().OrderByDescending(item => item).ToArray();
                /*
                distinct -> sort

                override int GetHashCode(5)
                override int GetHashCode(-1)
                override int GetHashCode(0)
                override int GetHashCode(3)
                override int GetHashCode(5)
                override bool Equals(object {FiledInt: 5})
                operator == (TestClassIComparableFull {FiledInt: 5}, TestClassIComparableFull {FiledInt: 5})
                override int GetHashCode(2)

                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: -1})
                int CompareTo(object {FiledInt: 2})
                int CompareTo(object {FiledInt: 3})
                int CompareTo(object {FiledInt: -1})
                int CompareTo(object {FiledInt: 5})
                int CompareTo(object {FiledInt: 3})
                int CompareTo(object {FiledInt: 3})

                */

            #endif
        }

        public static bool IsMatch(TestClassIEquatable key, TestClassIEquatable value)
        {
            return (value.PInt1 == null || key.PInt1 == value.PInt1)
                && (value.PInt2 == null || key.PInt2 == value.PInt2)
                && (value.PInt3 == null || key.PInt3 == value.PInt3);
        }
    }
}

using System;
using KellermanSoftware.CompareNetObjects;
using static System.Console;

namespace TestCompareLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareLogic compareLogicForPodIEnumerable = new CompareLogic
            {
                Config = new ComparisonConfig
                {
                    IgnoreCollectionOrder = true
                }
            };

            int[]
                arrayOfInt1 = { 1, 2, 3, 4, 5 },
                arrayOfInt2 = { 5, 4, 3, 2, 1 };

            var result = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).AreEqual; // true
            var diff = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).Differences; // Count = 0
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            arrayOfInt2 = new[] { 5, 8, 3, 9, 1 };
            result = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).AreEqual; // false
            diff = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).Differences; // Count=1 (item)
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            arrayOfInt2 = new[] { 5, 3, 1 };
            result = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).AreEqual; // false
            diff = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).Differences; // Count=2 (item, length)
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            arrayOfInt1 = new[] { 1, 3, 5 };
            arrayOfInt2 = new[] { 5, 4, 3, 2, 1 };
            result = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).AreEqual; // false
            diff = compareLogicForPodIEnumerable.Compare(arrayOfInt1, arrayOfInt2).Differences; // Count=2 (item, length)
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            DateTime[]
                arrayOfDateTime1 = { new DateTime(2020, 2, 29), new DateTime(2020, 2, 28), new DateTime(2020, 2, 27) },
                arrayOfDateTime2 = { new DateTime(2020, 2, 27), new DateTime(2020, 2, 28), new DateTime(2020, 2, 29) };

            result = compareLogicForPodIEnumerable.Compare(arrayOfDateTime1, arrayOfDateTime2).AreEqual;
            diff = compareLogicForPodIEnumerable.Compare(arrayOfDateTime1, arrayOfDateTime2).Differences;
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            arrayOfDateTime2 = new[] { new DateTime(2020, 3, 27), new DateTime(2020, 2, 28), new DateTime(2020, 3, 29) };
            result = compareLogicForPodIEnumerable.Compare(arrayOfDateTime1, arrayOfDateTime2).AreEqual;
            diff = compareLogicForPodIEnumerable.Compare(arrayOfDateTime1, arrayOfDateTime2).Differences;
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            float[]
                arrayOfFloat1 = { 1.1f, 2.2F, 3.3f, 4.4f, 5.5f },
                arrayOfFloat2 = { 5.5f, 4.4f, 3.3f, 2.2f, 1.1f };

            result = compareLogicForPodIEnumerable.Compare(arrayOfFloat1, arrayOfFloat2).AreEqual;
            diff = compareLogicForPodIEnumerable.Compare(arrayOfFloat1, arrayOfFloat2).Differences;
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            arrayOfFloat2 = new[] { 5.5f, 8.8f, 3.3f, 9.9f, 1.1f };
            result = compareLogicForPodIEnumerable.Compare(arrayOfFloat1, arrayOfFloat2).AreEqual;
            diff = compareLogicForPodIEnumerable.Compare(arrayOfFloat1, arrayOfFloat2).Differences;
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            arrayOfFloat2 = new[] { 5.5f, 3.3f, 1.1f };
            result = compareLogicForPodIEnumerable.Compare(arrayOfFloat1, arrayOfFloat2).AreEqual;
            diff = compareLogicForPodIEnumerable.Compare(arrayOfFloat1, arrayOfFloat2).Differences;
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            TestClass1[]
                arrayOfTestClass11 =
                {
                    new TestClass1 {PInt = 1, PFloat = 1.1f, PDateTime = new DateTime(2020,2,29)},
                    new TestClass1 {PInt = 2, PFloat = 2.2f, PDateTime = new DateTime(2020,2,28)},
                    new TestClass1 {PInt = 3, PFloat = 3.3f, PDateTime = new DateTime(2020,2,27)},
                },
                arrayOfTestClass12 =
                {
                    new TestClass1 {PInt = 3, PFloat = 3.3f, PDateTime = new DateTime(2020,2,27)},
                    new TestClass1 {PInt = 2, PFloat = 2.2f, PDateTime = new DateTime(2020,2,28)},
                    new TestClass1 {PInt = 1, PFloat = 1.1f, PDateTime = new DateTime(2020,2,29)},
                };

            result = compareLogicForPodIEnumerable.Compare(arrayOfTestClass11, arrayOfTestClass12).AreEqual;
            diff = compareLogicForPodIEnumerable.Compare(arrayOfTestClass11, arrayOfTestClass12).Differences;
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");

            arrayOfTestClass12 = new[]
            {
                new TestClass1 { PInt = 3, PFloat = 4.4f, PDateTime = new DateTime(2020, 2, 27) },
                new TestClass1 { PInt = 2, PFloat = 2.2f, PDateTime = new DateTime(2020, 2, 28) },
                new TestClass1 { PInt = 1, PFloat = 1.1f, PDateTime = new DateTime(2020, 3, 29) },
            };
            result = compareLogicForPodIEnumerable.Compare(arrayOfTestClass11, arrayOfTestClass12).AreEqual;
            diff = compareLogicForPodIEnumerable.Compare(arrayOfTestClass11, arrayOfTestClass12).Differences;
            WriteLine($"AreEqual={result} diff.Count={diff.Count}");
        }
    }
}

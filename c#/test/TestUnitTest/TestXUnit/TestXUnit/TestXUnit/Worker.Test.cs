// https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using Xunit;

namespace TestXUnit
{
    public class WorkerConcatDataForClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {null, null};
            yield return new object[] {new A(), string.Empty};
            yield return new object[] {new A("1st"), "1st"};
            yield return new object[] {new A("1st", "2nd"), "1st2nd"};
            yield return new object[] {new A("1st", "2nd", "3rd"), "1st2nd3rd"};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class WorkerConcatDataForMemberData
    {
        public static IEnumerable<object[]> WorkerConcatParameters =>
            new List<object[]>
            {
                new object[] {null, null},
                new object[] {new A(), string.Empty},
                new object[] {new A("1st"), "1st"},
                new object[] {new A("1st", "2nd"), "1st2nd"},
                new object[] {new A("1st", "2nd", "3rd"), "1st2nd3rd"},
            };
    }

    public class WorkerTest
    {
        public static IEnumerable<object[]> WorkerConcatParameters =>
            new List<object[]>
            {
                new object[] {null, null},
                new object[] {new A(), string.Empty},
                new object[] {new A("1st"), "1st"},
                new object[] {new A("1st", "2nd"), "1st2nd"},
                new object[] {new A("1st", "2nd", "3rd"), "1st2nd3rd"},
            };

        public static IEnumerable<object[]> GetWorkerConcatParameters(int numTests)
        {
            var allParameters = new List<object[]>
            {
                new object[] {null, null},
                new object[] {new A(), string.Empty},
                new object[] {new A("1st"), "1st"},
                new object[] {new A("1st", "2nd"), "1st2nd"},
                new object[] {new A("1st", "2nd", "3rd"), "1st2nd3rd"},
            };

            return allParameters.Take(numTests);
        }

        [Fact]
        [Trait("ClassLibrary", "Worker")]
        public void ConcatTest()
        {
            //Arrange
            A a = null;
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(default(string), default(string), default(string), "")]
        [InlineData("1st", default(string), default(string), "1st")]
        [InlineData("1st", "2nd", default(string), "1st2nd")]
        [InlineData("1st", "2nd", "3rd", "1st2nd3rd")]
        [Trait("ClassLibrary", "Worker")]
        public void ConcatTestByInlineData(string pString1, string pString2, string pString3, string expected)
        {
            //Arrange
            var a = new A(pString1, pString2, pString3);
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(WorkerConcatDataForClassData))]
        [Trait("ClassLibrary", "Worker")]
        public void ConcatTestByClassData(A a, string expected)
        {
            //Arrange
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(WorkerConcatParameters))]
        [Trait("ClassLibrary", "Worker")]
        public void ConcatTestByMemberData(A a, string expected)
        {
            //Arrange
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetWorkerConcatParameters), parameters: 3)]
        [Trait("ClassLibrary", "Worker")]
        public void ConcatTestByMemberDataWithThreeParameters(A a, string expected)
        {
            //Arrange
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(WorkerConcatDataForMemberData.WorkerConcatParameters), MemberType = typeof(WorkerConcatDataForMemberData))]
        [Trait("ClassLibrary", "Worker")]
        public void ConcatTestByMemberDataFromAnotherClass(A a, string expected)
        {
            //Arrange
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

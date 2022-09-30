// Nick Chapsas
// How to test "untestable" code in .NET
// https://www.youtube.com/watch?v=6WeT-JQBI98

namespace Victim.Tests
{
    public class Class1Tests
    {
        [Fact]
        public void Test1()
        {
            var class1 = new Class1();
        }
    }
}
using FakeItEasy;

namespace TestFakeItEasy
{
    public interface IMath
    {
        int Add(int left, int right);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var math = A.Fake<IMath>();
            //A.CallTo(() => math.Add(5, 5)).MustHaveHappened();
            A.CallTo(() => math.Add(1, 2)).Returns(3);
            A.CallTo(() => math.Add(3, 4)).Returns(7);

            int result;

            result = math.Add(5, 5);
            result = math.Add(1, 2);
            result = math.Add(3, 4);
            result = math.Add(1, 1);
        }
    }
}

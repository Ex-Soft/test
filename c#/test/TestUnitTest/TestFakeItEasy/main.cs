using FakeItEasy;

namespace TestFakeItEasy
{
    public interface IMath
    {
        int Add(int left, int right);
    }

    public interface IConvert
    {
        string IntToStr(int _int);
    }

    public interface IConvert2
    {
        string IntToStr(int _int);
    }

    public interface IConvert3
    {
        string IntToStr(int _int);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var math = A.Fake<IMath>();
            //A.CallTo(() => math.Add(5, 5)).MustHaveHappened();
            A.CallTo(() => math.Add(1, 2)).Returns(3);
            A.CallTo(() => math.Add(3, 4)).Returns(7);

            int resultInt;

            resultInt = math.Add(5, 5); // 0
            resultInt = math.Add(1, 2); // 3
            resultInt = math.Add(3, 4); // 7
            resultInt = math.Add(1, 1); // 0

            var convert = A.Fake<IConvert>();
            A.CallTo(() => convert.IntToStr(1)).Returns("1st");
            A.CallTo(() => convert.IntToStr(2)).Returns("2nd");
            A.CallTo(() => convert.IntToStr(3)).Returns("3rd");

            string resultStr;

            resultStr = convert.IntToStr(1); // "1st"
            resultStr = convert.IntToStr(2); // "2nd"
            resultStr = convert.IntToStr(3); // "3rd"
            resultStr = convert.IntToStr(4); // ""
            resultStr = convert.IntToStr(5); // ""

            var convert2 = A.Fake<IConvert2>();
            A.CallTo(() => convert2.IntToStr(1)).Returns("1st");
            A.CallTo(() => convert2.IntToStr(2)).Returns("2nd");
            A.CallTo(() => convert2.IntToStr(3)).Returns("3rd");
            A.CallTo(() => convert2.IntToStr(A<int>.Ignored)).ReturnsLazily(objectCall => objectCall.ToString());

            resultStr = convert2.IntToStr(1); // "TestFakeItEasy.IConvert2.IntToStr(1)"
            resultStr = convert2.IntToStr(2); // "TestFakeItEasy.IConvert2.IntToStr(2)"
            resultStr = convert2.IntToStr(3); // "TestFakeItEasy.IConvert2.IntToStr(3)"
            resultStr = convert2.IntToStr(4); // "TestFakeItEasy.IConvert2.IntToStr(4)"
            resultStr = convert2.IntToStr(5); // "TestFakeItEasy.IConvert2.IntToStr(5)"

            var convert3 = A.Fake<IConvert>();
            A.CallTo(() => convert3.IntToStr(1)).Returns("1st");
            A.CallTo(() => convert3.IntToStr(2)).Returns("2nd");
            A.CallTo(() => convert3.IntToStr(3)).Returns("3rd");
            A.CallTo(() => convert3.IntToStr(A<int>.Ignored)).ReturnsLazily((int _int) => $"{_int}th");

            resultStr = convert3.IntToStr(1); // "1th"
            resultStr = convert3.IntToStr(2); // "2th"
            resultStr = convert3.IntToStr(3); // "3th"
            resultStr = convert3.IntToStr(4); // "4th"
            resultStr = convert3.IntToStr(5); // "5th"
        }
    }
}

// https://github.com/Moq/moq4/wiki/Quickstart

using System.Text.RegularExpressions;
using Moq;

namespace Quickstart
{
	class Program
	{
		static void Main(string[] args)
		{
			var mock = new Mock<IFoo>();

			#region Methods

			// returns true when invoked with "concrete string"
			mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns<string>(s => s == "concrete string");

			// returns true when invoked with specific parameters
			mock.Setup(foo => foo.DoSomething("ping")).Returns(true);

			// throwing when invoked with specific parameters
			mock.Setup(foo => foo.DoSomething("reset")).Throws<InvalidOperationException>();
			mock.Setup(foo => foo.DoSomething("")).Throws(new ArgumentException("command"));

			// out arguments
			var outString = "this is out outString value";
			// TryParse will return true, and the out argument will return "ack", lazy evaluated
			mock.Setup(foo => foo.TryParse("ping", out outString)).Returns(true);

			// ref arguments
			var instance = new Bar();
			// Only matches if the ref argument to the invocation is the same instance
			mock.Setup(foo => foo.Submit(ref instance)).Returns(true);

			// access invocation arguments when returning a value
			mock.Setup(foo => foo.DoSomethingStringy(It.IsAny<string>())).Returns<string>(s => s.ToLower());
			// Multiple parameters overloads available

			var count = 13;
			// lazy evaluating return value
			mock.Setup(foo => foo.GetCount()).Returns(() => count);
			Console.WriteLine(mock.Object.GetCount());

			var calls = 0;
			mock.Setup(foo => foo.GetCountThing()).Returns(() => calls).Callback(() => calls++);
			// returns 0 on first invocation, 1 on the next, and so on
            Console.WriteLine(mock.Object.GetCountThing());
            Console.WriteLine(mock.Object.GetCountThing());

			Console.WriteLine(mock.Object.DoSomething("concrete string")); // true
			Console.WriteLine(mock.Object.DoSomething("another string")); // false

			Console.WriteLine(mock.Object.DoSomething("ping")); // true
			Console.WriteLine(mock.Object.DoSomething("pong")); // false

			try { Console.WriteLine(mock.Object.DoSomething("reset")); } catch (Exception e) { Console.WriteLine("{0}: {1}", e.GetType().FullName, e.Message); }
			try { Console.WriteLine(mock.Object.DoSomething("")); } catch (Exception e) { Console.WriteLine("{0}: {1}", e.GetType().FullName, e.Message); }
			
			string tmpString;
			Console.WriteLine(mock.Object.TryParse("ping", out tmpString));

			var tmpBar = new Bar();
			Console.WriteLine(mock.Object.Submit(ref tmpBar)); // false
			tmpBar = instance;
			Console.WriteLine(mock.Object.Submit(ref tmpBar)); // true

			Console.WriteLine(mock.Object.DoSomethingStringy("STRING IN UPPER CASE"));

			Console.WriteLine(mock.Object.GetCount());

			Console.WriteLine(mock.Object.GetCountThing());
			Console.WriteLine(mock.Object.GetCountThing());

			#endregion

			#region Matching Arguments

			// any value
			mock.Setup(foo => foo.DoSomething2(It.IsAny<string>())).Returns(true);
			
			// matching Func<int>, lazy evaluated
			mock.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);
			
			// matching ranges
			mock.Setup(foo => foo.Add2(It.IsInRange<int>(0, 10, Moq.Range.Inclusive))).Returns(true);
			
			// matching regex
			mock.Setup(x => x.DoSomething3(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");

			Console.WriteLine(mock.Object.DoSomething2(null)); // true
			Console.WriteLine(mock.Object.DoSomething2(string.Empty)); // true
			Console.WriteLine(mock.Object.DoSomething2("blah-blah-blah")); // true

			Console.WriteLine(mock.Object.Add(12)); // true
			Console.WriteLine(mock.Object.Add(13)); // false

			Console.WriteLine(mock.Object.Add2(-1)); // false
			Console.WriteLine(mock.Object.Add2(0)); // true
			Console.WriteLine(mock.Object.Add2(5)); // true
			Console.WriteLine(mock.Object.Add2(10)); // true
			Console.WriteLine(mock.Object.Add2(11)); // false

			Console.WriteLine(mock.Object.DoSomething3("aaa")); // "foo"
			Console.WriteLine(mock.Object.DoSomething3("zzz")); // null
			#endregion
        }
	}
}

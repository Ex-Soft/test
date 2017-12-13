// https://blogs.msdn.microsoft.com/dotnet/2017/03/09/new-features-in-c-7-0/
// https://www.erikheemskerk.nl/csharp-7-0-improvements/

using System;
using System.Collections.Concurrent;

using static System.Console;

namespace cs7
{
    // More expression bodied members
    class Person
    {
        private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
        private int id = GetId();

        public Person(string name) => names.TryAdd(id, name); // constructors
        ~Person() => names.TryRemove(id, out _);              // finalizers
        public string Name
        {
            get => names[id];                                 // getters
            set => names[id] = value;                         // setters
        }

        static int GetId() => 1;
    }

    class Person2
    {
        public string Name { get; }
        public Person2(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
        public string GetFirstName()
        {
            var parts = Name.Split(' ');
            return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
        }
        public string GetLastName() => throw new NotImplementedException();
    }

    class Shape
    {}

    class Circle : Shape
    {
        public int Radius { get; set; }
    }

    class Rectangle : Shape
    {
        public int Length { get; set; }
        public int Height { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Out variables
            MethodWithOutParameters(out int x, out int y);
            WriteLine($"({x}, {y})");
            MethodWithOutParameters(out int a, out _);
            WriteLine($"({a})");

            var tmpStr = "10";
            if (int.TryParse(tmpStr, out var tmpInt)) WriteLine($"tmpInt = {tmpInt}");

            // Pattern matching
            PrintStars(null);
            PrintStars(5.5m);
            PrintStars(5);
            Foo(10);

            Shape shape;
            //shape = null;
            //shape = new Circle { Radius = 10 };
            shape = new Rectangle { Height = 5, Length = 5 };
            //shape = new Rectangle { Height = 5, Length = 10 };
            switch (shape)
            {
                case Circle c:
                    WriteLine($"circle with radius {c.Radius}");
                    break;
                case Rectangle s when (s.Length == s.Height):
                    WriteLine($"{s.Length} x {s.Height} square");
                    break;
                case Rectangle r:
                    WriteLine($"{r.Length} x {r.Height} rectangle");
                    break;
                default:
                    WriteLine("<unknown shape>");
                    break;
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }

            var tuple1 = FooTuple1();
            WriteLine($"{{Item1: \"{tuple1.Item1}\", Item2: {tuple1.Item2}, Item3: {tuple1.Item3}}}");
            var tuple2 = FooTuple2();
            WriteLine($"{{first: \"{tuple2.first}\", second: {tuple2.second}, third: {tuple2.third}}}");
            //(string first, int second, decimal third) = FooTuple2();
            //(var first, var second, var third) = FooTuple2();
            //var (first, second, third) = FooTuple2();
            string first; int second; decimal third; (first, second, third) = FooTuple2();
            WriteLine($"{{first: \"{first}\", second: {second}, third: {third}}}");

            tmpInt = Fibonacci(5);

            // Literal improvements
            var d = 123_456;
            var _x_ = 0xAB_CD_EF;
            var b = 0b1010_1011_1100_1101_1110_1111;

            // Ref returns and locals
            int[] array = { 1, 15, -39, 0, 7, 14, -12 };
            ref int place = ref Find(7, array); // aliases 7's place in the array
            place = 9; // replaces 7 with 9 in the array
            WriteLine(array[4]); // prints 9
        }

        static void MethodWithOutParameters(out int x, out int y)
        {
            x = 1;
            y = 2;
        }

        static void PrintStars(object o)
        {
            if (o is null) return;     // constant pattern "null"
            if (!(o is int i)) return; // type pattern "int i"
            WriteLine(new string('*', i));
        }

        static void Foo(object o)
        {
            if (o is int i || (o is string s && int.TryParse(s, out i))) { WriteLine(i); }
        }

        static (string, int, decimal) FooTuple1()
        {
            return ("string", 1, 2.2m);
        }

        static (string first, int second, decimal third) FooTuple2()
        {
            return ("string", 1, 2.2m);
        }

        // Local functions
        static int Fibonacci(int x)
        {
            if (x < 0) throw new ArgumentException("Less negativity please!", nameof(x));
            return Fib(x).current;

            (int current, int previous) Fib(int i)
            {
                if (i == 0) return (1, 0);
                var (p, pp) = Fib(i - 1);
                return (p + pp, p);
            }
        }

        static ref int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; // return the storage location, not the value
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }
    }
}

using ClassLibrary;

using static System.Console;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            A a = null;
            var result = worker.Concat(a);
            WriteLine($"{(result != null ? $"\"{result}\"" : "null")}");

            a = new A();
            result = worker.Concat(a);
            WriteLine($"{(result != null ? $"\"{result}\"" : "null")}");

            a = new A("1st");
            result = worker.Concat(a);
            WriteLine($"{(result != null ? $"\"{result}\"" : "null")}");

            a = new A("1st", "2nd");
            result = worker.Concat(a);
            WriteLine($"{(result != null ? $"\"{result}\"" : "null")}");

            a = new A("1st", "2nd", "3rd");
            result = worker.Concat(a);
            WriteLine($"{(result != null ? $"\"{result}\"" : "null")}");
        }
    }
}

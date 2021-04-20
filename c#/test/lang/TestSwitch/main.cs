using static System.Console;

namespace TestSwitch
{
    public class A
    {
        public string Value { get; set; }
    }

    public class B
    {
        public string Value { get; set; }
    }

    public class C
    {
        public string Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new A { Value = "A" };
            var b = new B { Value = "B" };
            var c = new C { Value = "C" };

            WriteLine(GetByStatement(a));
            WriteLine(GetByStatement(b));
            WriteLine(GetByStatement(c));

            WriteLine(GetByExpression(a));
            WriteLine(GetByExpression(b));
            WriteLine(GetByExpression(c));

            WriteLine(GetByProperty(new A { Value = "A" }));
            WriteLine(GetByProperty(new A { Value = "B" }));
            WriteLine(GetByProperty(new A { Value = "C" }));
        }

        public static string GetByStatement(object o)
        {
            switch (o)
            {
                case A a:
                    return a.Value;
                case B b:
                    return b.Value;
                case C c:
                    return c.Value;
                default:
                    return null;
            }
        }

        public static string GetByExpression(object o)
        {
            return o switch
            {
                A a => a.Value,
                B b => b.Value,
                C c => c.Value,
                _ => null
            };
        }

        public static string GetByProperty(A a)
        {
            return a switch
            {
                { Value: "A" } => "A",
                { Value: "B" } => "B",
                { Value: "C" } => "C",
                _ => string.Empty
            };
        }
    }
}

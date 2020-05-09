using static System.Console;

namespace TestStringInterm
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                stringLiteral1 = "this is string literal",
                stringLiteral2 = "this is string literal",
                stringNew1 = new string(new[] {'t' , 'h', 'i', 's', ' ', 'i', 's', ' ', 's', 't', 'r', 'i', 'n', 'g', ' ', 'l', 'i', 't', 'e', 'r', 'a', 'l'}),
                stringNew2 = new string(new[] { 't', 'h', 'i', 's', ' ', 'i', 's', ' ', 's', 't', 'r', 'i', 'n', 'g', ' ', 'l', 'i', 't', 'e', 'r', 'a', 'l', ' ', '2' }),
                stringNew3 = new string(new[] { 't', 'h', 'i', 's', ' ', 'i', 's', ' ', 's', 't', 'r', 'i', 'n', 'g', ' ', 'l', 'i', 't', 'e', 'r', 'a', 'l', ' ', '3' }),
                stringNew4;

            WriteLine($"string.IsInterned(stringLiteral1) = \"{string.IsInterned(stringLiteral1)}\"");
            WriteLine($"string.IsInterned(stringLiteral2) = \"{string.IsInterned(stringLiteral2)}\"");
            WriteLine($"string.IsInterned(stringNew1) = {string.IsInterned(stringNew1)}\"");
            WriteLine($"string.IsInterned(\"this is string literal\") = \"{string.IsInterned("this is string literal")}\"");
            WriteLine($"string.IsInterned(stringNew2) = \"{string.IsInterned(stringNew2)}\"");

            WriteLine($"\"{stringLiteral1}\" {(stringLiteral1 == stringLiteral2 ? "==" : "!=")} \"{stringLiteral2}\"");
            WriteLine($"{(ReferenceEquals(stringLiteral1, stringLiteral2) ? string.Empty : "!")}ReferenceEquals(\"{stringLiteral1}\", \"{stringLiteral2}\")");
            WriteLine(string.IsInterned(stringLiteral1));

            WriteLine($"\"{stringLiteral1}\" {(stringLiteral1 == stringNew1 ? "==" : "!=")} \"{stringNew1}\"");
            WriteLine($"{(ReferenceEquals(stringLiteral1, stringNew1) ? string.Empty : "!")}ReferenceEquals(\"{stringLiteral1}\", \"{stringNew1}\")");

            WriteLine($"string.IsInterned(stringNew3) = \"{string.IsInterned(stringNew3)}\"");
            stringNew4 = string.Intern(stringNew3);
            WriteLine($"string.IsInterned(stringNew3) = \"{string.IsInterned(stringNew3)}\"");
            WriteLine($"string.IsInterned(stringNew4) = \"{string.IsInterned(stringNew4)}\"");
        }
    }
}

using static System.Console;

namespace DefaultImplementation
{
    public class Victim1
    {
        public int Id { get; set; }    
    }

    public class Victim2
    {
        public int Id { get; set; }
    }
    
    public interface IBase
    {
        string ExpressionBody1 => "IBase.ExpressionBody1";
        string ExpressionBody2 => $"IBase.ExpressionBody2 \"{ExpressionBody1}\"";
    }

    public class Base : IBase
    {
        public string ExpressionBody1 => "Base.ExpressionBody1";
    }

    public interface IDerived : IBase
    {
        string ExpressionBody1 => "IDerived.ExpressionBody1";
        string ExpressionBody2 => $"IDerived.ExpressionBody2 \"{ExpressionBody1}\"";
    }

    public class Derived : IDerived
    {
        public string ExpressionBody1 => "Derived.ExpressionBody1";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string tmpString;
            
            Base base1 = new();
            tmpString = base1.ExpressionBody1;
            WriteLine(tmpString);
            tmpString = ((IBase)base1).ExpressionBody2;
            WriteLine(tmpString);

            Derived derived1 = new();
            tmpString = derived1.ExpressionBody1;
            WriteLine(tmpString);
            tmpString = ((IDerived)derived1).ExpressionBody2;
            WriteLine(tmpString);
        }
    }
}

using static System.Console;

namespace TestInheritance
{
    public interface I
    {
        string PString1 { get; set; }
        string PString2 { get; set; }
        string PString3 { get; set; }

        string Get1();
        void Set1(string value);
        string Get2();
        void Set2(string value);
        string Get3();
        void Set3(string value);
    }

    public class Base : I
    {
        public string PString1 { get; set; } = "Base()";
        public virtual string PString2 { get; set; } = "Base()";
        string I.PString3 { get; set; } = "Base()";

        public string Get1()
        {
            return PString1;
        }

        public void Set1(string value)
        {
            PString1 = value;
        }

        public string Get2()
        {
            return PString2;
        }

        public void Set2(string value)
        {
            PString2 = value;
        }

        public string Get3()
        {
            return ((I)this).PString3;
        }

        public void Set3(string value)
        {
            ((I)this).PString3 = value;
        }
    }

    public class A : Base, I
    {
        public new string PString1 { get; set; } = "A()";
        public override string PString2 { get; set; } = "A()";
        string I.PString3 { get; set; } = "A()";
    }

    public class B : Base, I
    {
        public new string PString1 { get; set; } = "B()";
        public override string PString2 { get; set; } = "B()";
        string I.PString3 { get; set; } = "B()";
    }

    class Program
    {
        static void Main(string[] args)
        {
            I
                a = new A(),
                b = new B();

            WriteLine(a.Get1()); // Base()
            WriteLine(b.Get1()); // Base()
            WriteLine(a.Get2()); // A()
            WriteLine(b.Get2()); // B()
            WriteLine(a.Get3()); // A()
            WriteLine(b.Get3()); // B()

            b.Set1("b.Set1()");
            b.Set2("b.Set2()");
            b.Set3("b.Set3()");

            WriteLine(a.Get1());
            WriteLine(a.Get2());
            WriteLine(a.Get3());
        }
    }
}

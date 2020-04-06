using System;

namespace TestNew
{
    public interface IPrintable
    {
        void PrintSelf();
    }

    public class Base : IPrintable
    {
        public virtual void PrintSelf() { Console.WriteLine("Base"); }
    }

    public class A : Base
    {
        public override void PrintSelf() { Console.WriteLine("A"); }
    }

    public class B : A
    {
        public new void PrintSelf() { Console.WriteLine("B"); }
    }
    
    class Program
    {
        public static void PrintObject<T>(T obj) where T : IPrintable
        {
            obj.PrintSelf();
        }
    
        static void Main(string[] args)
        {
            Base bc = new Base();
            PrintObject(bc);

            A a = new A();
            PrintObject(a);

            B b = new B();
            PrintObject(b);
        }
    }
}

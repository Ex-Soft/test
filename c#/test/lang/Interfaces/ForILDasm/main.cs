using static System.Console;

namespace ForILDasm
{
    // .class interface public abstract auto ansi
    public interface IBase
    {
        // .method public hidebysig virtual newslot abstract instance void
        void Foo();

        // .method public hidebysig virtual newslot abstract instance void
        void FinalFoo();
    }

    // .class public auto ansi beforefieldinit
    // ForILDasm.Base
    // extends [mscorlib]System.Object
    // implements ForILDasm.IBase
    public class Base : IBase
    {
        // .method public       hidebysig virtual newslot instance void
        public virtual void Foo() { WriteLine("Base.Foo()"); }

        // .method public final hidebysig virtual newslot instance void
        public void FinalFoo() { WriteLine("Base.FinalFoo()"); }
    }

    // .class public auto ansi beforefieldinit
    // ForILDasm.A
    // extends ForILDasm.Base
    public class A : Base
    {
        // .method public hidebysig virtual instance void
        public override void Foo() { WriteLine("A.Foo()"); }

        // .method public hidebysig         instance void
        public void FinalFoo() { WriteLine("A.FinalFoo()"); }
    }

    // .class public auto ansi beforefieldinit
    // ForILDasm.AI
    // extends ForILDasm.Base
    // implements ForILDasm.IBase
    public class AI : Base, IBase
    {
        // .method public       hidebysig virtual         instance void
        public override void Foo() { WriteLine("AI.Foo()"); }

        // .method public final hidebysig virtual newslot instance void
        public void FinalFoo() { WriteLine("AI.FinalFoo()"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Base Base");
            Base b = new Base();
            b.Foo();        // Base.Foo()
            b.FinalFoo();   // Base.FinalFoo()
            WriteLine();

            WriteLine("Base A");
            b = new A();
            b.Foo();        // A.Foo()
            b.FinalFoo();   // Base.FinalFoo()
            WriteLine();

            WriteLine("A A");
            A a = new A();
            a.Foo();        // A.Foo()
            a.FinalFoo();   // A.FinalFoo()
            WriteLine();

            WriteLine("IBase Base A");
            IBase iBase = b;
            iBase.Foo();        // A.Foo()
            iBase.FinalFoo();   // Base.FinalFoo()
            WriteLine();

            WriteLine("IBase A A");
            iBase = a;
            iBase.Foo();        // A.Foo()
            iBase.FinalFoo();   // Base.FinalFoo()
            WriteLine();

            WriteLine("IBase AI AI");
            iBase = new AI();
            iBase.Foo();        // AI.Foo()
            iBase.FinalFoo();   // AI.FinalFoo()
        }
    }
}

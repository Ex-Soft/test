using System;

namespace AssemblyII
{
    public class PublicClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyII.PublicClass.Foo()");

            AssemblyII.InternalClass aIIic = new AssemblyII.InternalClass();
            aIIic.Foo();

            AssemblyII.PrivateClass aIIpc = new AssemblyII.PrivateClass();
            aIIpc.Foo();
        }
    }

    internal class InternalClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyII.InternalClass.Foo()");
        }
    }

    class PrivateClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyII.PrivateClass.Foo()");
        }
    }
}

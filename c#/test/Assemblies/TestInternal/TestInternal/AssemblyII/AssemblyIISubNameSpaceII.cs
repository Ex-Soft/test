using System;

namespace AssemblyII.SubNameSpaceII
{
    public class PublicClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceII.PublicClass.Foo()");

            AssemblyII.SubNameSpaceII.InternalClass aIIsnIIic = new AssemblyII.SubNameSpaceII.InternalClass();
            aIIsnIIic.Foo();

            AssemblyII.SubNameSpaceII.PrivateClass aIIsnIIpc = new AssemblyII.SubNameSpaceII.PrivateClass();
            aIIsnIIpc.Foo();
        }
    }

    internal class InternalClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceII.InternalClass.Foo()");
        }
    }

    class PrivateClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceII.PrivateClass.Foo()");
        }
    }
}

using System;

namespace AssemblyII.SubNameSpaceI
{
    public class PublicClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceI.PublicClass.Foo()");

            AssemblyII.SubNameSpaceI.InternalClass aIIsnIic = new AssemblyII.SubNameSpaceI.InternalClass();
            aIIsnIic.Foo();

            AssemblyII.SubNameSpaceI.PrivateClass aIIsnIpc = new AssemblyII.SubNameSpaceI.PrivateClass();
            aIIsnIpc.Foo();

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
            Console.WriteLine("AssemblyII.SubNameSpaceI.InternalClass.Foo()");
        }
    }

    class PrivateClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyII.SubNameSpaceI.PrivateClass.Foo()");
        }
    }
}

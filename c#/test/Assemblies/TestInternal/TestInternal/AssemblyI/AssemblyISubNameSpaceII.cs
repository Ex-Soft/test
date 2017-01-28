using System;

namespace AssemblyI.SubNameSpaceII
{
    public class PublicClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceII.PublicClass.Foo()");

            AssemblyI.SubNameSpaceII.InternalClass aIsnIIic = new AssemblyI.SubNameSpaceII.InternalClass();
            aIsnIIic.Foo();

            AssemblyI.SubNameSpaceII.PrivateClass aIsnIIpc = new AssemblyI.SubNameSpaceII.PrivateClass();
            aIsnIIpc.Foo();

            AssemblyI.SubNameSpaceI.InternalClass aIsnIic = new AssemblyI.SubNameSpaceI.InternalClass();
            aIsnIic.Foo();

            AssemblyI.SubNameSpaceI.PrivateClass aIsnIpc = new AssemblyI.SubNameSpaceI.PrivateClass();
            aIsnIpc.Foo();
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

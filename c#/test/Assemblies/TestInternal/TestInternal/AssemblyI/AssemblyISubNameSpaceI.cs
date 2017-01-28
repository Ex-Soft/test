using System;

namespace AssemblyI.SubNameSpaceI
{
    public class PublicClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceI.PublicClass.Foo()");

            AssemblyI.SubNameSpaceI.InternalClass aIsnIic = new AssemblyI.SubNameSpaceI.InternalClass();
            aIsnIic.Foo();

            AssemblyI.SubNameSpaceI.PrivateClass aIsnIpc = new AssemblyI.SubNameSpaceI.PrivateClass();
            aIsnIpc.Foo();

            AssemblyI.SubNameSpaceII.InternalClass aIsnIIic = new AssemblyI.SubNameSpaceII.InternalClass();
            aIsnIIic.Foo();

            AssemblyI.SubNameSpaceII.PrivateClass aIsnIIpc = new AssemblyI.SubNameSpaceII.PrivateClass();
            aIsnIIpc.Foo();
        }
    }

    internal class InternalClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceI.InternalClass.Foo()");
        }
    }

    class PrivateClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.SubNameSpaceI.PrivateClass.Foo()");
        }
    }
}

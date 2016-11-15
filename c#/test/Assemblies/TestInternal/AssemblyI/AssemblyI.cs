using System;

namespace AssemblyI
{
    public class PublicClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.PublicClass.Foo()");

            AssemblyI.InternalClass aIic = new AssemblyI.InternalClass();
            aIic.Foo();

            AssemblyI.PrivateClass aIpc = new AssemblyI.PrivateClass();
            aIpc.Foo();

            AssemblyI.SubNameSpaceI.PublicClass aIsnIpc = new AssemblyI.SubNameSpaceI.PublicClass();
            aIsnIpc.Foo();

            AssemblyI.SubNameSpaceI.InternalClass aIsnIic = new AssemblyI.SubNameSpaceI.InternalClass();
            aIsnIic.Foo();

            AssemblyI.SubNameSpaceI.PrivateClass aIsnIppc = new AssemblyI.SubNameSpaceI.PrivateClass();
            aIsnIppc.Foo();

            AssemblyI.SubNameSpaceII.PublicClass aIsnIIpc = new AssemblyI.SubNameSpaceII.PublicClass();
            aIsnIIpc.Foo();

            AssemblyI.SubNameSpaceII.InternalClass aIsnIIic = new AssemblyI.SubNameSpaceII.InternalClass();
            aIsnIIic.Foo();

            AssemblyI.SubNameSpaceII.PrivateClass aIsnIIppc = new AssemblyI.SubNameSpaceII.PrivateClass();
            aIsnIppc.Foo();
        }
    }

    internal class InternalClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.InternalClass.Foo()");
        }
    }

    class PrivateClass
    {
        public void Foo()
        {
            Console.WriteLine("AssemblyI.PrivateClass.Foo()");
        }
    }
}

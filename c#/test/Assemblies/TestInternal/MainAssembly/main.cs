namespace MainAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyI.PublicClass aIpc = new AssemblyI.PublicClass();
            AssemblyII.PublicClass aIIpc = new AssemblyII.PublicClass();

            aIpc.Foo();
            aIIpc.Foo();
        }
    }
}

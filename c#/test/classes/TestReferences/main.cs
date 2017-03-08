namespace TestReferences
{
    interface ITest
    {
        int F { get; set; }
        void Foo();
    }

    class Inner : ITest
    {
        public int F { get; set; }

        public void Foo()
        {
            System.Diagnostics.Debug.WriteLine("Foo()");
        }
    }

    class Outer
    {
        public Inner Inner { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var outer = new Outer();
            outer.Inner = new Inner();
            outer.Inner.F = 13;

            var iTest = outer.Inner as ITest;

            iTest.Foo();
            iTest = null;

            outer.Inner.Foo();

            var tmpInner = outer.Inner;
            outer.Inner = new Inner();
            outer.Inner.F = 69;
        }
    }
}

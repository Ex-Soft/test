using System;

namespace TestAction
{
    class Stub
    {
        public string FString { get; set; }

        public Stub(Stub obj) : this(obj.FString)
        { }

        public Stub(string fString = "")
        {
            FString = fString;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Action action = Foo;
            var @object = new Stub("FString");

            action.BeginInvoke(ExecuteDone, @object);

            System.Diagnostics.Debug.WriteLine(@object.FString);
        }

        static void Foo()
        {}

        static void ExecuteDone(IAsyncResult asyncResult)
        {
            Stub stub;

            if ((stub = asyncResult.AsyncState as Stub) == null)
                return;

            stub.FString += " (ExecuteDone(IAsyncResult))";
        }
    }
}

using System;

namespace TestEventsInDerivedClasses
{
    public class Base
    {
        public event EventHandler SomeEventHandler;

        public void SomeMethod()
        {
            OnSomeEvent();
        }

        protected void OnSomeEvent()
        {
            EventHandler handler = SomeEventHandler;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }

    public class Derived : Base
    {
        protected void OnSomeSomeEvent()
        {
            EventHandler handler = SomeEventHandler; // Error CS0070  The event 'Base.SomeEventHandler' can only appear on the left hand side of += or -= (except when used from within the type 'Base')

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

            // ||
            //SomeEventHandler?.Invoke(this, EventArgs.Empty); // Error CS0070  The event 'Base.SomeEventHandler' can only appear on the left hand side of += or -= (except when used from within the type 'Base')
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Base();
            a.SomeEventHandler += SomeEventHandler;
            a.SomeMethod();
            a.SomeEventHandler -= SomeEventHandler;
        }

        private static void SomeEventHandler(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("SomeEventHandler");
        }
    }
}

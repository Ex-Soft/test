using System;

namespace TestOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var tmp = new B();
                tmp.DoSmth();
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }

    public class ExceptionI : Exception
    {}

    public class ExceptionII : Exception
    {}

    public class ExceptionIII : Exception
    {}

    public class A
    {
        public virtual bool DoSmth()
        {
            bool result;

            try
            {
                result = Foo();
            }
            catch (ExceptionI)
            {
                result = false;
            }

            return result;
        }

        public virtual bool Foo()
        {
            throw new ExceptionIII();
            return true;
        }
    }

    public class B : A
    {
        public override bool DoSmth()
        {
            bool result;

            try
            {
                result = base.DoSmth();
            }
            catch (ExceptionII)
            {
                result = false;
            }

            return result;
        }
    }
}

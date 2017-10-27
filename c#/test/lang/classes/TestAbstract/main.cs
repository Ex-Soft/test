using System;

namespace TestAbstract
{
    public abstract class A
    {
        public A()
        {
            Console.WriteLine("A.ctor()");
        }

        protected string
            _Field3 = string.Empty;

        public abstract string Field1 { get; }
        public abstract string Field2 { get; }
        public abstract string Field3 { get; set; }
        public abstract string Field4 { get; set; }
        public abstract void SmthMethod1();
        public abstract void SmthMethod2();
    }

    public abstract class B : A
    {
        public B()
        {
            Console.WriteLine("B.ctor()");
        }

        public override string Field1
        {
            get
            {
                string
                    field1 = "Field1 (get)";

                Console.WriteLine(field1);

                return field1;
            }
        }

        public override string Field3
        {
            get
            {
                Console.WriteLine(string.Format("Field3 get: \"{0}\"", _Field3));
                return _Field3;
            }
            set
            {
                string
                    msg = "Field3 set ({0}): \"{1}\"";

                Console.WriteLine(string.Format(msg,"b4",_Field3));
                if (_Field3 != value)
                {
                    Console.WriteLine(string.Format("\t\"{0}\" -> \"{1}\"", _Field3, value));
                    _Field3 = value;
                }
                Console.WriteLine(string.Format(msg, "after", _Field3));
            }
        }

        public override void SmthMethod1()
        {
            Console.WriteLine("SmthMethod1()");
        }
    }

    public class C : B
    {
        public C()
        {
            Console.WriteLine("C.ctor()");
        }

        public override string Field2
        {
            get
            {
                string
                    field2 = "Field2 (get)";

                Console.WriteLine(field2);

                return field2;
            }
        }

        public override string Field4 { get; set; }

        public override void SmthMethod2()
        {
            Console.WriteLine("SmthMethod2()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            C
                c=new C();

            c.SmthMethod1();
            c.SmthMethod2();

            string
                tmpString;

            Console.WriteLine();
            tmpString = c.Field1;
            Console.WriteLine();

            Console.WriteLine();
            tmpString = c.Field2;
            Console.WriteLine();

            Console.WriteLine();
            c.Field3 = "blah-blah-blah";
            Console.WriteLine();

            Console.WriteLine();
            tmpString =c.Field3;
            Console.WriteLine();

            Console.WriteLine();
            c.Field3 = "blah-blah-blah";
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

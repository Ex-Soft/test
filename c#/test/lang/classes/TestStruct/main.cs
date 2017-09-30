// http://sergeyteplyakov.blogspot.com/2011/07/blog-post.html
#define TEST_SET_PRIVATE_FIELD

using System;
using System.Collections.Generic;
#if TEST_SET_PRIVATE_FIELD
    using System.Reflection;
#endif

namespace TestStruct
{
    #if TEST_SET_PRIVATE_FIELD
        struct TestStructWithPrivateField
        {
            private int FPrivateInt;

            public override string ToString()
            {
                return string.Format("{{FPrivateInt: {0}}}", FPrivateInt);
            }
        }
    #endif

    struct MutableWOGS
    {
        public int
            X,
            Y;

        public MutableWOGS(MutableWOGS obj) : this(obj.X, obj.Y)
        {}

        public MutableWOGS(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void IncrementX() { X++; }
    }

    struct Mutable
    {
        public Mutable(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
        public void IncrementX() { X++; }
        public int X { get; private set; }
        public int Y { get; set; }
    }

    struct TestStructII
    {
        public int
            i;

        public string
            s;

        public decimal
            d;
    }

    struct TestStruct
    {
        int
            _FInt;

        public int FInt
        {
            get {return _FInt;}
            set {_FInt=value;}
        }

        //TestStruct() : this(int.MinValue) //Compiler Error CS0568: Structs cannot contain explicit parameterless constructors
        //{}

        TestStruct(TestStruct obj) : this(obj.FInt)
        {}

        TestStruct(int aFInt)
        {
            _FInt = aFInt;
        }
    }

    class A
    {
        public A() { Mutable = new Mutable(5, 5); }
        public Mutable Mutable { get; private set; }
    }

    class AA
    {
        public AA() { Mutable = new MutableWOGS(5, 5); }
        public MutableWOGS Mutable { get; private set; }
    }

    class B
    {
        public readonly Mutable M = new Mutable(5, 5);
    }

    class BWORO
    {
        public Mutable M = new Mutable(5, 5);
    }

    class Program
    {
        static void Main(string[] args)
        {
            #if TEST_SET_PRIVATE_FIELD
                TestStructWithPrivateField
                    testStructWithPrivateField = new TestStructWithPrivateField();

                Console.WriteLine(testStructWithPrivateField);

                Type
                    typeTestStructWithPrivateField = typeof(TestStructWithPrivateField);

                FieldInfo
                    fi = typeTestStructWithPrivateField.GetField("FPrivateInt", BindingFlags.NonPublic | BindingFlags.Instance);

                ValueType
                    v = testStructWithPrivateField;

                if (fi != null)
                    fi.SetValue(v, 5);
                else
                    Console.WriteLine("fi==null");
                testStructWithPrivateField = (TestStructWithPrivateField)v;
                Console.WriteLine(testStructWithPrivateField);
            #endif

            //TestStruct
            //    tmpTestStruct = new TestStruct();

            TestStructII
                t;

            //Console.WriteLine(t.i); // Compiler Error CS0170: Use of possibly unassigned field 'i'

            t.i = 55;

            A a = new A();
            // a.Mutable.Y++; // Cannot modify the return value of 'TestStruct.A.Mutable' because it is not a variable

            Console.WriteLine("Исходное значение Mutable.X: {0}", a.Mutable.X);
            a.Mutable.IncrementX();
            Console.WriteLine("Mutable.X после вызова IncrementX(): {0}", a.Mutable.X);

            AA aa=new AA();
            //aa.Mutable.Y++; // Cannot modify the return value of 'TestStruct.A.Mutable' because it is not a variable

            Console.WriteLine("Исходное значение Mutable.X: {0}", aa.Mutable.X);
            aa.Mutable.IncrementX();
            Console.WriteLine("Mutable.X после вызова IncrementX(): {0}", aa.Mutable.X);

            B b = new B();
            Console.WriteLine("Исходное значение M.X: {0}", b.M.X);
            b.M.IncrementX();
            b.M.IncrementX();
            b.M.IncrementX();
            Console.WriteLine("M.X после трех вызовов IncrementX: {0}", b.M.X);

            Console.WriteLine("Исходное значение M.X: {0}", b.M.X);
            Mutable tmp1 = b.M;
            tmp1.IncrementX();
            Mutable tmp2 = b.M;
            tmp2.IncrementX();
            Mutable tmp3 = b.M;
            tmp3.IncrementX();
            Console.WriteLine("M.X после трех вызовов IncrementX: {0}", b.M.X);

            BWORO bworo = new BWORO();
            Console.WriteLine("Исходное значение M.X: {0}", bworo.M.X);
            bworo.M.IncrementX();
            bworo.M.IncrementX();
            bworo.M.IncrementX();
            Console.WriteLine("M.X после трех вызовов IncrementX: {0}", bworo.M.X);

            List<Mutable> lm = new List<Mutable> { new Mutable(5, 5) };
            //lm[0].Y++; // Cannot modify the return value of 'System.Collections.Generic.List<TestStruct.Mutable>.this[int]' because it is not a variable
            lm[0].IncrementX();

            Mutable[] am = new Mutable[] { new Mutable(5, 5) }; 
            Console.WriteLine("Исходные значения X: {0}, Y: {1}", am[0].X, am[0].Y);
            am[0].Y++;
            am[0].IncrementX();
            Console.WriteLine("Новые значения X: {0}, Y: {1}", am[0].X, am[0].Y);

            Mutable[] amam = new Mutable[] { new Mutable(5, 5) }; 
            IList<Mutable> lst = amam;
            // lst[0].Y++; // Cannot modify the return value of 'System.Collections.Generic.IList<TestStruct.Mutable>.this[int]' because it is not a variable
            lst[0].IncrementX();

            var x = new { Items = new List<int> { 1, 2, 3 }.GetEnumerator() };
            while (x.Items.MoveNext())
            {
                Console.WriteLine(x.Items.Current);
            }
        }
    }
}

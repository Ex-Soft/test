﻿#define TEST_INTERFACE
#define TEST_IPRINTABLE

using System;

namespace TestNew
{
    #if TEST_INTERFACE

        #if TEST_IPRINTABLE

            // .class interface private abstract auto ansi
            interface IPrintable
            {
                 // .method public hidebysig virtual newslot abstract instance void
                void PrintSelf();
            }

            // .class private auto ansi beforefieldinit
            // TestNew.Base
            // extends [mscorlib]System.Object
            // implements TestNew.IPrintable
            class Base : IPrintable
            {
                // .method public hidebysig virtual newslot instance void
                public virtual void PrintSelf()
                {
                    Console.WriteLine("Base");
                }
            }

            // .class private auto ansi beforefieldinit
            // TestNew.AA
            // extends TestNew.Base
            class AA : Base
            {
                // .method public hidebysig virtual instance void
                public override void PrintSelf()
                {
                    Console.WriteLine("AA");
                }
            }
 
            // .class private auto ansi beforefieldinit
            // TestNew.BB
            // extends TestNew.AA
            class BB : AA /*, IPrintable*/
            {
                // .method public hidebysig instance void
                public new void PrintSelf()
                {
                    Console.WriteLine("BB");
                }
            }
        #endif

        public interface II
        {
            void TestTest();
            void TestTestTest();
        }

        class X : II
        {
            public virtual void Test() { Console.WriteLine("X.Test()"); }
            public void TestTest() { Console.WriteLine("X.TestTest()"); }
            public void TestTestTest() { Console.WriteLine("X.TestTestTest()"); }
        }

        class XX : X
        {
            public override void Test() { Console.WriteLine("XX.Test()"); }
            public new void TestTest() { Console.WriteLine("XX.TestTest()"); }
            public void TestTestTest() { Console.WriteLine("XX.TestTestTest()"); }
        }

    #endif

    class A
    {
        public virtual void Test() { Console.WriteLine("A"); }
        public virtual string P { get { return "A"; } }

        #if TEST_INTERFACE
            public virtual X X { get; set; }
        #endif
    }

    class B : A
    {
        public override void Test() { Console.WriteLine("B"); }
        public override string P { get { return "B"; } }
    }

    class C : B
    {
        public new virtual void Test() { Console.WriteLine("C"); }
        public new virtual string P { get { return "C"; } }

        #if TEST_INTERFACE
            public new virtual X X { get { return base.X as XX; } set { base.X = value; } }
        #endif
    }

    class D : C
    {
        public override void Test() { Console.WriteLine("D"); }
        public override string P { get { return "D"; } }
    }

    class Program
    {
        #if TEST_INTERFACE && TEST_IPRINTABLE
            public static void PrintObject<T>(T obj) where T : IPrintable
            {
                obj.PrintSelf();
            }
        #endif

        static void Main(string[] args)
        {
            #if TEST_INTERFACE
                #if TEST_IPRINTABLE
                    Base bs = new Base();
                    IPrintable iPrintable = bs as IPrintable;
                    bs.PrintSelf();         // Base
                    iPrintable.PrintSelf(); // Base
                    PrintObject(bs);        // Base

                    AA aa = new AA();
                    iPrintable = aa as IPrintable;
                    aa.PrintSelf();         // AA
                    iPrintable.PrintSelf(); // AA
                    PrintObject(aa);        // AA

                    BB bb = new BB();
                    iPrintable = bb as IPrintable;
                    bb.PrintSelf();         // BB
                    iPrintable.PrintSelf(); // AA
                    PrintObject(bb);        // AA
                #endif

                II
                    iiPtr;

                X
                    x=new X(),
                    xPtrXX=new XX();

                x.TestTest();
                xPtrXX.TestTest();
                xPtrXX.TestTestTest();
                iiPtr = xPtrXX as II;
                iiPtr.TestTest();
                iiPtr.TestTestTest();

                XX
                    xx = new XX();

                xx.TestTest();
                xx.TestTestTest();
            #endif

            Console.WriteLine($"A {new string('-', 30)}");

            A
                a = new A(),
                aPtrB = new B(),
                aPtrC = new C(),
                aPtrD = new D();

            a.Test(); // A
            Console.WriteLine("A.P {{P: {0}}}", a.P); // A
            #if TEST_INTERFACE
                a.X = new XX();
                a.X.Test();
                a.X.TestTest();
                iiPtr = a.X as II;
                iiPtr.TestTest();
                a.X = new X();
                a.X.Test();
                a.X.TestTest();
                iiPtr = a.X as II;
                iiPtr.TestTest();
            #endif

            aPtrB.Test(); // B
            Console.WriteLine("aPtrB.P {{P: {0}}}", aPtrB.P); // B
            #if TEST_INTERFACE
                aPtrB.X = new XX();
                aPtrB.X.Test();
                aPtrB.X.TestTest();
                iiPtr = aPtrB.X as II;
                iiPtr.TestTest();
                aPtrB.X = new X();
                aPtrB.X.Test();
                aPtrB.X.TestTest();
                iiPtr = aPtrB.X as II;
                iiPtr.TestTest();
            #endif

            aPtrC.Test(); // B
            Console.WriteLine("aPtrC.P {{P: {0}}}", aPtrC.P); // B
            #if TEST_INTERFACE
                aPtrC.X = new XX();
                aPtrC.X.Test();
                aPtrC.X.TestTest();
                iiPtr = aPtrC.X as II;
                iiPtr.TestTest();
                aPtrC.X = new X();
                aPtrC.X.Test();
                aPtrC.X.TestTest();
                iiPtr = aPtrC.X as II;
                iiPtr.TestTest();
            #endif

            aPtrD.Test(); // B
            Console.WriteLine("aPrtD.P {{P: {0}}}", aPtrD.P); // B
            #if TEST_INTERFACE
                aPtrD.X = new XX();
                aPtrD.X.Test();
                aPtrD.X.TestTest();
                iiPtr = aPtrD.X as II;
                iiPtr.TestTest();
                aPtrD.X = new X();
                aPtrD.X.Test();
                aPtrD.X.TestTest();
                iiPtr = aPtrD.X as II;
                iiPtr.TestTest();
            #endif

            Console.WriteLine($"A {new string('-', 30)}");
            Console.WriteLine();
            Console.WriteLine($"B {new string('-', 30)}");

            B
                b = new B(),
                bPtrC = new C(),
                bPtrD = new D();

            b.Test(); // B
            Console.WriteLine("{{P: {0}}}", b.P); // B
            #if TEST_INTERFACE
                b.X = new XX();
                b.X.Test();
                b.X.TestTest();
                iiPtr=b.X as II;
                iiPtr.TestTest();
                b.X = new X();
                b.X.Test();
                b.X.TestTest();
                iiPtr = b.X as II;
                iiPtr.TestTest();
            #endif

            bPtrC.Test(); // B
            Console.WriteLine("bPtrC.P {{P: {0}}}", bPtrC.P); // B
            #if TEST_INTERFACE
                bPtrC.X = new XX();
                bPtrC.X.Test();
                bPtrC.X.TestTest();
                iiPtr = bPtrC.X as II;
                iiPtr.TestTest();
                bPtrC.X = new X();
                bPtrC.X.Test();
                bPtrC.X.TestTest();
                iiPtr = bPtrC.X as II;
                iiPtr.TestTest();
            #endif

            bPtrD.Test(); // B
            Console.WriteLine("bPtrD.P {{P: {0}}}", bPtrD.P); // B
            #if TEST_INTERFACE
                bPtrD.X = new XX();
                bPtrD.X.Test();
                bPtrD.X.TestTest();
                iiPtr = bPtrD.X as II;
                iiPtr.TestTest();
                bPtrD.X = new X();
                bPtrD.X.Test();
                bPtrD.X.TestTest();
                iiPtr = bPtrD.X as II;
                iiPtr.TestTest();
            #endif

            Console.WriteLine($"B {new string('-', 30)}");
            Console.WriteLine();
            Console.WriteLine($"C {new string('-', 30)}");

            C
                c = new C(),
                cPtrD = new D();

            c.Test(); // C
            Console.WriteLine("{{P: {0}}}", c.P); // C
            #if TEST_INTERFACE
                c.X = new XX();
                c.X.Test();
                c.X.TestTest();
                iiPtr = c.X as II;
                iiPtr.TestTest();
                c.X = new X();
                if (c.X != null)
                {
                    c.X.Test();
                    c.X.TestTest();
                }
                iiPtr = c.X as II;
                if (iiPtr != null)
                    iiPtr.TestTest();
            #endif

            cPtrD.Test(); // D
            Console.WriteLine("cPtrD.P {{P: {0}}}", cPtrD.P); // D
            #if TEST_INTERFACE
                cPtrD.X = new XX();
                cPtrD.X.Test();
                cPtrD.X.TestTest();
                cPtrD.X = new X();
                //cPtrD.X.Test();
                //cPtrD.X.TestTest();
            #endif

            Console.WriteLine($"C {new string('-', 30)}");
            Console.WriteLine();
            Console.WriteLine($"D {new string('-', 30)}");

            D
                d = new D();

            d.Test(); // D
            Console.WriteLine("{{P: {0}}}", d.P); // D
            #if TEST_INTERFACE
                d.X = new XX();
                d.X.Test();
                d.X.TestTest();
                d.X = new X();
                //d.X.Test();
                //d.X.TestTest();
            #endif

            Console.WriteLine($"D {new string('-', 30)}");
            Console.WriteLine();

            bool
                useNew = true;

			var
                tmpVar = useNew ? cPtrD : bPtrD;

            tmpVar.Test(); // B
            Console.WriteLine("{{P: {0}}}", tmpVar.P); // B
            Console.WriteLine();

	        var
		        tmpVarII = !useNew ? cPtrD : bPtrD;

			tmpVarII.Test(); // B
			Console.WriteLine("{{P: {0}}}", tmpVarII.P); // B
			Console.WriteLine();

            dynamic
                tmpDynamic;
            
            useNew = false;
            tmpDynamic = useNew ? cPtrD : bPtrD;
            tmpDynamic.Test(); // D
            Console.WriteLine("{{P: {0}}}", tmpDynamic.P); // D
            Console.WriteLine();

            useNew = true;
            tmpDynamic = useNew ? cPtrD : bPtrD;
            tmpDynamic.Test(); // D
            Console.WriteLine("{{P: {0}}}", tmpDynamic.P); // D
            Console.WriteLine();

            tmpDynamic = bPtrD;
            tmpDynamic.Test(); // D
            Console.WriteLine("{{P: {0}}}", tmpDynamic.P); // D
            Console.WriteLine();

            tmpDynamic = cPtrD;
            tmpDynamic.Test(); // D
            Console.WriteLine("{{P: {0}}}", tmpDynamic.P); // D
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

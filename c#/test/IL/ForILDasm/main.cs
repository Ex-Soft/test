#define TEST_STRING_LITERAL
//#define TEST_CALL_VALUE
//#define TEST_CALL_REFERENCE

//using System;

namespace ForILDasm
{
    class Program
    {
        //class A
        //{
        //    public string s;
        //}

        static void Main(string[] args)
        {
            #if TEST_STRING_LITERAL
                string str1 = "this is a string literal";
                string str2 = "this is a string literal";
            #endif
            #if TEST_CALL_VALUE
                int a = 1234;
                int b = 5678;
                int c = Add(a, b);
            #endif

            #if TEST_CALL_REFERENCE
                object o1 = new object();
                object o2;
                TestCallVoidReference(o1);
                o2 = TestCallObjectReference(o1); 
            #endif

            //var a= new A();
            //var b = a?.s?.Length;

            /*
            object
                a = new object(),
                b = new object();

            var result = ReferenceEquals(a, b);
            */
            /*string str = "aaa";
            Foo(str);*/
            /*decimal
                decimalVictimI = 1.123456789010000m,
                decimalVictimII = 1.12345678901m;

            string
                decimalVictimIStr = decimalVictimI.ToString(),
                decimalVictimIIStr = decimalVictimII.ToString();*/
        }

        /*static void Foo(string str)
        {
            
        }*/

        #if TEST_CALL_VALUE
            static int Add(int a, int b)
            {
                return a + b;
            }
        #endif

        #if TEST_CALL_REFERENCE
            static void TestCallVoidReference(object o)
            {
                o.ToString();
            }

            static object TestCallObjectReference(object o)
            {
                o.ToString();
                return o;
            }
        #endif
    }
}

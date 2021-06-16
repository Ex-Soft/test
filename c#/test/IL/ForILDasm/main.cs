#define TEST_DELEGATE
//#define TEST_STRING_LITERAL
//#define TEST_CALL_VALUE
//#define TEST_CALL_REFERENCE

using System;

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
            #if TEST_DELEGATE
                Action<int> actionInt = inp => System.Diagnostics.Debug.WriteLine(inp);
                
                // IL_0022: ldc.i4.s     13 // 0x0d
                // IL_0024: callvirt     instance void class [mscorlib]System.Action`1<int32>::Invoke(!0/*int32*/)
                actionInt(13);

                // if (action == null)
                //   return;
                // action(13);
                // IL_0030: ldc.i4.s     13 // 0x0d
                // IL_0032: callvirt     instance void class [mscorlib]System.Action`1<int32>::Invoke(!0/*int32*/)
                actionInt?.Invoke(13);
            #endif
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

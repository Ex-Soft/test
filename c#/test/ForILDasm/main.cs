using System;

namespace ForILDasm
{
    class Program
    {
        class A
        {
            public string s;
        }

        static void Main(string[] args)
        {
            var a= new A();
            var b = a?.s?.Length;

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
    }
}

#define USE_DYNAMIC

using System;
using System.Collections.Generic;

namespace InterfaceGenericII
{
    interface ISmth
    {
        void DoSmth<T>(T value);
    }

    class Smth : ISmth
    {
        public void DoSmth<T>(T value)
        {
            //DoSmthSmth(value);
            #if USE_DYNAMIC
                dynamic mv = value;
                DoSmthSmth(mv);
            #else
                if (value is string)
                    DoSmthSmth(value as string);
                else if(value is List<string>)
                    DoSmthSmth(value as List<string>);
                else if(value is Exception)
                    DoSmthSmth(value as Exception);
            #endif
        }

        void DoSmthSmth(string value)
        {
            System.Diagnostics.Debug.WriteLine("void DoSmthSmth(string value)");
        }

        void DoSmthSmth(List<string> value)
        {
            System.Diagnostics.Debug.WriteLine("void DoSmthSmth(List<string> value)");
        }

        void DoSmthSmth(Exception value)
        {
            System.Diagnostics.Debug.WriteLine("void DoSmthSmth(Exception value)");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISmth smth = new Smth();

            smth.DoSmth("string");
            smth.DoSmth(new List<string> { "l", "i", "s", "t" });
            smth.DoSmth(new Exception("exception"));
        }
    }
}

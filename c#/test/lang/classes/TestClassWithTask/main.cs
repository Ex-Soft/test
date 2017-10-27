using System;

namespace TestClassWithTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var classWithTask = new ClassWithTask(DateTime.Now);
            System.Diagnostics.Debug.WriteLine(classWithTask);
        }
    }
}

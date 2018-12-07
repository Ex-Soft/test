using System.Diagnostics;
using System.Reflection;

namespace TestPartialClass.Pure
{
    public partial class B
    {
        public int I1 { get; set; } = 1;

        public void Foo1()
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(): {nameof(I2)} = {I2}");
        }

        partial void Foo3()
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }

        partial void Foo4();

        public void Foo34()
        {
            Foo3();
            Foo4();
        }
    }
}

using System.Diagnostics;
using System.Reflection;

namespace TestPartialClass.Pure
{
    public partial class B
    {
        public int I2 { get; set; } = 2;

        public void Foo2()
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(): {nameof(I1)} = {I1}");
        }

        partial void Foo3();

        partial void Foo4()
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
        }
    }
}

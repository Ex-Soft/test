using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGetHashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int?
                tmpNullableInt1 = null,
                tmpNullableInt2 = 13;

            int
                hashCode1,
                hashCode2;

            hashCode1 = tmpNullableInt1.GetHashCode();

            hashCode1 = tmpNullableInt2.GetHashCode();
            hashCode2 = tmpNullableInt2.Value.GetHashCode();
        }
    }
}

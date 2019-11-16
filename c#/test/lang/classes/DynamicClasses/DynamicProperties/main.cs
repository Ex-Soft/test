using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTypeBuilder.CreateProperty(MyTypeBuilder.GetTypeBuilder(), "DynamicProperty1", typeof(string));
        }
    }
}

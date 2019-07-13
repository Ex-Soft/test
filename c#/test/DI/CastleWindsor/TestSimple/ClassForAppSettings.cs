using System.Diagnostics;
using System.Reflection;
using static System.Console;

namespace TestSimple
{
    public class ClassForAppSetting : IClassForAppSetting
    {
        public ClassForAppSetting(string value1, string value2)
        {
            string msg;
            Debug.WriteLine(msg = $"ClassForAppSetting{MethodBase.GetCurrentMethod().Name}({(value1 == null ? "null" : $"\"{value1}\"")}, {(value2 == null ? "null" : $"\"{value2}\"")})");
            WriteLine(msg);
        }
    }
}

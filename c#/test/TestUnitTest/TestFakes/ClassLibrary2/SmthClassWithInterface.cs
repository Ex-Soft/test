using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary2
{
    public class SmthClassWithInterface : ISmthInterface
    {
        public int Mul(int left, int right)
        {
            return left * right;
        }

        public int Div(int left, int right)
        {
            return left / right;
        }

        public List<T> GetList<T>() where T : class
        {
            var list = new List<object>
            {
                new ClassA("ClassA[0] (from SmthClassWithInterface)"),
                new ClassB("ClassB[0] (from SmthClassWithInterface)")
            };

            return list.OfType<T>().ToList();
        }
    }
}

using System.Collections.Generic;

namespace ClassLibrary2
{
    public interface ISmthInterface
    {
        int Mul(int left, int right);
        int Div(int left, int right);
        List<T> GetList<T>() where T : class;
    }
}

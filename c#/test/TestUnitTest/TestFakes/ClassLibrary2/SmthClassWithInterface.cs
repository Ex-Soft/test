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
    }
}

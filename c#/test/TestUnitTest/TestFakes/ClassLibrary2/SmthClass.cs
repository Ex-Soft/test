namespace ClassLibrary2
{
    public class SmthClass
    {
        public int Mul(ISmthInterface worker, int left, int right)
        {
            return worker.Mul(left, right);
        }

        public int Div(ISmthInterface worker, int left, int right)
        {
            return worker.Div(left, right);
        }
    }
}

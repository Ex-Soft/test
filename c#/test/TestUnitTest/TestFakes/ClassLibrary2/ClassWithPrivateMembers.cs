namespace ClassLibrary2
{
    public class ClassWithPrivateMembers
    {
        private int _privateFInt;
        private int PrivatePInt { get; set; }

        public ClassWithPrivateMembers(int fInt = 0, int pInt = 0)
        {
            _privateFInt = fInt;
            PrivatePInt = pInt;
        }

        private int Mul(int param)
        {
            _privateFInt *= param;
            PrivatePInt *= param;

            return _privateFInt * PrivatePInt;
        }
    }
}

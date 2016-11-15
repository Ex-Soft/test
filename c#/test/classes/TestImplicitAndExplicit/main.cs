namespace TestImplicitAndExplicit
{
    class IntExplicit
    {
        public int FInt;

        public IntExplicit(int fInt = 0)
        {
            System.Diagnostics.Debug.WriteLine("public IntExplicit(int fInt = {0})", fInt);
            FInt = fInt;
        }

        public static explicit operator DecimalExplicit(IntExplicit fIntExplicit)
        {
            System.Diagnostics.Debug.WriteLine("public static explicit operator DecimalExplicit(IntExplicit fIntExplicit = {0})", fIntExplicit);
            return new DecimalExplicit(fIntExplicit);
        }

        public override string ToString()
        {
            return string.Format("{{FInt: {0}}}", FInt);
        }
    }

    class IntImplicit
    {
        public int FInt;

        public IntImplicit(int fInt = 0)
        {
            System.Diagnostics.Debug.WriteLine("public IntImplicit(int fInt = {0})", fInt);
            FInt = fInt;
        }

       public override string ToString()
        {
            return string.Format("{{FInt: {0}}}", FInt);
        }
    }

    class DecimalExplicit
    {
        public decimal FDecimal;

        public DecimalExplicit(decimal fDecimal = 0)
        {
            System.Diagnostics.Debug.WriteLine("public DecimalExplicit(decimal fDecimal = {0})", fDecimal);
            FDecimal = fDecimal;
        }

        public DecimalExplicit(int fInt = 0)
        {
            System.Diagnostics.Debug.WriteLine("public DecimalExplicit(int fInt = {0})", fInt);
            FDecimal = fInt;
        }

        public DecimalExplicit(IntExplicit fIntExplicit)
        {
            System.Diagnostics.Debug.WriteLine("public DecimalExplicit(IntExplicit fIntExplicit = {0})", fIntExplicit);
            FDecimal = fIntExplicit.FInt;
        }
    }

    class DecimalImplicit
    {
        public decimal FDecimal;

        public DecimalImplicit(decimal fDecimal = 0)
        {
            System.Diagnostics.Debug.WriteLine("public DecimalImplicit(decimal fDecimal = {0})", fDecimal);
            FDecimal = fDecimal;
        }

        public DecimalImplicit(int fInt = 0)
        {
            System.Diagnostics.Debug.WriteLine("public DecimalImplicit(int fInt = {0})", fInt);
            FDecimal = fInt;
        }

        public DecimalImplicit(IntImplicit fIntImplicit)
        {
            System.Diagnostics.Debug.WriteLine("public DecimalImplicit(IntImplicit fIntImplicit = {0})", fIntImplicit);
            FDecimal = fIntImplicit.FInt;
        }

        public static implicit operator DecimalImplicit(IntImplicit fIntImplicit)
        {
            System.Diagnostics.Debug.WriteLine("public static implicit operator DecimalImplicit(IntImplicit fIntImplicit = {0})", fIntImplicit);
            return new DecimalImplicit(fIntImplicit);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tmpIntExplicit = new IntExplicit(13);

            DecimalExplicit
                tmpDecimalExplicit1 = new DecimalExplicit(13.13m),
                tmpDecimalExplicit2 = new DecimalExplicit(13),
                tmpDecimalExplicit3 = new DecimalExplicit(tmpIntExplicit),
                tmpDecimalExplicit4 = (DecimalExplicit)tmpIntExplicit;

            var tmpIntImplicit = new IntImplicit(13);

            DecimalImplicit
                tmpDecimalImplicit1 = new DecimalImplicit(13.13m),
                tmpDecimalImplicit2 = new DecimalImplicit(13),
                tmpDecimalImplicit3 = new DecimalImplicit(tmpIntImplicit),
                tmpDecimalImplicit4 = tmpIntImplicit;
        }
    }
}

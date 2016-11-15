namespace TestDelegateWithParameters
{
    class Base
    {
        public int FInt { get; set; }
    }

    class Derived : Base
    {}

    delegate int SmthDelegateWithBaseParam(Base param);
    delegate int SmthDelegateWithDerivedParam(Derived param);

    class Program
    {
        static void Main(string[] args)
        {
            SmthDelegateWithBaseParam smthDelegateWithBaseParamToSmthMethod = SmthMethod;
            SmthDelegateWithDerivedParam smthDelegateWithDerivedParamToSmthMethod = SmthMethod;

            smthDelegateWithBaseParamToSmthMethod(new Base { FInt = 13 });
            smthDelegateWithDerivedParamToSmthMethod(new Base {FInt = 13}); // Error 1 Delegate 'TestDelegateWithParameters.SmthDelegateWithDerivedParam' has some invalid arguments

        }

        static int SmthMethod(Base param)
        {
            return param.FInt;
        }
    }
}

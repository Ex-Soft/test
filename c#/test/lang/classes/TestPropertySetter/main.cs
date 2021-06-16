//#define TEST_AUTOPROPERTY
//#define TEST_CHANGE_VALUE_PROPERTY
#define TEST_SET_NEW_VALUE

namespace TestPropertySetter
{
    class A
    {
        int _property;

        public int AutoProperty { get; set; }

        public int Property
        {
            get { return _property; }
            set { _property = value; }
        }
    }

    #if !TEST_AUTOPROPERTY
        class B
        {
            A _a;

            public A A
            {
                get { return _a; }
                set
                {
                    _a = value;

                    #if TEST_CHANGE_VALUE_PROPERTY
                        value.AutoProperty *= 2;
                    #endif

                    #if TEST_SET_NEW_VALUE
                        value = new A {AutoProperty = 31};
                    #endif
                }
            }
        }
    #endif

    class Program
    {
        static void Main(string[] args)
        {
            #if !TEST_AUTOPROPERTY
                var a = new A {AutoProperty = 13};
                var b = new B();

                b.A = a;
            #endif
        }
    }
}

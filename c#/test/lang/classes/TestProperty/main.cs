#define TEST_SETTERS
using System;

namespace TestProperty
{
    #if TEST_SETTERS
    class Dictionary
    {
        public System.Collections.Generic.Dictionary<string, string> Properties { get; } = new System.Collections.Generic.Dictionary<string, string>();
    }

    class Wrapper
    {
        private readonly Dictionary _dictionary = new Dictionary();

        public int PInt
        {
            get
            {
                int value = default;
                if (_dictionary.Properties.TryGetValue("PInt", out var valueStr))
                    _ = int.TryParse(valueStr, out value);
                return value;
            }
            set
            {
                _dictionary.Properties["PInt"] = value.ToString();
            }
        }
    }

    class X
    {
        public int FInt { get; set; }
        public int FIntPrivate { get; private set; }
        public int FIntProtected { get; protected set; }

        public X(X obj) : this(obj.FInt, obj.FIntPrivate, obj.FIntProtected)
        {}

        public X(int fInt = default(int), int fIntPrivate = default(int), int fIntProtected = default(int))
        {
            FInt = fInt;
            FIntPrivate = fIntPrivate;
            FIntProtected = fIntProtected;
        }
    }

    class XX : X
    {
        public XX(XX obj) : this(obj.FInt, obj.FIntPrivate, obj.FIntProtected)
        {}

        public XX(int fInt = default(int), int fIntPrivate = default(int), int fIntProtected = default(int)) : base(fInt, fIntPrivate, fIntProtected)
        {
            FInt *= 2;
            FIntProtected *= 2;
        }
    }
    #endif

	class A
	{
		string
			_value;

	    int
	        _fInt1,
	        _fInt2;

		virtual public int FInt { get; set; }
		virtual public long FLong { get; set; }
		virtual public string FString { get; set; }
		virtual public DateTime FDateTime { get; set; }

		virtual public string Value
		{
			get
			{
				if (_value == null)
					_value = "get";

				return _value;
			}
		}

	    public int FInt1
	    {
	        get { return _fInt1; }
            set { _fInt1 = value; }
	    }

        public int FInt2
        {
            get
            {
                Console.WriteLine("A.FInt2.get()");

                return _fInt1 * _fInt2;
            }
            set
            {
                Console.WriteLine("A.FInt2.set()");

                if (_fInt2 != value)
                    _fInt2 = value;
            }
        }
    }

    class B
    {
        int
            _fInt;

        /*
        public B()
        {
            Console.WriteLine("B.B()");
        }
        */

        public B(int fInt=-1)
        {
            _fInt = fInt;
            Console.WriteLine("B.B(int fInt=-1)");
        }

        public int FInt
        {
            get
            {
                Console.WriteLine("B.FInt.get()");
                return _fInt;
            }
            set
            {
                Console.WriteLine("B.FInt.set()");
                if (_fInt != value)
                    _fInt = value;
            }
        }
    }

	class Program
	{
		static void Main(string[] args)
		{
            #if TEST_SETTERS
                var wrapper = new Wrapper { PInt = 13 };
                wrapper.PInt++;
                --wrapper.PInt;

                X
                    x1 = new X(),
                    x2 = new X(1,1,1),
                    x3 = new X(x2);

                x1.FInt = 10;

                XX
                    xx1 = new XX(),
                    xx2 = new XX(100, 100, 100),
                    xx3 = new XX(xx2);

                xx1.FInt *= 3;
            #endif

            B
                b1 = new B(),
                b2 = new B(123),
                b3 = new B() { FInt = 321 };

            Console.WriteLine(b1.FInt);
            Console.WriteLine(b2.FInt);
            Console.WriteLine(b3.FInt);

			A
				a = new A();

			if (a.FInt == 0)
				Console.WriteLine("0");
			if (a.FLong == 0)
				Console.WriteLine("0");
			if(a.FString==null)
				Console.WriteLine("null");
			if (a.FString != null && a.FString==string.Empty)
				Console.WriteLine("string.Empty");
			if(string.IsNullOrEmpty(a.FString))
				Console.WriteLine("string.IsNullOrEmpty");
			if(a.FDateTime==DateTime.MinValue)
				Console.WriteLine("DateTime.MinValue");

			Console.WriteLine(a.Value);
			Console.WriteLine(a.Value);

		    int
		        i = a.FInt2 = 10;

            Console.WriteLine(i);
		}
	}
}

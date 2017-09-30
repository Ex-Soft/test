//#define FROM_MSDN // http://msdn.microsoft.com/en-us/library/ms182331%28VS.80%29.aspx
//#define FROM_EL
//#define FROM_EL_1 // http://blogs.msdn.com/b/ericlippert/archive/2008/02/18/why-do-initializers-run-in-the-opposite-order-as-constructors-part-one.aspx
//#define FROM_EL_2 // http://blogs.msdn.com/b/ericlippert/archive/2008/02/18/why-do-initializers-run-in-the-opposite-order-as-constructors-part-two.aspx
//#define FROM_SO
#define FROM_DE

using System;
#if FROM_EL && FROM_EL_2
    using System.Collections;
#endif

namespace TestCallVirtInCtor
{
	#if FROM_DE
		public class Base
		{
		    private int _baseFiled;

		    private int _basePropertyHolder;

		    public int BaseProperty
		    {
		        get
		        {
                    System.Diagnostics.Debug.WriteLine("Base.get_BaseProperty()");
		            return _basePropertyHolder;
		        }
		        set
		        {
                    System.Diagnostics.Debug.WriteLine($"Base.set_BaseProperty({value})");
		            if (_basePropertyHolder != value)
		                _basePropertyHolder = value;
		        }
		    }

			public Base()
			{
				System.Diagnostics.Debug.WriteLine("Base.Base()");
				Init();
			}

			protected virtual void Init()
			{
				System.Diagnostics.Debug.WriteLine("Base.Init()");

			    _baseFiled = int.MaxValue;
			    BaseProperty = int.MaxValue;
			}
		}

		public class Derived : Base
		{
            private int _derivedFiled;

            private int _derivedPropertyHolder;

   		    public int DerivedProperty
        {
		        get
		        {
                    System.Diagnostics.Debug.WriteLine("Derived.get_DerivedProperty()");
		            return _derivedPropertyHolder;
		        }
		        set
		        {
                    System.Diagnostics.Debug.WriteLine($"Derived.set_DerivedProperty({value})");
		            if (_derivedPropertyHolder != value)
                        _derivedPropertyHolder = value;
		        }
		    }

			public Derived()
			{
				System.Diagnostics.Debug.WriteLine("Derived.Derived()");
			}

			protected override void Init()
			{
				base.Init();

				System.Diagnostics.Debug.WriteLine("Derived.Init()");
			    _derivedFiled = int.MaxValue;
			    DerivedProperty = int.MaxValue;
			}
		}
	#endif

    #if FROM_MSDN
        public class BadlyConstructedType
        {
            protected string initialized = "No";

            public BadlyConstructedType()
            {
                Console.WriteLine("Calling base ctor.");
                // Violates rule: DoNotCallOverridableMethodsInConstructors.
                DoSomething();
            }

            // This will be overridden in the derived type.
            public virtual void DoSomething()
            {
                Console.WriteLine("Base DoSomething");
            }
        }

        public class BadlyConstructedType2
        {
            protected string initialized = "No";

            public BadlyConstructedType2(string initialized)
            {
                this.initialized = initialized;
                Console.WriteLine("Calling base ctor.");
                // Violates rule: DoNotCallOverridableMethodsInConstructors.
                DoSomething();
            }

            // This will be overridden in the derived type.
            public virtual void DoSomething()
            {
                Console.WriteLine("Base DoSomething");
            }
        }

        public class DerivedType : BadlyConstructedType
        {
            public DerivedType()
            {
                Console.WriteLine("Calling derived ctor.");
                initialized = "Yes";
            }

            public override void DoSomething()
            {
                Console.WriteLine("Derived DoSomething is called - initialized ? {0}", initialized);
            }
        }

        public class DerivedType2 : BadlyConstructedType2
        {
            public DerivedType2() : this("Yes") { }
            public DerivedType2(string initialized) : base(initialized)
            {
                Console.WriteLine("Calling derived ctor.");
            }

            public override void DoSomething()
            {
                Console.WriteLine("Derived DoSomething is called - initialized ? {0}", initialized);
            }
        }
    #endif

    #if FROM_EL
        class Foo
        {
            public Foo(string s)
            {
                Console.WriteLine("Foo constructor: {0}", s);
            }
            public void Bar() { }
        }
    #endif

    #if FROM_EL && FROM_EL_1
        class Base
        {
            readonly Foo baseFoo = new Foo("Base initializer");
            public Base()
            {
                Console.WriteLine("Base constructor");
            }
        }

        class Derived : Base
        {
            readonly Foo derivedFoo = new Foo("Derived initializer");
            public Derived()
            {
                Console.WriteLine("Derived constructor");
            }
        } 
    #endif

    #if FROM_EL && FROM_EL_2
        class Base
        {
            public static ArrayList t = new ArrayList();
            public Base()
            {
                Console.WriteLine("Base constructor");
                if (this is Derived) (this as Derived).DoIt();
                // would deref null if we are constructing an instance of Derived
                Blah();
                // would deref null if we are constructing an instance of MoreDerived
                t.Add(this);
                // would deref null if another thread calls Base.t.GetLatest().Blah();
                // before derived constructor runs
            }
            public virtual void Blah() { }
        }

        class Derived : Base
        {
            readonly Foo derivedFoo = new Foo("Derived initializer");
            public void DoIt()
            {
                derivedFoo.Bar();
            }
        }

        class MoreDerived : Derived
        {
            public override void Blah() { DoIt(); }
        } 
    #endif

    #if FROM_SO
        class A 
        {
          public A()
          {
            Console.WriteLine("This is a {0},", GetType());
          }
        }

        class B : A
        {      
        }

        class Parent
        {
            public Parent()
            {
                DoSomething();
            }
            protected virtual void DoSomething() {}
        }

        class Child : Parent
        {
            private string foo;
            public Child() { foo = "HELLO"; }
            protected override void DoSomething()
            {
                Console.WriteLine(foo.ToLower());
            }
        }

    #endif

    class Program
    {
        static void Main(string[] args)
        {
			#if FROM_DE
				Derived derived = new Derived();
			#endif

            #if FROM_MSDN
                DerivedType derivedInstance = new DerivedType();
                Console.WriteLine();
                DerivedType2 derivedInstance2 = new DerivedType2();
            #endif

            #if FROM_EL && FROM_EL_1
                Derived derived = new Derived();
            #endif

            #if FROM_EL && FROM_EL_2
                Derived derived = new Derived();
            #endif

            #if FROM_SO
                B b = new B();
                Child child = new Child();
            #endif
        }
    }
}

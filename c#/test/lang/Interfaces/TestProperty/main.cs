using System;

namespace TestProperty
{
    public interface IProperty
    {
        int SmthProperty { get; set; }
    }

    public class A : IProperty
    {
        int _smthProperty;

        public A(int smthProperty=0)
        {
            _smthProperty = smthProperty;
        }

        public int SmthProperty
        {
            get
            {
                return _smthProperty;
            }
            set
            {
                if(_smthProperty != value)
                    _smthProperty = value;
            }
        }
    }

    public class B : IProperty
    {
        int _smthProperty;

        public B(int smthProperty=0)
        {
            _smthProperty = smthProperty;
        }

        public int SmthProperty
        {
            get
            {
                return _smthProperty;
            }
            set
            {
                if (_smthProperty != value)
                    _smthProperty = value;
            }
        }
    }

    public class C
    {
        readonly IProperty _property;

        public C(IProperty property=null)
        {
            _property = property;
        }

        public void Foo()
        {
            Console.WriteLine(_property.SmthProperty);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            C
                c1 = new C(new A(1)),
                c2 = new C(new B(10));

            c1.Foo();
            c2.Foo();
        }
    }
}

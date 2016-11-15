// http://haacked.com/archive/2013/01/11/hidden-pitfalls-with-object-initializers.aspx/
// http://sergeyteplyakov.blogspot.com/2012/05/using.html
// http://sergeyteplyakov.blogspot.com/2011/08/blog-post_15.html

#define PERSON_EXT

using System;

namespace TestObjectCollectionInitializers
{
#if !PERSON_EXT
    
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

#else

    class PersonExt
    {
        private string
            _name;

        private int
            _age;

        public PersonExt()
        {
            Console.WriteLine("PersonExt()");
            _name = string.Empty;
            _age = int.MinValue;
        }

        public PersonExt(PersonExt obj)
        {
            Console.WriteLine("PersonExt(obj)");
            _name = obj.Name;
            _age = obj.Age;
        }

        public PersonExt(string name="")
        {
            Console.WriteLine("PersonExt(name)");
            _name = name;
            _age = int.MinValue;
        }

        public PersonExt(string name="", int age=Int32.MinValue)
        {
            Console.WriteLine("Person(name, age)");
            _name = name;
            _age = age;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                Console.WriteLine("set_Name({0})", value);
                _name = value;
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                Console.WriteLine("set_Age({0})", value);
                _age = value;
            }
        }
    }

#endif

    class Program
    {
        static void Main(string[] args)
        {
#if !PERSON_EXT
            var person = new Person { Name = "Jonh", Age = 42 };
#else
            var person = new PersonExt { Name = "Jonh", Age = 42 };
#endif
            //Console.WriteLine("{0} {1}", person.Name, person.Age );
            var s = person.Name;
        }
    }
}

using System;
using System.Collections.Generic;

using static System.Console;

namespace TestMultiCall
{
    public class Class1
    {
        public string PString1 { get; set; }

        public override string ToString()
        {
            return $"{{PString1:\"{PString1}\"}}";
        }
    }

    public class Class2
    {
        public string PString1 { get; set; }

        public override string ToString()
        {
            return $"{{PString1:\"{PString1}\"}}";
        }
    }

    public class Container<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return $"{{Value:{Value}}}";
        }
    }

    public class Container1 : Container<Class1>
    {}

    public class Container2 : Container<Class2>
    {}

    public class Wrapper<T>
    {
        public T Entity { get; set; }

        public override string ToString()
        {
            return $"{{Entity:{Entity}}}";
        }
    }

    public class Wrapper1 : Wrapper<Container1>
    {}

    public class Wrapper2 : Wrapper<Container2>
    {}

    public class Creator
    {
        public T1 Create<T1, T2, T3>()
            where T1 : new()
            where T2 : new()
            where T3 : new()
        {
            T1 result = new T1();
            if (result is Wrapper<T2> wrapper)
            {
                wrapper.Entity = new T2();
                if (wrapper.Entity is Container<T3> container)
                {
                    container.Value = new T3();
                }
            }

            return result;
        }
    }

    public class SmthClass
    {
        private readonly Creator _creator = new Creator();

        public Wrapper1 GetWrapper1()
        {
            return Get(_creator.Create<Wrapper1, Container1, Class1>);
        }

        public Wrapper2 GetWrapper2()
        {
            return Get(_creator.Create<Wrapper2, Container2, List<Class2>>);
        }

        private static T Get<T>(Func<T> creator)
        {
            return creator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var smthClass = new SmthClass();
            var wrapper1 = smthClass.GetWrapper1();
            var wrapper2 = smthClass.GetWrapper2();
            WriteLine(wrapper1);
            WriteLine(wrapper2);
        }
    }
}

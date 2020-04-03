using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace TestAutoFixture
{
    public class ClassWithGettersAndSetters
    {
        public int PInt { get; set; }
        public string PString { get; set; }

        public ClassWithGettersAndSetters(int pInt = default, string pString = "")
        {
            PInt = pInt;
            PString = pString;
        }

        public ClassWithGettersAndSetters(ClassWithGettersAndSetters obj) : this(obj.PInt, obj.PString)
        {}
    }

    public class ClassWithGettersOnly
    {
        public int PInt { get; private set; }
        public string PString { get; private set; }

        public ClassWithGettersOnly(int pInt = default, string pString = "")
        {
            PInt = pInt;
            PString = pString;
        }

        public ClassWithGettersOnly(ClassWithGettersOnly obj) : this(obj.PInt, obj.PString)
        {}
    }

    public class ClassWithoutCtor
    {
        public int PInt { get; private set; }
        public string PString { get; private set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var _fixture = new Fixture();

            var classWithGettersAndSetters = _fixture.Create<ClassWithGettersAndSetters>();

            //_fixture.RepeatCount = 1000;

            List<int>
                listOfInt1 = _fixture.CreateMany<int>().ToList(),
                listOfInt2 = listOfInt1.Select(i => i).Distinct().ToList();

            var listOfClassWithGettersAndSetters = _fixture.CreateMany<ClassWithGettersAndSetters>().ToList();
            var listOfClassWithGettersOnly = _fixture.CreateMany<ClassWithGettersOnly>().ToList();
            var listOfClassWithoutCtor = _fixture.CreateMany<ClassWithoutCtor>().ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace TestIEnumerable
{
    class City
    {
        public string CityCode;
        public string CityName;
        public string CityPopulation;
    }

    class CityPlace
    {
        public string CityCode;
        public string Place;
    }

    class ClassForTestAggregate
    {
        string _fString;

        public string FString
        {
            get
            {
                Debug.WriteLine(string.Format("ClassForTestAggregate.get_FString() = \"{0}\"", _fString));
                return _fString;
            }
            set
            {
                Debug.WriteLine(string.Format("ClassForTestAggregate.set_FString(\"{0}\")", value));
                _fString = value;
            }
        }

        public ClassForTestAggregate(ClassForTestAggregate obj) : this(obj.FString)
        {}

        public ClassForTestAggregate(string fString = "")
        {
            _fString = fString;
        }

        public override string ToString()
        {
            return string.Format("{{FString:\"{0}\"}}", _fString);
        }
    }

    class A
    {
        public int FA { get; set; }
        public bool FB { get; set; }
        public bool FC { get; set; }

        public override string ToString()
        {
            return string.Format("{{FA:{0}, FB:{1}, FC:{2}}}", FA, FB, FC);
        }
    }

    class B
    {
        public List<A> LA { get; set; }

        public B() : this(new List<A>())
        {}

        public B(B obj) : this(obj.LA)
        {}

        public B(List<A> la)
        {
            LA = la;
        }
    }

    class C
    {
        public int FI { get; set; }
        public List<A> LA { get; set; }

        public C() : this(default(int), new List<A>())
        { }

        public C(C obj) : this(obj.FI, obj.LA)
        { }

        public C(int fi, List<A> la)
        {
            FI = fi;
            LA = la;
        }
    }

    class AA
    {
        public int FAA { get; set; }

        public AA(AA obj) : this(obj.FAA)
        {}

        public AA(int fAA = 0)
        {
            FAA = fAA;
        }

        public static bool operator ==(AA left, AA right)
        {
            return left.FAA == right.FAA;
        }

        public static bool operator !=(AA left, AA right)
        {
            return !(left.FAA == right.FAA);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            bool
                result = false;

            /*if (GetType() != obj.GetType())
                return result;*/

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Int32:
                    {
                        result = FAA == Convert.ToInt32(obj);
                        break;
                    }
                default:
                    {
                        result = this == (AA)obj;
                        break;
                    }
            }

            return result;
        }

        public override int GetHashCode()
        {
            return FAA.GetHashCode();
        }
    }

    class BB : AA, IComparable
    {
        public int FBB { get; set; }

        public BB(BB obj) : this(obj.FAA, obj.FBB)
        {}

        public BB(int fAA = 0, int fBB = 0) : base(fAA)
        {
            FBB = fBB;
        }

        public int CompareTo(object obj)
        {
            int
                result = -1;

            if (obj == null)
                return result;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Int32:
                    {
                        result = FAA.CompareTo(Convert.ToInt32(obj));
                        break;
                    }
                default:
                    {
                        result = FAA.CompareTo(((AA)obj).FAA);
                        break;
                    }
            }

            return (result);
        }
    }

    class CC : BB
    {
        public int FCC { get; set; }

        public CC(CC obj) : this(obj.FAA, obj.FBB, obj.FCC)
        {}

        public CC(int fAA = 0, int fBB = 0, int fCC=0) : base(fAA, fBB)
        {
            FCC = fCC;
        }
    }

    class AComparer : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.FA == y.FA;
        }

        public int GetHashCode(A a)
        {
            return a.FA.GetHashCode();
        }
    }

    class ClassWithNullableValues
    {
        public DateTime? fDateTime { get; set; }
        public long? fLong { get; set; }
    }

    class Program
    {
        static void Main()
        {
            List<bool> listOfBool = new List<bool> { true, true, true };
            bool tmpBool = listOfBool.Aggregate(true, (val, next) => { return val && next; });
            listOfBool = new List<bool> { true, false, true };
            tmpBool = listOfBool.Aggregate(true, (val, next) => { return val && next; });

            List<ClassWithNullableValues> listOfClassWithNullableValues = new List<ClassWithNullableValues>
            {
                new ClassWithNullableValues { fDateTime = null, fLong = null },
                new ClassWithNullableValues { fDateTime = DateTime.Now.Date, fLong = null },
                new ClassWithNullableValues { fDateTime = null, fLong = 9L },
                new ClassWithNullableValues { fDateTime = DateTime.Now.Date, fLong = 13L },
            };
            
            var testNullable = listOfClassWithNullableValues.Where(item => item.fDateTime == DateTime.Now.Date).ToArray();
            testNullable = listOfClassWithNullableValues.Where(item => item.fLong == 13L).ToArray();

            Dictionary<int, List<A>> dictionaryIntListOfA = new Dictionary<int, List<A>>
            {
                { 1, new List<A> { new A { FA = 1 } } },
                { 2, new List<A> { new A { FA = 1 }, new A { FA = 2 } } },
                { 3, new List<A> { new A { FA = 1 }, new A { FA = 2 }, new A { FA = 3 } } },
                { 4, new List<A> { new A { FA = 1 }, new A { FA = 1 }, new A { FA = 2 } } },
                { 5, new List<A> { new A { FA = 1 }, new A { FA = 2 }, new A { FA = 2 } } },
                { 6, new List<A> { new A { FA = 1 }, new A { FA = 1 }, new A { FA = 2 }, new A { FA = 2 } } }
            };
            
            var _equalsValues = dictionaryIntListOfA[4].GroupBy(a => a.FA).Where(g => g.Count() > 1).Select(g => g.ToList());

            foreach (List<A> _tmpA_ in _equalsValues)
                Console.WriteLine(_tmpA_.Count());

            _equalsValues = dictionaryIntListOfA[6].GroupBy(a => a.FA).Where(g => g.Count() > 1).Select(g => g.ToList());

            foreach (List<A> _tmpA_ in _equalsValues)
                Console.WriteLine(_tmpA_.Count());

            //var _equalsNodes = dictionaryIntListOfA.Where(item => item.Value.GroupBy(a => a.FA).Where(g => g.Count() > 1).Count() > 0);
            //var _equalsNodes = dictionaryIntListOfA.Where(item => item.Value.GroupBy(a => a.FA).Where(g => g.Count() > 1).Any());
            var _equalsNodes = dictionaryIntListOfA.Where(item => item.Value.GroupBy(a => a.FA).Any(g => g.Count() > 1));

            int[] tmpInts = null;
            int tmpInt;

            try
            {
                tmpInt = tmpInts.First(); // ArgumentNullException "Value cannot be null.\r\nParameter name: source"
                //tmpInt = tmpInts.FirstOrDefault(); // ArgumentNullException "Value cannot be null.\r\nParameter name: source"
            }
            catch (ArgumentNullException eException)
            {
                Debug.WriteLine("{0}: \"{1}\"", eException.GetType().FullName, eException.Message);
            }

            tmpInts = new int[0];

            try
            {
                tmpInt = tmpInts.First(); // InvalidOperationException "Sequence contains no elements"
                //tmpInt = tmpInts.FirstOrDefault(); // ok
            }
            catch (InvalidOperationException eException)
            {
                Debug.WriteLine("{0}: \"{1}\"", eException.GetType().FullName, eException.Message);
            }

            City[] cities =
            {
                new City{CityCode="0771",CityName="Raipur",CityPopulation="BIG"},
                new City{CityCode="0751",CityName="Gwalior",CityPopulation="MEDIUM"},
                new City{CityCode="0755",CityName="Bhopal",CityPopulation="BIG"},
                new City{CityCode="022",CityName="Mumbai",CityPopulation="BIG"},
            };

            CityPlace[] places =
            {
                new CityPlace{CityCode="0771",Place="Shankar Nagar"},
                new CityPlace{CityCode="0771",Place="Pandari"},
                new CityPlace{CityCode="0771",Place="Energy Park"},

                new CityPlace{CityCode="0751",Place="Baadaa"},
                new CityPlace{CityCode="0751",Place="Nai Sadak"},
                new CityPlace{CityCode="0751",Place="Jayendraganj"},
                new CityPlace{CityCode="0751",Place="Vinay Nagar"},

                new CityPlace{CityCode="0755",Place="Idgah Hills"},

                new CityPlace{CityCode="022",Place="Parel"},
                new CityPlace{CityCode="022",Place="Haaji Ali"},
                new CityPlace{CityCode="022",Place="Girgaon Beach"},

                new CityPlace{CityCode="0783",Place="Railway Station"}
            };

            var placesDoubles = places.GroupBy(item => item.CityCode).Where(g => g.Count() > 1).ToDictionary(g => g.Key, g => g.ToList());

            var query = places.GroupJoin(cities, place => place.CityCode, city => city.CityCode, (place, matchingCities) => new { place, matchingCities }).SelectMany(groupJoinItem => groupJoinItem.matchingCities.DefaultIfEmpty(new City { CityName = "NO NAME" }), (groupJoinItem, city) => new { Place = groupJoinItem.place, City = city });
            foreach (var pair in query)
                Console.WriteLine(pair.Place.Place + ": " + pair.City.CityName);

            List<A>
                listOfA = new List<A>(new[]
                {
                    new A() { FA = 1 },
                    new A() { FA = 2 },
                    new A() { FA = 3 }
                }),
                listOfAII = new List<A>(new[]
                {
                    new A() { FA = 1 },
                    new A() { FA = 3 }
                });

            var joinResult = listOfA.Join(listOfAII, outerKeySelector => outerKeySelector.FA, innerKeySelector => innerKeySelector.FA, (outerList, innerList) => new { OuterListFA = outerList.FA, InnerListFA = innerList.FA }).ToList();

            var leftJoinResult = listOfA.GroupJoin(listOfAII, outerKeySelector => outerKeySelector.FA, innerKeySelector => innerKeySelector.FA, (outerList, innerList) => new { OuterList = outerList.FA, InnerList = innerList.Select(a => a.FA) }).SelectMany(groupJoinItem => groupJoinItem.InnerList.DefaultIfEmpty(), (groupJoinItem, innerFA) => new { groupJoinItem.OuterList, innerFA } ).ToList();

            tmpInts = new[] { 1, 1, 1, 1, 1 };

            int[]
                tmpIntsII;

            tmpBool = tmpInts.Any(itemOuter => tmpInts.Any(itemInner => itemInner != itemOuter));
            tmpBool = tmpInts.Distinct().Count() != 1;
            tmpInts = new[] { 1, 2, 3, 4, 5 };
            tmpBool = tmpInts.Any(itemOuter => tmpInts.Any(itemInner => itemInner != itemOuter));
            tmpBool = tmpInts.Distinct().Count() != 1;

            A
                tmpA = new A() { FA = 1, FB = false, FC = false },
                tmpAII = new A() { FA = 2, FB = false, FC = false },
                tmpAIII = new A() { FA = 3, FB = false, FC = false };

            listOfA = new List<A>(new[] { tmpA, tmpAII, tmpAIII });
            listOfAII = new List<A>(new[] { tmpA, tmpAII, tmpAIII });

            Console.WriteLine("{0}listOfA.SequenceEqual(listOfAII)", !listOfA.SequenceEqual(listOfAII) ? "!" : string.Empty);
            Console.WriteLine("{0}listOfA.SequenceEqual(listOfAII, new AComparer())", !listOfA.SequenceEqual(listOfAII, new AComparer()) ? "!" : string.Empty);

            listOfAII = new List<A>(new[]
            {
                new A() {FA = 1, FB = false, FC = false},
                new A() {FA = 2, FB = false, FC = false},
                new A() {FA = 3, FB = false, FC = false}
            });

            Console.WriteLine("{0}listOfA.SequenceEqual(listOfAII)", !listOfA.SequenceEqual(listOfAII) ? "!" : string.Empty);
            Console.WriteLine("{0}listOfA.SequenceEqual(listOfAII, new AComparer())", !listOfA.SequenceEqual(listOfAII, new AComparer()) ? "!" : string.Empty);

            listOfAII = new List<A>(new[]
            {
                new A() {FA = 1, FB = false, FC = false},
                new A() {FA = 2, FB = false, FC = false},
                new A() {FA = 2, FB = true, FC = false},
                new A() {FA = 3, FB = false, FC = false},
                new A() {FA = 3, FB = true, FC = false},
                new A() {FA = 3, FB = true, FC = true}
            });

            var groupsOfA = listOfAII.GroupBy(a => a.FA);

            foreach (var group in groupsOfA)
            {
                Console.WriteLine("{0} {1} {2}", group.Key, group.Count(), group.Select(a => a.FB).Distinct().Aggregate(string.Empty, (str, next) => { if (!string.IsNullOrWhiteSpace(str)) str += ", "; return str + next.ToString(); }));
            }

            tmpInt = listOfA.Select(item => item.FB).Distinct().Count();

            tmpInts = new [] { 1, 3, 5, 3 };

            List<string>
                listOfString = tmpInts.OfType<string>().ToList(); // listOfString.Count == 0

            listOfString = tmpInts.Select(item => item.ToString(CultureInfo.InvariantCulture)).ToList();

            var groups = tmpInts.GroupBy(x => x).Where(g => g.Count() > 1);

            tmpInt = tmpInts.GroupBy(x => x).Where(g => g.Count() > 1).Count();

            List<object>
                listOfObjectsI = new List<object>(new[] { (object)1, 3, 5.5 });

            List<int>
                listOfIntsI;

            listOfIntsI = listOfObjectsI.OfType<int>().Distinct().ToList();

            tmpInts = new [] { 1, 3, 5 };
            tmpIntsII = new[] {2, 4, 5};

            int[]
                tmpIntsIII;

            tmpIntsIII = tmpInts.Except(tmpIntsII).ToArray(); // { 1, 3 }
            tmpIntsIII = tmpIntsII.Except(tmpInts).ToArray(); // { 2, 4 }
            tmpIntsIII = tmpInts.Concat(tmpIntsII).ToArray(); // { 1, 3, 5, 2, 4, 5 }
            tmpIntsIII = tmpInts.Concat(tmpIntsII).Distinct().ToArray(); // { 1, 3, 5, 2, 4 }
            tmpIntsIII = tmpInts.Concat(tmpIntsII.Except(tmpInts)).ToArray(); // { 1, 3, 5, 2, 4 }
            tmpIntsIII = tmpInts.Intersect(tmpIntsII).ToArray(); // { 5 }
            tmpIntsIII = tmpIntsII.Intersect(tmpInts).ToArray(); // { 5 }

            tmpIntsII = new int[0];
            tmpIntsIII = tmpInts.Intersect(tmpIntsII).ToArray(); // { }
            tmpIntsIII = tmpIntsII.Intersect(tmpInts).ToArray(); // { }
			tmpIntsIII = tmpInts.Except(tmpIntsII).ToArray(); // { 1, 3, 5 }
			tmpIntsIII = tmpIntsII.Except(tmpInts).ToArray(); // { }

            tmpInts = new[] { 1, 3, 5, 3, 1 };
            tmpIntsII = new[] { 3, 4, 5 };
            tmpIntsIII = tmpInts.Intersect(tmpIntsII).ToArray(); // { 3, 5 }
            tmpIntsIII = tmpIntsII.Intersect(tmpInts).ToArray(); // { 3, 5 }

            tmpIntsII = new[] { 3, 4, 3 };
            tmpIntsIII = tmpInts.Intersect(tmpIntsII).ToArray(); // { 3 }
            tmpIntsIII = tmpIntsII.Intersect(tmpInts).ToArray(); // { 3 }

            string[]
                tmpStrings = { "рАз", "ДвА", "тРи" },
                tmpStringsII = { "РаЗ", "дВа", "ТрИ" },
                tmpStringsIII;

            tmpStringsIII = tmpStrings.Intersect(tmpStringsII).ToArray();
            tmpStringsIII = tmpStrings.Intersect(tmpStringsII, StringComparer.CurrentCultureIgnoreCase).ToArray();

            listOfA = new List<A>();

            tmpBool = listOfA.All(a => !a.FB); // true
            tmpBool = listOfA.Any(a => !a.FB); //false

            List<List<A>>
                listOfListOfA = new List<List<A>>();

            tmpBool = listOfListOfA.Any(list => list.LongCount(a => a.FA == 11) > 0);

            listOfListOfA = new List<List<A>>(new List<A>[]
                {
                    new List<A>(),
                    new List<A>(),
                    new List<A>()
                });

            tmpBool = listOfListOfA.Any(list => list.LongCount(a => a.FA == 11) > 0);

            listOfListOfA = new List<List<A>>(new List<A>[]
                {
                    new List<A>(new A[] { new A() { FA = 1 }, new A() { FA = 2 }, new A() { FA = 3 } }),
                    new List<A>(new A[] { new A() { FA = 1 }, new A() { FA = 2 }, new A() { FA = 3 } }),
                    new List<A>(new A[] { new A() { FA = 1 }, new A() { FA = 2 }, new A() { FA = 3 } })
                });

            listOfA = listOfListOfA.SelectMany(list => list.Where(item => item.FA == 2)).ToList();

            long
                tmpLong = listOfListOfA[0].LongCount(a => a.FA == 1);

            tmpBool = listOfListOfA.Any(list => list.LongCount(a => a.FA == 11) > 0);
            tmpBool = listOfListOfA.Any(list => list.LongCount(a => a.FA == 1) > 0);

            List<AA>
                listOfAASrc = new List<AA>(new AA[] {new AA(), new BB(), new CC()}),
                listOfAA = new List<AA>(new AA[] { new AA(1), new BB(2), new CC(3) }),
                listOfAAII = new List<AA>(new AA[] { new AA(1), new BB(3), new CC(5) }),
                tmpListOfAA;

            tmpListOfAA = listOfAA.Intersect(listOfAAII).ToList();
            tmpListOfAA = listOfAA.Except(listOfAAII).ToList();

            List<BB>
                listOfBB = new List<BB>(new BB[] { new BB(1), new BB(2), new CC(3) }),
                listOfBBII = new List<BB>(new BB[] { new BB(5), new BB(3), new CC(1) }),
                tmpListOfBB,
                listOfBBCast,
                listOfBBOfType = listOfAASrc.OfType<BB>().ToList();

            tmpListOfBB = listOfBB.Intersect(listOfBBII).ToList();
            tmpListOfBB = listOfBB.Except(listOfBBII).ToList();
            tmpListOfBB = listOfBBII.OrderBy(i => i).ToList();

            try
            {
                listOfBBCast = listOfAASrc.Cast<BB>().ToList();
            }
            catch (InvalidCastException eException)
            {
                Console.WriteLine(eException.Message);
            }

            List<CC>
                listOfCCCast,
                listOfCCOfType = listOfAASrc.OfType<CC>().ToList();

            try
            {
                listOfCCCast = listOfAASrc.Cast<CC>().ToList();
            }
            catch (InvalidCastException eException)
            {
                Console.WriteLine(eException.Message);
            }

            listOfAASrc = new List<AA>();
            listOfCCOfType = listOfAASrc.OfType<CC>().Where(c => c.FAA == 1).ToList();

            tmpInt = listOfAASrc.OfType<CC>().Count(c => c.FAA == 1);

            try
            {
                tmpInt = listOfAASrc.OfType<CC>().Max(c => c.FCC);
            }
            catch (InvalidOperationException eException)
            {
                Console.WriteLine(eException.Message);
            }

            string
                tmpString = "1st 2nd 3rd 4th 5th";

            tmpStrings = tmpString.Split(' ');
            tmpString = tmpStrings.Aggregate((str, next) => {
                if (!string.IsNullOrEmpty(str))
                    str += ", ";
                return str += next;
            });

            tmpInts = new[] {1, 2, 3, 4, 5};
            tmpIntsII = new[] {1, 2, 3, 4, 5};

            tmpString = tmpInts.Aggregate(string.Empty, (str, next) => {
                if (!string.IsNullOrEmpty(str))
                    str += ", ";
                return str += next;
            });

            tmpIntsIII = (
                from i in tmpInts
                where i <= 2
                select i
            ).ToArray();

            tmpIntsIII = (
                from i in tmpInts
                where i <= 2
                select i
            ).Union(
                from i in tmpIntsII
                where i > 2
                select i
            ).ToArray();

            tmpIntsIII = (
                from i in tmpInts
                where i <= 4
                select i
            ).Union(
                from i in tmpIntsII
                where i > 2
                select i
            ).ToArray();

            tmpInt = tmpInts.Aggregate((sum, i) => sum + i);
            tmpInt = tmpInts.Aggregate(0, (total, next) => {
                Console.WriteLine("total: {0} next: {1}", total, next);
                return next % 2 == 0 ? total + 1 : total;
            });
            tmpInt = tmpInts.Aggregate(3, (biggest, i) => {
                Console.WriteLine("biggest: {0} i: {1}", biggest, i);
                return biggest > i ? biggest : i;
            }, b => {
                Console.WriteLine("b: {0}", b);
                return b*10;
            });

            listOfA = new List<A>(new[]
            {
                new A {FA = 1, FB = true, FC = false},
                new A {FA = 2, FB = true, FC = true},
                new A {FA = 3, FB = true, FC = false},
                new A {FA = 4, FB = true, FC = false}
            });

            listOfAII = new List<A>(new[]
            {
                new A {FA = 1, FB = true, FC = false},
                new A {FA = 3, FB = true, FC = false}
            });

            List<A>
                tmpListOfA;

            tmpListOfA = listOfA.Where(a => a.FA == 5).Where(a => a.FB).ToList();

            AComparer
                aComparer = new AComparer();

            tmpListOfA = listOfA.Intersect(listOfAII, aComparer).ToList();
            tmpListOfA = listOfA.Except(listOfAII, aComparer).ToList();

            Dictionary<int, bool>
                dictionaryOfA = listOfA.Select(e => new KeyValuePair<int, bool>(e.FA, e.FB)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (KeyValuePair<int, bool> kvp in dictionaryOfA)
                Console.WriteLine(string.Format("dictionaryOfA[{0}]=\"{1}\"", kvp.Key, kvp.Value));

            dictionaryOfA = (from e in listOfA select new {e.FA, e.FB}).ToDictionary(o => o.FA, o => o.FB);
            foreach (KeyValuePair<int, bool> kvp in dictionaryOfA)
                Console.WriteLine(string.Format("dictionaryOfA[{0}]=\"{1}\"", kvp.Key, kvp.Value));

            dictionaryOfA = listOfA.Select(e => new { e.FA, e.FB }).ToDictionary(o => o.FA, o => o.FB);
            foreach (KeyValuePair<int, bool> kvp in dictionaryOfA)
                Console.WriteLine(string.Format("dictionaryOfA[{0}]=\"{1}\"", kvp.Key, kvp.Value));

            tmpA = default(A);
            tmpA = listOfA.SingleOrDefault(i => i.FA == 3);
            tmpA = listOfA.SingleOrDefault(i => i.FA == 13);
            if(tmpA==default(A))
                Console.WriteLine("default(A)");

            List<int>
                tmpListOfIntII = new List<int>(/*new int[] { -1, 0, 1}*/);

            tmpIntsIII = tmpListOfIntII.ToArray();
            tmpBool = tmpIntsIII.All(i => i>0);
            tmpBool = tmpIntsIII.Any(i => i==0);
            tmpBool = listOfA.All(i => i.FB);
            tmpBool = listOfA.All(i => i.FC);
            tmpBool = listOfA.Any();
            tmpBool = listOfA.Any(i => i.FA>13);

            tmpListOfA = listOfA.Take(2).ToList();

            tmpInt = listOfA.Count();
            tmpInt = listOfA.Count(i=>!i.FC);
            tmpInt = listOfA.Where(i => i.FC).Select(i => i.FA).FirstOrDefault();

            listOfA = new List<A>(new A[]
		                            {
		                                new A {FA = 1, FB = true, FC = false},
                                        new A {FA = 2, FB = true, FC = true},
		                                new A {FA = 3, FB = true, FC = false},
                                        new A {FA = 4, FB = true, FC = false}
		                            });

            List<B>
                listOfB=new List<B>();

            listOfB.Add(new B(listOfA));
            listOfB.Add(new B(listOfA));
            listOfB.Add(new B(listOfA));

            List<int>
                listOfInt = listOfB.SelectMany(i => i.LA).Where(i => i.FC).Select(i => i.FA).ToList();

            var tmp = listOfB.SelectMany(i => i.LA).Select(ii => ii.FA);

            List<C>
                listOfC = new List<C>();

            listOfC.Add(new C(1, listOfA));
            listOfC.Add(new C(2, listOfA));
            listOfC.Add(new C(3, listOfA));
            listOfC.Add(new C(4, listOfA));

            var
                tmpList = from c in listOfC
                          select
                          new
                          {
                              c.FI,
                              IsSelected = c.LA.Any(a => a.FC)
                          };

            tmpListOfA = listOfA.Where(r => r.FC).ToList();

            IEnumerable<int>
                tmpListOfInt = Enumerable.Range(0, 10); // [0,1,2,3,4,5,6,7,8,9]

            IEnumerable<IEnumerable<int>>
                tmpListOfListOfInt = Enumerable.Repeat(tmpListOfInt, 100); // [[0,1,2,3,4,5,6,7,8,9],...,[0,1,2,3,4,5,6,7,8,9]]

            tmpListOfInt = tmpListOfListOfInt.SelectMany(x => x); // [0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,...,0,1,2,3,4,5,6,7,8,9] // 2D -> 1D

            IEnumerable<string>
                tmpListOfString = tmpListOfInt.Select(x => x.ToString()); // ["0","1","2","3","4","5","6","7","8","9",...,"0","1","2","3","4","5","6","7","8","9"]

            tmpString = tmpListOfString.ToString();
            tmpString = tmpListOfString.Aggregate((a, b) => a + b); // "01234566789...01234566789"

            tmpString = Enumerable.Repeat(Enumerable.Range(0, 10), 100).SelectMany(x => x).Select(x => x.ToString()).Aggregate((a, b) => a + b);

            tmpInts = new int[] {1, 2, 3, 4, 5};
            tmpIntsII = new int[] {1, 2, 3, 4, 5};
            tmpIntsIII = tmpInts.Zip(tmpIntsII, (first, second) => first * second).ToArray();

            List<DateTime>
                listOfDateTime =
                    new List<DateTime>(new[]
                                           {
                                               new DateTime(2013, 1, 15), new DateTime(2013, 1, 5),
                                               new DateTime(2013, 1, 14)
                                           });

            var _orderBy_ = listOfDateTime.OrderBy(x => x);
            var _select_ = _orderBy_.Select(x => x.ToShortDateString());
            // if list is empty System.InvalidOperationException is occured
            var _aggregate_ = _select_.Aggregate((str, next) =>
                                                     {
                                                         if (!string.IsNullOrEmpty(str))
                                                             str += "-";

                                                         return str + next;
                                                     });

            var __aggregate__ = _select_.Aggregate("", (str, next) =>
                                                       {
                                                           if (!string.IsNullOrEmpty(str))
                                                               str += "-";

                                                           return str + next;
                                                       });

            tmpString = listOfDateTime.OrderBy(x => x).Select(x => x.ToShortDateString()).Aggregate("", (str, next) =>
                                                                                    {
                                                                                        if (!string.IsNullOrEmpty(str))
                                                                                            str += "-";

                                                                                        return str + next;
                                                                                    });

            tmpString = listOfDateTime.OrderBy(x => x).Select(x => x.ToShortDateString()).Aggregate("", (str, next) =>
                                                                                                            {
                                                                                                                if (!string.IsNullOrEmpty(str))
                                                                                                                    str += "-";

                                                                                                                return str + next;
                                                                                                            },
                                                                                                            str =>
                                                                                                            {
                                                                                                                return str.Replace("-", "~");
                                                                                                            });

            var listOfClassForTestAggregate = new List<ClassForTestAggregate>
            {
                new ClassForTestAggregate("1st"),
                new ClassForTestAggregate("2nd"),
                new ClassForTestAggregate("3rd"),
                new ClassForTestAggregate("4th")
            };

            tmpString = listOfClassForTestAggregate.Aggregate("", (str, next) =>
            {
                if (string.IsNullOrWhiteSpace(next.FString))
                    return str;

                if (next.FString[0] - '0' > 2)
                    return str;

                return str += next.FString;
            });

            Console.WriteLine(tmpString);

            var xmlTree = XElement.Parse(
@"<Root>
    <Child>aaa<GrandChild anAttribute='xyz'>Text</GrandChild>
        <!--a comment-->
        <?xml-stylesheet type='text/xsl' href='test.xsl'?>
    </Child>
    <Child>ccc<GrandChild>Text</GrandChild>ddd</Child>
</Root>");
            var nodes =
                from node in xmlTree.Elements("Child").DescendantNodes()
                select node;

            foreach (var node in nodes)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.WriteLine("Element: {0}", ((XElement)node).Name);
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine("Text: {0}", ((XText)node).Value);
                        break;
                    case XmlNodeType.Comment:
                        Console.WriteLine("Comment: {0}", ((XComment)node).Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        Console.WriteLine("PI: {0}", ((XProcessingInstruction)node).Data);
                        break;
                }
            }
        }
    }
}

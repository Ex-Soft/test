// http://www.codedigest.com/Articles/CSHARP/84_Sorting_in_Generic_List.aspx

using System;
using System.Collections.Generic;

namespace TestListSort
{
    class TestClassIComparableFull : IComparable
    {
        public string
            FieldName;

        public object
            FieldValue;

        public TestClassIComparableFull() : this(string.Empty, null)
        {}

        public TestClassIComparableFull(TestClassIComparableFull aObj) : this(aObj.FieldName, aObj.FieldValue)
        {}

        public TestClassIComparableFull(string aFieldName, object aFieldValue)
        {
            FieldName = aFieldName;
            FieldValue = aFieldValue;
        }

        public static bool operator == (TestClassIComparableFull left, TestClassIComparableFull right)
        {
            return (left.FieldName == right.FieldName);
        }

        public static bool operator != (TestClassIComparableFull left, TestClassIComparableFull right)
        {
            return (!(left == right));
        }

        public static bool operator == (TestClassIComparableFull left, string right)
        {
            return (left.FieldName == right);
        }

        public static bool operator != (TestClassIComparableFull left, string right)
        {
            return (!(left == right));
        }

        public static bool operator == (string left, TestClassIComparableFull right)
        {
            return (left == right.FieldName);
        }

        public static bool operator != (string left, TestClassIComparableFull right)
        {
            return (!(left == right));
        }

        public override bool Equals(object obj)
        {
            bool
                result = false;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case System.TypeCode.String:
                    {
                        result = this.FieldName == Convert.ToString(obj);
                        break;
                    }
                default:
                    {
                        result = this == (TestClassIComparableFull)obj;
                        break;
                    }
            }

            return (result);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            int
                result = -1;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case System.TypeCode.String:
                    {
                        result = this.FieldName.CompareTo(Convert.ToString(obj));
                        break;
                    }
                default:
                    {
                        result = this.FieldName.CompareTo(((TestClassIComparableFull)obj).FieldName);
                        break;
                    }
            }

            return (result);
        }

        public override string ToString()
        {
            return ("{FiledName: \"" + FieldName + "\", FieldValue: " + FieldValue.ToString() + "}");
        }
    }

    class TestClassIComparable : IComparable
	{
		int
			_Value1,
			_Value2;

		public TestClassIComparable() : this(int.MinValue, int.MinValue)
		{}

		public TestClassIComparable(TestClassIComparable obj) : this(obj.Value1, obj.Value2)
		{}

		public TestClassIComparable(int aValue1, int aValue2)
		{
			_Value1 = aValue1;
			_Value2 = aValue2;
		}

		public virtual int Value1
		{
			get { return _Value1; }
			set { _Value1 = value; }
		}

		public virtual int Value2
		{
			get { return _Value2; }
			set { _Value2 = value; }
		}

		public override string ToString()
		{
			return string.Format("{{ Value1={0}, Value2={1} }}", Value1, Value2);
		}

		#region IComparable Members
		public int CompareTo(object obj)
		{
			int
				result = -1;

			switch (Type.GetTypeCode(obj.GetType()))
			{
				case System.TypeCode.Int32:
				{
					result = this.Value2.CompareTo(Convert.ToInt32(obj));
					break;
				}
				default:
				{
					result = this.Value2.CompareTo(((TestClassIComparable)obj).Value2);
					break;
				}
			}

			return result;
		}
		#endregion
	}

	class TestClassIComparableGeneric : IComparable<TestClassIComparableGeneric>, IComparable<int>
	{
		int
			_Value1,
			_Value2;

		public TestClassIComparableGeneric() : this(int.MinValue, int.MinValue)
		{}

		public TestClassIComparableGeneric(TestClassIComparableGeneric obj) : this(obj.Value1, obj.Value2)
		{}

		public TestClassIComparableGeneric(int aValue1, int aValue2)
		{
			_Value1 = aValue1;
			_Value2 = aValue2;
		}

		public virtual int Value1
		{
			get { return _Value1; }
			set { _Value1 = value; }
		}

		public virtual int Value2
		{
			get { return _Value2; }
			set { _Value2 = value; }
		}

		public override string ToString()
		{
			return string.Format("{{ Value1={0}, Value2={1} }}", Value1, Value2);
		}

		#region IComparable<TestClassWithGeneric> Members
		public int CompareTo(TestClassIComparableGeneric other)
		{
			return this.Value2.CompareTo(other.Value2);
		}
		#endregion

		#region IComparable<int> Members
		public int CompareTo(int other)
		{
			return this.Value2.CompareTo(other);
		}
		#endregion
	}

	class TestClass
	{
		int
			_Value1,
			_Value2;

		public TestClass() : this(int.MinValue, int.MinValue)
		{}

		public TestClass(TestClass obj) : this(obj.Value1, obj.Value2)
		{}

		public TestClass(int aValue1, int aValue2)
		{
			_Value1 = aValue1;
			_Value2 = aValue2;
		}

		public virtual int Value1
		{
			get { return _Value1; }
			set { _Value1 = value; }
		}

		public virtual int Value2
		{
			get { return _Value2; }
			set { _Value2 = value; }
		}

		public override string ToString()
		{
			return string.Format("{{ Value1={0}, Value2={1} }}", Value1, Value2);
		}

		public static int CompareValue2(TestClass obj1, TestClass obj2)
		{
			return obj1.Value2.CompareTo(obj2.Value2);
		}
	}

	class TestClassValue2Sort : IComparer<TestClass>
	{
		public int Compare(TestClass obj1, TestClass obj2)
		{
			return obj1.Value2.CompareTo(obj2.Value2);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<int>
				tmpListInt1 = new List<int>(new int[] { 5, 2, 9, 1 });

			Console.WriteLine("tmpListInt1:");
			tmpListInt1.ForEach((item) => { Console.WriteLine(item); });
			Console.WriteLine();

			tmpListInt1.Sort();
			Console.WriteLine("tmpListInt1:");
			tmpListInt1.ForEach((item) => { Console.WriteLine(item); });
			Console.WriteLine();

			List<TestClassIComparable>
				tmpListTestClassIComparable1 = new List<TestClassIComparable>(new TestClassIComparable[] {new TestClassIComparable(5,2),
																		new TestClassIComparable(2,5),
																		new TestClassIComparable(9,1),
																		new TestClassIComparable(1,9)});

			Console.WriteLine("tmpListTestClassIComparable1:");
			tmpListTestClassIComparable1.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			tmpListTestClassIComparable1.Sort();
			Console.WriteLine("tmpListTestClassIComparable1:");
			tmpListTestClassIComparable1.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			List<TestClassIComparableGeneric>
				tmpListTestClassIComparableGeneric1 = new List<TestClassIComparableGeneric>(new TestClassIComparableGeneric[] {new TestClassIComparableGeneric(5,2),
																											new TestClassIComparableGeneric(2,5),
																											new TestClassIComparableGeneric(9,1),
																											new TestClassIComparableGeneric(1,9)});

			Console.WriteLine("tmpListTestClassIComparableGeneric1:");
			tmpListTestClassIComparableGeneric1.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			tmpListTestClassIComparableGeneric1.Sort();
			Console.WriteLine("tmpListTestClassIComparableGeneric1:");
			tmpListTestClassIComparableGeneric1.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			List<TestClass>
				tmpListTestClass1 = new List<TestClass>(new TestClass[] {new TestClass(5,2),
																		new TestClass(2,5),
																		new TestClass(9,1),
																		new TestClass(1,9)});

			Console.WriteLine("tmpListTestClass1:");
			tmpListTestClass1.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			Comparison<TestClass> comp = new Comparison<TestClass>(TestClass.CompareValue2);
			tmpListTestClass1.Sort(comp);
			Console.WriteLine("tmpListTestClass1:");
			tmpListTestClass1.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			List<TestClass>
				tmpListTestClass2 = new List<TestClass>(new TestClass[] {new TestClass(5,2),
																		new TestClass(2,5),
																		new TestClass(9,1),
																		new TestClass(1,9)});

			Console.WriteLine("tmpListTestClass2:");
			tmpListTestClass2.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			TestClassValue2Sort sort1 = new TestClassValue2Sort();
			tmpListTestClass2.Sort(sort1);
			Console.WriteLine("tmpListTestClass2:");
			tmpListTestClass2.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			List<TestClass>
				tmpListTestClass3 = new List<TestClass>(new TestClass[] {new TestClass(5,2),
																		new TestClass(2,5),
																		new TestClass(9,1),
																		new TestClass(1,9)});

			Console.WriteLine("tmpListTestClass3:");
			tmpListTestClass3.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();

			TestClassValue2Sort sort2 = new TestClassValue2Sort();
			tmpListTestClass3.Sort(1,2,sort2);
			Console.WriteLine("tmpListTestClass3:");
			tmpListTestClass3.ForEach((item) => { Console.WriteLine(item.ToString()); });
			Console.WriteLine();
		}
	}
}

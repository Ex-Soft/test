using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TestSerializationI
{
    [DataContract]
	[Serializable]
	public class TestClass
    {
        [XmlElement(ElementName = "fIeLd3"), DataMember(Order = 1)]
        public string Field3;

		[XmlAttribute("Field1")]
		public string Field1;

		[XmlAttribute("Field2")]
		public string Field2;

		[XmlElement("in_ts"), DataMember(Order = 0)]
		public IntsList Ints;

        [DataMember(Order = 2)]
        public string Field4;

        public bool FieldBool;

        public decimal? FieldNullableDecimal;

        public TestClass() : this(string.Empty, string.Empty, string.Empty, string.Empty, null, false)
        {
            System.Diagnostics.Debug.WriteLine("TestClass.TestClass()");
        }

        public TestClass(TestClass obj) : this(obj.Field1, obj.Field2, obj.Field3, obj.Field4, obj.Ints, obj.FieldBool)
        {
            System.Diagnostics.Debug.WriteLine("TestClass.TestClass(TestClass)");
        }

        public TestClass(string Field1, string Field2, string Field3, string Field4, IntsList Ints, bool FieldBool)
		{
            System.Diagnostics.Debug.WriteLine("TestClass.TestClass(string, string, string, string, InsList, bool)");
			this.Field1 = Field1;
			this.Field2 = Field2;
            this.Field3 = Field3;
            this.Field4 = Field4;
		    this.FieldBool = FieldBool;
			this.Ints = new IntsList();

			if (Ints != null)
				Ints.ForEach((item) => { this.Ints.Add(item); });
		}
	}

	[Serializable]
	[XmlRoot("ints")]
	public class IntsList : List<int>
	{
		[XmlElement("int", typeof(int))]
		public List<int> Collection = new List<int>();

		public IntsList()
		{
		}
	}

	[Serializable]
	[XmlRoot("TestClassesList")]
	public class TestClassesList : List<TestClass>
	{
		public TestClassesList()
		{
		}
	}

    [Serializable]
    [XmlRoot("TestClassWithCollection")]
    public class TestClassWithCollection
    {
        public List<TestClass> Collection = new List<TestClass>();

        public TestClassWithCollection()
        {
            
        }
    }

    [Serializable]
    [XmlRoot("TestClassWithCollection")]
    public class TestClassWithCollectionAndAttribute
    {
        [XmlElement("Collect_ion")]
        public List<TestClass> Collection = new List<TestClass>();

        public TestClassWithCollectionAndAttribute()
        {

        }
    }
}

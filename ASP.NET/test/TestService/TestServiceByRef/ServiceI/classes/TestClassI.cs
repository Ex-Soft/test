using System.Xml;
using System.Xml.Serialization;

namespace ServiceI
{
	public class TestClassI
	{
		[XmlAttribute("FInt")]
		public virtual int FInt { get; set; }

		public TestClassI()
			: this(int.MinValue)
		{ }

		public TestClassI(TestClassI obj)
			: this(obj.FInt)
		{ }

		public TestClassI(int FInt)
		{
			this.FInt = FInt;
		}
	}
}
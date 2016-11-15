using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceI
{
	public class TestClassIContainer
	{
		[XmlElement("TestClassIContainer")]
		public List<TestClassI>
			container=new List<TestClassI>();

		public TestClassIContainer()
		{ }
	}
}
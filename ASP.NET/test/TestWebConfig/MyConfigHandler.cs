// http://www.sql.ru/forum/actualthread.aspx?bid=19&tid=358241

using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace TestWebConfig
{
	public class MyConfigHandler : IConfigurationSectionHandler
	{
		public MyConfigHandler()
		{}

		public object Create(object parent, object configContext, XmlNode section)
		{
			NameValueSection
				nvs = new NameValueSection();

			nvs.NVSparam1 = section.SelectSingleNode("MCHparam1key").InnerText;
			nvs.NVSparam2 = section.SelectSingleNode("MCHparam2key").InnerText;
			nvs.NVSparam3 = section.SelectSingleNode("MCHparam3key").InnerText;

			return nvs;
		}
	}

	public class NameValueSection
	{
		string
			_NVSparam1,
			_NVSparam2,
			_NVSparam3;

		public NameValueSection()
		{
			_NVSparam1 = _NVSparam2 = _NVSparam3 = string.Empty;
		}

		public string NVSparam1
		{
			get
			{
				return _NVSparam1;
			}
			set
			{
				_NVSparam1 = value;
			}
		}

		public string NVSparam2
		{
			get
			{
				return _NVSparam2;
			}
			set
			{
				_NVSparam2 = value;
			}
		}

		public string NVSparam3
		{
			get
			{
				return _NVSparam3;
			}
			set
			{
				_NVSparam3 = value;
			}
		}
	}

	public class MyConfigHandlerAdvanced : IConfigurationSectionHandler
	{
		public static List<MyConfigHandlerAdvancedEntry>
			MyConfigHandlerAdvancedEntries = (List<MyConfigHandlerAdvancedEntry>)ConfigurationManager.GetSection("MyConfigHandlerAdvanced");

		public object Create(object parent, object configContext, XmlNode section)
		{
			List<MyConfigHandlerAdvancedEntry>
				list = new List<MyConfigHandlerAdvancedEntry>();

			string
				MCHAparam1key,
				MCHAparam2key,
				MCHAparam3key;

			foreach (XmlNode node in section.ChildNodes)
			{
				if (node.Name == "add")
				{
					MCHAparam1key = node.Attributes["MCHAparam1key"].Value;
					MCHAparam2key = node.Attributes["MCHAparam2key"].Value;
					MCHAparam3key = node.Attributes["MCHAparam3key"].Value;
					list.Add(new MyConfigHandlerAdvancedEntry(MCHAparam1key, MCHAparam2key, MCHAparam3key));
				}
			}

			return list;
		}
	}

	public class MyConfigHandlerAdvancedEntry
	{
		string
			_MCHAparam1key,
			_MCHAparam2key,
			_MCHAparam3key;

		public MyConfigHandlerAdvancedEntry():this(string.Empty, string.Empty, string.Empty)
		{}

		public MyConfigHandlerAdvancedEntry(MyConfigHandlerAdvancedEntry obj):this(obj.MCHAparam1key, obj.MCHAparam2key, obj.MCHAparam3key)
		{}

		public MyConfigHandlerAdvancedEntry(string MCHAparam1key, string MCHAparam2key, string MCHAparam3key)
		{
			_MCHAparam1key = MCHAparam1key;
			_MCHAparam2key = MCHAparam2key;
			_MCHAparam3key = MCHAparam3key;
		}

		public string MCHAparam1key
		{
			get
			{
				return _MCHAparam1key;
			}
			set
			{
				_MCHAparam1key = value;
			}
		}

		public string MCHAparam2key
		{
			get
			{
				return _MCHAparam2key;
			}
			set
			{
				_MCHAparam2key = value;
			}
		}

		public string MCHAparam3key
		{
			get
			{
				return _MCHAparam3key;
			}
			set
			{
				_MCHAparam3key = value;
			}
		}
	}
}

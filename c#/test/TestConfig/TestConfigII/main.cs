using System.Collections;
using System.Configuration;

namespace TestConfigII
{
	class Program
	{
		static void Main(string[] args)
		{
			Hashtable
				singleTagSection = (Hashtable)ConfigurationManager.GetSection("SingleTagSection"),
                globalization = (Hashtable)ConfigurationManager.GetSection("globalization");

            string
				value;

			if (singleTagSection != null)
			{
				if (!string.IsNullOrEmpty(value = (string)singleTagSection["STSparam1key_"]))
				{
				}
			}

		    if (globalization != null)
		        value = (string)globalization["culture"];
		}
	}
}

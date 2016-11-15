using System;
using System.Collections;
using System.Configuration;

namespace TestConfigII
{
	class Program
	{
		static void Main(string[] args)
		{
			Hashtable
				SingleTagSection = (Hashtable)ConfigurationManager.GetSection("SingleTagSection");

			string
				Value;

			if (SingleTagSection != null)
			{
				if (!string.IsNullOrEmpty(Value = (string)SingleTagSection["STSparam1key_"]))
				{
				}
			}
		}
	}
}

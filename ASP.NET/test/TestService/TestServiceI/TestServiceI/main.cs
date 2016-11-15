//#define TEST_DO_SMTH_WITH_TEST_CLASS_SIMPLE_LOW
//#define TEST_HELO_WORD_LOW
//#define TEST_METHOD_WITHOUT_PARAMETERS_LOW
//#define USE_SERIALIZE

//#define TEST_BASIC_AUTHENTICATION

#define TEST_METHODS
//#define TEST_HELO_WORD
//#define TEST_DO_SMTH_WITH_TEST_CLASS_SIMPLE
#define TEST_DO_SMTH_WITH_TEST_CLASS
//#define TEST_SAVE_XML

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TestServiceI
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				#if TEST_METHODS
					ServiceI
						ServiceI = new ServiceI();

					#if TEST_HELO_WORD
						Console.WriteLine(ServiceI.HeloWord());
					#endif

					#if TEST_DO_SMTH_WITH_TEST_CLASS_SIMPLE
						TestClassSimple
							TestClassSimpleIn = new TestClassSimple(),
							TestClassSimpleOut;

						TestClassSimpleOut = ServiceI.DoSmthWithTestClassSimple(TestClassSimpleIn);
					#endif

					#if TEST_DO_SMTH_WITH_TEST_CLASS
						TestClass
							TestClassIn = new TestClass(),
							TestClassOut;

						TestClassIn.ListTestClassSimple = new TestClassSimple[] { new TestClassSimple() };

						TestClassOut = ServiceI.DoSmthWithTestClass(TestClassIn);
					#endif

					#if TEST_SAVE_XML
						bool
							Result=ServiceI.SaveXml("test", CreateXmlDocument());

						Console.WriteLine(Result.ToString().ToLower());
					#endif
				#elif TEST_BASIC_AUTHENTICATION
					TestBasicAuthentication();
				#elif TEST_HELO_WORD_LOW
					TestHeloWordLow();
				#elif TEST_DO_SMTH_WITH_TEST_CLASS_SIMPLE_LOW
					DoSmthWithTestClassSimpleLow();
				#elif TEST_METHOD_WITHOUT_PARAMETERS_LOW
					TestMethodWithoutParametersLow();
				#endif
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
			Console.ReadLine();
		}

		static XmlDocument CreateXmlDocument()
		{
			XmlDocument
				doc = new XmlDocument();

			XmlNode
				node = doc.CreateXmlDeclaration("1.0", "utf-8", null),
				RootNode;

			doc.AppendChild(node);

			RootNode = doc.CreateElement("TestClassSimple");
			doc.AppendChild(RootNode);

			node = doc.CreateElement("FInt");
			node.AppendChild(doc.CreateTextNode("1"));
			RootNode.AppendChild(node);

			node = doc.CreateElement("FDecimal");
			node.AppendChild(doc.CreateTextNode("1.1"));
			RootNode.AppendChild(node);

			node = doc.CreateElement("FDateTime");
			node.AppendChild(doc.CreateTextNode(DateTime.Now.ToString("o")));
			RootNode.AppendChild(node);

			node = doc.CreateElement("FString");
			node.AppendChild(doc.CreateTextNode("TestТест"));
			RootNode.AppendChild(node);

			return doc;
		}

		#if TEST_BASIC_AUTHENTICATION
			static void TestBasicAuthentication()
			{
				WebRequest
					request = WebRequest.Create(ConfigurationManager.AppSettings["URL"] + "/HeloWord");

				request.ContentType = "text/xml";
				request.Method = "POST";

				request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["username"] + ":" + ConfigurationManager.AppSettings["password"])));

				request.ContentLength = 0;

				WebResponse
					response = request.GetResponse();

				StreamReader
					sr = new StreamReader(response.GetResponseStream());

				string
					result = sr.ReadToEnd().Trim();

				XmlDocument
					doc = new XmlDocument();

				doc.LoadXml(result);

				XmlNodeList
					nodes = doc.GetElementsByTagName("string");

				for (int i = 0; i < nodes.Count; ++i)
					Console.WriteLine(nodes[i].FirstChild.Value);
			}
		#endif

		#if TEST_HELO_WORD_LOW
			static void TestHeloWordLow()
			{
				WebRequest
					request = WebRequest.Create(ConfigurationManager.AppSettings["URL"] + "/HeloWord");

				request.ContentType = "text/xml";
				request.Method = "POST";

				request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("sms-user:_KtybyUhfl_")));

				request.ContentLength = 0;

				WebResponse
					response = request.GetResponse();

				StreamReader
					sr = new StreamReader(response.GetResponseStream());

				string
					result = sr.ReadToEnd().Trim();

				XmlDocument
					doc = new XmlDocument();

				doc.LoadXml(result);

				XmlNodeList
					nodes = doc.GetElementsByTagName("string");

				for (int i = 0; i < nodes.Count; ++i)
					Console.WriteLine(nodes[i].FirstChild.Value);
			}
		#endif

		#if TEST_DO_SMTH_WITH_TEST_CLASS_SIMPLE_LOW
			static void DoSmthWithTestClassSimpleLow()
			{
				WebRequest
					request = WebRequest.Create(ConfigurationManager.AppSettings["URL"] + "/DoSmthWithTestClassSimple");

				request.ContentType = "text/xml";
				request.Method = "POST";

				request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("sms-user:_KtybyUhfl_")));

				XmlDocument
					doc = CreateXmlDocument();

				byte[]
					bytes = System.Text.Encoding.UTF8.GetBytes(doc.InnerXml);

				request.ContentLength = bytes.Length;

				Stream
					os = request.GetRequestStream();

				os.Write(bytes, 0, bytes.Length);
				os.Close();
								
				WebResponse
					response = request.GetResponse();

				StreamReader
					sr = new StreamReader(response.GetResponseStream());

				string
					result = sr.ReadToEnd().Trim();

				doc = new XmlDocument();
				doc.LoadXml(result);

				XmlNodeList
					nodes = doc.GetElementsByTagName("string");

				for (int i = 0; i < nodes.Count; ++i)
					Console.WriteLine(nodes[i].FirstChild.Value);
			}
		#endif

		#if TEST_METHOD_WITHOUT_PARAMETERS_LOW
			static void TestMethodWithoutParametersLow()
			{
				WebRequest
					request = WebRequest.Create(ConfigurationManager.AppSettings["URL"] + "/MethodWithoutParameters?param=ParamValue");

				request.ContentType = "text/xml";
				request.Method = "POST";

				XmlDocument
					doc = CreateXmlDocument();

				byte[]
					bytes = System.Text.Encoding.UTF8.GetBytes(doc.InnerXml);

				request.ContentLength = bytes.Length;

				Stream
					os = request.GetRequestStream();

				os.Write(bytes, 0, bytes.Length);
				os.Close();

				WebResponse
					response = request.GetResponse();

				StreamReader
					sr = new StreamReader(response.GetResponseStream());

				#if !USE_SERIALIZE
					string
						result = sr.ReadToEnd().Trim();

					doc = new XmlDocument();
					doc.LoadXml(result);

					XmlNodeList
						nodes = doc.GetElementsByTagName("TestClassSimple");

					for (int i = 0; i < nodes.Count; ++i)
						for (int j = 0; j < nodes[i].ChildNodes.Count; ++j)
							Console.WriteLine("\"{0}\"=\"{1}\"", nodes[i].ChildNodes[j].Name, nodes[i].ChildNodes[j].FirstChild.Value);
				#else
					TestClassSimple
						TestClassSimple=new TestClassSimple();

					XmlSerializer
						XmlSerializer = new XmlSerializer(TestClassSimple.GetType());

					TestClassSimple.FInt = 999;
					TestClassSimple.FDecimal = 999.99m;
					TestClassSimple.FDateTime = DateTime.Now;
					TestClassSimple.FString = "Test Тест";

					string
						FileName = Path.GetFullPath(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "TestClassSimple.xml");

					if (File.Exists(FileName))
						File.Delete(FileName);

					StreamWriter
						sw = new StreamWriter(FileName, false, Encoding.UTF8);

					XmlSerializer.Serialize(sw, TestClassSimple);
					sw.Close();

					FileName = Path.GetFullPath(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "TestClassSimpleFromService.xml");

					StreamReader
						StreamReader = new StreamReader(FileName, Encoding.UTF8);

					TestClassSimple = new TestClassSimple();
					TestClassSimple = (TestClassSimple)XmlSerializer.Deserialize(StreamReader);

					TestClassSimple = new TestClassSimple();
					TestClassSimple = (TestClassSimple)XmlSerializer.Deserialize(sr);
				#endif
			}
		#endif
	}
}

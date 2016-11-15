//#define TEST_BASIC_AUTHENTICATION

using System;
using System.Collections.Generic;
using System.Web.Services;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

#if TEST_BASIC_AUTHENTICATION
   using System;
   using System.Configuration;
#endif

namespace TestServiceI
{
	/// <summary>
	/// Summary description for ServiceI
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class ServiceI : System.Web.Services.WebService
	{
		#if TEST_BASIC_AUTHENTICATION
			public ServiceI()
			{
				string
					configUsername = ConfigurationManager.AppSettings["username"],
					configPassword = ConfigurationManager.AppSettings["password"];

				if (!string.IsNullOrEmpty(configUsername))
				{
					string
						requestUsername,
						requestPassword;

					try
					{
						string
							userAndPassEncoded = this.Context.Request.Headers["Authorization"].Substring(6),
							userAndPassDecoded = new System.Text.ASCIIEncoding().GetString(Convert.FromBase64String(userAndPassEncoded));

						string[]
							userAndPasswordArray = userAndPassDecoded.Split(':');

						requestUsername = userAndPasswordArray[0];
						requestPassword = userAndPasswordArray[1];
					}
					catch (Exception eException)
					{
						throw new ApplicationException("Unable to get the Basic Authentication credentials from the request", eException);
					}

					if (configUsername != requestUsername || configPassword != requestPassword)
						throw new ApplicationException("You are not authorized to access this web service");
				}
			}
		#endif

		[WebMethod]
		public string HeloWord()
		{
			return "Helo, word!";
		}

		[WebMethod]
		public TestClassSimple DoSmthWithTestClassSimple(TestClassSimple TestClassSimple)
		{
			TestClassSimple
				OutputTestClassSimple = new TestClassSimple();

			Context.Request.InputStream.Seek(0, SeekOrigin.Begin);

			StreamReader
				StreamReader = new StreamReader(Context.Request.InputStream, Encoding.UTF8);

			string
				tmpString = StreamReader.ReadToEnd().Trim();

			return OutputTestClassSimple;
		}

		[WebMethod]
		public TestClass DoSmthWithTestClass(TestClass TestClass)
		{
			TestClass
				OutputTestClass = new TestClass();

			OutputTestClass.ListTestClassSimple = new List<TestClassSimple>(new TestClassSimple[] { new TestClassSimple() });

			return OutputTestClass;
		}

		[WebMethod]
		public bool SaveXml(string name, XmlDocument XmlBody)
		{
			bool
				Result = false;

			string
				XmlFileName;

			if (File.Exists(XmlFileName = Server.MapPath(null) + Path.DirectorySeparatorChar + name + ".xml"))
				File.Delete(XmlFileName);

			XmlBody.Save(XmlFileName);

			Result = true;

			return Result;
		}

		[WebMethod]
		public TestClassSimple MethodWithoutParameters()
		{
			TestClassSimple
				InputTestClassSimple = new TestClassSimple(),
				OutputTestClassSimple = new TestClassSimple();

			try
			{
				string
					param = Context.Request.QueryString["param"];

				StreamReader
					StreamReader = new StreamReader(Context.Request.InputStream, Encoding.UTF8);

				XmlSerializer
					XmlSerializer = new XmlSerializer(InputTestClassSimple.GetType());

				InputTestClassSimple = (TestClassSimple)XmlSerializer.Deserialize(StreamReader);

				int
					delta = 100;

				OutputTestClassSimple.FInt = InputTestClassSimple.FInt * delta;
				OutputTestClassSimple.FDecimal = InputTestClassSimple.FDecimal * delta;
				OutputTestClassSimple.FDateTime = InputTestClassSimple.FDateTime.AddYears(delta);
				OutputTestClassSimple.FString = InputTestClassSimple.FString + " " + InputTestClassSimple.FString + (!string.IsNullOrEmpty(param) ? " \"" + param + "\"" : string.Empty);
			}
			catch (Exception eException)
			{
				OutputTestClassSimple.FString = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace;
			}

			return OutputTestClassSimple;
		}

        [WebMethod]
        public void GetFile()
        {
            string fileName = "Incoming_RCC.docx";
            byte[] file = File.ReadAllBytes(fileName);
            Context.Response.Clear();
            Context.Response.ClearHeaders();
            Context.Response.ClearContent();
            Context.Response.ContentType = "application/ms-word";
            Context.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Context.Response.AddHeader("Content-Length", file.Length.ToString());
            Context.Response.OutputStream.Write(file, 0, file.Length);
            Context.Response.Flush();
            Context.Response.Close();
            Context.Response.End();
        }
	}
}

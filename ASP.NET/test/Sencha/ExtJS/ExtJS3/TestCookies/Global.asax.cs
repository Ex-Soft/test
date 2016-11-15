using System;

namespace TestCookies
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			log4net.Config.XmlConfigurator.Configure();
		}
	}
}
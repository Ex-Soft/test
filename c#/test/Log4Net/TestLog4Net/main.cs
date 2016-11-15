// http://megadarja.blogspot.com/2008/04/log4net.html

using System;
using log4net;

namespace TestLog4Net
{
	class Program
	{
		static void Main(string[] args)
		{
			log4net.Config.XmlConfigurator.Configure();

			ILog
				//log = LogManager.GetLogger(typeof(Program));
				//log = LogManager.GetLogger("System");
				log = LogManager.GetLogger("NHibernate");

			log.Info("log.Info Test");
			log.InfoFormat("log.InfoFormat Key={0}, Value={1}", "Key", "Value");
			log.Debug("log.Debug Test");
			log.DebugFormat("log.DebugFormat Key={0}, Value={1}", "Key", "Value");
			log.Warn("log.Warn Test");
			log.WarnFormat("log.WarnFormat Key={0}, Value={1}", "Key", "Value");
			log.Error("log.Error Test");
			log.ErrorFormat("log.ErrorFormat Key={0}, Value={1}", "Key", "Value");
			log.Fatal("log.Fatal Test");
			log.FatalFormat("log.FatalFormat Key={0}, Value={1}", "Key", "Value");
			

			try
			{
				int
					a = 0,
					b = 0,
					c = 0;

				a = b / c;
			}
			catch (Exception e)
			{
				log.Error("Exception catched while calculation.", e);
			}
		}
	}
}

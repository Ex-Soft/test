using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WriterLateByPort
{
	class Program
	{
		static void Main(string[] args)
		{
			const string
				ServiceManagerIDStr = "com.sun.star.ServiceManager",
				UnoUrlResolverIDStr = "com.sun.star.bridge.UnoUrlResolver",
				DesktopIDStr = "com.sun.star.frame.Desktop";

			object
				ServiceManager = null,
				Desktop = null;

			try
			{
				try
				{
					Type
						ServiceManagerType;

					if ((ServiceManagerType = Type.GetTypeFromProgID(ServiceManagerIDStr)) != null)
					{
						try
						{
							if ((ServiceManager = Activator.CreateInstance(ServiceManagerType)) == null)
								throw (new Exception("Can't create instance of \"" + ServiceManagerIDStr + "\""));

							if ((Desktop = ServiceManager.GetType().InvokeMember("createInstance", BindingFlags.InvokeMethod, null, ServiceManager, new object[] { DesktopIDStr })) == null)
								throw (new Exception("Can't create instance of \"" + DesktopIDStr + "\""));
						}
						catch (Exception eException)
						{
							throw (new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
						}
					}
					else
						throw (new Exception("Can't GetTypeFromProgID(\"" + ServiceManagerIDStr + "\")"));
				}
				catch (Exception eException)
				{
					throw (new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
				}
			}
			finally
			{
				if (Desktop != null)
				{
					Desktop.GetType().InvokeMember("terminate", BindingFlags.InvokeMethod, null, Desktop, null);
					Marshal.ReleaseComObject(Desktop);
					Desktop = null;
				}
				if (ServiceManager != null)
				{
					Marshal.ReleaseComObject(ServiceManager);
					ServiceManager = null;
				}
			}
		}
	}
}

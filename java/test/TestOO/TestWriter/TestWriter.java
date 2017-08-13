public class TestWriter
{
	public static void main(String[] args)
	{
		try
		{
			com.sun.star.uno.XComponentContext
				xContext=null;

			try
			{
				xContext=com.sun.star.comp.helper.Bootstrap.bootstrap();
			}
			catch(com.sun.star.comp.helper.BootstrapException e)
			{
				System.out.println("com.sun.star.comp.helper.BootstrapException");
				e.printStackTrace(System.err);
			}

			if(xContext!=null)
			{
				System.out.println("xContext");

				com.sun.star.lang.XMultiComponentFactory
					ServiceManager=null;

				if((ServiceManager=xContext.getServiceManager())!=null)
				{
					System.out.println("ServiceManager");

					com.sun.star.uno.XDesktop
						xDesktop=null;

					if((xDesktop=ServiceManager.createInstance("com.sun.star.frame.Desktop"))!=null)
					{
						System.out.println("xDesktop");
					}
					else
						System.out.println("!xDesktop");
				}
				else
					System.out.println("!ServiceManager");
			}
			else
				System.out.println("!xContext");
		}/*
		catch(java.lang.Exception e)
		{
			System.out.println("catch java.lang.Exception");
			e.printStackTrace();
		}*/
		catch(Exception e)
		{
			System.out.println("catch Exception");
			e.printStackTrace(System.err);
		}
		catch(Throwable e)
		{
			System.out.println("catch Throwable");
			e.printStackTrace(System.err);
		}
		finally
		{
			System.out.println("finally");
			System.exit(0);
		}
	}
}


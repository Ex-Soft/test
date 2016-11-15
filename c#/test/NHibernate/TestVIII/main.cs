using System;
//using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace TestVIII
{
	class Program
	{
		static ISessionFactory
			SessionFactory;

		static void Main(string[] args)
		{
			try
			{
				using (ISession session = OpenSession())
				{
					IQuery
						query;

					query = session.GetNamedQuery("CallTestProcedure");
					query.SetParameter("arg", 99);

					Dual
						result = query.UniqueResult<Dual>();

				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		static ISession OpenSession()
		{
			if (SessionFactory == null)
			{
				Configuration
					configuration = new Configuration();

				configuration.AddAssembly(Assembly.GetCallingAssembly());
				SessionFactory = configuration.BuildSessionFactory();
			}

			return SessionFactory.OpenSession();
		}
	}
}

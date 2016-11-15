using System;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

// http://nhforge.org/blogs/nhibernate/archive/2009/04/10/nhibernate-mapping-inheritance.aspx

namespace TestXI
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
						query = session.CreateQuery("from Party");

					query.List();

					using (ITransaction transaction = session.BeginTransaction())
					{
						//session.CreateCriteria(typeof(Party)).List();
						//session.CreateCriteria(typeof(Company)).List();
						//session.CreateCriteria(typeof(Person)).List();
						transaction.Commit();
					}
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

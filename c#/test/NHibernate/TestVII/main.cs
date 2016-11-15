using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace TestVII
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
					Master
						tmpMaster = session.Get<Master>(5);

					if (tmpMaster != null)
						NHibernateUtil.Initialize(tmpMaster.Details);

					IQuery
						query;

					query = session.CreateQuery("select m from Master m where m.Id=:ID");
					query.SetParameter("ID", 5);
					tmpMaster = query.UniqueResult<Master>();
					if (tmpMaster != null)
						NHibernateUtil.Initialize(tmpMaster.Details);

					query = session.CreateQuery("select m from Master m where m.Id in (:ID)");
					query.SetParameterList("ID", new object[] { 1, 3, 5 });

					IList<Master>
						MasterRecords = query.List<Master>();

					foreach (Master m in MasterRecords)
					{
						NHibernateUtil.Initialize(m.Details);

						Console.WriteLine();
						Console.WriteLine("{0}\t{1}", m.Id, m.Val);
						foreach (Detail d in m.Details)
						{
							Console.WriteLine("\t{0}\t{1}\t{2}", d.Master.Id, d.Id, d.Val);
						}
						Console.WriteLine();
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
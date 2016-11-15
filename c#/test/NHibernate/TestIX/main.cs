using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace TestIX
{
	class TestGood
	{
		public virtual int g_id { get; set; }
		public virtual decimal price { get; set; }
	}

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
					Type
						t = typeof(NHibernate.Connection.DriverConnectionProvider);

					PropertyInfo
						pi = t.GetProperty("ConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);

					string connectionString = (string)pi.GetValue(((NHibernate.Impl.SessionFactoryImpl)(session.SessionFactory)).ConnectionProvider /*session.SessionFactory.ConnectionProvider*/, null);

					IQuery
						query;

					query = session.CreateSQLQuery("select goodsutil.getgoodpropnumbyfs(:g_id, :price_id, :fs_id) as price from dual");
					query.SetParameter("g_id", 5619974);
					query.SetParameter("price_id", 10290);
					query.SetParameter("fs_id", 2000);

					object
						tmpObject;

					decimal
						tmpDecimal = (tmpObject = query.UniqueResult()) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToDecimal(tmpObject) : 0m;

					ISQLQuery
						SQLquery=session.CreateSQLQuery("select goodsutil.getgoodpropnumbyfs(:g_id, :price_id, :fs_id) as price from dual");

					SQLquery.SetParameter("g_id", 5619974);
					SQLquery.SetParameter("price_id", 10290);
					SQLquery.SetParameter("fs_id", 2000);
					//SQLquery.AddScalar("price", NHibernateUtil.Decimal);
					tmpDecimal = (tmpObject = SQLquery.UniqueResult()) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToDecimal(tmpObject) : 0m;

					query = session.GetNamedQuery("NamedQuery1");
					query.SetParameterList("goodId", new List<int>(new int[] { 3032803, 5619974 }));
					query.SetParameter("price_id", 10290);
					query.SetParameter("fs_id", 2000);

					List<TestGood>
						tmlList = (List<TestGood>)query.List<TestGood>();
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

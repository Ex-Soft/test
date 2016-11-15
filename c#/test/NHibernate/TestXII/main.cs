using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;

namespace TestXII
{
	public class Staff
	{
		public virtual decimal Id { get; set; }
		public virtual string Name { get; set; }
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
					ISQLQuery
						query = session.CreateSQLQuery("select Id, Name from Staff"),
						//queryGeneric = session.CreateSQLQuery("select Id, Name from Staff").AddEntity(typeof(Staff)); // NHibernate.MappingException: No persister for: TestXIII.Staff 
						queryGeneric = (ISQLQuery)session.CreateSQLQuery("select Id, Name from Staff").SetResultTransformer(Transformers.AliasToBean(typeof(Staff))); 

					IList
						_List_ = query.List(); // System.Collections.ArrayList

					IList<Staff>
						_List_Staff_ = queryGeneric.List<Staff>();
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
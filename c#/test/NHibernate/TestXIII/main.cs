using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;

namespace TestXIII
{
	public class Staff
	{
		decimal _ID;
		string _Name;

		public virtual decimal ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		public virtual string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
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
						query = (ISQLQuery)session.CreateSQLQuery("select ID, Name from Staff").SetResultTransformer(Transformers.AliasToBean(typeof(Staff))); //.AddEntity(typeof(Staff));

					IList<Staff>
						_List_Staff_ = query.List<Staff>();

					foreach (Staff s in _List_Staff_)
						Console.WriteLine("{0} {1}", s.ID, s.Name);
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

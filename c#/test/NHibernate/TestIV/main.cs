using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace TestIV
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

					ClassStaff
						tmpClassStaff = session.Get<ClassStaff>(1);

					query = session.CreateQuery("select s from ClassStaff s where s.ID in (:ID)");
					query.SetParameterList("ID", new object[] { 1, 3, 5 });

					List<ClassStaff>
						ClassStaffRecords = (List<ClassStaff>)query.List<ClassStaff>();

					foreach (ClassStaff s in ClassStaffRecords)
					{
						;
					}

					query = session.GetNamedQuery("NamedQuery1");
					query.SetParameter("pID", 3);
					query.SetParameter("pCoeff", 4);
					ClassStaffRecords = (List<ClassStaff>)query.List<ClassStaff>();

					foreach (ClassStaff s in ClassStaffRecords)
					{
						;
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

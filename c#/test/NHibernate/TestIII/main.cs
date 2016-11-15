using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace TestIII
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
						tmpClassStaff=session.Get<ClassStaff>(1);
					
					query = session.CreateQuery("select s from ClassStaff s where s.ID in (:ID)");
					query.SetParameterList("ID", new object[] { 1, 3, 5 });
					
					List<ClassStaff>
						ClassStaffRecords = (List<ClassStaff>)query.List<ClassStaff>();

					foreach (ClassStaff s in ClassStaffRecords)
					{
						;
					}

					/*
					query = session.GetNamedQuery("NamedQuery1");
					query.SetParameter("pID",3);

					List<ClassStaffWithReallyBirthDate>
						ClassStaffWithReallyBirthDateRecords = (List<ClassStaffWithReallyBirthDate>)query.List<ClassStaffWithReallyBirthDate>();

					foreach (ClassStaffWithReallyBirthDate s in ClassStaffWithReallyBirthDateRecords)
					{
						;
					}
					*/
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

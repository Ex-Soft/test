using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using System.Collections;

namespace TestX
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

					query = session.CreateQuery("select s from ClassStaff s where s.ID in (:ID)");
					query.SetParameterList("ID", new object[] { 1, 3, 5 });

					/*
					IList
						ClassStaffRecords = query.List();
					*/

					List<ClassStaff>
						ClassStaffRecords = (List<ClassStaff>)query.List<ClassStaff>();
					
					/*
					using (ITransaction transaction = session.BeginTransaction())
					{
						ClassStaff
							tmpClassStaff = new ClassStaff();

						tmpClassStaff.Name = "Иванов Иван Иванович";
						session.Save(tmpClassStaff);
						tmpClassStaff.Name = "Петров Петр Петрович";
						session.Save(tmpClassStaff);
						transaction.Commit();
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

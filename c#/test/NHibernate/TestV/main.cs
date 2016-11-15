using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace TestV
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

					Master
						tmpMaster = session.Get<Master>(1);

					Console.WriteLine();
					Console.WriteLine("{0}\t{1}", tmpMaster.Id, tmpMaster.Val);
					foreach (Detail d in tmpMaster.Details)
					{
						Console.WriteLine("\t{0}\t{1}\t{2}",d.Master.Id,d.Id,d.Val);
					}
					Console.WriteLine();

					query = session.CreateQuery("select m from Master m where m.Id in (:ID)");
					query.SetParameterList("ID", new object[] { 1, 3, 5 });

					IList<Master>
						MasterRecords = query.List<Master>();

					foreach (Master m in MasterRecords)
					{
						Console.WriteLine();
						Console.WriteLine("{0}\t{1}", m.Id, m.Val);
						foreach (Detail d in m.Details)
						{
							Console.WriteLine("\t{0}\t{1}\t{2}", d.Master.Id, d.Id, d.Val);
						}
						Console.WriteLine();
					}

					tmpMaster = new Master();
					tmpMaster.Val = "Master_X";
					tmpMaster.Details = new List<Detail>();

					Detail
						tmpDetail;

					tmpDetail = new Detail();
					tmpDetail.Master = tmpMaster;
					tmpDetail.Val = "Detal_X";
					tmpMaster.Details.Add(tmpDetail);

					tmpDetail = new Detail();
					tmpDetail.Master = tmpMaster;
					tmpDetail.Val = "Detal_XX";
					tmpMaster.Details.Add(tmpDetail);

					tmpDetail = new Detail();
					tmpDetail.Master = tmpMaster;
					tmpDetail.Val = "Detal_XXX";
					tmpMaster.Details.Add(tmpDetail);

					Console.WriteLine();
					Console.WriteLine("{0}\t{1}", tmpMaster.Id, tmpMaster.Val);
					foreach (Detail d in tmpMaster.Details)
					{
						Console.WriteLine("\t{0}\t{1}\t{2}", d.Master.Id, d.Id, d.Val);
					}
					Console.WriteLine();

					using (ITransaction transaction = session.BeginTransaction())
					{
						session.Save(tmpMaster);
						transaction.Commit();
					}

					Console.WriteLine();
					Console.WriteLine("{0}\t{1}", tmpMaster.Id, tmpMaster.Val);
					foreach (Detail d in tmpMaster.Details)
					{
						Console.WriteLine("\t{0}\t{1}\t{2}", d.Master.Id, d.Id, d.Val);
					}
					Console.WriteLine();

					/*
					using (ITransaction transaction = session.BeginTransaction())
					{
						query = session.CreateQuery("FROM Master WHERE Id > 5");
						MasterRecords=query.List<Master>();
						foreach (Master _m_ in MasterRecords)
							session.Delete(_m_);

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
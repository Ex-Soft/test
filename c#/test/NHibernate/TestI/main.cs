using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using System.Reflection;
using NHibernate.Cfg;

namespace NHibernatePets
{
	public class Pet
	{
		virtual public int id { get; set; }
		virtual public string PetName { get; set; }
		virtual public string Species { get; set; }
		virtual public DateTime Birthday { get; set; }

		virtual public string Speak()
		{
			return "Hi.  My name is '" + PetName + "' and I'm a " + Species + " born on " + Birthday + ".";
		}
	}

	public class Program
	{
		private static void Main()
		{
			Pet
				rosey = new Pet { PetName = "Rosey", Species = "Cat", Birthday = new DateTime(2009, 1, 1, 10, 5, 15) };

			Console.WriteLine(rosey.Speak());

			//let's save rosey to the database
			try
			{
				using (ISession session = OpenSession())
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						session.Save(rosey);
						transaction.Commit();
					}
					Console.WriteLine("Saved rosey to the database");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			//let's read all the pets in the database
			using (ISession session = OpenSession())
			{
				IQuery query = session.CreateQuery("FROM Pet");
				IList<Pet> pets = query.List<Pet>();
				Console.Out.WriteLine("pets.Count = " + pets.Count);
				pets.ToList().ForEach(p => Console.WriteLine(p.Speak()));
			}

			//let's update our pet in the database
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					IQuery query = session.CreateQuery("FROM Pet WHERE PetName = 'Rosey'");
					Pet pet = query.List<Pet>()[0];
					pet.PetName = "Rosie";
					transaction.Commit();
				}
			}

			//let's read all the pets in the database (again)
			using (ISession session = OpenSession())
			{
				IQuery query = session.CreateQuery("FROM Pet");
				IList<Pet> pets = query.List<Pet>();
				Console.Out.WriteLine("pets.Count = " + pets.Count);
				pets.ToList().ForEach(p => Console.WriteLine(p.Speak()));
			}

			//let's delete our pet from the database
			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					IQuery query = session.CreateQuery("FROM Pet WHERE PetName = 'Rosie'");
					Pet pet = query.List<Pet>()[0];
					session.Delete(pet);
					transaction.Commit();
				}
			}
		}

		static ISessionFactory SessionFactory;

		static ISession OpenSession()
		{
			if (SessionFactory == null) //not threadsafe
			{ //SessionFactories are expensive, create only once
				Configuration configuration = new Configuration();

				string
					CallingAssembly = Assembly.GetCallingAssembly().FullName;

				configuration.AddAssembly(Assembly.GetCallingAssembly());
				SessionFactory = configuration.BuildSessionFactory();
			}

			return SessionFactory.OpenSession();
		}
	}
}

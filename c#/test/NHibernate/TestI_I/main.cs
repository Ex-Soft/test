using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernatePets
{
	public class Pet
	{
		int
			_id;

		string
			_PetName,
			_Species;

		DateTime
			_BirthDay;

		public Pet():this(default(int),string.Empty,string.Empty,default(DateTime))
		{}

		public Pet(Pet obj):this(obj.id,obj.PetName,obj.Species,obj.BirthDay)
		{}

		public Pet(int aid, string aPetName, string aSpecies, DateTime aBirthDay)
		{
			_id = aid;
			_PetName = aPetName;
			_Species = aSpecies;
			_BirthDay = aBirthDay;
		}

		public virtual int id
		{
			get
			{
				return _id;
			}
			set
			{
				if (_id != value)
					_id = value;
			}
		}

		public virtual string PetName
		{
			get
			{
				return _PetName;
			}
			set
			{
				if(_PetName!=value)
					_PetName = value;
			}
		}

		public virtual string Species
		{
			get
			{
				return _Species;
			}
			set
			{
				if(_Species!=value)
					_Species = value;
			}
		}

		public virtual DateTime BirthDay
		{
			get
			{
				return _BirthDay;
			}
			set
			{
				if(_BirthDay!=value)
					_BirthDay = value;
			}
		}

		virtual public string Speak()
		{
			return "Hi.  My name is '" + PetName + "' and I'm a " + Species + " born on " + BirthDay + ".";
		}
	}

	public class Program
	{
		private static void Main()
		{
			Pet
				rosey = new Pet(default(int),"Rosey","Cat",new DateTime(2009, 1, 1, 10, 5, 15));

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
				//pets.ToList().ForEach(p => Console.WriteLine(p.Speak()));
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
				//pets.ToList().ForEach(p => Console.WriteLine(p.Speak()));
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

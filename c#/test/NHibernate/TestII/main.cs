using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using Iesi.Collections;

namespace TestII
{
	public class TableMaster
	{
		int
			_Id;

		string
			_Val;
		
		ISet
			_Details = new HashedSet();

		virtual public int Id
		{
			get
			{
				return _Id;
			}
			set
			{
				if (_Id != value)
				{
					_Id = value;
					foreach (TableDetail d in Details)
						d.MasterId = value;
				}
			}
		}

		virtual public string Val
		{
			get
			{
				return _Val;
			}
			set
			{
				if (_Val != value)
					_Val = value;
			}
		}

		public virtual ISet Details
		{
			get
			{
				return _Details;
			}
			set
			{
				_Details = value;
			}
		}

		virtual public void Show()
		{
			Console.WriteLine("Id={0} -> Val=\"{1}\"", Id, Val);
			foreach (TableDetail d in Details)
				d.Show();
		}

		virtual public void AddDetail(string _Val)
		{
			TableDetail
				Detail = new TableDetail();

			Detail.Master = this;
			Detail.Val = _Val;

			Details.Add(Detail);
		}
	}

	public class TableDetail
	{
		int
			_Id,
			_MasterId;

		string
			_Val;

		TableMaster
			_Master;

		virtual public int Id
		{
			get
			{
				return _Id;
			}
			set
			{
				if (_Id != value)
					_Id = value;
			}
		}

		virtual public int MasterId
		{
			get
			{
				return _MasterId;
			}
			set
			{
				if (_MasterId != value)
					_MasterId = value;
			}
		}

		virtual public string Val
		{
			get
			{
				return _Val;
			}
			set
			{
				if (_Val != value)
					_Val = value;
			}
		}

		virtual public TableMaster Master
		{
			get
			{
				return _Master;
			}
			set
			{
				_Master = value;
			}
		}

		virtual public void Show()
		{
			Console.WriteLine("Id={0} MasterId={1} -> Val=\"{2}\"", Id, MasterId, Val);
		}
	}

	class Program
	{
		static ISessionFactory
			SessionFactory;

		static void Main(string[] args)
		{
			TableMaster
				m = new TableMaster();

			m.Val = "Master_X";
			m.AddDetail("Detal_X");
			m.AddDetail("Detal_XX");
			m.AddDetail("Detal_XXX");
			m.Show();

			try
			{
				using (ISession session = OpenSession())
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						session.Save(m);
						transaction.Commit();
					}
					m.Show();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			using (ISession session = OpenSession())
			{
				IQuery
					query = session.CreateQuery("FROM TableMaster");

				IList<TableMaster>
					ms = query.List<TableMaster>();

				Console.Out.WriteLine("ms.Count = " + ms.Count);
			}

			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					IQuery
						query = session.CreateQuery("FROM TableMaster WHERE Id > 5");

					IList<TableMaster>
						ms = query.List<TableMaster>();

					foreach (TableMaster _m_ in ms)
						_m_.Val = "Master_Y";
					transaction.Commit();
				}
			}

			using (ISession session = OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					IQuery
						query = session.CreateQuery("FROM TableMaster WHERE Id > 5");

					IList<TableMaster>
						ms = query.List<TableMaster>();

					foreach (TableMaster _m_ in ms)
						session.Delete(_m_);

					transaction.Commit();
				}
			}
		}

		static ISession OpenSession()
		{
			if (SessionFactory == null)
			{
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

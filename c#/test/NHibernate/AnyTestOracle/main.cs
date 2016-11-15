#define TEST_WAREHOUSE
//#define TEST_MARKUP

using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;

namespace AnyTestOracle
{
	#if TEST_MARKUP
		class MarkUp
		{
			public virtual decimal Id { get; set; }
			public virtual string Description { get; set; }
		}
	#endif

	#if TEST_WAREHOUSE
		class Warehouse
		{
			public virtual decimal Id { get; set; }
			public virtual string Description { get; set; }
		}
	#endif

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
						SQLQuery;

					#if TEST_MARKUP
						SQLQuery = (ISQLQuery)session.CreateSQLQuery(@"
select distinct
  tew.ew_id as ""Id"",
  tew.ew_name as ""Description""
from
  applicationinfo ai
  join userofapplication uoa on (uoa.applicationid=ai.applicationid)
  join client c on (c.clientid=uoa.userofapplicationid)
  join restricted_markups rm on (rm.restrictionid=c.restrictionid)
  join typhoon.tbl_extra_what tew on (tew.ew_id=rm.markupid)
where
  (ai.applicationid=:application_id)
  and (uoa.userofapplicationid=:userofapplication_id)
order by tew.ew_id
").SetResultTransformer(Transformers.AliasToBean(typeof(MarkUp)));
						SQLQuery.SetParameter("application_id", 123);
						SQLQuery.SetParameter("userofapplication_id", 222);

						IList<MarkUp>
							_List_MarkUp_ = SQLQuery.List<MarkUp>();

						foreach (MarkUp markup in _List_MarkUp_)
							Console.WriteLine("{0} {1}", markup.Id, markup.Description);
					#endif

					#if TEST_WAREHOUSE
						SQLQuery = (ISQLQuery)session.CreateSQLQuery(@"
select distinct
  vw.kontr_id as ""Id"",
  vw.kontr_name as ""Description""
from
  applicationinfo ai
  join userofapplication uoa on (uoa.applicationid=ai.applicationid)
  join client c on (c.clientid=uoa.userofapplicationid)
  join restricted_warehouses rw on (rw.restrictionid=c.restrictionid)
  join v_warehouses vw on (vw.kontr_id=rw.warehouseid)
where
  (ai.applicationid=:application_id)
  and (uoa.userofapplicationid=:userofapplication_id)
order by vw.kontr_id
").SetResultTransformer(Transformers.AliasToBean(typeof(Warehouse)));
						SQLQuery.SetParameter("application_id", 123);
						SQLQuery.SetParameter("userofapplication_id", 222);

						IList<Warehouse>
							_List_Warehouse_ = SQLQuery.List<Warehouse>();

						foreach (Warehouse warehouse in _List_Warehouse_)
							Console.WriteLine("{0} {1}", warehouse.Id, warehouse.Description);

					#endif
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

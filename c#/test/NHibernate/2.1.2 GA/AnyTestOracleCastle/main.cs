#define TEST_CLOB
#define TEST_CLOB_BY_OBJECT
//#define TEST_WHERE_IN_BY_CONTRAGENT
//#define TEST_HO
//#define TEST_WAREHOUSE
//#define TEST_MARKUP

using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Transform;

namespace AnyTestOracleCastle
{
	#if TEST_WHERE_IN_BY_CONTRAGENT
		class Contragent
		{
			public virtual decimal Id { get; set; }
			public virtual string Name { get; set; }
		}
	#endif

	#if TEST_HO
		class HO
		{
			public virtual decimal Id { get; set; }
			public virtual string Description { get; set; }
		}
	#endif

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

					IQuery
						query;

					#if TEST_CLOB
						using (ITransaction transaction = session.BeginTransaction())
						{
							TestTableTypes
								TestTableTypes;

							string
								//tmpString = "<P style=\"FONT-SIZE: large\" align=center>Спасибо, что пользуетесь нашей системой заказов!</P><P style=\"FONT-SIZE: large\" align=center>С 3 декабря изменился интерфейс \"онлайн заказов\" для клиентов компании.</P><P style=\"FONT-SIZE: large\" align=center>Просьба о всех пожеланиях и возможных проблемах сообщать на эл. адрес <A href=\"mailto:garnik-a@mtr.com.ua\">garnik-a@mtr.com.ua</A></P><P>Для создания заказа воспользуйтесь пунктом меню \"Каталог товаров\", либо загрузите заказ из <IMG src=\"http://corp.mtr.com.ua/OrdersApp/images/excel.gif\"> Excel через меню \"Загрузить заказ\"</P><P>Более подробно о том, как делать заказы и пользоваться системой вы можете почитать в <A href=\"http://corp.mtr.com.ua/OrdersApp/client/manual/help%20b2b.doc\">документации</A>.</P><P align=center><B>Уважаемые партнёры:</B></P><P align=center>Не упустите возможность закупить продукцию «Медиа Трейдинг» по очень хорошим ценам.</P><P align=center>Только раз в неделю, каждую пятницу, мы предлагаем специальные цены на несколько позиций из своего ассортимента. Размер партии может быть любой. Условие только одно: <B>Полная оплата закупки в тот же день*.</B><BR><BR>Способ оплаты может быть любой.<BR><SPAN style=\"COLOR: rgb(255,0,0); FONT-WEIGHT: bold\">ВНИМАНИЕ: АССОРТИМЕНТ ТОВАРОВ ОБНОВЛЯЕТСЯ КАЖДЫЙ ЧЕТВЕРГ В 16:00.</SPAN><BR></P><P><B>*Пояснение к условию:</B><BR>Вы можете получить товар по объявленной цене при условии оплаты в этот же день.<BR>Это значит, что нужно <B>«принести» (любым способом: безнал, предоплата) деньги в офис или представительство компании с 9:00 до 17:00 пятницы.</B> При этом <B>у Вас не должно быть вообще никаких задолженностей перед компанией, <U>независимо от размеров и срока давности</U>. Баланс либо нулевой, либо плюс.</B><BR><B><U>Без подтверждения оплаты товар отгружен не будет!</U></B><BR><BR>В случае, если товара нет на складе представительства, заказ будет доставлен с центрального склада ближайшей отгрузкой.</P><p align=\"center\"><b><br></b></p><p align=\"center\"><b><br></b></p"; // <p align=\"center\"><b><br></b></p>
								//tmpString = new string('я', 0x0ffff);
								//tmpString = new string('я', 2000);
								tmpString = new string('я', 2001);
								//tmpString = new string('я', 1000) + new string('ю', 1000) + new string('э', 1);

							#if !TEST_CLOB_BY_OBJECT
								TestTableTypes = new TestTableTypes();
								TestTableTypes.Id = 1;
								TestTableTypes.FClob = tmpString;
								TestTableTypes.FNClob = tmpString;
								session.SaveOrUpdate(TestTableTypes);
							#else
								query = session.CreateQuery("FROM TestTableTypes WHERE Id = 1");
								TestTableTypes = query.List<TestTableTypes>()[0];
								TestTableTypes.FClob = tmpString;
								TestTableTypes.FNClob = tmpString;
							#endif

							transaction.Commit();
						}
					#endif

					#if TEST_WHERE_IN_BY_CONTRAGENT
						SQLQuery = (ISQLQuery)session.CreateSQLQuery(@"
select
  k.k_id as ""Id"",
  k.k_name as ""Name""
from
  typhoon.tbl_kontragents k
where
  k.k_id in (:k_id_list);
").SetResultTransformer(Transformers.AliasToBean(typeof(Contragent)));
						SQLQuery.SetParameterList("k_id_list", new List<int>(new int[] { 121839, 1136719, 121495 }));

						IList<Contragent>
							_List_Contragent_ = SQLQuery.List<Contragent>();

						foreach (Contragent contragent in _List_Contragent_)
							Console.WriteLine("{0} {1}", contragent.Id, contragent.Name);
					#endif

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

					#if TEST_HO
						SQLQuery = (ISQLQuery)session.CreateSQLQuery(@"
select
  tht.hoty_id as ""Id"",
  tht.hoty_name as ""Description""
from
  restricted_ho rh
  join typhoon.tbl_ho_types tht on (tht.hoty_id=rh.hoty_id)
where
  (rh.restriction_id=:restriction_id)
").SetResultTransformer(Transformers.AliasToBean(typeof(HO)));
						SQLQuery.SetParameter("restriction_id", 25684);

						IList<HO>
							_List_HO_ = SQLQuery.List<HO>();

						foreach (HO ho in _List_HO_)
							Console.WriteLine("{0} {1}", ho.Id, ho.Description);
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

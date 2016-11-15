using System;
using System.Collections;
using NHibernate;
using NHibernate.Cfg;
using log4net.Config;

namespace NHibernateOneToMany
{

	public class TheApp
	{
		ISessionFactory factory = null;

		
		static void Main(string[] args)
		{
			TheApp application = new TheApp();
			application.Initialize();

			// Execute your demomethods here
			application.TestUniDirectionalOneToManyMappingUsingBag();
//			application.TestBiDirectionalOneToManyMappingUsingBag();
			
//			application.TestUniDirectionalOneToManyMappingUsingSet();
//			application.TestBiDirectionalOneToManyMappingUsingSet();
			
//			application.TestUniDirectionalOneToManyMappingUsingList();
			
//			application.TestUniDirectionalOneToManyMappingUsingDictionaryWithSimpleKey();
//			application.TestUniDirectionalOneToManyMappingUsingDictionaryWithEntityKey();
		}

		
		public void Initialize()
		{
			XmlConfigurator.Configure();

			Configuration config;

			config = new Configuration();

			try
			{
				config.SetProperty(NHibernate.Cfg.Environment.ConnectionDriver,
					"NHibernate.Driver.SqlClientDriver");
					//"NHibernate.Driver.MySqlDataDriver");

				config.SetProperty(NHibernate.Cfg.Environment.ConnectionString,
					"Server=NOZHENKO-PC\\SQLEXPRESS;database=ormapping;Integrated Security=SSPI");
					//"Server=localhost;Database=ormapping;User ID=root;Password=root;CharSet=latin1");

				config.SetProperty(NHibernate.Cfg.Environment.ShowSql,
					"true");

				config.SetProperty(NHibernate.Cfg.Environment.Dialect,
					"NHibernate.Dialect.MsSql2005Dialect");
					//"NHibernate.Dialect.MySQLDialect");

				config.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass,
					"NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu");

				//config.SetProperty(NHibernate.Cfg.Environment.ConnectionProvider,
				//	"NHibernate.Connection.DriverConnectionProvider" );

				config.AddAssembly("NHibernateOneToMany");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}


			factory = config.BuildSessionFactory();
		}
		
		
		public void TestUniDirectionalOneToManyMappingUsingBag()
		{
			ITransaction transaction = null;
			ISession session = null;

			try
			{
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				UniDirectional.UOrder orderOne = new UniDirectional.UOrder();
				orderOne.Number = 10;
				UniDirectional.UOrder orderTwo = new UniDirectional.UOrder();
				orderTwo.Number = 20;
				UniDirectional.UOrder orderThree = new UniDirectional.UOrder();
				orderThree.Number = 30;
				ArrayList orderList = new ArrayList();
				orderList.Add(orderOne);
				orderList.Add(orderTwo);
				orderList.Add(orderThree);

				UniDirectional.UCustomer someCustomer = new UniDirectional.UCustomer();
				someCustomer.Name = "SomePerson";
				someCustomer.OrderList = (IList)orderList;

				session.Save(someCustomer);

				transaction.Commit();

                Console.WriteLine("Customer.Id:{0}", someCustomer.Id);
				Console.WriteLine("Order One.Id:{0}", orderOne.Id);
				Console.WriteLine("Order Two.Id:{0}", orderTwo.Id);
				Console.WriteLine("Order Three.Id:{0}", orderThree.Id);


				string querySting = "from UniDirectional.UCustomer as aCustomer where aCustomer.Id=" + someCustomer.Id;
				IQuery query = session.CreateQuery(querySting);
				IList customerList = query.List();
				foreach(UniDirectional.UCustomer aCustomer in customerList)
				{
					Console.WriteLine("Customer Id:{0} - Name:{1}", aCustomer.Id, aCustomer.Name);
                    Console.WriteLine("Customer.Order.Count:{0}", aCustomer.OrderList.Count);
                    foreach (UniDirectional.UOrder anOrder in aCustomer.OrderList)
                    {
                        Console.WriteLine("- Order Id:{0} - Number:{1}", anOrder.Id, anOrder.Number);
                    }
				}

			}
			catch (Exception ex)
			{
				transaction.Rollback();
			}
			finally 
			{
				session.Close();
			}
		}
		
		
		public void TestBiDirectionalOneToManyMappingUsingBag()
		{
			ITransaction transaction = null;
			ISession session = null;

			try
			{
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				BiDirectional.BCustomer someCustomer = new BiDirectional.BCustomer();
				someCustomer.Name = "SomePerson";

				BiDirectional.BOrder orderOne = new BiDirectional.BOrder();
				orderOne.Number = 10;
				orderOne.OrderedBy = someCustomer;
				BiDirectional.BOrder orderTwo = new BiDirectional.BOrder();
				orderTwo.Number = 20;
				orderTwo.OrderedBy = someCustomer;
				BiDirectional.BOrder orderThree = new BiDirectional.BOrder();
				orderThree.Number = 30;
				orderThree.OrderedBy = someCustomer;
				ArrayList orderList = new ArrayList();
				orderList.Add(orderOne);
				orderList.Add(orderTwo);
				orderList.Add(orderThree);
				
				someCustomer.OrderList = (IList)orderList;

				session.Save(someCustomer);

				transaction.Commit();
				
				session.Close();
				session = null;

                Console.WriteLine("Customer.Id:{0}", someCustomer.Id);
				Console.WriteLine("Order One.Id:{0}", orderOne.Id);
				Console.WriteLine("Order Two.Id:{0}", orderTwo.Id);
				Console.WriteLine("Order Three.Id:{0}", orderThree.Id);

				session = factory.OpenSession();
				
				string querySting = "from BiDirectional.BCustomer as aCustomer where aCustomer.Id=" + someCustomer.Id;
				IQuery query = session.CreateQuery(querySting);
				IList customerList = query.List();
				foreach(BiDirectional.BCustomer aCustomer in customerList)
				{
					Console.WriteLine("Customer Id:{0} - Name:{1}", aCustomer.Id, aCustomer.Name);
                    Console.WriteLine("Customer.Order.Count:{0}", aCustomer.OrderList.Count);
                    foreach (BiDirectional.BOrder anOrder in aCustomer.OrderList)
                    {
                        Console.WriteLine("- Order Id:{0} - Number:{1}", anOrder.Id, anOrder.Number);
                        if (anOrder.OrderedBy != null)
                        {
							Console.WriteLine("- Order Customer Id:{0} - Name:{1}", anOrder.OrderedBy.Id, anOrder.OrderedBy.Name);
							Console.WriteLine("- Order ObjectIdentity: Customer == Order.Customer ? {0}", Object.ReferenceEquals(aCustomer, anOrder.OrderedBy));
                        }
                        else
                        {
							Console.WriteLine("- Order Customer (No Customer)");
                        }
                    }
				}
				session.Close();
				session = null;

				session = factory.OpenSession();
				transaction = session.BeginTransaction();
				session.Delete(someCustomer);
				transaction.Commit();
				session.Close();
				session = null;
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				Console.WriteLine(ex);
			}
			finally 
			{
				if (session != null)
				{
					session.Close();
				}
			}
		}
		
		
		public void TestUniDirectionalOneToManyMappingUsingSet()
		{
			ITransaction transaction = null;
			ISession session = null;

			try
			{
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				UniDirectional.ULeg frontLeftLeg = new UniDirectional.ULeg();
				frontLeftLeg.Position = UniDirectional.ULeg.LegPosition.FrontLeft;
				UniDirectional.ULeg frontRightLeg = new UniDirectional.ULeg();
				frontRightLeg.Position = UniDirectional.ULeg.LegPosition.FrontRight;
				UniDirectional.ULeg backLeftLeg = new UniDirectional.ULeg();
				backLeftLeg.Position = UniDirectional.ULeg.LegPosition.BackLeft;
				UniDirectional.ULeg backRightLeg = new UniDirectional.ULeg();
				backRightLeg.Position = UniDirectional.ULeg.LegPosition.BackRight;
				Iesi.Collections.ListSet dogLegs = new Iesi.Collections.ListSet();
				dogLegs.Add(frontLeftLeg);
				dogLegs.Add(frontRightLeg);
				dogLegs.Add(backLeftLeg);
				dogLegs.Add(backRightLeg);

				UniDirectional.UDog someDog = new UniDirectional.UDog();
				someDog.Name = "Fido";
				someDog.Legs = (Iesi.Collections.ISet)dogLegs;

				session.Save(someDog);

				transaction.Commit();

                Console.WriteLine("Dog.Id:{0}", someDog.Id);
				Console.WriteLine("Leg FrontLeftLeg.Id:{0}", frontLeftLeg.Id);
				Console.WriteLine("Leg FrontRightLeg.Id:{0}", frontRightLeg.Id);
				Console.WriteLine("Leg BackLeftLeg.Id:{0}", backLeftLeg.Id);
				Console.WriteLine("Leg BackRightLeg.Id:{0}", backRightLeg.Id);


				string querySting = "from UniDirectional.UDog as aDog where aDog.Id=" + someDog.Id;
				IQuery query = session.CreateQuery(querySting);
				IList dogList = query.List();
				foreach(UniDirectional.UDog aDog in dogList)
				{
					Console.WriteLine("Dog Id:{0} - Name:{1}", aDog.Id, aDog.Name);
                    Console.WriteLine("Dog.Legs.Count:{0}", aDog.Legs.Count);
                    foreach (UniDirectional.ULeg aLeg in aDog.Legs)
                    {
                        Console.WriteLine("- Leg Id:{0} - Position:{1}", aLeg.Id, aLeg.Position);
                    }
				}

			}
			catch (Exception ex)
			{
				transaction.Rollback();
			}
			finally 
			{
				session.Close();
			}
		}
		
		
		public void TestBiDirectionalOneToManyMappingUsingSet()
		{
			ITransaction transaction = null;
			ISession session = null;

			try
			{
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				BiDirectional.BDog someDog = new BiDirectional.BDog();
				someDog.Name = "Fido";

				BiDirectional.BLeg frontLeftLeg = new BiDirectional.BLeg();
				frontLeftLeg.Position = BiDirectional.BLeg.LegPosition.FrontLeft;
				frontLeftLeg.Owner = someDog;
				BiDirectional.BLeg frontRightLeg = new BiDirectional.BLeg();
				frontRightLeg.Position = BiDirectional.BLeg.LegPosition.FrontRight;
				frontRightLeg.Owner = someDog;
				BiDirectional.BLeg backLeftLeg = new BiDirectional.BLeg();
				backLeftLeg.Position = BiDirectional.BLeg.LegPosition.BackLeft;
				backLeftLeg.Owner = someDog;
				BiDirectional.BLeg backRightLeg = new BiDirectional.BLeg();
				backRightLeg.Position = BiDirectional.BLeg.LegPosition.BackRight;
				backRightLeg.Owner = someDog;
				Iesi.Collections.ListSet dogLegs = new Iesi.Collections.ListSet();
				dogLegs.Add(frontLeftLeg);
				dogLegs.Add(frontRightLeg);
				dogLegs.Add(backLeftLeg);
				dogLegs.Add(backRightLeg);

				someDog.Legs = (Iesi.Collections.ISet)dogLegs;

				session.Save(someDog);

				transaction.Commit();
				
				session.Close();
				session = null;

                Console.WriteLine("Dog.Id:{0}", someDog.Id);
				Console.WriteLine("Leg FrontLeftLeg.Id:{0}", frontLeftLeg.Id);
				Console.WriteLine("Leg FrontRightLeg.Id:{0}", frontRightLeg.Id);
				Console.WriteLine("Leg BackLeftLeg.Id:{0}", backLeftLeg.Id);
				Console.WriteLine("Leg BackRightLeg.Id:{0}", backRightLeg.Id);

				session = factory.OpenSession();
				
				string querySting = "from BiDirectional.BDog as aDog where aDog.Id=" + someDog.Id;
				IQuery query = session.CreateQuery(querySting);
				IList dogList = query.List();
				foreach(BiDirectional.BDog aDog in dogList)
				{
					Console.WriteLine("Dog Id:{0} - Name:{1}", aDog.Id, aDog.Name);
                    Console.WriteLine("Dog.Legs.Count:{0}", aDog.Legs.Count);
                    foreach (BiDirectional.BLeg aLeg in aDog.Legs)
                    {
                        Console.WriteLine("- Leg Id:{0} - Position:{1}", aLeg.Id, aLeg.Position);
                        if (aLeg.Owner != null)
                        {
							Console.WriteLine("- Leg Owner Id:{0} - Name:{1}", aLeg.Owner.Id, aLeg.Owner.Name);
							Console.WriteLine("- Leg ObjectIdentity: Dog == Leg.Owner ? {0}", Object.ReferenceEquals(aDog, aLeg.Owner));
                        }
                        else
                        {
							Console.WriteLine("- Order Owner (No Owner)");
                        }
                    }
				}

			}
			catch (Exception ex)
			{
				transaction.Rollback();
			}
			finally 
			{
				session.Close();
			}
		}
		
		
		public void TestUniDirectionalOneToManyMappingUsingList()
		{
			ITransaction transaction = null;
			ISession session = null;

			try
			{
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				UniDirectional.UMessage message1 = new UniDirectional.UMessage();
				message1.Text = "Text1";
				UniDirectional.UMessage message2 = new UniDirectional.UMessage();
				message2.Text = "Text2";
				UniDirectional.UMessage message3 = new UniDirectional.UMessage();
				message3.Text = "Text3";
				UniDirectional.UMessage message4 = new UniDirectional.UMessage();
				message4.Text = "Text4";
				ArrayList messageList = new ArrayList();
				messageList.Add(message1);
				messageList.Add(message2);
				messageList.Add(message3);
				messageList.Add(message4);

				UniDirectional.UConversation someConversation = new UniDirectional.UConversation();
				someConversation.Subject = "a test conversation";
				someConversation.MessageList = (IList)messageList;

				session.Save(someConversation);

				transaction.Commit();

                Console.WriteLine("Conversation.Id:{0}", someConversation.Id);
				Console.WriteLine("Message message1.Id:{0}", message1.Id);
				Console.WriteLine("Message message2.Id:{0}", message2.Id);
				Console.WriteLine("Message message3.Id:{0}", message3.Id);
				Console.WriteLine("Message message4.Id:{0}", message4.Id);


				string querySting = "from UniDirectional.UConversation as aConversation where aConversation.Id=" + someConversation.Id;
				IQuery query = session.CreateQuery(querySting);
				IList conversationList = query.List();
				foreach(UniDirectional.UConversation aConversation in conversationList)
				{
					Console.WriteLine("Conversation Id:{0} - Subject:{1}", aConversation.Id, aConversation.Subject);
                    Console.WriteLine("Conversation.MessageList.Count:{0}", aConversation.MessageList.Count);
                    foreach (UniDirectional.UMessage aMessage in aConversation.MessageList)
                    {
                        Console.WriteLine("- Message Id:{0} - Text:{1}", aMessage.Id, aMessage.Text);
                    }
				}

			}
			catch (Exception ex)
			{
				transaction.Rollback();
			}
			finally 
			{
				session.Close();
			}
		}
		
		
		public void TestUniDirectionalOneToManyMappingUsingDictionaryWithSimpleKey()
		{
			ITransaction transaction = null;
			ISession session = null;

			try
			{
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				UniDirectional.UEmployee employee1 = new UniDirectional.UEmployee();
				employee1.Name = "John";
				employee1.Address = "Heaven";
				UniDirectional.UEmployee employee2 = new UniDirectional.UEmployee();
				employee2.Name = "Paul";
				employee2.Address = "Somewhere in England";
				UniDirectional.UEmployee employee3 = new UniDirectional.UEmployee();
				employee3.Name = "George";
				employee3.Address = "Heaven too";
				UniDirectional.UEmployee employee4 = new UniDirectional.UEmployee();
				employee4.Name = "Ringo";
				employee4.Address = "Near the drums";
				Hashtable employeeList = new Hashtable();
				employeeList.Add(employee1.Name, employee1);
				employeeList.Add(employee2.Name, employee2);
				employeeList.Add(employee3.Name, employee3);
				employeeList.Add(employee4.Name, employee4);

				UniDirectional.UDepartment someDepartment = new UniDirectional.UDepartment();
				someDepartment.Name = "Music";
				someDepartment.EmployeeList = (IDictionary)employeeList;

				session.Save(someDepartment);

				transaction.Commit();

                Console.WriteLine("Department.Id:{0}", someDepartment.Id);
				Console.WriteLine("Employee employee1.Id:{0}", employee1.Id);
				Console.WriteLine("Employee employee2.Id:{0}", employee2.Id);
				Console.WriteLine("Employee employee3.Id:{0}", employee3.Id);
				Console.WriteLine("Employee employee4.Id:{0}", employee4.Id);


				string querySting = "from UniDirectional.UDepartment as aDepartment where aDepartment.Id=" + someDepartment.Id;
				IQuery query = session.CreateQuery(querySting);
				IList departmentList = query.List();
				foreach(UniDirectional.UDepartment aDepartment in departmentList)
				{
					Console.WriteLine("Conversation Id:{0} - Name:{1}", aDepartment.Id, aDepartment.Name);
                    Console.WriteLine("Conversation.EmployeeList.Count:{0}", aDepartment.EmployeeList.Count);
                    
                    IDictionaryEnumerator employeeEnumerator = aDepartment.EmployeeList.GetEnumerator();
					while ( employeeEnumerator.MoveNext() )
						Console.WriteLine("- Key: {0} - Employee: {1}", employeeEnumerator.Key, employeeEnumerator.Value);
				}

			}
			catch (Exception ex)
			{
				transaction.Rollback();
			}
			finally 
			{
				session.Close();
			}
		}
		
		
		public void TestUniDirectionalOneToManyMappingUsingDictionaryWithEntityKey()
		{
			ITransaction transaction = null;
			ISession session = null;

			try
			{
				session = factory.OpenSession();
				transaction = session.BeginTransaction();

				UniDirectional.UHabitant habitant1 = new UniDirectional.UHabitant();
				habitant1.HouseNumber = 10;
				UniDirectional.UPersonName name1 = new UniDirectional.UPersonName();
				name1.Name = "John";
				UniDirectional.UHabitant habitant2 = new UniDirectional.UHabitant();
				habitant2.HouseNumber = 15;
				UniDirectional.UPersonName name2 = new UniDirectional.UPersonName();
				name2.Name = "Paul";
				Hashtable habitantList = new Hashtable();
				habitantList.Add(name1, habitant1);
				habitantList.Add(name2, habitant2);

				UniDirectional.UStreet someStreet = new UniDirectional.UStreet();
				someStreet.Name = "AbbeyRoad";
				someStreet.HabitantList = (IDictionary)habitantList;

				session.Save(name1);
				session.Save(name2);
				session.Save(someStreet);

				transaction.Commit();

                Console.WriteLine("Street.Id:{0}", someStreet.Id);
				Console.WriteLine("Habitant habitant1.Id:{0}", habitant1.Id);
				Console.WriteLine("Habitant habitant2.Id:{0}", habitant2.Id);


				string querySting = "from UniDirectional.UStreet as aStreet where aStreet.Id=" + someStreet.Id;
				IQuery query = session.CreateQuery(querySting);
				IList streetList = query.List();
				foreach(UniDirectional.UStreet aStreet in streetList)
				{
					Console.WriteLine("Street Id:{0} - Name:{1}", aStreet.Id, aStreet.Name);
                    Console.WriteLine("Street.HabitantList.Count:{0}", aStreet.HabitantList.Count);
                    
                    IDictionaryEnumerator habitantEnumerator = aStreet.HabitantList.GetEnumerator();
					while ( habitantEnumerator.MoveNext() )
						Console.WriteLine("- Key: {0} - Value: {1}", habitantEnumerator.Key, habitantEnumerator.Value);
				}

			}
			catch (Exception ex)
			{
				transaction.Rollback();
			}
			finally 
			{
				session.Close();
			}
		}
	}
}

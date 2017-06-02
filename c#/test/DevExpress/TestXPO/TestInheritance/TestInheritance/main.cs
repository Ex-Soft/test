#define TEST_AGGREGATED
//#define TEST_NO_FOREIGN_KEY
//#define TEST_INHERITANCE
//#define SHOW_ATTRIBUTES
#define TEST_SINGLE_TABLE
//#define TEST_OWN_TABLE

using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using TestInheritance.Db;

namespace TestInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DevExpress.Xpo.Metadata.ReflectionClassInfo.SuppressSuspiciousMemberInheritanceCheck = true;

                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");

                object tmpObject;

                #if TEST_NO_FOREIGN_KEY
                    using (var unitOfWork = new UnitOfWork())
                    {
                        var entity1 = new Entity1(unitOfWork);
                        entity1.Id = (int)unitOfWork.ExecuteScalar("select max(Id) + 1 from Entity1");
                        entity1.Value = "Entity1";
                        entity1.Entity3Derived1.AddRange(new[] { new Entity3Derived1(unitOfWork), new Entity3Derived1(unitOfWork) });
                        for (var i = 0; i < entity1.Entity3Derived1.Count; ++i)
                            ((Entity3Derived1)entity1.Entity3Derived1[i]).Value = $"Entity3Derived1 #{i + 1} (\"{entity1.Value}\")";

                        var entity2 = new Entity2(unitOfWork);
                        entity2.Id = (int)unitOfWork.ExecuteScalar("select max(Id) + 1 from Entity2");
                        entity2.Value = "Entity2";
                        entity2.Entity3Derived2.AddRange(new[] { new Entity3Derived2(unitOfWork), new Entity3Derived2(unitOfWork) });
                        for (var i = 0; i < entity2.Entity3Derived2.Count; ++i)
                            ((Entity3Derived2)entity2.Entity3Derived2[i]).Value = $"Entity3Derived2 #{i + 1} (\"{entity2.Value}\")";

                        unitOfWork.CommitChanges();

                        foreach (var entity in new XPCollection<Entity3Base>(unitOfWork).OrderBy(item => item.Id))
                        {
                            var entity3Derived1 = entity as Entity3Derived1;
                            var entity3Derived2 = entity as Entity3Derived2;
                            var elementId = entity3Derived1?.Element.Id ?? entity3Derived2?.Element.Id;
                            var elementValue = entity3Derived1?.Element.Value ?? entity3Derived2?.Element.Value;
                            Debug.WriteLine($"Id:{entity.Id}, Value:{entity.Value}, Element.Id:{elementId?.ToString() ?? "NULL"}, Element.Value:{elementValue ?? "NULL"}");
                        }
                    }
                #endif

                using (var session = new Session())
                {
					#if TEST_INHERITANCE
                        var twA = new TableForTestInheritanceWithVinaigretteFieldA(session);
                        twA.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceWithVinaigretteField")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                        twA.VinaigretteField = new TableForTestInheritanceForVinaigretteFieldA(session);
                        twA.VinaigretteField.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceForVinaigretteFieldA")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 10;
                        twA.Value = $"{twA.Id} -> A({twA.VinaigretteField.Id})";
                        twA.VinaigretteField.Value = $"-> {twA.Id}";
                        twA.Save();
                        session.Save(twA);

                        var twB = new TableForTestInheritanceWithVinaigretteFieldB(session);
                        twB.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceWithVinaigretteField")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                        twB.VinaigretteField = new TableForTestInheritanceForVinaigretteFieldB(session);
                        twB.VinaigretteField.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceForVinaigretteFieldB")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 100;
                        twB.Value = $"{twB.Id} -> B({twB.VinaigretteField.Id})";
                        twB.VinaigretteField.Value = $"-> {twB.Id}";
                        twB.Save();
                        session.Save(twB);

                        #if TEST_AGGREGATED
                            var tfA = new TableForTestInheritanceForVinaigretteFieldA(session);
                            tfA.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceForVinaigretteFieldA")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 10;
                            twA = new TableForTestInheritanceWithVinaigretteFieldA(session);
                            twA.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceWithVinaigretteField")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                            twA.Value = $"{twA.Id} -> A({tfA.Id})";
                            tfA.Value = $"-> {twA.Id}";
                            tfA.VinaigretteField.Add(twA);
                            tfA.Save();
                            twA.Reload();
                            twA.Value += " " + twA.Value;
                            tfA.Save();
                            twA.Reload();

                            var tfB = new TableForTestInheritanceForVinaigretteFieldB(session);
                            tfB.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceForVinaigretteFieldB")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 100;
                            twB = new TableForTestInheritanceWithVinaigretteFieldB(session);
                            twB.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from TableForTestInheritanceWithVinaigretteField")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                            twB.Value = $"{twB.Id} -> B({tfB.Id})";
                            tfB.Value = $"-> {twB.Id}";
                            tfB.VinaigretteField.Add(twB);
                            tfB.Save();
                            twB.Reload();
                            twB.Value += " " + twB.Value;
                            tfB.Save();
                            twB.Reload();
                        #endif

                        StuSKU
                            sku;

                        if ((sku = session.GetObjectByKey<StuSKU>(1)) != null)
                        { 
                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByGood)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));

                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByCopetitor)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));
                        }
                        Console.WriteLine();

                        if ((sku = session.GetObjectByKey<StuSKU>(3)) != null)
                        {
                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByGood)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));

                            foreach (StuSKUCompetitorByGood item in sku.StuSKUCopetitorByCopetitor)
                                Console.WriteLine("{{id:{0}, SKU.id:{1} (\"{3}\"), SKUCompetitor.id:{2} (\"{4}\")}}", item.id, item.SKU != null ? item.SKU.id.ToString() : "null", item.SKUCompetitor != null ? item.SKUCompetitor.id.ToString() : "null", item.SKU != null ? item.SKU.FullName : "null", item.SKUCompetitor != null ? item.SKUCompetitor.FullName : "null");
                            Console.WriteLine(new string('-', 60));
                        }
                        Console.WriteLine();

                        StuSKUCompetitorByGood
                            skuCompetitorByGood;

                        if ((skuCompetitorByGood = new StuSKUCompetitorByGood(session)) != null)
                        {
                            skuCompetitorByGood.SKU = session.GetObjectByKey<StuSKU>(2);
                            skuCompetitorByGood.SKUCompetitor = session.GetObjectByKey<StuSKU>(5);
                            skuCompetitorByGood.Value = $"{{STU:'{skuCompetitorByGood.SKU.FullName}', SKUCompetitor:'{skuCompetitorByGood.SKUCompetitor.FullName}'}}";
                            skuCompetitorByGood.Save();
                            session.Save(skuCompetitorByGood);
                        }

                        ShowProperties(typeof(ForTestInheritanceIIBackward));

						Reference
							left = session.GetObjectByKey<Reference>(1),
							right = session.GetObjectByKey<Reference>(2);

						ForTestInheritanceII
							forTestInheritanceII = new ForTestInheritanceII(session);

						forTestInheritanceII.Left = left;
						forTestInheritanceII.Right = right;
						forTestInheritanceII.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceII.Left.Value, forTestInheritanceII.Right.Value);
						forTestInheritanceII.Save();
						session.Save(forTestInheritanceII);

						ForTestInheritanceIIBackward
							forTestInheritanceIIBackward = new ForTestInheritanceIIBackward(session);

						forTestInheritanceIIBackward.Left = left;
						forTestInheritanceIIBackward.Right = right;
						forTestInheritanceIIBackward.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceIIBackward.Left.Value, forTestInheritanceIIBackward.Right.Value);
						forTestInheritanceIIBackward.Save();
						session.Save(forTestInheritanceIIBackward);

						ForTestInheritanceILeftRight
							forTestInheritanceILeftRight = session.GetObjectByKey<ForTestInheritanceILeftRight>(1);

						ForTestInheritanceIRightLeft
							forTestInheritanceIRightLeft = session.GetObjectByKey<ForTestInheritanceIRightLeft>(2);

						ShowReference(session.GetObjectByKey<Reference>(1));
						ShowReference(session.GetObjectByKey<Reference>(2));

						left = new Reference(session);
						left.Value = string.Format("Link# {0}", session.GetObjects(session.GetClassInfo<Reference>(), null, null, 0, true, true).Count + 1);
						left.Save();
						session.Save(left);

						right = new Reference(session);
						right.Value = string.Format("Link# {0}", session.GetObjects(session.GetClassInfo<Reference>(), null, null, 0, true, true).Count + 1);
						right.Save();
						session.Save(right);

						forTestInheritanceILeftRight = new ForTestInheritanceILeftRight(session);
						forTestInheritanceILeftRight.Left = left;
						forTestInheritanceILeftRight.Right = right;
						forTestInheritanceILeftRight.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceILeftRight.Left.Value, forTestInheritanceILeftRight.Right.Value);
						forTestInheritanceILeftRight.Save();
						session.Save(forTestInheritanceILeftRight);

						forTestInheritanceIRightLeft = new ForTestInheritanceIRightLeft(session);
						forTestInheritanceIRightLeft.Left = left;
						forTestInheritanceIRightLeft.Right = right;
						forTestInheritanceIRightLeft.Value = string.Format("{{Left:'{0}', Right:'{1}'}}", forTestInheritanceIRightLeft.Left.Value, forTestInheritanceIRightLeft.Right.Value);
						forTestInheritanceIRightLeft.Save();
						session.Save(forTestInheritanceIRightLeft);
					#endif

                    #if TEST_SINGLE_TABLE
                        #if SHOW_ATTRIBUTES
                            var ci = session.GetClassInfo<TestDEMasterTableWithInheritanceLite>();

                            foreach (var m in ci.OwnMembers)
                                // _id, _valueLite, Id, ValueLite, Details
                                Console.WriteLine(m.Name);

                            AssociationAttribute associationAttribute;

                            var mi = ci.GetMember("Details");
                            foreach (var attribute in mi.Attributes)
                            {
                                if ((associationAttribute = attribute as AssociationAttribute) != null)
                                    // AssociationAttribute: Name = "TestMaster-TestDetail" ElementTypeName ="TestInheritance.Db.TestDEDetailTableWithInheritanceLite"
                                    Console.WriteLine("{0}: Name = \"{1}\" ElementTypeName =\"{2}\"", attribute.GetType().Name, associationAttribute.Name, associationAttribute.ElementTypeName);
                            }

                            ci = session.GetClassInfo<TestDEMasterTableWithInheritance>();

                            foreach (var m in ci.OwnMembers)
                                // _value, Value
                                Console.WriteLine(m.Name);

                            mi = ci.GetMember("Details");
                            foreach (var attribute in mi.Attributes)
                            {
                                if ((associationAttribute = attribute as AssociationAttribute) != null)
                                    // AssociationAttribute: Name = "TestMaster-TestDetail" ElementTypeName ="TestInheritance.Db.TestDEDetailTableWithInheritanceLite"
                                    Console.WriteLine("{0}: Name = \"{1}\" ElementTypeName =\"{2}\"", attribute.GetType().Name, associationAttribute.Name, associationAttribute.ElementTypeName);
                            }

                            var tmpType = typeof(TestDEMasterTableWithInheritance);
                            var rmi = tmpType.GetMember("Details", BindingFlags.Public | BindingFlags.Instance);

                            ci = session.GetClassInfo<TestDEDetailTableWithInheritanceLite>();
                            mi = ci.GetMember("Master");
                            foreach (var attribute in mi.Attributes)
                            {
                                if (attribute is PersistentAttribute)
                                    Console.WriteLine("{0}: MapTo = \"{1}\"", attribute.GetType().Name, (attribute as PersistentAttribute).MapTo);
                                if ((associationAttribute = attribute as AssociationAttribute) != null)
                                    Console.WriteLine("{0}: Name = \"{1}\" ElementTypeName =\"{2}\"", attribute.GetType().Name, associationAttribute.Name, associationAttribute.ElementTypeName);
                            }

                            ci = session.GetClassInfo<TestDEDetailTableWithInheritance>();
                            mi = ci.GetMember("Master");
                            foreach (var attribute in mi.Attributes)
                            {
                                if (attribute is PersistentAttribute)
                                    Console.WriteLine("{0}: MapTo = \"{1}\"", attribute.GetType().Name, (attribute as PersistentAttribute).MapTo);
                                if ((associationAttribute = attribute as AssociationAttribute) != null)
                                    Console.WriteLine("{0}: Name = \"{1}\" ElementTypeName =\"{2}\"", attribute.GetType().Name, associationAttribute.Name, associationAttribute.ElementTypeName);
                            }
                        #endif

                        Console.WriteLine("TestDEMasterTableWithInheritanceLite.IsAssignableFrom(TestDEMasterTableWithInheritance) (TestDEMasterTableWithInheritanceLite->TestDEMasterTableWithInheritance): {0}", typeof(TestDEMasterTableWithInheritanceLite).IsAssignableFrom(typeof(TestDEMasterTableWithInheritance))); // true
                        Console.WriteLine("TestDEMasterTableWithInheritance.IsAssignableFrom(TestDEMasterTableWithInheritanceLite) (TestDEMasterTableWithInheritance->TestDEMasterTableWithInheritanceLite): {0}", typeof(TestDEMasterTableWithInheritance).IsAssignableFrom(typeof(TestDEMasterTableWithInheritanceLite))); // false

                        TestDEMasterTableWithInheritanceLite masterLite;
                        TestDEDetailTableWithInheritanceLite detailLite;
                        TestDEMasterTableWithInheritance master;
                        TestDEDetailTableWithInheritance detail;

                        int key = (tmpObject = session.ExecuteScalar("select min(id) from TestDEMasterTableWithInheritance")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;

                        if ((masterLite = session.GetObjectByKey<TestDEMasterTableWithInheritanceLite>(key)) == null)
                        {
                            masterLite = new TestDEMasterTableWithInheritanceLite(session);
                            masterLite.ValueLite = "ValueLite (from masterLite) by new ()";
                        }
                        else
                            masterLite.ValueLite = "ValueLite (from masterLite) by edit";

                        detailLite = new TestDEDetailTableWithInheritanceLite(session);
                        detailLite.ValueLite = "ValueLite (from detailLite) by new ()";
                        masterLite.Details.Add(detailLite);
                        masterLite.Save();

                        try
                        {
                            master = session.GetObjectByKey<TestDEMasterTableWithInheritance>(key);
                        }
                        catch (Exception eException)
                        {
                            Console.WriteLine("{0}: \"{1}\"", eException.GetType().Name, eException.Message);
                        }

                        key += 1;
                        if ((master = session.GetObjectByKey<TestDEMasterTableWithInheritance>(key)) == null)
                        {
                            master = new TestDEMasterTableWithInheritance(session);
                            master.ValueLite = "ValueLite (from master) by new()";
                            master.Value = "Value (from master) by new()";
                        }
                        else
                        {
                            master.ValueLite = "ValueLite (from master) by edit";
                            master.Value = "Value (from master) by edit";
                        }

                        detail = new TestDEDetailTableWithInheritance(session);
                        detail.ValueLite = "ValueLite (from detail) by new ()";
                        detail.Value = "Value (from detail) by new ()";

                        detail.Master = master;
                        // equ
                        //master.Details.Add(detail);

                        master.Save();

                        Console.WriteLine();
                        if((masterLite = session.GetObjectByKey<TestDEMasterTableWithInheritanceLite>(key)) != null)
                        {
                            Console.WriteLine("{2} {{id: {0}, valueLite: \"{1}\"}}", masterLite.Id, masterLite.ValueLite, masterLite.GetType());
                            Console.WriteLine("Details");
                            foreach (var _detail_ in masterLite.Details)
                                Console.WriteLine("{2} {{id: {0}, valueLite: \"{1}\"}}", _detail_.Id, _detail_.ValueLite, _detail_.GetType());
                        }
                    #endif

                    #if TEST_OWN_TABLE
                        Left left;
                        Right right;

                        if ((left = session.GetObjectByKey<Left>(1)) == null)
                        {
                            left = new Left(session);
                            left.Val = "Val (from Left)";
                            left.ValLeft = "ValLeft";
                            left.Save();
                        }

                        if ((right = session.GetObjectByKey<Right>(1)) == null)
                        {
                            right = new Right(session);
                            right.Val = "Val (from Right)";
                            right.ValRight = "ValRight";
                            right.Save();
                        }

                        if (left != null && session.IsObjectToSave(left))
                            left.Save();

                        if (right != null && session.IsObjectToSave(right))
                            right.Save();
                    #endif
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

		#if TEST_INHERITANCE
			static void ShowReference(Reference reference)
			{
				if (reference == null)
				{
					Console.WriteLine("null");
					return;
				}

				foreach (var item in reference.ForTestInheritanceILeftRightLeft.OfType<ForTestInheritanceILeftRight>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);

				foreach (var item in reference.ForTestInheritanceILeftRightRight.OfType<ForTestInheritanceILeftRight>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);

				foreach (var item in reference.ForTestInheritanceIRightLeftLeft.OfType<ForTestInheritanceIRightLeft>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);

				foreach (var item in reference.ForTestInheritanceIRightLeftRight.OfType<ForTestInheritanceIRightLeft>())
					Console.WriteLine("{{Id:{0}, Value:\"{1}\"}}", item.Id, item.Value);
			}

			static void ShowProperties(Type type)
			{
				var pis = type.GetProperties();

				foreach (var pi in pis)
				{
					Console.WriteLine(pi.Name);

					var attrs = pi.GetCustomAttributes(typeof(PersistentAttribute), true);
					if (attrs.Length > 0)
						Console.WriteLine("MapTo: \"{0}\"", ((PersistentAttribute)attrs[0]).MapTo);

					attrs = pi.GetCustomAttributes(typeof(PersistentAttribute), false);
					if (attrs.Length > 0)
						Console.WriteLine("MapTo: \"{0}\"", ((PersistentAttribute)attrs[0]).MapTo);

					attrs = pi.GetCustomAttributes(typeof(AssociationAttribute), true);
					if (attrs.Length > 0)
						Console.WriteLine("Name: \"{0}\"", ((AssociationAttribute)attrs[0]).Name);

					attrs = pi.GetCustomAttributes(typeof(AssociationAttribute), false);
					if (attrs.Length > 0)
						Console.WriteLine("Name: \"{0}\"", ((AssociationAttribute)attrs[0]).Name);
				}
			}
		#endif
    }
}

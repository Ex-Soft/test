﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using TestDB.TestOwnTable;

namespace TestOwnTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //DevExpress.Xpo.Metadata.ReflectionClassInfo.SuppressSuspiciousMemberInheritanceCheck = true;

                XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString(".", "sa", "123", "testdb");

                using (var session = new UnitOfWork())
                {
                    object tmpObject;

                    var person = new Person(session);
                    person.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from Person")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                    person.Name = "Person";
                    session.Save(person);
                    session.CommitChanges();

                    var employee = new Employee(session);
                    employee.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from Person")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                    employee.Name = "Employee";
                    employee.Salary = 123;

                    person = session.GetObjectByKey<Person>(employee.Id);
                    var employee2 = session.GetObjectByKey<Employee>(employee.Id);
                    session.Save(employee);
                    person = session.GetObjectByKey<Person>(employee.Id);
                    employee2 = session.GetObjectByKey<Employee>(employee.Id);
                    session.CommitChanges();

                    var executive = new Executive(session);
                    executive.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from Person")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                    executive.Name = "Executive";
                    executive.Salary = 456;
                    executive.Bonus = 789;
                    session.Save(executive);
                    session.CommitChanges();

                    var customer = new Customer(session);
                    customer.Id = (tmpObject = session.ExecuteScalar("select max(Id) + 1 from Person")) != null && !Convert.IsDBNull(tmpObject) ? Convert.ToInt32(tmpObject) : 1;
                    customer.Name = "Customer";
                    customer.Preferences = "Preferences";
                    session.Save(customer);
                    session.CommitChanges();
                }
            }
            catch (Exception eException)
            {
                Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }
    }
}

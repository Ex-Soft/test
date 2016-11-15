using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLINQ2SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Testdb
                db = new Testdb("Data Source=nozhenko-s8k;Initial Catalog=testdb;Integrated Security=SSPI;");

            var sql = from s in db.Staffs select s;

            foreach (var s in sql)
            {
                ;
            }

            Staff
                staff=new Staff();

            staff.ID = 2;
            staff.Name = "blah-blah-blah";
            db.Staffs.InsertOnSubmit(staff);
            db.SubmitChanges();
        }
    }
}

using System;
using System.Linq;

namespace ManyToOneII
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestDbContext())
            {
                var tmpDF = new DF { D = "D", E = "E", F = "F" };
                var tmpGI = new GI { G = "G", H = "H", I = "I" };
                var tmpAC = new AC { A = "A", B = "B", C = "C", DF = tmpDF, GI = tmpGI };

                db.ACs.Add(tmpAC);
                var count = db.SaveChanges();

                foreach(var ac in db.ACs)
                    Console.WriteLine("{{ id={0}, A=\"{1}\" }}", ac.id, ac.A);

                foreach(var df in db.DFs)
                    Console.WriteLine("{{ id={0}, D=\"{1}\" }}", df.id, df.D);

                //tmpAC = db.ACs.FirstOrDefault(i => i.id == 2);
                tmpAC = db.ACs.Find(2);
                if (tmpAC != null)
                {
                    tmpAC.DF.D = "AC.D";

                    tmpDF = db.DFs.FirstOrDefault(i => i.id == 2);
                    if(tmpDF!=null)
                        Console.WriteLine("{{ id={0}, D=\"{1}\" }}", tmpDF.id, tmpDF.D);

                    db.SaveChanges();

                    tmpDF = db.DFs.FirstOrDefault(i => i.id == 2);
                    if (tmpDF != null)
                        Console.WriteLine("{{ id={0}, D=\"{1}\" }}", tmpDF.id, tmpDF.D);
                }
            }
        }
    }
}

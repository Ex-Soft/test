using System;

namespace ManyToOne
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestDbContext())
            {
                var ac = new AC { A = "A", B = "B", C = "C"};
                var df = new DF { D = "D", E = "E", F = "F" };
                var gi = new GI { G = "G", H = "H", I = "I" };

                db.ACs.Add(ac);
                db.DFs.Add(df);
                db.GIs.Add(gi);
                var count = db.SaveChanges();

                foreach (var o in db.Bases)
                {
                    Console.WriteLine("{{ id={0} }} ({1})", o.id, o.GetType());
                }
            }
        }
    }
}

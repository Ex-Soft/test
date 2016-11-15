using System.Data.Entity;
using ABC.Models.Mapping;

namespace ABC.Models
{
    /*public class TestModelDbContext : DbContext
    {
        static TestModelDbContext()
        {
            Database.SetInitializer<TestModelDbContext>(null);
        }

        public TestModelDbContext() : base("name=TestModelDbContext")
        {
            System.Diagnostics.Debug.WriteLine(Database.Connection.ConnectionString);
        }

        public DbSet<TestTable4TestPIVOTStore> TestTable4TestPIVOTStores { get; set; }
        public DbSet<TestTable4TestPIVOTProduct> TestTable4TestPIVOTProducts { get; set; }
        public DbSet<TestTable4TestPIVOTList> TestTable4TestPIVOTList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TestTable4TestPIVOTStoreMap());
            modelBuilder.Configurations.Add(new TestTable4TestPIVOTProductMap());
            modelBuilder.Configurations.Add(new TestTable4TestPIVOTListMap());
        }
    }*/
}
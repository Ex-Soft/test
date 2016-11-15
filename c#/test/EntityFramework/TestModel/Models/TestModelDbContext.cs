using System.Data.Entity;
using TestModel.Models.Mapping;

namespace TestModel.Models
{
    public class TestModelDbContext : DbContext
    {
        static TestModelDbContext()
        {
            Database.SetInitializer<TestModelDbContext>(null);
        }

        public TestModelDbContext() : base("name=TestModelDbContext")
        {
            System.Diagnostics.Debug.WriteLine(Database.Connection.ConnectionString);
        }

        public DbSet<TestTable4TestPivotStore> TestTable4TestPivotStores { get; set; }
        public DbSet<TestTable4TestPivotProduct> TestTable4TestPivotProducts { get; set; }
        public DbSet<TestTable4TestPivotList> TestTable4TestPivotList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TestTable4TestPivotStoreMap());
            modelBuilder.Configurations.Add(new TestTable4TestPivotProductMap());
            modelBuilder.Configurations.Add(new TestTable4TestPivotListMap());
        }
    }
}
using System.Data.Entity;
using TestGridWithServerMode.Models.EF.Mapping;

namespace TestGridWithServerMode.Models.EF
{
    class TestDBContext : DbContext
    {
        static TestDBContext()
        {
            Database.SetInitializer<TestDBContext>(null);
        }

        public TestDBContext() : base("Name=TestDBContext")
        {
        }

        public DbSet<TableWithHugeData> TableWithHugeData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TableWithHugeDataMap());
        }
    }
}

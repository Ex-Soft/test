using System.Data.Entity;
using TestPivotReportWithPaging.Models.Mapping;

namespace TestPivotReportWithPaging.Models
{
    public class TestPivotReportDbContext : DbContext
    {
        static TestPivotReportDbContext()
        {
            Database.SetInitializer<TestPivotReportDbContext>(null);
        }

        public TestPivotReportDbContext() : base("name=TestPivotReportDbContext")
        {}

        public DbSet<Data4TestDEPivotGrid> Data4TestDEPivotGrids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Data4TestDEPivotGridMap());
        }
    }
}
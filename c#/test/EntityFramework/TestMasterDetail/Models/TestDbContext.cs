using System.Data.Entity;
using TestMasterDetail.Models;
using TestMasterDetail.Models.Mapping;

namespace TestMasterDetail
{
    class TestDbContext : DbContext
    {
        public DbSet<Master> Masters { get; set; }
        public DbSet<Detail> Details { get; set; }

        static TestDbContext()
        {
            Database.SetInitializer<TestDbContext>(null);
        }

        public TestDbContext() : base("name=testdbContext")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MasterMap());
            modelBuilder.Configurations.Add(new DetailMap());
        }
    }
}

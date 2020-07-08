using System.Data.Entity;
using TestUOW.Models.Mapping;

namespace TestUOW.Models
{
    public class TestDbContext : DbContext
    {
        static TestDbContext()
        {
            Database.SetInitializer<TestDbContext>(null);
        }

        public TestDbContext() : base("Name=TestDbContext")
        { }

        public DbSet<TestMaster> TestMasters { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TestMasterMap());
            modelBuilder.Configurations.Add(new TestDetailMap());
            modelBuilder.Configurations.Add(new StaffMap());
        }
    }
}

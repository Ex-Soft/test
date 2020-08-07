using System.Data.Entity;
using OneToOne.Models.Mapping;

namespace OneToOne.Models
{
    public class OneToOneDbContext : DbContext
    {
        static OneToOneDbContext()
        {
            Database.SetInitializer<OneToOneDbContext>(null);
        }

        public OneToOneDbContext() : base("Name=OneToOneDbContext")
        {}

        public DbSet<TestTable4TestPIVOTStore> TestTable4TestPIVOTStores { get; set; }
        public DbSet<TestTable4TestPIVOTProduct> TestTable4TestPIVOTProducts { get; set; }
        public DbSet<TestTable4TestPIVOTList> TestTable4TestPIVOTList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TestTable4TestPIVOTStoreMap());
            modelBuilder.Configurations.Add(new TestTable4TestPIVOTProductMap());
            modelBuilder.Configurations.Add(new TestTable4TestPIVOTListMap());
        }
    }
}
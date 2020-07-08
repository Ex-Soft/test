using System.Data.Entity;

namespace ManyToOne
{
    class TestDbContext : DbContext
    {
        public DbSet<Base> Bases { get; set; }
        public DbSet<AC> ACs { get; set; }
        public DbSet<DF> DFs { get; set; }
        public DbSet<GI> GIs { get; set; }

        static TestDbContext()
        {
            Database.SetInitializer<TestDbContext>(null);
        }

        public TestDbContext() : base("Name=testdbContext")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BaseMap());
            modelBuilder.Configurations.Add(new ACMap());
            modelBuilder.Configurations.Add(new DFMap());
            modelBuilder.Configurations.Add(new GIMap());
        }
    }
}

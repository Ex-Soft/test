using System.Data.Entity;

namespace ManyToOneII
{
    class TestDbContext : DbContext
    {
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
            modelBuilder.Entity<AC>().HasRequired(e => e.DF).WithRequiredPrincipal(e => e.AC);
            modelBuilder.Entity<AC>().HasRequired(e => e.GI).WithRequiredPrincipal(e => e.AC);
            modelBuilder.Entity<DF>().HasRequired(e => e.GI).WithRequiredPrincipal(e => e.DF);

            modelBuilder.Entity<AC>().ToTable("TestTableManyToOne");
            modelBuilder.Entity<DF>().ToTable("TestTableManyToOne");
            modelBuilder.Entity<GI>().ToTable("TestTableManyToOne");
        }
    }
}

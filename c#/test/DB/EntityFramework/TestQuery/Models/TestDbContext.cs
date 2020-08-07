using System.Data.Entity;
using TestQuery.Models.Mapping;

namespace TestQuery.Models
{
    public class TestDbContext : DbContext
    {
        static TestDbContext()
        {
            Database.SetInitializer<TestDbContext>(null);
        }

        public TestDbContext() : base("name=TestDbContext")
        {
            System.Diagnostics.Debug.WriteLine(Database.Connection.ConnectionString);
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StaffMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new DocumentMap());
        }
    }
}
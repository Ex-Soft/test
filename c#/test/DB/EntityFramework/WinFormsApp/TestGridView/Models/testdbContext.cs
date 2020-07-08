using System.Data.Entity;
using TestGridView.Models.Mapping;

namespace TestGridView.Models
{
    public partial class testdbContext : DbContext
    {
        static testdbContext()
        {
            Database.SetInitializer<testdbContext>(null);
        }

        public testdbContext() : base("name=testdbContext")
        {}

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StaffMap());
        }
    }
}

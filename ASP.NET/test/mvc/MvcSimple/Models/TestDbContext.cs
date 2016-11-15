using System.Data.Entity;
using MvcSimple.Models.Mapping;

namespace MvcSimple.Models
{
    public class TestDbContext : DbContext
    {
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StaffMap());
        }
    }
}
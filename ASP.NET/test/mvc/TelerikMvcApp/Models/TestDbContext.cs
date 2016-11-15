using System.Data.Entity;
using TelerikMvcApp.Models.Mapping;

namespace TelerikMvcApp.Models
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
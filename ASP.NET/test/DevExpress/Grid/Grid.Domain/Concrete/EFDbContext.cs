using System.Data.Entity;
using Grid.Domain.Entities;

namespace Grid.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Staff> Staffs { get; set; } 
    }
}

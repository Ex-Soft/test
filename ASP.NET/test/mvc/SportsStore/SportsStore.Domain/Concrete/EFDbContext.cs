using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
		public DbSet<Product> Products { get; set; }
	}
}

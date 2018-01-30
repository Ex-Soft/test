using System.Data.Entity;
using TestPivotGridWithServerMode.Models.Mapping;

namespace TestPivotGridWithServerMode.Models
{
    public class PivotGridDemoDBContext : DbContext
    {
        static PivotGridDemoDBContext()
        {
            Database.SetInitializer<PivotGridDemoDBContext>(null);
        }

        public PivotGridDemoDBContext() : base("Name=PivotGridDemoDBContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesPeople> SalesPeoples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SaleMap());
            modelBuilder.Configurations.Add(new SalesPeopleMap());
        }
    }
}

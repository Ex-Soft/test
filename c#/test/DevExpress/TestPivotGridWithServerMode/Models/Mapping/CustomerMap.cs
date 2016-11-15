using System.Data.Entity.ModelConfiguration;

namespace TestPivotGridWithServerMode.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(t => t.OID);

            Property(t => t.CustomerName).HasMaxLength(100);

            ToTable("Customers");
            Property(t => t.OID).HasColumnName("OID");
            Property(t => t.CustomerName).HasColumnName("CustomerName");
            Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            Property(t => t.GCRecord).HasColumnName("GCRecord");
        }
    }
}

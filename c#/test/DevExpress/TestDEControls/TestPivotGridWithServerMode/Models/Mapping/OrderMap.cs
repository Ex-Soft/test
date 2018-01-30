using System.Data.Entity.ModelConfiguration;

namespace TestPivotGridWithServerMode.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            HasKey(t => t.OID);

            ToTable("Orders");
            Property(t => t.OID).HasColumnName("OID");
            Property(t => t.IdSalesPerson).HasColumnName("SalesPerson");
            Property(t => t.IdCustomer).HasColumnName("Customer");
            Property(t => t.OrderDate).HasColumnName("OrderDate");
            Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            Property(t => t.GCRecord).HasColumnName("GCRecord");

            HasRequired(t => t.SalesPeople).WithMany(t => t.Orders).HasForeignKey(t => t.IdSalesPerson);
            HasRequired(t => t.Customer).WithMany(t => t.Orders).HasForeignKey(t => t.IdCustomer);
        }
    }
}

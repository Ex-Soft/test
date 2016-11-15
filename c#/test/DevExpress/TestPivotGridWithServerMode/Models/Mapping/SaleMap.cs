using System.Data.Entity.ModelConfiguration;

namespace TestPivotGridWithServerMode.Models.Mapping
{
    public class SaleMap : EntityTypeConfiguration<Sale>
    {
        public SaleMap()
        {
            HasKey(t => t.OID);

            ToTable("Sales");
            Property(t => t.OID).HasColumnName("OID");
            Property(t => t.IdOrder).HasColumnName("Order");
            Property(t => t.IdProduct).HasColumnName("Product");
            Property(t => t.Quantity).HasColumnName("Quantity");
            Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            Property(t => t.GCRecord).HasColumnName("GCRecord");

            HasRequired(t => t.Order).WithMany(t => t.Sales).HasForeignKey(t => t.IdOrder);
            HasRequired(t => t.Product).WithMany(t => t.Sales).HasForeignKey(t => t.IdProduct);
        }
    }
}

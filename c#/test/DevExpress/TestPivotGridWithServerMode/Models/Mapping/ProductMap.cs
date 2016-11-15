using System.Data.Entity.ModelConfiguration;

namespace TestPivotGridWithServerMode.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(t => t.OID);

            Property(t => t.ProductName).HasMaxLength(100);

            ToTable("Products");
            Property(t => t.OID).HasColumnName("OID");
            Property(t => t.ProductName).HasColumnName("ProductName");
            Property(t => t.IdCategory).HasColumnName("Category");
            Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            Property(t => t.GCRecord).HasColumnName("GCRecord");

            HasRequired(t => t.Category).WithMany(t => t.Products).HasForeignKey(t => t.IdCategory);
        }
    }
}

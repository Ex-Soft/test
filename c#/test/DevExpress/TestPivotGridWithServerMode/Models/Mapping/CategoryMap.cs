using System.Data.Entity.ModelConfiguration;

namespace TestPivotGridWithServerMode.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(t => t.OID);

            Property(t => t.CategoryName).HasMaxLength(100);

            ToTable("Categories");
            Property(t => t.OID).HasColumnName("OID");
            Property(t => t.CategoryName).HasColumnName("CategoryName");
            Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            Property(t => t.GCRecord).HasColumnName("GCRecord");
        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace TestPivotGridWithServerMode.Models.Mapping
{
    public class SalesPeopleMap : EntityTypeConfiguration<SalesPeople>
    {
        public SalesPeopleMap()
        {
            HasKey(t => t.OID);

            Property(t => t.SalesPersonName).HasMaxLength(100);

            ToTable("SalesPeople");
            Property(t => t.OID).HasColumnName("OID");
            Property(t => t.SalesPersonName).HasColumnName("SalesPersonName");
            Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            Property(t => t.GCRecord).HasColumnName("GCRecord");
        }
    }
}

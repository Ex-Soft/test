using System.Data.Entity.ModelConfiguration;

namespace TestGridWithServerMode.Models.EF.Mapping
{
    class TableWithHugeDataMap : EntityTypeConfiguration<TableWithHugeData>
    {
        public TableWithHugeDataMap()
        {
            HasKey(t => t.Id);

            Property(t => t.FString).HasMaxLength(254);

            ToTable("TableWithHugeData");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.FString).HasColumnName("FString");
        }
    }
}

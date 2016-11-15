using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestPivotReportWithPaging.Models.Mapping
{
    public class Data4TestDEPivotGridMap : EntityTypeConfiguration<Data4TestDEPivotGrid>
    {
        public Data4TestDEPivotGridMap()
        {
            // Primary Key
            HasKey(t => t.id);

            // Properties
            Property(t => t.year);
            Property(t => t.quarter);
            Property(t => t.month);
            Property(t => t.day);
            Property(t => t.name).HasMaxLength(255);
            Property(t => t.value);

            // Table & Column Mappings
            ToTable("Data4TestDEPivotGrid");
            Property(t => t.id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.year).HasColumnName("year");
            Property(t => t.quarter).HasColumnName("quarter");
            Property(t => t.month).HasColumnName("month");
            Property(t => t.day).HasColumnName("day");
            Property(t => t.name).HasColumnName("name");
            Property(t => t.value).HasColumnName("value");
        }
    }
}

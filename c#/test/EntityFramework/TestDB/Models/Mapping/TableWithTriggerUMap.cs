using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TableWithTriggerUMap : EntityTypeConfiguration<TableWithTriggerU>
    {
        public TableWithTriggerUMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TableWithTriggerU");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.value1).HasColumnName("value1");
            this.Property(t => t.value2).HasColumnName("value2");
            this.Property(t => t.value3).HasColumnName("value3");
            this.Property(t => t.recordModify).HasColumnName("recordModify");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TableWithTriggerAfterMap : EntityTypeConfiguration<TableWithTriggerAfter>
    {
        public TableWithTriggerAfterMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.value)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("TableWithTriggerAfter");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.value).HasColumnName("value");
        }
    }
}

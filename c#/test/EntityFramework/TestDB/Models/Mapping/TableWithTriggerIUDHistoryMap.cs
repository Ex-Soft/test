using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TableWithTriggerIUDHistoryMap : EntityTypeConfiguration<TableWithTriggerIUDHistory>
    {
        public TableWithTriggerIUDHistoryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Value, t.RecordModify });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("TableWithTriggerIUDHistory");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.RecordModify).HasColumnName("RecordModify");
        }
    }
}

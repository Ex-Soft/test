using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TableWithHierarchyMap : EntityTypeConfiguration<TableWithHierarchy>
    {
        public TableWithHierarchyMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Val)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TableWithHierarchy");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Val).HasColumnName("Val");

            // Relationships
            this.HasOptional(t => t.TableWithHierarchy2)
                .WithMany(t => t.TableWithHierarchy1)
                .HasForeignKey(d => d.ParentId);

        }
    }
}

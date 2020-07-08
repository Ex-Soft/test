using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestDetailMap : EntityTypeConfiguration<TestDetail>
    {
        public TestDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Val)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TestDetail");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdMaster).HasColumnName("IdMaster");
            this.Property(t => t.Val).HasColumnName("Val");
            this.Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            this.Property(t => t.GCRecord).HasColumnName("GCRecord");

            // Relationships
            this.HasRequired(t => t.TestMaster)
                .WithMany(t => t.TestDetails)
                .HasForeignKey(d => d.IdMaster);

        }
    }
}

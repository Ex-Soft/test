using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestMasterMap : EntityTypeConfiguration<TestMaster>
    {
        public TestMasterMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Val)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TestMaster");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Val).HasColumnName("Val");
            this.Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            this.Property(t => t.GCRecord).HasColumnName("GCRecord");
        }
    }
}

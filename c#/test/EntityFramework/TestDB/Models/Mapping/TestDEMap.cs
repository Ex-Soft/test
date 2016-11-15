using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestDEMap : EntityTypeConfiguration<TestDE>
    {
        public TestDEMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestDE");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.f1).HasColumnName("f1");
            this.Property(t => t.f2).HasColumnName("f2");
            this.Property(t => t.f3).HasColumnName("f3");
            this.Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            this.Property(t => t.GCRecord).HasColumnName("GCRecord");
        }
    }
}

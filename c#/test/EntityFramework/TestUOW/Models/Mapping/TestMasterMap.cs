using System.Data.Entity.ModelConfiguration;

namespace TestUOW.Models.Mapping
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
        }
    }
}

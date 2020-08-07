using System.Data.Entity.ModelConfiguration;

namespace TestUOW.Models.Mapping
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
            this.Property(t => t.TestMasterId).HasColumnName("IdMaster");
            this.Property(t => t.Val).HasColumnName("Val");

            // Relationships
            this.HasRequired(t => t.TestMaster)
                .WithMany(t => t.TestDetails)
                .HasForeignKey(d => d.TestMasterId);
        }
    }
}

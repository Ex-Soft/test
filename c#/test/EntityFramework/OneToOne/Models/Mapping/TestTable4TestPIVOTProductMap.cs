using System.Data.Entity.ModelConfiguration;

namespace OneToOne.Models.Mapping
{
    public class TestTable4TestPIVOTProductMap : EntityTypeConfiguration<TestTable4TestPIVOTProduct>
    {
        public TestTable4TestPIVOTProductMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(256);

            // Table & Column Mappings
            ToTable("TestTable4TestPIVOTProducts");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}

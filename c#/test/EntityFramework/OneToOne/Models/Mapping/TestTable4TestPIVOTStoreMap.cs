using System.Data.Entity.ModelConfiguration;

namespace OneToOne.Models.Mapping
{
    public class TestTable4TestPIVOTStoreMap : EntityTypeConfiguration<TestTable4TestPIVOTStore>
    {
        public TestTable4TestPIVOTStoreMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(256);

            // Table & Column Mappings
            ToTable("TestTable4TestPIVOTStores");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}

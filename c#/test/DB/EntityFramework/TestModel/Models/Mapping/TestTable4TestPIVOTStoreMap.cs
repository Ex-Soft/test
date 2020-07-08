using System.Data.Entity.ModelConfiguration;

namespace TestModel.Models.Mapping
{
    public class TestTable4TestPivotStoreMap : EntityTypeConfiguration<TestTable4TestPivotStore>
    {
        public TestTable4TestPivotStoreMap()
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

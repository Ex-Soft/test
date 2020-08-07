using System.Data.Entity.ModelConfiguration;

namespace TestModel.Models.Mapping
{
    public class TestTable4TestPivotProductMap : EntityTypeConfiguration<TestTable4TestPivotProduct>
    {
        public TestTable4TestPivotProductMap()
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

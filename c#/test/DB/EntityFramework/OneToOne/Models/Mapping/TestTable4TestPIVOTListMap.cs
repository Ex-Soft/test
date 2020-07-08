using System.Data.Entity.ModelConfiguration;

namespace OneToOne.Models.Mapping
{
    public class TestTable4TestPIVOTListMap : EntityTypeConfiguration<TestTable4TestPIVOTList>
    {
        public TestTable4TestPIVOTListMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.IdStore);
            Property(t => t.IdProduct);
            Property(t => t.Cnt);

            // Table & Column Mappings
            ToTable("TestTable4TestPIVOTList");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.IdStore).HasColumnName("IdStore");
            Property(t => t.IdProduct).HasColumnName("IdProduct");
            Property(t => t.Cnt).HasColumnName("Cnt");

            HasRequired(t => t.Store).WithOptional(t => t.TestTable4TestPIVOTList);
            HasRequired(t => t.Product).WithOptional(t => t.TestTable4TestPIVOTList);
        }
    }
}

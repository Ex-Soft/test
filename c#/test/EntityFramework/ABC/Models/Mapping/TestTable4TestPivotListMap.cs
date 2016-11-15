using System.Data.Entity.ModelConfiguration;

namespace ABC.Models.Mapping
{
    public class TestTable4TestPivotListMap : EntityTypeConfiguration<TestTable4TestPivotList>
    {
        public TestTable4TestPivotListMap()
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
            Property(t => t.IdStore).HasColumnName("IdStore").IsOptional();
            Property(t => t.IdProduct).HasColumnName("IdProduct").IsOptional();
            Property(t => t.Cnt).HasColumnName("Cnt").IsOptional();

            // http://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx

            //HasRequired(t => t.Store).WithMany(t => t.TestTable4TestPivotLists).HasForeignKey(t => t.IdStore);
            //HasRequired(t => t.Product).WithMany(t => t.TestTable4TestPivotLists).HasForeignKey(t => t.IdProduct);
            
            // Nullable foreign key for one-to-many relationship.
            HasOptional(t => t.Store).WithMany(t => t.TestTable4TestPivotLists).HasForeignKey(t => t.IdStore);
            HasOptional(t => t.Product).WithMany(t => t.TestTable4TestPivotLists).HasForeignKey(t => t.IdProduct);
        }
    }
}

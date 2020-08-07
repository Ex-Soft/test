using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestTableWithNullFieldMap : EntityTypeConfiguration<TestTableWithNullField>
    {
        public TestTableWithNullFieldMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestTableWithNullField");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.val).HasColumnName("val");
        }
    }
}

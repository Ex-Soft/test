using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestTable4ApplyIIMap : EntityTypeConfiguration<TestTable4ApplyII>
    {
        public TestTable4ApplyIIMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestTable4ApplyII");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Field1).HasColumnName("Field1");
            this.Property(t => t.Field2).HasColumnName("Field2");
        }
    }
}

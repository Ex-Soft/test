using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestTable4ApplyIMap : EntityTypeConfiguration<TestTable4ApplyI>
    {
        public TestTable4ApplyIMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestTable4ApplyI");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Field1).HasColumnName("Field1");
            this.Property(t => t.Field2).HasColumnName("Field2");
        }
    }
}

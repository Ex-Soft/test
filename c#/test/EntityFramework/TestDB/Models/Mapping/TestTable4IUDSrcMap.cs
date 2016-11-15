using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestTable4IUDSrcMap : EntityTypeConfiguration<TestTable4IUDSrc>
    {
        public TestTable4IUDSrcMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TestTable4IUDSrc");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Val).HasColumnName("Val");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestTable4IUDDestMap : EntityTypeConfiguration<TestTable4IUDDest>
    {
        public TestTable4IUDDestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TestTable4IUDDest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Val).HasColumnName("Val");
        }
    }
}

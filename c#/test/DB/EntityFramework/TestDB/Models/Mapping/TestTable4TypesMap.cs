using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestTable4TypesMap : EntityTypeConfiguration<TestTable4Types>
    {
        public TestTable4TypesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FVarChar)
                .HasMaxLength(256);

            this.Property(t => t.FNVarChar)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("TestTable4Types");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FVarChar).HasColumnName("FVarChar");
            this.Property(t => t.FNVarChar).HasColumnName("FNVarChar");
            this.Property(t => t.FBit).HasColumnName("FBit");
        }
    }
}

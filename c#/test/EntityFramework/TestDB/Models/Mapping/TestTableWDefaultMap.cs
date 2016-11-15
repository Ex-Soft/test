using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestTableWDefaultMap : EntityTypeConfiguration<TestTableWDefault>
    {
        public TestTableWDefaultMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.UsrName, t.DtTm });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.UsrName)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("TestTableWDefault");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Val).HasColumnName("Val");
            this.Property(t => t.UsrName).HasColumnName("UsrName");
            this.Property(t => t.DtTm).HasColumnName("DtTm");
        }
    }
}

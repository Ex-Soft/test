using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class VictimMap : EntityTypeConfiguration<Victim>
    {
        public VictimMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Victim");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.f_int).HasColumnName("f_int");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class XPObjectTypeMap : EntityTypeConfiguration<XPObjectType>
    {
        public XPObjectTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.OID);

            // Properties
            this.Property(t => t.TypeName)
                .HasMaxLength(254);

            this.Property(t => t.AssemblyName)
                .HasMaxLength(254);

            // Table & Column Mappings
            this.ToTable("XPObjectType");
            this.Property(t => t.OID).HasColumnName("OID");
            this.Property(t => t.TypeName).HasColumnName("TypeName");
            this.Property(t => t.AssemblyName).HasColumnName("AssemblyName");
        }
    }
}

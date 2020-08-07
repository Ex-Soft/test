using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TableWithImgSrcMap : EntityTypeConfiguration<TableWithImgSrc>
    {
        public TableWithImgSrcMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TableWithImgSrc");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Img).HasColumnName("Img");
            this.Property(t => t.ImgOut).HasColumnName("ImgOut");
        }
    }
}

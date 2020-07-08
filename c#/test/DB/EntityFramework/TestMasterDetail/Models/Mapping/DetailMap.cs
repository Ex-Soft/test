using System.Data.Entity.ModelConfiguration;

namespace TestMasterDetail.Models.Mapping
{
    public class DetailMap : EntityTypeConfiguration<Detail>
    {
        public DetailMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Val)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TestDetail");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.IdMaster).HasColumnName("IdMaster");
            Property(t => t.Val).HasColumnName("Val").IsOptional();

            // Relationships
            HasRequired(t => t.Master)
                .WithMany(t => t.Details)
                .HasForeignKey(d => d.IdMaster);
        }
    }
}

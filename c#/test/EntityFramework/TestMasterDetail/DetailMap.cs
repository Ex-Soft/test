using System.Data.Entity.ModelConfiguration;

namespace TestMasterDetail
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
            Property(t => t.Val).HasColumnName("Val");
            Property(t => t.OptimisticLockField).HasColumnName("OptimisticLockField");
            Property(t => t.GCRecord).HasColumnName("GCRecord");

            // Relationships
            HasRequired(t => t.Master)
                .WithMany(t => t.Details)
                .HasForeignKey(d => d.IdMaster);
        }
    }
}

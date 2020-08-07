using System.Data.Entity.ModelConfiguration;

namespace TestMasterDetail.Models.Mapping
{
    public class MasterMap : EntityTypeConfiguration<Master>
    {
        public MasterMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Val).HasMaxLength(255);

            // Table & Column Mappings
            ToTable("TestMaster");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Val).HasColumnName("Val").IsOptional();
        }
    }
}

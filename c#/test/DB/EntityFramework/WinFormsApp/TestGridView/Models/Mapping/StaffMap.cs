using System.Data.Entity.ModelConfiguration;

namespace TestGridView.Models.Mapping
{
    public class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Name).HasMaxLength(255);

            // Table & Column Mappings
            ToTable("Staff");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Name).HasColumnName("Name").IsOptional();
            Property(t => t.Salary).HasColumnName("Salary").IsOptional();
            Property(t => t.Dep).HasColumnName("Dep").IsOptional();
            Property(t => t.BirthDate).HasColumnName("BirthDate").IsOptional();
            Property(t => t.NullField).HasColumnName("NullField").IsOptional();
        }
    }
}

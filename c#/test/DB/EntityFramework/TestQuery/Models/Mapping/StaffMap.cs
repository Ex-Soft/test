using System.Data.Entity.ModelConfiguration;

namespace TestQuery.Models.Mapping
{
    public class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(255);

            // Table & Column Mappings
            ToTable("Staff");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.Salary).HasColumnName("Salary");
            Property(t => t.Dep).HasColumnName("Dep");
            Property(t => t.BirthDate).HasColumnName("BirthDate");
            Property(t => t.NullField).HasColumnName("NullField").IsOptional();
        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace TestUOW.Models.Mapping
{
    public class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Staff");
            this.Property(t => t.Id).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Salary).HasColumnName("Salary");
            this.Property(t => t.Dep).HasColumnName("Dep");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.NullField).HasColumnName("NullField");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TestAllAnyEmployeeMap : EntityTypeConfiguration<TestAllAnyEmployee>
    {
        public TestAllAnyEmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TestAllAnyEmployee");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.department_id).HasColumnName("department_id");
            this.Property(t => t.chief_id).HasColumnName("chief_id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.salary).HasColumnName("salary");

            // Relationships
            this.HasOptional(t => t.TestAllAnyDepartment)
                .WithMany(t => t.TestAllAnyEmployees)
                .HasForeignKey(d => d.department_id);
            this.HasOptional(t => t.TestAllAnyEmployee2)
                .WithMany(t => t.TestAllAnyEmployee1)
                .HasForeignKey(d => d.chief_id);

        }
    }
}

using System.Data.Entity.ModelConfiguration;

namespace TestQuery.Models.Mapping
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            // Primary Key
            HasKey(t => t.JobID);

            // Table & Column Mappings
            ToTable("Job");
            Property(t => t.JobID).HasColumnName("JobID");
            Property(t => t.Name).HasColumnName("Name");
        }
    }
}

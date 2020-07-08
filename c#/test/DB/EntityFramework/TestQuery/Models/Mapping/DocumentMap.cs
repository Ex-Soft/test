using System.Data.Entity.ModelConfiguration;

namespace TestQuery.Models.Mapping
{
    public class DocumentMap : EntityTypeConfiguration<Document>
    {
        public DocumentMap()
        {
            // Primary Key
            HasKey(t => t.DocumentId);

            // Table & Column Mappings
            ToTable("Document");
            Property(t => t.DocumentId).HasColumnName("DocumentId");
            Property(t => t.JobId).HasColumnName("JobId");
            Property(t => t.DocumentTypeId).HasColumnName("DocumentTypeId");
            Property(t => t.DocumentStatus).HasColumnName("DocumentStatus");

            // Relationships
            HasRequired(t => t.Job)
                .WithMany(t => t.Documents)
                .HasForeignKey(t => t.JobId);
        }
    }
}

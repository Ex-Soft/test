using System.Data.Entity.ModelConfiguration;

namespace MvcMovie.Models.Mapping
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Title);
            Property(t => t.ReleaseDate);
            Property(t => t.Genre);
            Property(t => t.Price);

            // Table & Column Mappings
            ToTable("Movie");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Title).HasColumnName("Title").IsOptional();
            Property(t => t.ReleaseDate).HasColumnName("ReleaseDate").IsOptional();
            Property(t => t.Genre).HasColumnName("Genre").IsOptional();
            Property(t => t.Price).HasColumnName("Price").IsOptional();
        }
    }
}
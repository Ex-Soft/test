using System.Data.Entity;
using MvcMovie.Models.Mapping;

namespace MvcMovie.Models
{
    public class MovieDBContext : DbContext
    {
        static MovieDBContext()
        {
            Database.SetInitializer<MovieDBContext>(null);
        }

        public MovieDBContext() : base("name=MovieDBContext")
        {
            System.Diagnostics.Debug.WriteLine(Database.Connection.ConnectionString);
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieMap());
        }
    }
}
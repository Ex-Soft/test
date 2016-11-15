using System.Collections.Generic;
using System.Data.Entity;
using ABC.Models;
using ABC.Models.Mapping;

namespace ABC
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public decimal FDecimal { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<TestTable4TestPivotStore> TestTable4TestPivotStores { get; set; }
        public DbSet<TestTable4TestPivotProduct> TestTable4TestPivotProducts { get; set; }
        public DbSet<TestTable4TestPivotList> TestTable4TestPivotList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TestTable4TestPivotStoreMap());
            modelBuilder.Configurations.Add(new TestTable4TestPivotProductMap());
            modelBuilder.Configurations.Add(new TestTable4TestPivotListMap());
        }
    } 
}
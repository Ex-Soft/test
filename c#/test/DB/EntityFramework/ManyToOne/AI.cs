using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ManyToOne
{
    public class Base
    {
        [Key]
        public int id { get; set; }
    }

    public class BaseMap : EntityTypeConfiguration<Base>
    {
        public BaseMap()
        {
            // Primary Key
            HasKey(t => t.id);

            // Table & Column Mappings
            ToTable("TestTableManyToOne");
            Property(t => t.id).HasColumnName("id");
        }
    }

    public class AC : Base
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }

    public class ACMap : EntityTypeConfiguration<AC>
    {
        public ACMap()
        {
            // Primary Key
            HasKey(t => t.id);

            // Properties
            Property(t => t.A).HasMaxLength(10);
            Property(t => t.B).HasMaxLength(10);
            Property(t => t.C).HasMaxLength(10);

            // Table & Column Mappings
            ToTable("TestTableManyToOne");
            Property(t => t.id).HasColumnName("id");
            Property(t => t.A).HasColumnName("A");
            Property(t => t.B).HasColumnName("B");
            Property(t => t.C).HasColumnName("C");
        }
    }

    public class DF : Base
    {
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
    }

    public class DFMap : EntityTypeConfiguration<DF>
    {
        public DFMap()
        {
            // Primary Key
            HasKey(t => t.id);

            // Properties
            Property(t => t.D).HasMaxLength(10);
            Property(t => t.E).HasMaxLength(10);
            Property(t => t.F).HasMaxLength(10);

            // Table & Column Mappings
            ToTable("TestTableManyToOne");
            Property(t => t.id).HasColumnName("id");
            Property(t => t.D).HasColumnName("D");
            Property(t => t.E).HasColumnName("E");
            Property(t => t.F).HasColumnName("F");
        }
    }

    public class GI : Base
    {
        public string G { get; set; }
        public string H { get; set; }
        public string I { get; set; }
    }

    public class GIMap : EntityTypeConfiguration<GI>
    {
        public GIMap()
        {
            // Primary Key
            HasKey(t => t.id);

            // Properties
            Property(t => t.G).HasMaxLength(10);
            Property(t => t.H).HasMaxLength(10);
            Property(t => t.I).HasMaxLength(10);

            // Table & Column Mappings
            ToTable("TestTableManyToOne");
            Property(t => t.id).HasColumnName("id");
            Property(t => t.G).HasColumnName("G");
            Property(t => t.H).HasColumnName("H");
            Property(t => t.I).HasColumnName("I");
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ManyToOneII
{
    public class AC
    {
        [Key]
        public int id { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }

        public virtual DF DF { get; set; }
        public virtual GI GI { get; set; }
    }

    public class DF
    {
        [Key]
        public int id { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }

        public virtual AC AC { get; set; }
        public virtual GI GI { get; set; }
    }

    public class GI
    {
        [Key]
        public int id { get; set; }
        public string G { get; set; }
        public string H { get; set; }
        public string I { get; set; }

        public virtual AC AC { get; set; }
        public virtual DF DF { get; set; }
    }
}

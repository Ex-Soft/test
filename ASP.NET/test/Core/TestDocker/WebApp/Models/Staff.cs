using System;

namespace WebApp.Models
{
    public class Staff
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        public int? Dep { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

using System.Collections.Generic;

namespace WebApi.Models
{
    public class ComplexObjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ComplexObjectGroupDto> Groups { get; set; }
    }
}

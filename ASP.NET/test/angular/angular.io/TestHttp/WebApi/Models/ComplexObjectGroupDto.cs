using System.Collections.Generic;

namespace WebApi.Models
{
    public class ComplexObjectGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ComplexObjectGroupItemDto> Items { get; set; }
    }
}

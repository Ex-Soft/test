using System.Collections.Generic;

namespace WebApi.Models
{
    public class TodoGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TodoGroupItemDto> Items { get; set; }
    }
}

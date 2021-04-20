using System.Collections.Generic;

namespace WebApi.Models
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TodoGroupDto> Groups { get; set; }
    }
}

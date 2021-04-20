using System;

namespace WebApi.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}

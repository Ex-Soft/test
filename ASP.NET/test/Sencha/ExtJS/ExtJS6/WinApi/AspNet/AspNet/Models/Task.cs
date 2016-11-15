using System;

namespace AspNet.Models
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Project { get; set; }
        public string Comment { get; set; }
        public TimeSpan TimeLeft { get; set; }
    }
}
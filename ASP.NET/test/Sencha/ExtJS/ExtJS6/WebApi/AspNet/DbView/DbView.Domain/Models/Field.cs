using System;

namespace DbView.Domain.Models
{
    public class Field
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public bool IsKey { get; set; }
        public string Description { get; set; }

        public Field(string name, Type type, bool isKey = false, string description = "")
        {
            Name = name;
            Type = type;
            IsKey = isKey;
            Description = description;
        }
    }
}

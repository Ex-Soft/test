namespace DbView.Domain.Models
{
    public class FieldWithDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public FieldWithDescription(string name, string description = "")
        {
            Name = name;
            Description = description;
        }
    }
}

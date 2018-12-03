namespace DbView.Domain.Models
{
    public class NavigationItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public NavigationItem(int id = 0, string name= "", string description = "")
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}

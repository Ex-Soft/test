namespace DbView.Models
{
    public class NavigationItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public NavigationItem(int _id = 0, string _name = "", string _description = "")
        {
            id = _id;
            name = _name;
            description = _description;
        }
    }
}
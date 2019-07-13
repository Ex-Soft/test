namespace TodoApi
{
    public class Personnel
    {
        public int id {get; set;}
        public string name {get; set;}
        public string email{get; set;}
        public string phone{get; set;}

        public Personnel(int id = 0, string name = "", string email = "", string phone = "")
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.phone = phone;
        }
    }
}
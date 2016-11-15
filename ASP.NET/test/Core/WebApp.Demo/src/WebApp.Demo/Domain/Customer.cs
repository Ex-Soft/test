namespace WebApp.Demo.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName => Name + " " + LastName;
    }
}

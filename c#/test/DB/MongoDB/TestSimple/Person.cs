using MongoDB.Bson;

namespace TestSimple
{
    public class Person
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
    }
}

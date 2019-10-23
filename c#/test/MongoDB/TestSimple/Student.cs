using System.Collections.Generic;
using MongoDB.Bson;

namespace TestSimple
{
    public class Student
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}

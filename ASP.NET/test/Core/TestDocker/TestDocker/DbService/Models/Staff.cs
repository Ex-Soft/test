using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DbService.Models
{
    public class Staff
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        public int? Dep { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

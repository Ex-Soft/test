using System.Collections.Generic;
using DbService.Models;
using MongoDB.Driver;

namespace DbService.Services
{
    public class DbService
    {
        private readonly IMongoCollection<Staff> _staffs;

        public DbService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _staffs = database.GetCollection<Staff>(settings.CollectionName);
        }

        public List<Staff> Get() =>
            _staffs.Find(staff => true).ToList();

        public Staff Get(string id) =>
            _staffs.Find<Staff>(staff => staff.Id == id).FirstOrDefault();

        public Staff Create(Staff staff)
        {
            _staffs.InsertOne(staff);
            return staff;
        }

        public void Update(string id, Staff staffIn) =>
            _staffs.ReplaceOne(staff => staff.Id == id, staffIn);

        public void Remove(Staff staffIn) =>
            _staffs.DeleteOne(staff => staff.Id == staffIn.Id);

        public void Remove(string id) =>
            _staffs.DeleteOne(staff => staff.Id == id);
    }
}

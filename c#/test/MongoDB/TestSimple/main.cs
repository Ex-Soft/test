// https://www.codementor.io/pmbanugo/working-with-mongodb-in-net-1-basics-g4frivcvz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

using static System.Console;

namespace TestSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            try
            {
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                //var client = new MongoClient(new MongoUrl("mongodb://localhost:27017"));
                //var client = new MongoClient(MongoUrl.Create("mongodb://localhost:27017"));
                IMongoDatabase db = client.GetDatabase("test");
                IMongoCollection<Person> myCollection = db.GetCollection<Person>("myCollection");
                IMongoCollection<Person> cappedCollection = db.GetCollection<Person>("cappedCollection");
                IMongoCollection<BsonDocument> nonCappedCollection = db.GetCollection<BsonDocument>("nonCappedCollection");

                BsonDocument document;
                Person person;

                if ((document = nonCappedCollection.Find(new BsonDocument("firstname", "Peter")).FirstOrDefault()) == null)
                {
                    document = new BsonDocument
                    {
                        {"firstname", BsonValue.Create("Peter")},
                        {"lastname", new BsonString("Mbanugo")},
                        {"subjects", new BsonArray(new[] {"English", "Mathematics", "Physics"})},
                        {"class", "JSS 3"},
                        {"age", 45}
                    };

                    await nonCappedCollection.InsertOneAsync(document);
                }

                if ((document = nonCappedCollection.Find("{ firstname: 'Ugo' }").FirstOrDefault()) == null)
                {
                    await nonCappedCollection.InsertManyAsync(CreateNewStudents());
                }

                using (IAsyncCursor<BsonDocument> cursor = await nonCappedCollection.FindAsync(new BsonDocument()))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        IEnumerable<BsonDocument> batch = cursor.Current;
                        foreach (BsonDocument _document_ in batch)
                        {
                            WriteLine(_document_);
                            WriteLine();
                        }
                    }
                }

                FilterDefinition<BsonDocument> filter = FilterDefinition<BsonDocument>.Empty;
                FindOptions<BsonDocument> options = new FindOptions<BsonDocument>
                {
                    BatchSize = 2,
                    NoCursorTimeout = false
                };

                using (IAsyncCursor<BsonDocument> cursor = await nonCappedCollection.FindAsync(filter, options))
                {
                    var batch = 0;
                    while (await cursor.MoveNextAsync())
                    {
                        IEnumerable<BsonDocument> documents = cursor.Current;
                        batch++;

                        WriteLine($"Batch: {batch}");

                        foreach (BsonDocument _document_ in documents)
                        {
                            WriteLine(_document_);
                            WriteLine();
                        }
                    }

                    WriteLine($"Total Batch: { batch}");
                }

                if ((person = myCollection.Find(p => p.Name == "person #4").FirstOrDefault()) == null)
                {
                    await myCollection.InsertOneAsync(new Person { Name = "person #4", Age = 4, Location = "location #4" });
                }

                if ((person = myCollection.Find("{ Age: { '$eq': 2} }").FirstOrDefault()) == null)
                {
                    await myCollection.InsertManyAsync(CreateNewPersons());
                }
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        private static IEnumerable<BsonDocument> CreateNewStudents()
        {
            var student1 = new BsonDocument
            {
                {"firstname", "Ugo"},
                {"lastname", "Damian"},
                {"subjects", new BsonArray {"English", "Mathematics", "Physics", "Biology"}},
                {"class", "JSS 3"},
                {"age", 23}
            };

            var student2 = new BsonDocument
            {
                {"firstname", "Julie"},
                {"lastname", "Lerman"},
                {"subjects", new BsonArray {"English", "Mathematics", "Spanish"}},
                {"class", "JSS 3"},
                {"age", 23}
            };

            var student3 = new BsonDocument
            {
                {"firstname", "Julie"},
                {"lastname", "Lerman"},
                {"subjects", new BsonArray {"English", "Mathematics", "Physics", "Chemistry"}},
                {"class", "JSS 1"},
                {"age", 25}
            };

            var newStudents = new List<BsonDocument>();
            newStudents.Add(student1);
            newStudents.Add(student2);
            newStudents.Add(student3);

            return newStudents;
        }

        private static IEnumerable<Person> CreateNewPersons()
        {
            return new List<Person>
            {
                new Person {Name = "person #1", Age = 1, Location = "location #1"},
                new Person {Name = "person #2", Age = 2, Location = "location #2"},
                new Person {Name = "person #3", Age = 3, Location = "location #3"}
            };
        }

    }
}

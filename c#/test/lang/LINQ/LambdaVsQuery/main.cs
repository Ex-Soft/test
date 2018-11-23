using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaVsQuery
{
    class A
    {
        public int FA { get; set; }

        public static bool operator == (A left, A right)
        {
            return left.FA == right.FA;
        }

        public static bool operator != (A left, A right)
        {
            return !(left.FA == right.FA);
        }
        
        public override bool Equals(object obj)
        {
            bool
                result = false;

            switch (Type.GetTypeCode(obj.GetType()))
            {
                case System.TypeCode.Int32:
                    {
                        result = this.FA == Convert.ToInt32(obj);
                        break;
                    }
                default:
                    {
                        result = this == (A) obj;
                        break;
                    }
            }

            return (result);
        }
    }

    class B
    {
        public int FA { get; set; }
    }

    class C
    {
        public int FA { get; set; }
        public bool FB { get; set; }
        public bool FC { get; set; }

        public override string ToString()
        {
            return string.Format("{{FA:{0}, FB:{1}, FC:{2}}}", FA, FB, FC);
        }
    }

    class D
    {
        public int FI { get; set; }
        public List<C> LC { get; set; }

        public D() : this(default(int), new List<C>())
        {}

        public D(D obj) : this(obj.FI, obj.LC)
        {}

        public D(int fi, List<C> lc)
        {
            FI = fi;
            LC = lc;
        }
    }

    public class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _compareFunc;
        private readonly Func<T, int> _hashFunc;

        public GenericEqualityComparer(Func<T, T, bool> compareFunc)
        {
            _compareFunc = compareFunc;
        }

        public GenericEqualityComparer(Func<T, T, bool> compareFunc, Func<T, int> hashFunc)
            : this(compareFunc)
        {
            _compareFunc = compareFunc;
            _hashFunc = hashFunc;
        }

        public bool Equals(T x, T y)
        {
            return _compareFunc(x, y);
        }

        public int GetHashCode(T obj)
        {
            return _hashFunc != null ? _hashFunc(obj) : obj.GetHashCode();
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    class Document
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentStatus { get; set; }

        public override string ToString()
        {
            return string.Format("{{Id:{0}, JobId:{1}, DocumentTypeId:{2}, DocumentStatus:{3}}}", Id, JobId, DocumentTypeId, DocumentStatus);
        }
    }

    class Job
    {
        public int JobId { get; set; }
        public List<Document> Documents { get; set; }

        public override string ToString()
        {
            return string.Format("{{JobId:{0}}}", JobId);
        }
    }

    class Field
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }

        public Field(string name, Type type, string description = "")
        {
            Name = name;
            Type = type;
            Description = description;
        }

        public override string ToString()
        {
            return $"{{Name:\"{Name}\", Type:\"{Type.GetTypeCode(Type)}\", Description\"{Description}\"}}";
        }
    }

    class FieldWithDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{{Name:\"{Name}\", Description\"{Description}\"}}";
        }
    }

    class Program
	{
		static void Main(string[] args)
		{
		    var listOfC = new List<C>
		    {
                new C { FA = 1, FB = true, FC = true },
                new C { FA = 2, FB = true, FC = false },
                new C { FA = 3, FB = false, FC = true },
                new C { FA = 4, FB = false, FC = false }
            };

		    var listOfD = new List<D>
		    {
                new D(1, listOfC),
                new D(2, listOfC),
                new D(3, listOfC)
            };

		    var selectManyByQuerySyntax = from itemOfD in listOfD
		        where itemOfD.FI == 1
		        from itemOfC in itemOfD.LC
		        select itemOfC;

		    var selectManyByLambdaSyntax = listOfD.Where(itemOfD => itemOfD.FI == 1).SelectMany(itemOfD => itemOfD.LC);

            int[]
				tmpIntsI = { 1, 3, 5 },
				tmpIntsII = { 2, 4, 5 },
                tmpIntsIII;

		    tmpIntsIII = (from i1 in tmpIntsI
                          join i2 in tmpIntsII on i1 equals i2
                          select i1).ToArray(); // { 5 }

		    tmpIntsIII = tmpIntsI.Intersect(tmpIntsII).ToArray(); // { 5 }

            tmpIntsI = new[] { 1, 3, 5, 3, 1 };
            tmpIntsII = new[] { 3, 4, 5 };

            tmpIntsIII = (from i1 in tmpIntsI
                          join i2 in tmpIntsII on i1 equals i2
                          select i1).ToArray(); // { 3, 5, 3 }

		    tmpIntsIII = tmpIntsI.Join(tmpIntsII, outerKeySelector => outerKeySelector, innerKeySelector => innerKeySelector, (outer, inner) => outer).ToArray(); // { 3, 5, 3 }
            tmpIntsIII = tmpIntsI.Join(tmpIntsII, outerKeySelector => outerKeySelector, innerKeySelector => innerKeySelector, (outer, inner) => inner).ToArray(); // { 3, 5, 3 }

            tmpIntsIII = (from i2 in tmpIntsII
                          join i1 in tmpIntsI on i2 equals i1
                          select i2).ToArray(); // { 3, 3, 5 }

            tmpIntsIII = tmpIntsII.Join(tmpIntsI, outerKeySelector => outerKeySelector, innerKeySelector => innerKeySelector, (outer, inner) => outer).ToArray(); // { 3, 3, 5 }
            tmpIntsIII = tmpIntsII.Join(tmpIntsI, outerKeySelector => outerKeySelector, innerKeySelector => innerKeySelector, (outer, inner) => inner).ToArray(); // { 3, 3, 5 }

            tmpIntsIII = tmpIntsI.Intersect(tmpIntsII).ToArray(); // { 3, 5 }

		    tmpIntsI = new[] { 1, 3, 5 };
		    tmpIntsII = new[] { 2, 3, 4 };

			tmpIntsIII = tmpIntsI.Where(f => !tmpIntsII.Contains(f)).ToArray(); // { 1, 5 }
            tmpIntsIII = tmpIntsI.Except(tmpIntsII).ToArray();  // { 1, 5 }
            tmpIntsIII = tmpIntsI.Intersect(tmpIntsII).ToArray(); // { 3 }

		    tmpIntsIII = new int[0];
            tmpIntsIII = tmpIntsIII.Union(tmpIntsI).ToArray(); // { 1, 3, 5 }
		    tmpIntsIII = tmpIntsIII.Union(tmpIntsII).ToArray(); // { 1, 3, 5, 2, 4 }

            List<List<int>>
                list=new List<List<int>>();

		    list.Add(new List<int>(new int[] { 1, 2, 3 }));
            list.Add(new List<int>(new int[] { 4, 5, 6 }));
            list.Add(new List<int>(new int[] { 1, 4, 3 }));

		    List<int>
		        all_all = (from aa in list from bb in aa select bb).ToList();

            all_all.ForEach((item) => {
                Console.WriteLine(item);
            });
            Console.WriteLine();

            List<int>
                all_unique = (from aa in list from bb in aa select bb).Distinct().ToList();

            all_unique.ForEach((item) => {
                Console.WriteLine(item);
            });
            Console.WriteLine();

		    List<A>
		        listOfA1 = new List<A>(new A[] { new A { FA = 1 }, new A { FA = 3 }, new A { FA = 5 } }),
                listOfA2 = new List<A>(new A[] { new A { FA = 2 }, new A { FA = 3 }, new A { FA = 4 } });

            A
                tmpA;

            tmpA = listOfA1.Find(item => item.FA == 1);
            tmpA = listOfA1.Find(item => item.FA == 13);

            List<A>
                listOfA = listOfA1.Where(f => !listOfA2.Contains(f)).ToList();

            listOfA.ForEach((item) => {
                Console.WriteLine(item.FA);                   
            });
            Console.WriteLine();
            
            List<A>
                listOfAFA = listOfA1.Where(f1 => !(from f2 in listOfA2 select f2.FA).Contains(f1.FA)).ToList();

            listOfAFA.ForEach((item) => {
                Console.WriteLine(item.FA);
            });
            Console.WriteLine();

            List<B>
                listOfB1 = new List<B>(new B[] { new B { FA = 1 }, new B { FA = 3 }, new B { FA = 5 } }),
                listOfB2 = new List<B>(new B[] { new B { FA = 2 }, new B { FA = 3 }, new B { FA = 4 } });

            var
                varOfB = listOfB1.Select(i => i).ToList();

            varOfB.ForEach((item) =>
            {
                Console.WriteLine(item.FA);
            });
            Console.WriteLine();

		    List<B>
		        listOfB = listOfB1.Select(i => i).ToList();

            listOfB.ForEach((item) =>
            {
                Console.WriteLine(item.FA);
            });
            Console.WriteLine();
            
            listOfB = listOfB1.Where(f => !listOfB2.Contains(f)).ToList();
            listOfB.ForEach((item) => {
                Console.WriteLine(item.FA);
            });
            Console.WriteLine();

            listOfB = listOfB1.Except(listOfB2, new GenericEqualityComparer<B>((x, y) => x.FA == y.FA, (x) => x.FA.GetHashCode())).ToList();
            listOfB.ForEach((item) => {
                Console.WriteLine(item.FA);
            });
            Console.WriteLine();

            List<B>
                listOfBFA = listOfB1.Where(f1 => !(from f2 in listOfB2 select f2.FA).Contains(f1.FA)).ToList();

            listOfBFA.ForEach((item) => {
                Console.WriteLine(item.FA);
            });
            Console.WriteLine();

		    List<C>
		        tmpListOfCI = new List<C>(new[]
		        {
		            new C {FA = 1, FB = true, FC = false},
		            new C {FA = 2, FB = true, FC = true},
		            new C {FA = 3, FB = true, FC = false}
		        }),
                tmpListOfCII;

		    List<KeyValuePair<int, bool>>
		        tmpListOfCPair = (from e in tmpListOfCI where !e.FC select new KeyValuePair<int, bool>(e.FA, e.FC)).ToList(); // { {1, False}, {3, False} }

		    tmpListOfCII = (from e in tmpListOfCI where !e.FC select e).ToList(); // { {FA:1, FB:True, FC:False}, {FA:3, FB:True, FC:False} }
            tmpListOfCII = (from e in tmpListOfCI where e.FB && e.FC select e).ToList(); // { {FA:2, FB:True, FC:True} }
            tmpListOfCII = (from e in tmpListOfCI where e.FA > 2 || e.FC select e).ToList(); // { {FA:2, FB:True, FC:True}, {FA:3, FB:True, FC:False} }
            tmpListOfCII = (from e in tmpListOfCI where (e.FA = 2) > 0 select e).ToList(); // { {FA:2, FB:True, FC:False}, {FA:2, FB:True, FC:True}, {FA:2, FB:True, FC:False} }
		    tmpListOfCII = (from e in tmpListOfCI where e.FC = true select e).ToList(); // { {FA:2, FB:True, FC:True}, {FA:2, FB:True, FC:True}, {FA:2, FB:True, FC:True} }

            Person
                magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" },
                terry = new Person { FirstName = "Terry", LastName = "Adams" },
                charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" },
                arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet
                barley = new Pet { Name = "Barley", Owner = terry },
                boots = new Pet { Name = "Boots", Owner = terry },
                whiskers = new Pet { Name = "Whiskers", Owner = charlotte },
                bluemoon = new Pet { Name = "Blue Moon", Owner = terry },
                daisy = new Pet { Name = "Daisy", Owner = magnus };

            var people = new List<Person> { magnus, terry, charlotte, arlene };
            var pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

		    var lefJoinResultByQuerySyntax = (from person in people
		        join pet in pets on person equals pet.Owner into gj
		        from subpet in gj.DefaultIfEmpty()
		        select new {person.FirstName, PetName = (subpet == null ? String.Empty : subpet.Name)}).ToArray();

		    var lefJoinResultByLambdaSyntax = people
		        .GroupJoin(pets, person => person, pet => pet.Owner, (outerListPeoples, innerListPets) => new {outerListPeoples.FirstName, PetName = innerListPets.Select(pet => pet.Name)})
		        .SelectMany(groupJoinItem => groupJoinItem.PetName.DefaultIfEmpty(), (groupJoinItem, PetName) => new {groupJoinItem.FirstName, PetName }).ToArray();

            var dbFields = new List<Field>
            {
                new Field("Field# 1", typeof(string)),
                new Field("Field# 2", typeof(int)),
                new Field("Field# 3", typeof(string))
            };

            var fieldsDescriptions = new List<FieldWithDescription>
            {
                new FieldWithDescription { Name = "Field# 1", Description = "Description of Field# 1" },
                new FieldWithDescription { Name = "Field# 2", Description = "Description of Field# 2" }
            };

            var lefJoinResultByLambdaSyntax2 = dbFields.GroupJoin(fieldsDescriptions, dbField => dbField.Name, fieldDescription => fieldDescription.Name, (outerListDbFields, innerListFieldsDescriptions) => new { outerListDbFields.Name, outerListDbFields.Type, Description = innerListFieldsDescriptions.Select(field => field.Description) })
                .SelectMany(groupJoinItem => groupJoinItem.Description.DefaultIfEmpty(), (groupJoinItem, Description) => new Field(groupJoinItem.Name, groupJoinItem.Type, Description)).ToArray();

            tmpIntsI = new[] { 2, 5, 5, 51, 2, 54, 54, 41, 1, 1, 1, 451 };
		    var result = tmpIntsI.GroupBy(d => d).Select(d => new {Value = d.Key, Count = d.Count()}).OrderBy(d => d.Value);
            foreach(var r in result)
                Console.WriteLine("{0} - {1}", r.Value, r.Count);
            Console.WriteLine();

            var result2 = from x in tmpIntsI
                          group x by x
                          into g
                          orderby g.Key
                          select new { Value = g.Key, Count = g.Count() };

            foreach (var r in result2)
                Console.WriteLine("{0} - {1}", r.Value, r.Count);
            Console.WriteLine();

            var crossJoinResultByQuerySyntax = from person in people
                                               from pet in pets
                                               select new
                                               {
                                                   person,
                                                   pet
                                               };

            foreach (var r in crossJoinResultByQuerySyntax)
                Console.WriteLine("{0} - {1}", r.person.FirstName, r.pet.Name);
            Console.WriteLine();

		    var crossJoinResultByLambdaSyntax = people.SelectMany(person => pets, (person, pet) => new {person, pet});
            foreach (var r in crossJoinResultByLambdaSyntax)
                Console.WriteLine("{0} - {1}", r.person.FirstName, r.pet.Name);
            Console.WriteLine();

		    var documents = new List<Document>
		    {
		        new Document { Id = 1, JobId = 1, DocumentTypeId = 32, DocumentStatus = 1 },
                new Document { Id = 2, JobId = 1, DocumentTypeId = 63, DocumentStatus = 2 },
                new Document { Id = 3, JobId = 1, DocumentTypeId = 13, DocumentStatus = 1 }
            };

		    var targetStatus = 2;

		    var docs = documents.SelectMany(document => documents, (siteSurvey, sitePhotos) => new { siteSurvey, sitePhotos }).Where(doc => (doc.siteSurvey.DocumentTypeId == 32 && doc.sitePhotos.DocumentTypeId == 63 && doc.siteSurvey.DocumentStatus == targetStatus && doc.sitePhotos.DocumentStatus <= targetStatus) || (doc.siteSurvey.DocumentTypeId == 32 && doc.sitePhotos.DocumentTypeId == 63 && doc.sitePhotos.DocumentStatus == targetStatus && doc.siteSurvey.DocumentStatus <= targetStatus));
            foreach (var r in docs)
                Console.WriteLine("{0} - {1}", r.siteSurvey, r.sitePhotos);
            Console.WriteLine();

		    var jobs = new List<Job>
		    {
		        new Job
		        {
		            JobId = 1,
		            Documents = new List<Document>
		            {
		                new Document {Id = 1, JobId = 1, DocumentTypeId = 32, DocumentStatus = 1},
		                new Document {Id = 2, JobId = 1, DocumentTypeId = 63, DocumentStatus = 2},
		                new Document {Id = 3, JobId = 1, DocumentTypeId = 13, DocumentStatus = 1}
		            }
		        },
                new Job
                {
                    JobId = 2,
                    Documents = new List<Document>
                    {
                        new Document {Id = 4, JobId = 2, DocumentTypeId = 32, DocumentStatus = 2},
                        new Document {Id = 5, JobId = 2, DocumentTypeId = 63, DocumentStatus = 2},
                        new Document {Id = 6, JobId = 2, DocumentTypeId = 13, DocumentStatus = 1}
                    }
                },
                new Job
                {
                    JobId = 3,
                    Documents = new List<Document>
                    {
                        new Document {Id = 7, JobId = 3, DocumentTypeId = 32, DocumentStatus = 2},
                        new Document {Id = 8, JobId = 3, DocumentTypeId = 63, DocumentStatus = 1},
                        new Document {Id = 9, JobId = 3, DocumentTypeId = 13, DocumentStatus = 1}
                    }
                },
                new Job
                {
                    JobId = 4,
                    Documents = new List<Document>
                    {
                        new Document {Id = 10, JobId = 4, DocumentTypeId = 32, DocumentStatus = 1},
                        new Document {Id = 11, JobId = 4, DocumentTypeId = 63, DocumentStatus = 1},
                        new Document {Id = 12, JobId = 4, DocumentTypeId = 13, DocumentStatus = 1}
                    }
                },
                new Job
                {
                    JobId = 5,
                    Documents = new List<Document>
                    {
                        new Document {Id = 13, JobId = 5, DocumentTypeId = 32, DocumentStatus = 3},
                        new Document {Id = 14, JobId = 5, DocumentTypeId = 63, DocumentStatus = 2},
                        new Document {Id = 15, JobId = 5, DocumentTypeId = 13, DocumentStatus = 1}
                    }
                }
            };

            var jobsWithTargetStatus = jobs.Where(j => j.Documents.SelectMany(document => j.Documents, (siteSurvey, sitePhotos) => new {siteSurvey, sitePhotos}).Any(doc => (doc.siteSurvey.DocumentTypeId == 32 && doc.sitePhotos.DocumentTypeId == 63 && doc.siteSurvey.DocumentStatus == targetStatus && doc.sitePhotos.DocumentStatus <= targetStatus) || (doc.siteSurvey.JobId == doc.sitePhotos.JobId && doc.siteSurvey.DocumentTypeId == 32 && doc.sitePhotos.DocumentTypeId == 63 && doc.sitePhotos.DocumentStatus == targetStatus && doc.siteSurvey.DocumentStatus <= targetStatus)));
            foreach (var r in jobsWithTargetStatus)
                Console.WriteLine("{0}", r);
            Console.WriteLine();

		    var documentTypes = new[] {32, 63};
		    var allowedStatuses = new[] {1, 2};

		    var jobsWithTargetStatus2 = jobs
                .Where(j => j.Documents.Where(d => documentTypes.Contains(d.DocumentTypeId)).Any(d => d.DocumentStatus == 2))
                .Where(j => j.Documents.Where(d => documentTypes.Contains(d.DocumentTypeId)).All(d => allowedStatuses.Contains(d.DocumentStatus)))
                .ToArray();

            foreach (var r in jobsWithTargetStatus2)
                Console.WriteLine("{0}", r);
            Console.WriteLine();

            var jobsWithTargetStatus3 = jobs
                .Where(j => j.Documents.Where(d => documentTypes.Contains(d.DocumentTypeId)).Any(d => d.DocumentStatus == 2) && j.Documents.Where(d => documentTypes.Contains(d.DocumentTypeId)).All(d => allowedStatuses.Contains(d.DocumentStatus)))
                .ToArray();

            foreach (var r in jobsWithTargetStatus3)
                Console.WriteLine("{0}", r);
            Console.WriteLine();

            Console.ReadLine();
		}
	}
}

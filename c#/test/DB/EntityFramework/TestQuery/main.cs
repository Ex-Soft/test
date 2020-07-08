#define TEST_NULLABLE_FIELDS
//#define TEST_LAZY_LOAD
//#define TEST_DOCUMENTS
//#define TEST_EXPRESSION

using System;
using System.Linq;
using TestQuery.Models;

namespace TestQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestDbContext())
            {
				#if TEST_NULLABLE_FIELDS
					decimal? tmpDecimal = 13m;

/*
exec sp_executesql N'SELECT 
    [Extent1].[ID] AS [ID], 
    [Extent1].[Name] AS [Name], 
    [Extent1].[Salary] AS [Salary], 
    [Extent1].[Dep] AS [Dep], 
    [Extent1].[BirthDate] AS [BirthDate], 
    [Extent1].[NullField] AS [NullField]
    FROM [dbo].[Staff] AS [Extent1]
    WHERE (@p__linq__0 IS NULL) AND ([Extent1].[NullField] IS NULL)',N'@p__linq__0 decimal(29,0)',@p__linq__0=NULL
*/
					var staffs = db.Staffs.Where(staff => !tmpDecimal.HasValue && !staff.NullField.HasValue).ToList();

/*
exec sp_executesql N'SELECT 
    [Extent1].[ID] AS [ID], 
    [Extent1].[Name] AS [Name], 
    [Extent1].[Salary] AS [Salary], 
    [Extent1].[Dep] AS [Dep], 
    [Extent1].[BirthDate] AS [BirthDate], 
    [Extent1].[NullField] AS [NullField]
    FROM [dbo].[Staff] AS [Extent1]
    WHERE (@p__linq__0 IS NOT NULL) AND ([Extent1].[NullField] IS NOT NULL) AND ((@p__linq__1 = [Extent1].[NullField]) OR ((@p__linq__1 IS NULL) AND ([Extent1].[NullField] IS NULL)))',N'@p__linq__0 decimal(29,0),@p__linq__1 decimal(29,0)',@p__linq__0=NULL,@p__linq__1=NULL
*/
					staffs = db.Staffs.Where(staff => tmpDecimal.HasValue && staff.NullField.HasValue && tmpDecimal.Value == staff.NullField.Value).ToList();

/*
exec sp_executesql N'SELECT 
    [Extent1].[ID] AS [ID], 
    [Extent1].[Name] AS [Name], 
    [Extent1].[Salary] AS [Salary], 
    [Extent1].[Dep] AS [Dep], 
    [Extent1].[BirthDate] AS [BirthDate], 
    [Extent1].[NullField] AS [NullField]
    FROM [dbo].[Staff] AS [Extent1]
    WHERE (@p__linq__0 = [Extent1].[NullField]) OR ((@p__linq__0 IS NULL) AND ([Extent1].[NullField] IS NULL))',N'@p__linq__0 decimal(29,0)',@p__linq__0=NULL
*/
					staffs = db.Staffs.Where(staff => tmpDecimal.Value == staff.NullField.Value).ToList();

/*
exec sp_executesql N'SELECT 
    [Extent1].[ID] AS [ID], 
    [Extent1].[Name] AS [Name], 
    [Extent1].[Salary] AS [Salary], 
    [Extent1].[Dep] AS [Dep], 
    [Extent1].[BirthDate] AS [BirthDate], 
    [Extent1].[NullField] AS [NullField]
    FROM [dbo].[Staff] AS [Extent1]
    WHERE ((@p__linq__0 IS NULL) AND ([Extent1].[NullField] IS NULL)) OR ((@p__linq__1 IS NOT NULL) AND ([Extent1].[NullField] IS NOT NULL) AND ((@p__linq__2 = [Extent1].[NullField]) OR ((@p__linq__2 IS NULL) AND ([Extent1].[NullField] IS NULL))))',N'@p__linq__0 decimal(29,0),@p__linq__1 decimal(29,0),@p__linq__2 decimal(29,0)',@p__linq__0=NULL,@p__linq__1=NULL,@p__linq__2=NULL
*/
					staffs = db.Staffs.Where(staff => (!tmpDecimal.HasValue && !staff.NullField.HasValue) || (tmpDecimal.HasValue && staff.NullField.HasValue && tmpDecimal.Value == staff.NullField.Value)).ToList();
				#endif

                #if TEST_LAZY_LOAD
                    /*foreach (var job in db.Jobs)
                        Console.WriteLine(job.JobID);

                    foreach (var job in db.Jobs)
                    { 
                        Console.WriteLine(job.JobID);

                        foreach (var doc in job.Documents)
                            Console.WriteLine(doc.DocumentId);
                    }

                    foreach (var doc in db.Documents)
                    {
                        Console.WriteLine("{{DocumentId: {0}, JobId: {1}}}", doc.DocumentId, doc.JobId);
                    }

                    foreach (var doc in db.Documents)
                    {
                        Console.WriteLine("{{DocumentId: {0}, Job.JobID: {1}}}", doc.DocumentId, doc.Job.JobID);
                    }*/

                    var ids = new[] {2, 3};

/*
SELECT 
    [Extent1].[DocumentId] AS [DocumentId], 
    [Extent1].[JobId] AS [JobId], 
    [Extent1].[DocumentTypeId] AS [DocumentTypeId], 
    [Extent1].[DocumentStatus] AS [DocumentStatus]
    FROM [dbo].[Document] AS [Extent1]
    WHERE (1 = [Extent1].[JobId]) AND ([Extent1].[DocumentId] IN (2, 3))
*/
                    //foreach (var doc in db.Jobs.SelectMany(j => j.Documents).Where(d => d.JobId == 1 && ids.Contains(d.DocumentId)))
                    //    Console.WriteLine("{{DocumentId: {0}, Job.Name: {1}}}", doc.DocumentId, doc.Job.Name);

/*
SELECT 
    [Extent1].[DocumentId] AS [DocumentId], 
    [Extent1].[JobId] AS [JobId], 
    [Extent1].[DocumentTypeId] AS [DocumentTypeId], 
    [Extent1].[DocumentStatus] AS [DocumentStatus]
    FROM [dbo].[Document] AS [Extent1]
    WHERE (1 = [Extent1].[JobId]) AND ([Extent1].[DocumentId] IN (2, 3))
*/
                    foreach (var doc in db.Documents.Where(d => d.JobId == 1 && ids.Contains(d.DocumentId)))
                        Console.WriteLine("{{DocumentId: {0}, Job.Name: {1}}}", doc.DocumentId, doc.Job.Name);

                    foreach (var doc in db.Documents)
                    {
                        Console.WriteLine("{{DocumentId: {0}, Job.Name: {1}}}", doc.DocumentId, doc.Job.Name);
                    }
                #endif

                #if TEST_DOCUMENTS
                    var targetStatus = 2;
                    var targetDocTypes = new[] {32, 63};
                    var allowedStatuses = new[] {1, 2};

                    var jobs = db.Jobs
                        .Where(j => j.Documents.Where(d => targetDocTypes.Contains(d.DocumentTypeId)).Any(d => d.DocumentStatus == targetStatus))
                        .Where(j => j.Documents.Where(d => targetDocTypes.Contains(d.DocumentTypeId)).All(d => allowedStatuses.Contains(d.DocumentStatus)))
                        .ToArray();

                    foreach (var job in jobs)
                        Console.WriteLine(job);

                    Console.ReadLine();
                #endif

                #if TEST_EXPRESSION
                    var query = (from s1 in db.Staffs
                                 from s2 in db.Staffs
                                 /*from s3 in db.Staffs*/
                                 select new
                                 {
                                     s1/*.ID*/,
                                     s2/*.Name,
                                     s3.BirthDate*/
                                 });

                    var expression = query.Expression.ToString();
                    var result = query.ToArray();

                    expression = db.Staffs.SelectMany(s1 => db.Staffs, (s1, s2) => new {s1, s2}).Expression.ToString();
                #endif
            }
        }
    }
}

using System;
using System.Data.SqlClient;
using RepoDb;

using static System.Console;

namespace TestSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=True";

            try
            {
                SqlServerBootstrap.Initialize();

                using var connection = new SqlConnection(connectionString).EnsureOpen();
                var staffs = connection.ExecuteQuery<Staff>("select * from Staff");
                // select * from Staff
                foreach (var item in staffs)
                {
                    WriteLine($"{{ID: {item.ID}}}");
                }

                staffs = connection.QueryAll<Staff>();
                // SELECT [ID], [Name], [Salary], [Dep], [BirthDate], [NullField] FROM [Staff] ;
                foreach (var item in staffs)
                {
                    WriteLine($"{{ID: {item.ID}}}");
                }

                var staff = connection.Query<Staff>(s => s.ID == 1);
                // exec sp_executesql N'SELECT [ID], [Name], [Salary], [Dep], [BirthDate], [NullField] FROM [Staff] WHERE ([ID] = @ID) ;',N'@ID bigint',@ID=1
            }
            catch (Exception eException)
            {
                WriteLine($"{eException.GetType().FullName}{Environment.NewLine}Message: {eException.Message}{Environment.NewLine}{(eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? $"InnerException.Message {eException.InnerException.Message}{Environment.NewLine}" : string.Empty)}StackTrace:{Environment.NewLine}{eException.StackTrace}");
            }
        }
    }
}

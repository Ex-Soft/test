using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;

namespace TestDynamic
{
    class TestDbContext : DbContext
    {
        public TestDbContext(DbConnection connection, DbCompiledModel model, bool contextOwnsConnection) : base(connection, model, contextOwnsConnection)
        {
            Database.SetInitializer<TestDbContext>(null);
            //((IObjectContextAdapter)this).ObjectContext.CommandTimeout = DataContext.DataContextEx.CommandTimeOut;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const string
                //connectionString = "Data Source=.;Initial Catalog=testdb;User ID=sa;Password=123;MultipleActiveResultSets=True";
                connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testdb;Integrated Security=true;MultipleActiveResultSets=True";

            var listOfFields = GetFields(connectionString, "Staff") /*new List<Field>
            {
                new Field { FieldName = "ID", FieldType = typeof(long) },
                new Field { FieldName = "Name", FieldType = typeof(string) },
                new Field { FieldName = "Salary", FieldType = typeof(decimal) },
                new Field { FieldName = "Dep", FieldType = typeof(int) },
                new Field { FieldName = "BirthDate", FieldType = typeof(DateTime) }
            }*/;

            var typeOfStaff = StaffTypeBuilder.CompileResultType(listOfFields);
            var builder = new DbModelBuilder(DbModelBuilderVersion.Latest);
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            var method = builder.GetType().GetMethod("Entity");
            method = method.MakeGenericMethod(typeOfStaff);
            method.Invoke(builder, null);

            var con = new SqlConnection(connectionString);
            var model = builder.Build(con);
            var compiledModel = model.Compile();
            var context = new TestDbContext(con, compiledModel, false);
            var query = context.Set(typeOfStaff);
            var nodeType = query.AsQueryable().Expression.NodeType;
            //query.Load();
            var local = query.Local;
        }

        static IEnumerable<Field> GetFields(string connectionString, string tableName)
        {
            var result = new List<Field>();

            SqlConnection connection = null;
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                
                var command = connection.CreateCommand();
                
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("select * from {0}", tableName);
                reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
                
                var schemaTable = reader.GetSchemaTable();

                //for (var i = 0; i < reader.FieldCount; ++i)
                //    result.Add(new Field { FieldName = reader.GetName(i), FieldType = reader.GetFieldType(i) });

                reader.Close();
                connection.Close();

                if (schemaTable == null)
                    return result;

                foreach (DataRow row in schemaTable.Rows)
                {
                    var columnName = Convert.ToString(row["ColumnName"]);
                    var dataType = row["DataType"] as Type;

                    if (Convert.ToBoolean(row["AllowDBNull"]) && (dataType != typeof (string)))
                        dataType = typeof (Nullable<>).MakeGenericType(dataType);

                    result.Add(new Field { FieldName = columnName, FieldType = dataType });
                }
            }
            finally
            {
                if(reader != null && !reader.IsClosed)
                    reader.Close();

                if(connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return result;
        }
    }
}

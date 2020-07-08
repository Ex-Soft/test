using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq.Dynamic;
using System.Diagnostics;
using System.Reflection;

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
            var expression = query.AsQueryable().Expression;
            var nodeType = query.AsQueryable().Expression.NodeType;
            //query.Load();
            //var local = query.Local;

            PropertyInfo
                propertyInfoName = typeOfStaff.GetProperty("Name"),
                propertyInfoBirthDate = typeOfStaff.GetProperty("BirthDate");

            var result = query.AsQueryable().Where("ID = @0", 1);
            foreach (var item in result)
            {
                Debug.WriteLine(propertyInfoName.GetValue(item));
            }

            result = query.AsQueryable().OrderBy("ID").Skip(2).Take(3);
            foreach (var item in result)
            {
                Debug.WriteLine(propertyInfoName.GetValue(item));
            }

            result = query.AsQueryable().Where("ID = @0", 13);
            foreach (var item in result)
            {
                propertyInfoBirthDate.SetValue(item, DateTime.Now);
            }
            context.SaveChanges();

            var staff = Activator.CreateInstance(typeOfStaff);
            propertyInfoName.SetValue(staff, "Newbie");
            propertyInfoBirthDate.SetValue(staff, DateTime.Now);
            query.Add(staff);
            context.SaveChanges();

            var awaiter = query.AsQueryable().Where("ID = @0", 13).ToListAsync().GetAwaiter();
            awaiter.OnCompleted(() => {
                var _list_ = awaiter.GetResult();

                Debug.WriteLine("OnCompleted()");

                for (var i = 0; i < _list_.Count; ++i)
                    Debug.WriteLine($"{{Name: \"{propertyInfoName.GetValue(_list_[i])}\", BirthDate: \"{propertyInfoBirthDate.GetValue(_list_[i])}\"}}");
            });

            var _query_ = query.AsQueryable().Where("ID = @0", 13).ToListAsync();
            _query_.Wait();
            var list = _query_.Result;
            for (var i = 0; i < list.Count; ++i)
                Debug.WriteLine($"{{Name: \"{propertyInfoName.GetValue(list[i])}\", BirthDate: \"{propertyInfoBirthDate.GetValue(list[i])}\"}}");
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

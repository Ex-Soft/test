using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DbView.Domain.Models;

namespace DbView.Domain.Helpers
{
    public sealed class MsSqlDbHelper
    {
        private const string connectionStringKey = "connectionStringKey";

        private static readonly Lazy<MsSqlDbHelper> lazy = new Lazy<MsSqlDbHelper>(() => new MsSqlDbHelper());

        public static MsSqlDbHelper Instance { get { return lazy.Value; } }

        public string ConnectionString { get; }

        private MsSqlDbHelper()
        {
            string connectionStringKeyValue;

            if (string.IsNullOrWhiteSpace(connectionStringKeyValue = ConfigurationManager.AppSettings[connectionStringKey]))
                return;

            if (ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Any(cs => cs.Name == connectionStringKeyValue))
                ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringKeyValue].ConnectionString;
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            var result = new DataTable();

            if (string.IsNullOrWhiteSpace(ConnectionString))
                return result;

            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter da = null;

            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandTimeout = connection.ConnectionTimeout;
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                da = new SqlDataAdapter(command);
                da.Fill(result);
            }
            finally
            {
                if (da != null)
                    da.Dispose();

                if (command != null)
                    command.Dispose();

                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    connection.Dispose();
                }
            }

            return result;
        }

        public ICollection<Field> GetFields(string tableName)
        {
            var result = new List<Field>();

            if (string.IsNullOrWhiteSpace(ConnectionString))
                return result;

            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();

                command = connection.CreateCommand();
                command.CommandTimeout = connection.ConnectionTimeout;
                command.CommandType = CommandType.Text;
                command.CommandText = $"select * from {tableName}";

                reader = command.ExecuteReader(CommandBehavior.SchemaOnly);

                var schemaTable = reader.GetSchemaTable();

                reader.Close();
                connection.Close();

                if (schemaTable == null)
                    return result;

                foreach (DataRow row in schemaTable.Rows)
                {
                    var columnName = Convert.ToString(row["ColumnName"]);
                    var dataType = row["DataType"] as Type;
                    var isKey = false/*Convert.ToBoolean(row["IsKey"])*/;

                    if (Convert.ToBoolean(row["AllowDBNull"]) && (dataType != typeof(string)))
                        dataType = typeof(Nullable<>).MakeGenericType(dataType);

                    result.Add(new Field(columnName, dataType, isKey));
                }
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (command != null)
                    command.Dispose();

                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Dispose();
            }

            return result;
        }

        public ICollection<FieldWithDescription> GetFieldsDescriptions(string tableName)
        {
            var parameters = new[] { new SqlParameter("@tableName", SqlDbType.NVarChar) { Value = tableName } };
            var query = @"
select
	c.name as Name,
	coalesce(cast(ep.value as sql_variant), c.name) as Description
from
	sys.tables t
	join sys.all_columns c on c.object_id = t.object_id
	left join sys.extended_properties ep on ep.major_id = t.object_id and ep.minor_id = c.column_id and ep.class = 1
where
    t.name = @tableName;
";
            return ExecuteQuery(query, parameters).AsEnumerable().Select(field => new FieldWithDescription(Convert.ToString(field["Name"]), Convert.ToString(field["Description"]))).ToArray();
        }
    }
}

using System.Data;
using System.Data.Common;
using System.Linq;

using static System.Console;

namespace TestAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingProviderFactory();
        }

        static void UsingProviderFactory()
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", "System.Data.SqlClient.SqlClientFactory, System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", "MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data");

            var dt = GetProviderFactoryClasses();

            var dbManager = new DBManager(ConfigurationSettings.DbConnectionName);

            var dataTable = dbManager.GetDataTable("select * from Staff", CommandType.Text);
        }

        static DataTable GetProviderFactoryClasses()
        {
            DataTable table = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in table.Rows)
            {
                WriteLine(table.Columns.OfType<DataColumn>().Aggregate(string.Empty, (str, column) =>
                {
                    if (!string.IsNullOrEmpty(str))
                        str += "\t";

                    return str += row[column.ColumnName];
                }));
            }

            return table;
        }
    }
}

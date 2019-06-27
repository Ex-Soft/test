#define TEST_TABLE_VALUED_PARAMETER

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

using static System.Console;

namespace TestSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionStringKey = "connectionString";

            string connectionString = null;

            if (ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Any(cs => cs.Name == connectionStringKey))
                connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;

            if (connectionString == null)
                return;

            try
            {
                #if TEST_TABLE_VALUED_PARAMETER
                    var parameter = new DynamicParameters(new { ids = CreateDataTable(new [] { 1L, 2, 3 }).AsTableValuedParameter("dbo.IdsTableType") });
                    //parameter.Add("ids", CreateDataTable(new[] { 1L, 2, 3 }).AsTableValuedParameter("dbo.IdsTableType"));

                    var result = GetStaff(connectionString, @"
select
    staff.ID, staff.Name, staff.Salary, staff.Dep, staff.BirthDate, staff.NullField
from
    Staff staff
    join @ids ids on ids.id = staff.ID
",
                        parameter).ToArray();

                    WriteLine(result.Length);
                #endif
            }
            catch (Exception eException)
            {
                WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        #if TEST_TABLE_VALUED_PARAMETER
            static IEnumerable<Staff> GetStaff(string connectionString, string query, DynamicParameters parameter)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    return connection.Query<Staff>(query, parameter);
                }
            }

            static DataTable CreateDataTable(IEnumerable<long> ids)
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(long));
                foreach (var id in ids)
                    dataTable.Rows.Add(id);
                return dataTable;
            }
        #endif
    }
}

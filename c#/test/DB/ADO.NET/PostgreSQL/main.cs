#define TEST_DERIVE_PARAMETERS

using System;
using System.Data;
using Npgsql;
using static System.Console;

namespace PostgreSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=masterkey;";

            NpgsqlConnection conn = null;
            NpgsqlCommand cmd = null;

            try
            {
                try
                {
                    conn = new NpgsqlConnection(connectionString);
                    conn.Open();

                    #if TEST_DERIVE_PARAMETERS
                        if (cmd == null)
                            cmd = conn.CreateCommand();
                        else
                            cmd.Parameters.Clear();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "testdb.select_table_from_staff";

                        NpgsqlCommandBuilder.DeriveParameters(cmd);

                        foreach (NpgsqlParameter parameter in cmd.Parameters)
                        {
                            WriteLine($"ParameterName: \"{parameter.ParameterName}\"");
                        }
                    #endif

                    conn.Close();
                }
                catch (Exception eException)
                {
                    WriteLine($"{eException.GetType().FullName}{Environment.NewLine}Message: {eException.Message}{Environment.NewLine}{(eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? $"InnerException.Message {eException.InnerException.Message}{Environment.NewLine}" : string.Empty)}StackTrace:{Environment.NewLine}{eException.StackTrace}");
                }
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}

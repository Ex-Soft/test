using System.Data;

namespace TestAdoNet
{
    public class DBManager
    {
        DatabaseHelper database;

        public DBManager(string connectionStringName)
        {
            database = new DatabaseHelper(connectionStringName);
        }

        public IDbConnection GetDatabasecOnnection()
        {
            return database.GetConnection();
        }

        public void CloseConnection(IDbConnection connection)
        {
            database.CloseConnection(connection);
        }

        public DataTable GetDataTable(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.GetConnection())
            {
                using (var command = database.GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    var dataset = new DataSet();
                    var dataAdaper = database.GetDataAdapter(command);
                    dataAdaper.Fill(dataset);

                    return dataset.Tables[0];
                }
            }
        }
    }
}

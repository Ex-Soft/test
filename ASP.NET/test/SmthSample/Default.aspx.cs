using System;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

namespace SmthSample
{
	public partial class MainPage : System.Web.UI.Page
	{
		public const string
			MainPageSessionSignature = "MainPageSession",
			TableName="SmthTable";

		DataSet
			ds = null;

		protected void Page_Load(object sender, EventArgs e)
		{
			if ((ds = (DataSet)Session[MainPageSessionSignature]) == null)
			{
				Session[MainPageSessionSignature] = ds = new DataSet();

				ds.Tables.Add(TableName);
			}

			if (!IsPostBack)
			{
				FillDataTable(ds.Tables[TableName]);
				GridView1.DataSource=ds.Tables[TableName];
				GridView1.DataBind();
			}
		}

		void FillDataTable(DataTable dt)
		{
			OleDbConnection
				connection = null;

			try
			{
				try
				{
					connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["SybaseASEServer"].ConnectionString);

					connection.Open();

					OleDbCommand
						cmd = connection.CreateCommand();

					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "select * from Test order by Id";

					OleDbDataAdapter
						da=new OleDbDataAdapter(cmd);

					dt.Clear();
					da.Fill(dt);

					if(dt.PrimaryKey.Length==0)
						dt.PrimaryKey=new DataColumn[] {dt.Columns["Id"]};
				}
				catch (Exception eException)
				{
					throw (new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
				}
			}
			finally
			{
				if(connection!=null && connection.State==ConnectionState.Open)
					connection.Close();
			}
		}
	}
}
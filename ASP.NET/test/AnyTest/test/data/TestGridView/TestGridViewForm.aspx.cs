using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace AnyTest
{
	public partial class TestGridViewForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DataTable
					dt = new DataTable();

				FillDataTable(dt);
				GridView1.DataSource = dt;
				GridView1.DataBind();
			}
		}

		void FillDataTable(DataTable dt)
		{
			SqlConnection
				connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MSSQLConnectionString"].ConnectionString);

			SqlDataAdapter
				da = new SqlDataAdapter("select * from Staff", connection);

			da.Fill(dt);
			dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };
		}

		protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType != DataControlRowType.DataRow)
				return;

			e.Row.Attributes.Add("onclick", "alert('\"" + Convert.ToString(Convert.ToInt64((e.Row.DataItem as System.Data.DataRowView).Row["ID"])) + "\"');");
			e.Row.CssClass = "data";
		}
	}
}
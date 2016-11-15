using System;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

namespace SmthSample
{
	public partial class DetailPage : System.Web.UI.Page
	{
		DataSet
			ds = null;

		protected void Page_Load(object sender, EventArgs e)
		{
			if ((ds = (DataSet)Session[MainPage.MainPageSessionSignature]) == null)
				throw(new Exception("DataSet is empty!!!"));

			string[]
				ParamArray = Request.QueryString.GetValues("id");

			long
				Id = long.MinValue;

			if (ParamArray != null && ParamArray.Length > 0 && ParamArray[0]!=string.Empty)
				Id = Convert.ToInt64(ParamArray[0]);

			if(!IsPostBack && Id!=long.MinValue)
			{
				HtmlInputHiddenId.Value = Id.ToString();

				DataRow
					tmpDataRow;
				
				if((tmpDataRow=ds.Tables[MainPage.TableName].Rows.Find(Id))==null)
					throw(new Exception("Unknown Id=\""+Id+"\""));

				string
					FieldName = "Value";

				TextBoxValue.Text = !tmpDataRow.IsNull(FieldName) ? Convert.ToString(tmpDataRow[FieldName]) : string.Empty;
			}
		}

		protected void ButtonSave_Click(object sender, EventArgs e)
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

					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SaveTest";
					OleDbCommandBuilder.DeriveParameters(cmd);
					cmd.Parameters["Id"].Value = HtmlInputHiddenId.Value != string.Empty ? (object)Convert.ToInt64(HtmlInputHiddenId.Value) : DBNull.Value;
					cmd.Parameters["Value"].Value = TextBoxValue.Text != string.Empty ? (object)TextBoxValue.Text : DBNull.Value;
					cmd.ExecuteNonQuery();
					Response.Write("<script type=\"text/javascript\">alert('"+((int)cmd.Parameters["RETURN_VALUE"].Value==0 ? "oB!" : "Tampax")+"'); opener.location.reload(); window.close()</script>");
				}
				catch (Exception eException)
				{
					throw (new Exception(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace));
				}
			}
			finally
			{
				if (connection != null && connection.State == ConnectionState.Open)
					connection.Close();
			}
		}
	}
}

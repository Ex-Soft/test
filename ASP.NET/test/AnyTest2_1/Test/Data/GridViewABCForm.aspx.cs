using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class GridViewABCForm : System.Web.UI.Page
	{
		const string
			GridViewABCFormDataTableSessionSignature = "GridViewABCFormDataTable";

		DataTable
			Staff = null;

		decimal
			Total;

		protected void Page_Load(object sender, EventArgs e)
		{
			if((Staff=(DataTable)Session[GridViewABCFormDataTableSessionSignature])==null)
				Session[GridViewABCFormDataTableSessionSignature]=Staff=new DataTable();

			if(!IsPostBack)
			{
				OleDbConnection
					con = new OleDbConnection(WebConfigurationManager.ConnectionStrings["SybaseASEServerFull"].ConnectionString);

				con.Open();

				OleDbCommand
					cmd = con.CreateCommand();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select * from staff order by id";

				OleDbDataReader
					dr = cmd.ExecuteReader();

				GridView1.DataSource = dr;
				GridView1.DataBind();
				dr.Close();

				OleDbDataAdapter
					da=new OleDbDataAdapter(cmd);

				da.Fill(Staff);
				GridView2.DataSource = Staff;
				GridView2.DataBind();

				dr = cmd.ExecuteReader();
				GridView3.DataSource = dr;
				GridView3.DataBind();
				dr.Close();

			    cmd.CommandText = "select * from TestString";
                dr = cmd.ExecuteReader();
                GridView4.DataSource = dr;
                GridView4.DataBind();
                dr.Close();

				con.Close();
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Label1.Text = TextBox1.Text;
		}

		protected void GridView1_DataBinding(object sender, EventArgs e)
		{
			string
				tmpString = "GridView_DataBinding(sender.GetType().FullName=\"" + sender.GetType().FullName + "\" e.GetType().FullName=\"" + e.GetType().FullName + "\")";

			if (tmpString != string.Empty)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), tmpString, true);
		}

		protected void GridView1_DataBound(object sender, EventArgs e)
		{
			string
				tmpString = "GridView_DataBound(sender.GetType().FullName=\"" + sender.GetType().FullName + "\" e.GetType().FullName=\"" + e.GetType().FullName + "\")";

			if (tmpString != string.Empty)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), tmpString, true);
		}

		protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			GridView
				tmpGridView;

			if((tmpGridView=sender as GridView)==null)
				return;

			string
				tmpString = "GridView_RowDataBound(sender.GetType().FullName=\"" + sender.GetType().FullName + "\" e.GetType().FullName=\"" + e.GetType().FullName + "\")";

			if (tmpString != string.Empty)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), tmpString, true);

			DataRowView
				tmpDataRowView;

			if ((tmpDataRowView = e.Row.DataItem as System.Data.DataRowView) != null)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), "System.Data.DataRowView", true);

			DbDataRecord
				tmpDbDataRecord;

			if ((tmpDbDataRecord = e.Row.DataItem as DbDataRecord) != null)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), "DbDataRecord", true);

			string
				FieldName = "Salary";

			switch(tmpGridView.ID)
			{
				case "GridView1" :
				{
					switch (e.Row.RowType)
					{
						case DataControlRowType.Header:
						{
							Total = 0m;

							break;
						}
						case DataControlRowType.DataRow:
						{
							decimal
								tmpDecimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem,FieldName));

							Total += tmpDecimal;

							break;
						}
					}

					break;	
				}
				case "GridView2" :
				{
					switch (e.Row.RowType)
					{
						case DataControlRowType.Header:
						{
							Total = 0m;

							break;
						}
						case DataControlRowType.DataRow:
						{
							decimal
								tmpDecimal = !((DataRowView) e.Row.DataItem).Row.IsNull(FieldName) ? Convert.ToDecimal(((DataRowView) e.Row.DataItem).Row[FieldName]) : 0m;

							//decimal
							//	tmpDecimal = !(e.Row.DataItem as System.Data.DataRowView).Row.IsNull(FieldName) ? Convert.ToDecimal((e.Row.DataItem as System.Data.DataRowView).Row[FieldName]) : 0m;

							Total += tmpDecimal;

							break;
						}
						case DataControlRowType.Footer:
						{
							e.Row.Cells[0].Text = "<b>Итого:</b>";
							e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
							e.Row.Cells[1].Text = "<b>" + Total.ToString("c") + "</b>";
							e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

							break;
						}
					}

					break;
				}
			}
		}

		protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
		{
			string
				tmpString = "GridView_RowCreated(sender.GetType().FullName=\"" + sender.GetType().FullName + "\" e.GetType().FullName=\"" + e.GetType().FullName + "\")";

			if (tmpString != string.Empty)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), tmpString, true);

			DataRowView
				tmpDataRowView;

			if ((tmpDataRowView = e.Row.DataItem as DataRowView) != null)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), "DataRowView", true);

			DbDataRecord
				tmpDbDataRecord;

			if ((tmpDbDataRecord = e.Row.DataItem as DbDataRecord) != null)
				LogII.LogII.MakeFile(LogII.LogII.MakeLogFileName(), "DbDataRecord", true);
		}

		protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton
				tmpImageButton;

			if ((tmpImageButton = sender as ImageButton) == null)
				return;

			GridViewRow
				row = (GridViewRow)tmpImageButton.NamingContainer;

			string
				tmpString = row.RowIndex.ToString();
		}

		protected void GridViewButton_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)==null)
				return;

			GridViewRow
				row=(GridViewRow)tmpButton.NamingContainer;

			string
				tmpString=row.RowIndex.ToString();
		}
	}
}

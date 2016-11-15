using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class TestDataBindForm : System.Web.UI.Page
	{
		protected int
			a = 10;

		protected DateTime
			b = DateTime.Now;

		protected string
			ImageUrl = "Images\\Small\\mm_01_small.jpg";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Hashtable
					ht=new Hashtable(3);

				ht.Add("1st","1");
				ht.Add("2nd","2");
				ht.Add("3rd","3");

				Select1.DataSource = ht;
				Select2.DataSource = ht;
				ListBox1.DataSource = ht;
				DropDownList1.DataSource = ht;
				RadioButtonList1.DataSource = ht;
				CheckBoxList1.DataSource = ht;

				DataBind();

				OleDbConnection
					connection=new OleDbConnection(TestDataData.GetConnectionString());

				connection.Open();

				OleDbCommand
					cmd = connection.CreateCommand();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select id, name from staff order by id";

				OleDbDataReader
					dr = cmd.ExecuteReader();

				ListBoxNames.DataSource = dr;
				ListBoxNames.DataBind();
				dr.Close();
				connection.Close();

				// DataBind(); // System.InvalidOperationException: Invalid attempt to FieldCount when reader is closed.
			}
		}

		protected void ButtonGetSelection_Click(object sender, EventArgs e)
		{
			HtmlSelect
				tmpSelect = Select1;

			LiteralSelectionResult.Text = " - Item selected in "+tmpSelect.ID+": " + (tmpSelect.SelectedIndex>=0 ? tmpSelect.Items[tmpSelect.SelectedIndex].Text + " - " + tmpSelect.Value : "nothing")+"<br />";
			tmpSelect = Select2;
			LiteralSelectionResult.Text += " - Item selected in " + tmpSelect.ID + ": " + (tmpSelect.SelectedIndex >= 0 ? tmpSelect.Items[tmpSelect.SelectedIndex].Text + " - " + tmpSelect.Value : "nothing") + "<br />";
			LiteralSelectionResult.Text += " - Item selected in ListBox1: " + (ListBox1.SelectedItem!=null ? ListBox1.SelectedItem.Text + " - " + ListBox1.SelectedItem.Value : "nothing") + "<br />";
			LiteralSelectionResult.Text += " - Item selected in DropDownList1: " + (DropDownList1.SelectedItem != null ? DropDownList1.SelectedItem.Text + " - " + DropDownList1.SelectedItem.Value : "nothing") + "<br />";
			LiteralSelectionResult.Text += " - Item selected in RadioButtonList1: " + (RadioButtonList1.SelectedItem != null ? RadioButtonList1.SelectedItem.Text + " - " + RadioButtonList1.SelectedItem.Value : "nothing") + "<br />";

			LiteralSelectionResult.Text += " - Item selected in CheckBoxList1: ";
			if (CheckBoxList1.SelectedItem != null)
			{
				foreach (ListItem li in CheckBoxList1.Items)
					if (li.Selected)
						LiteralSelectionResult.Text += li.Text + " - " + li.Value+" ";
			}
			else
				LiteralSelectionResult.Text += "nothing";
			LiteralSelectionResult.Text += "<br />";

			LiteralSelectionResult.Text += " - Item selected in ListBoxNames: ";
			if (ListBoxNames.SelectedItem != null)
			{
				foreach (ListItem li in ListBoxNames.Items)
					if (li.Selected)
						LiteralSelectionResult.Text += li.Text + " - " + li.Value + " ";
			}
			else
				LiteralSelectionResult.Text += "nothing";
			LiteralSelectionResult.Text += "<br />";
		}
	}
}

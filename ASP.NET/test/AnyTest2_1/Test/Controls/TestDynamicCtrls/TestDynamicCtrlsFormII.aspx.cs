using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class TestDynamicCtrlsFormII : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			DateTime
				Start = DateTime.Now;

			LabelDateTimeStart.Text = Start.ToString();

			HtmlTable
				tmpTable=new HtmlTable();

			HtmlTableRow
				tmpRow;

			HtmlTableCell
				tmpCell;

			TextBox
				tmpTextBox;

			DropDownList
				tmpDropDownList;

			RadioButtonList
				tmpRadioButtonList;

			for (int i = 0; i < 1000; ++i)
			{
				tmpRow=new HtmlTableRow();
				tmpTable.Rows.Add(tmpRow);

				tmpCell=new HtmlTableCell();
				tmpRow.Cells.Add(tmpCell);

				tmpTextBox=new TextBox();
				tmpTextBox.ID = "TextBox" + i;
				tmpCell.Controls.Add(tmpTextBox);

				tmpCell = new HtmlTableCell();
				tmpRow.Cells.Add(tmpCell);

				tmpDropDownList=new DropDownList();
				tmpDropDownList.ID = "DropDownList" + i;
				tmpDropDownList.Items.Add(new ListItem("1st", "1"));
				tmpDropDownList.Items.Add(new ListItem("2nd", "2"));
				tmpDropDownList.Items.Add(new ListItem("3rd", "3"));
				tmpCell.Controls.Add(tmpDropDownList);

				tmpCell = new HtmlTableCell();
				tmpRow.Cells.Add(tmpCell);

				tmpRadioButtonList=new RadioButtonList();
				tmpRadioButtonList.ID = "RadioButtonList" + i;
				tmpRadioButtonList.RepeatDirection = RepeatDirection.Horizontal;
				tmpRadioButtonList.Items.Add(new ListItem("1st", "1"));
				tmpRadioButtonList.Items.Add(new ListItem("2nd", "2"));
				tmpRadioButtonList.Items.Add(new ListItem("3rd", "3"));
				tmpCell.Controls.Add(tmpRadioButtonList);
			}

			PlaceHolderMain.Controls.Add(tmpTable);

			DateTime
				Stop = DateTime.Now;

			LabelDateTimeStop.Text = Stop.ToString();
			LabelDateTimeDiff.Text = (Stop - Start).ToString();
		}
	}
}

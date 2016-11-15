using System.Data;
using System.Web.UI.WebControls;

namespace TwoInOne
{
	class Common
	{
		public static void FillDropDownList(DataTable aTable, string ColumnNameId, string ColumnNameDescription, string Filter, DropDownList aDropDownList, bool AddEmptyOptions)
		{
			DataView
				view=new DataView(aTable);

			Filter=Filter.Trim();
			if(Filter.Length!=0)
				view.RowFilter=Filter;

			aDropDownList.DataSource=view;
			aDropDownList.DataValueField=ColumnNameId;
			aDropDownList.DataTextField=ColumnNameDescription;
			aDropDownList.DataBind();
			if(AddEmptyOptions)
				aDropDownList.Items.Insert(0," ");
		}
	}
}
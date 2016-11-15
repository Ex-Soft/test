using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
    public partial class GridViewFullForm : System.Web.UI.Page
    {
        private string
            GridViewFullFormSessionSignature="GridViewFullFormSession",
            GridViewFullFormViewStateSortSignature = "GridViewFullFormViewStateSort",
			connstring = (string) System.Web.HttpContext.Current.Application["connectionString"],
            TableName = "TestTable",
            CheckedFieldName = "Checked",
            CheckBoxSignature = "tmpCheckBox",
            LinkButtonSignature = "LinkButtonDelete";

        private DataSet
            ds = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((ds = (DataSet)Session[GridViewFullFormSessionSignature]) == null)
            {
                Session[GridViewFullFormSessionSignature] = ds = new DataSet();

                ds.Tables.Add(TableName);
                ds.Tables[TableName].Columns.Add(CheckedFieldName, typeof(bool));
            }

            if(!IsPostBack)
                FillDataTable(ds.Tables[TableName]);
            SetDataSource(GridViewFull, ds.Tables[TableName]);
            if (!IsPostBack)
                GridViewFull.DataBind();
            else
            {
                CheckBox
                    tmpCheckBox;

                int
                    tmpInt;

                DataRow
                    tmpDataRow;

                foreach (GridViewRow row in GridViewFull.Rows)
                {
                    if ((tmpCheckBox = (row.FindControl(CheckBoxSignature) as CheckBox)) == null)
                        continue;

                    if ((tmpDataRow = ds.Tables[TableName].Rows.Find(tmpInt = Convert.ToInt32(GridViewFull.DataKeys[row.RowIndex].Value))) != null)
                    {
                        if (tmpDataRow.IsNull(CheckedFieldName) || Convert.ToBoolean(tmpDataRow[CheckedFieldName]) != tmpCheckBox.Checked)
                            tmpDataRow[CheckedFieldName] = tmpCheckBox.Checked;
                    }
                    else
                        throw (new Exception("Unknown ID: '" + tmpInt + "'"));
                }
            }
        }

        void FillDataTable(DataTable dt)
        {
            OleDbConnection
                connection = new OleDbConnection(connstring);

            OleDbDataAdapter
                da = new OleDbDataAdapter("select * from Staff", connection);

            da.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };
        }

        void SetDataSource(GridView aGridView, DataTable dt)
        {
            if (ViewState[GridViewFullFormViewStateSortSignature] != null)
                dt.DefaultView.Sort = (string)ViewState[GridViewFullFormViewStateSortSignature];
            aGridView.DataSource = dt.DefaultView;
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            GridView
                tmpGridView;

            if ((tmpGridView = sender as GridView) == null)
                return;

            ViewState[GridViewFullFormViewStateSortSignature] = e.SortExpression;
            foreach (DataControlField column in tmpGridView.Columns)
            {
                column.HeaderText = column.HeaderText.Replace(" v", "");
                column.HeaderText = column.HeaderText.Replace(" ^", "");
                if (column.SortExpression == e.SortExpression)
                {
                    if (e.SortExpression.IndexOf(" desc") != -1)
                    {
                        column.SortExpression = column.SortExpression.Replace(" desc", "");
                        column.HeaderText += " ^";
                    }
                    else
                    {
                        column.SortExpression += " desc";
                        column.HeaderText += " v";
                    }
                }
            }
            SetDataSource(tmpGridView, ds.Tables[TableName]);
            tmpGridView.DataBind();
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView
                tmpGridView;

            if ((tmpGridView = sender as GridView) == null)
                return;

            tmpGridView.PageIndex=e.NewPageIndex;
            tmpGridView.DataBind(); 
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            bool
                tmpBool = !(e.Row.DataItem as System.Data.DataRowView).Row.IsNull(CheckedFieldName) ? Convert.ToBoolean((e.Row.DataItem as System.Data.DataRowView).Row[CheckedFieldName]) : false;

            CheckBox
                tmpCheckBox;

            if ((tmpCheckBox = e.Row.FindControl(CheckBoxSignature) as CheckBox) != null
                && tmpCheckBox.Checked != tmpBool)
                tmpCheckBox.Checked = tmpBool;

        	LinkButton
                tmpLinkButton;

            if ((tmpLinkButton = e.Row.FindControl(LinkButtonSignature) as LinkButton) != null)
                tmpLinkButton.CommandArgument = Convert.ToString(Convert.ToInt64((e.Row.DataItem as System.Data.DataRowView).Row["ID"]));

            e.Row.Attributes.Add("onclick", "alert('\"" + Convert.ToString(Convert.ToInt64((e.Row.DataItem as System.Data.DataRowView).Row["ID"])) + "\"');");

			if((tmpCheckBox = e.Row.FindControl("chkRow") as CheckBox) != null)
				tmpCheckBox.Attributes.Add("onclick", "DoIt(this,'" + (!(e.Row.DataItem as System.Data.DataRowView).Row.IsNull("ID") ? Convert.ToString((e.Row.DataItem as System.Data.DataRowView).Row["ID"]).Replace("\\", "\\\\").Replace("'", "\\'").Replace("\"", "\\x22") : string.Empty) + "');");
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    {
                        if (Convert.ToInt64(e.CommandArgument) != long.MinValue)
                        {

                        }
                        break;
                    }
            }
        }
        
    }
}

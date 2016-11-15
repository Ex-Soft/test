using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class TestSqlDataSourceForm : Page
	{
		private string
			LogFileName = LogII.LogII.MakeLogFileName();

		#region Init
		protected override void OnPreInit(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnPreInit (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnPreInit(e);
		}

		protected override void OnInit(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnInit (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnInit(e);
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "Page_Init (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
		}

		protected override void OnInitComplete(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnInitComplete (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnInitComplete(e);
		}
		#endregion

		#region Load
		protected override void OnPreLoad(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnPreLoad (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnPreLoad(e);
		}

		protected override void OnLoad(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnLoad (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnLoad(e);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName,"Page_Load (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")",true);

            if (!IsPostBack)
            {
                SqlDataSource4.SelectParameters["BirthDate"].DefaultValue = DateTime.Now.ToShortDateString();
            }
		}

		protected override void OnLoadComplete(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnLoadComplete (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnLoadComplete(e);
		}
		#endregion

		#region PreRender
		protected override void OnPreRender(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnPreRender (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnPreRender(e);
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "Page_PreRender (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
		}

		protected override void OnPreRenderComplete(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnPreRenderComplete (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnPreRenderComplete(e);
		}
		#endregion

		protected override void Render(HtmlTextWriter writer)
		{
			LogII.LogII.MakeFile(LogFileName, "Render (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.Render(writer);
		}

		#region Unload
		protected override void OnUnload(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnUnload (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
			base.OnUnload(e);
		}

		protected void Page_Unload(object sender, EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "Page_Unload (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\")", true);
		}
		#endregion

		protected override void OnDataBinding(EventArgs e)
		{
			LogII.LogII.MakeFile(LogFileName, "OnDataBinding (IsPostBack=\"" + IsPostBack.ToString().ToLower() + "\", e.GetType().FullName=\"" + e.GetType().FullName+"\")", true);
			base.OnDataBinding(e);
		}

		protected void PageDropDownList_SelectedIndexChanged(Object sender, EventArgs e)
		{

			// Retrieve the pager row.
			GridViewRow pagerRow = GridView1.BottomPagerRow;

			// Retrieve the PageDropDownList DropDownList from the bottom pager row.
			DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

			// Set the PageIndex property to display that page selected by the user.
			GridView1.PageIndex = pageList.SelectedIndex;
		}

		protected void CustomersGridView_DataBound(Object sender, EventArgs e)
		{

			// Retrieve the pager row.
			GridViewRow pagerRow = GridView1.BottomPagerRow;

			// Retrieve the DropDownList and Label controls from the row.
			DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
			Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

			if (pageList != null)
			{

				// Create the values for the DropDownList control based on 
				// the  total number of pages required to display the data
				// source.
				for (int i = 0; i < GridView1.PageCount; i++)
				{

					// Create a ListItem object to represent a page.
					int pageNumber = i + 1;
					ListItem item = new ListItem(pageNumber.ToString());

					// If the ListItem object matches the currently selected
					// page, flag the ListItem object as being selected. Because
					// the DropDownList control is recreated each time the pager
					// row gets created, this will persist the selected item in
					// the DropDownList control.   
					if (i == GridView1.PageIndex)
					{
						item.Selected = true;
					}

					// Add the ListItem object to the Items collection of the 
					// DropDownList.
					pageList.Items.Add(item);

				}

			}

			if (pageLabel != null)
			{

				// Calculate the current page number.
				int currentPage = GridView1.PageIndex + 1;

				// Update the Label control with the current page information.
				pageLabel.Text = "Page " + currentPage +
				  " of " + GridView1.PageCount;

			}

		}

		protected void SqlDataSource2_Selected(object sender, SqlDataSourceStatusEventArgs e)
		{
			if(e.Exception!=null)
			{
				LiteralError.Text=e.Exception.GetType().FullName + "<br/>Message: " + e.Exception.Message + "<br/>StackTrace:<br/>" + e.Exception.StackTrace;
				e.ExceptionHandled = true;
			}
		}

		protected void GridView3_DataBound(Object sender, EventArgs e)
		{
			
		}

        protected void SqlDataSource4_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            e.Command.Parameters["BirthDate"].Value = new DateTime(1870, 4, 22);
        }
    }
}

using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vladsm.Samples.RadioButtonSamples
{
	public class StandardRadioButtonSample : Page
	{
		protected DataGrid countriesGrid;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				countriesGrid.DataSource = DataSource.CreateSampleDataSource();
				countriesGrid.DataBind();
			}
		}
	
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
	}
}
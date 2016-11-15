using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using Vladsm.Web.UI.WebControls;

namespace Vladsm.Samples.RadioButtonSamples
{
	public class GroupRadioButtonSample : Page
	{
		protected System.Web.UI.WebControls.Button selectButton;
		protected System.Web.UI.WebControls.Label selectedCountryInfo;
		protected DataGrid countriesGrid;
	
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{    
			this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				countriesGrid.DataSource = DataSource.CreateSampleDataSource();
				countriesGrid.DataBind();
			}
		}

		/// <summary>
		/// "Select" button click event handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void selectButton_Click(object sender, System.EventArgs e)
		{
			// for each grid items...
			foreach(DataGridItem dgItem in countriesGrid.Items)
			{
				// get GroupRadioButton object...
				GroupRadioButton selectRadioButton = 
					dgItem.FindControl("selectRadioButton") as GroupRadioButton;

				// if it is checked (current item is selected)...
				if(selectRadioButton != null && selectRadioButton.Checked)
				{
					DataTable dataSource = DataSource.CreateSampleDataSource();
					// get country corresponding to the current item...
					DataRow row = dataSource.Rows.Find(countriesGrid.DataKeys[dgItem.ItemIndex]);
					
					// ...and show selected country information
					selectedCountryInfo.Text = 
						String.Format("Selected country: {0}, Capital: {1}", row["Country"], row["Capital"]);

					return;
				}
			}

			// there are no selected countries
			selectedCountryInfo.Text = String.Empty;
		}
	}
}
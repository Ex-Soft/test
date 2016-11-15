using System;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestSendDataByAJAXMainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button ButtomSubmit;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				DropDownList1.Items.Add(new ListItem("1st","1"));
				DropDownList1.Items.Add(new ListItem("2nd","2"));
				DropDownList1.Items.Add(new ListItem("3rd","3"));
			}

			string
				tmpString;

			int
				i,
				ii;

			string[]
				array1,
				array2;

			tmpString=string.Empty;
			if((array1=Request.Form.AllKeys)!=null)
			{
				for(i=0; i<array1.Length; ++i)
				{
					if((array2=Request.Form.GetValues(array1[i]))!=null)
					{
						tmpString+="Key ["+Convert.ToString(i)+"]="+array1[i]+Environment.NewLine;
					
						for(ii=0; ii<array2.Length; ++ii)
						{
							tmpString+="Value ["+Convert.ToString(ii)+"]="+array2[ii]+Environment.NewLine;
						}
					}
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtomSubmit.Click+=new EventHandler(ButtomSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void ButtomSubmit_Click(object sender, EventArgs e)
		{

		}
	}
}

using System;
using System.Web.UI.WebControls;

namespace AnyTest
{
	/// <summary>
	/// Summary description for SubmitTestForm.
	/// </summary>
	public class SubmitTestForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LabelInit;
		protected System.Web.UI.WebControls.Label LabelLoad;
		protected System.Web.UI.WebControls.CheckBox CheckBoxSubmitEnabled;
		protected System.Web.UI.WebControls.TextBox TextBoxSrc1;
		protected System.Web.UI.WebControls.Button ButtonCopy;
		protected System.Web.UI.WebControls.TextBox TextBoxDest1;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBoxSrc2;
		protected System.Web.UI.HtmlControls.HtmlGenericControl SpanForInputDynamic;
		protected System.Web.UI.HtmlControls.HtmlInputText TextBoxDest2;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;

		protected string
			InputDynamicId="InputDynamic";

		private void Page_Init(object sender, System.EventArgs e)
		{
			LabelInit.Text+=DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss.fffffff tt")+" (IsPostBack=\""+IsPostBack.ToString()+"\")<br>";
			TextBoxSrc2.Value=DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");

			int
				SmthVariable=0;

			if(Session["SmthVariable"]!=null)
				SmthVariable=Convert.ToInt32(Session["SmthVariable"]);
			
			Session["SmthVariable"]=++SmthVariable;

			Log.Log.WriteToLog(LabelInit.Text,true);

			if(IsPostBack && this.FindControl(InputDynamicId)==null)
			{
				TextBox
					tmpTextBox=new TextBox();

				tmpTextBox.ID=InputDynamicId;
				SpanForInputDynamic.Controls.Add(tmpTextBox);
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			LabelLoad.Text+=DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss.fffffff tt")+" (IsPostBack=\""+IsPostBack.ToString()+"\") SmthVariable="+Convert.ToInt32(Session["SmthVariable"])+"<br>";

			if(IsPostBack)
			{
				TextBox
					tmpTextBox;

				if((tmpTextBox=this.FindControl(InputDynamicId) as TextBox)!=null)
				{
					tmpTextBox.Text+=tmpTextBox.Text;
				}

				AccessToApplication.AccessToApplication.Applications=Application;
				AccessToApplication.AccessToApplication.IsUserOnlineExists();
			}
		}
		private void ButtonCopy_Click(object sender, System.EventArgs e)
		{
			TextBoxDest1.Text=TextBoxSrc1.Text;
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
			this.ButtonCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

	}
}

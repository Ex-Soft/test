using System;

namespace AnyTest
{
	public class TestSessionIIForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LabelInit;
		protected System.Web.UI.WebControls.Label LabelLoad;
		protected System.Web.UI.WebControls.CheckBox CheckBoxTimerOn;
		protected System.Web.UI.WebControls.Button btnSubmit;

		private void Page_Init(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog("TestSessionIIForm::Page_Init(): Session[\"SmthValue\"]="+(Session["SmthValue"]!=null ? "\""+((bool)Session["SmthValue"]).ToString().ToLower()+"\"" : "null")+" (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\", Session.SessionID: "+Session.SessionID+")",true);
			LabelInit.Text+=DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss.fffffff tt")+" (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")<br>";
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog("TestSessionIIForm::Page_Load(): Session[\"SmthValue\"]="+(Session["SmthValue"]!=null ? "\""+((bool)Session["SmthValue"]).ToString().ToLower()+"\"" : "null")+" (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\", Session.SessionID: "+Session.SessionID+")",true);
			LabelLoad.Text+=DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss.fffffff tt")+" (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\")<br>";
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			Log.Log.WriteToLog("TestSessionIIForm::btnSubmit_Click(): Session[\"SmthValue\"]="+(Session["SmthValue"]!=null ? "\""+((bool)Session["SmthValue"]).ToString().ToLower()+"\"" : "null")+" (IsPostBack=\""+IsPostBack.ToString().ToLower()+"\", Session.SessionID: "+Session.SessionID+")",true);
		}
	}
}

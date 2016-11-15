using System;

namespace AnyTest
{
	public class TestSessionIIIIFrameForm : System.Web.UI.Page
	{
		protected bool
			SessionExists=false;

		public const string
			Msg="Увага!\\nДопустимий час бездіяльності використано!\\nНеобхідно пройти аутентифікацію!\\nЗараз и будете автоматично переадресовані на сторінку авторизації користувача.";

		private void Page_Load(object sender, System.EventArgs e)
		{
			SessionExists=Session["SmthValue"]!=null;
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}

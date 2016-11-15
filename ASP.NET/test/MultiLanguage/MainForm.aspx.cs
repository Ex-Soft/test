using System;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;

namespace MultiLanguage
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class MainForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLinkEnglis;
		protected System.Web.UI.WebControls.HyperLink HyperLinkRusshian;
		protected System.Web.UI.WebControls.Label LabelHeader;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (this.Request.QueryString["Culture"]==null)
			{
				return;
			}

			string
				_sCulture=this.Request.QueryString["Culture"];

			// ����� �������� ��� �������� ������ ������� ������������
			Thread.CurrentThread.CurrentCulture=CultureInfo.CreateSpecificCulture(_sCulture);

			// ����� ��������, ������������ ResourceManager ��� ������
			// �������������� ��������
			Thread.CurrentThread.CurrentUICulture=CultureInfo.CreateSpecificCulture(_sCulture);

			// ����� ��������� �������� ������ �� ������ ������������
			this.Response.ContentEncoding=Encoding.GetEncoding(Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage);

			// ������ ��������� ������ ResourceManager ��� ������� ������ � ������ ������
			ResourceManager
				_resourceManager=new ResourceManager(this.GetType().BaseType.FullName,this.GetType().BaseType.Assembly);

			// �������� �������������� �������� �� �������������� ������ ��������
			this.LabelHeader.Text=_resourceManager.GetString("LabelHeader");
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

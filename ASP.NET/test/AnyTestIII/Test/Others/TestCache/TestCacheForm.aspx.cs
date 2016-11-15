using System;
using System.Threading;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestCacheForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBoxCCacheSet;
		protected System.Web.UI.WebControls.Button ButtonCCacheSet;
		protected System.Web.UI.WebControls.TextBox TextBoxCCacheGet;
		protected System.Web.UI.WebControls.Button ButtonCCacheGet;
		protected System.Web.UI.WebControls.TextBox TextBoxSCacheSet;
		protected System.Web.UI.WebControls.Button ButtonSCacheSet;
		protected System.Web.UI.WebControls.TextBox TextBoxSCacheGet;
		protected System.Web.UI.WebControls.Button ButtonSCacheGet;
	
		string
			CacheSignature="DataInCache";

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.ButtonSCacheSet.Click += new System.EventHandler(this.ButtonCacheSet_Click);
			this.ButtonCCacheSet.Click += new System.EventHandler(this.ButtonCacheSet_Click);
			this.ButtonSCacheGet.Click += new System.EventHandler(this.ButtonCacheGet_Click);
			this.ButtonCCacheGet.Click += new System.EventHandler(this.ButtonCacheGet_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ButtonCacheSet_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)==null)
				return;

			string
				tmpCacheSignature=CacheSignature;

			TextBox
				tmpTextBox=null;

			switch(tmpButton.ID)
			{
				case "ButtonCCacheSet" :
				{
					tmpTextBox=TextBoxCCacheSet;
					break;	
				}
				case "ButtonSCacheSet" :
				{
					tmpTextBox=TextBoxSCacheSet;
					tmpCacheSignature+=Session.SessionID;
					break;	
				}
				default :
				{
					return;	
				}
			}

			ReaderWriterLock
				rwlock=new ReaderWriterLock();

			rwlock.AcquireWriterLock(Timeout.Infinite);
			try
			{
				Cache[tmpCacheSignature]=tmpTextBox.Text.Trim();
			}
			finally
			{
				rwlock.ReleaseWriterLock();
			}
		}

		private void ButtonCacheGet_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if((tmpButton=sender as Button)==null)
				return;

			string
				tmpCacheSignature=CacheSignature;

			TextBox
				tmpTextBox=null;

			switch(tmpButton.ID)
			{
				case "ButtonCCacheGet" :
				{
					tmpTextBox=TextBoxCCacheGet;
					break;	
				}
				case "ButtonSCacheGet" :
				{
					tmpTextBox=TextBoxSCacheGet;
					tmpCacheSignature+=Session.SessionID;
					break;	
				}
				default :
				{
					return;	
				}
			}

			ReaderWriterLock
				rwlock=new ReaderWriterLock();

			rwlock.AcquireReaderLock(Timeout.Infinite);
			try
			{
				tmpTextBox.Text = Cache[tmpCacheSignature]!=null ? "\""+Convert.ToString(Cache[tmpCacheSignature])+"\"" : "null";
			}
			finally
			{
				rwlock.ReleaseReaderLock();
			}
		}
	}
}

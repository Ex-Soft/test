using System;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;

namespace AnyTestII
{
	public partial class TestCacheForm : System.Web.UI.Page
	{
		string
			CacheSignature = "DataInCache";

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ButtonCacheSet_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if ((tmpButton = sender as Button) == null)
				return;

			string
				tmpCacheSignature = CacheSignature;

			TextBox
				tmpTextBox = null;

			switch (tmpButton.ID)
			{
				case "ButtonCCacheSet":
				{
					tmpTextBox = TextBoxCCacheSet;
					break;
				}
				case "ButtonSCacheSet":
				{
					tmpTextBox = TextBoxSCacheSet;
					tmpCacheSignature += Session.SessionID;
					break;
				}
				default:
				{
					return;
				}
			}

			ReaderWriterLock
				rwlock = new ReaderWriterLock();

			rwlock.AcquireWriterLock(Timeout.Infinite);
			try
			{
				Cache[tmpCacheSignature] = tmpTextBox.Text.Trim();
			}
			finally
			{
				rwlock.ReleaseWriterLock();
			}
		}

		protected void ButtonCacheGet_Click(object sender, EventArgs e)
		{
			Button
				tmpButton;

			if ((tmpButton = sender as Button) == null)
				return;

			string
				tmpCacheSignature = CacheSignature;

			TextBox
				tmpTextBox = null;

			switch (tmpButton.ID)
			{
				case "ButtonCCacheGet":
				{
					tmpTextBox = TextBoxCCacheGet;
					break;
				}
				case "ButtonSCacheGet":
				{
					tmpTextBox = TextBoxSCacheGet;
					tmpCacheSignature += Session.SessionID;
					break;
				}
				default:
				{
					return;
				}
			}

			ReaderWriterLock
				rwlock = new ReaderWriterLock();

			rwlock.AcquireReaderLock(Timeout.Infinite);
			try
			{
				tmpTextBox.Text = Cache[tmpCacheSignature] != null ? "\"" + Convert.ToString(Cache[tmpCacheSignature]) + "\"" : "null";
			}
			finally
			{
				rwlock.ReleaseReaderLock();
			}
		}
	}
}

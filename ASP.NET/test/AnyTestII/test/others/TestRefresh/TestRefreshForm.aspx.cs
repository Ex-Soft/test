//http://www.sql.ru/forum/actualthread.aspx?tid=784304
//http://prashantprof.blogspot.com/2008/02/handling-page-refresh-f5-in-aspnet-post.html

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnyTestII
{
	public partial class TestRefreshForm : System.Web.UI.Page
	{
		const string
			Key = "PostID";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session[Key] = "1001";
				ViewState[Key] = Session[Key].ToString();
			}
		}

		bool IsValidPost()
		{
			if (ViewState[Key].ToString() == Session[Key].ToString())
			{
				Session[Key] =	(Convert.ToInt16(Session[Key]) + 1).ToString();
				ViewState[Key] = Session[Key].ToString();
				return true;
			}
			else
			{
				ViewState[Key] = Session[Key].ToString();
				return false;
			}
		}

		protected void ButtonSubmit_Click(object sender, EventArgs e)
		{
			if (IsValidPost())
			{
				LabelInfo.Text = DateTime.Now.ToLongTimeString();
			}
		}
	}
}

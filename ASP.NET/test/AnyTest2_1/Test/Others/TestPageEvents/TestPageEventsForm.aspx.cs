using System;

namespace AnyTest2_1
{
	public partial class TestPageEventsForm : System.Web.UI.Page
	{
		protected int
			TestVar = 0;

		private string
			Mess = string.Empty;

		protected void Page_DataBinding(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_DataBinding()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Disposed(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_Disposed()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Error(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_Error()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_Init()";

			string
				tmpString = GetHeaderValues(new string[] {"Content-Type"}, Environment.NewLine);

			Log.Log.WriteToLog(Mess + (!string.IsNullOrEmpty(tmpString) ? Environment.NewLine+tmpString : string.Empty), true);

			tmpString = GetHeaderValues(new string[] {"Content-Type"}, "<br />");
			LabelInfo.Text += Mess + "<br />"+(!string.IsNullOrEmpty(tmpString) ? tmpString+"<br />" : string.Empty);
		}

		protected void Page_InitComplete(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_InitComplete()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_Load()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_LoadComplete()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_PreInit(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_PreInit()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_PreLoad(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_PreLoad()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_PreRender()";

			string
				tmpString = GetHeaderValues(new string[] { "Content-Type" }, Environment.NewLine);

			Log.Log.WriteToLog(Mess + (!string.IsNullOrEmpty(tmpString) ? Environment.NewLine + tmpString : string.Empty), true);

			tmpString = GetHeaderValues(new string[] { "Content-Type" }, "<br />");
			LabelInfo.Text += Mess + "<br />" + (!string.IsNullOrEmpty(tmpString) ? tmpString + "<br />" : string.Empty);
		}

		protected void Page_PreRenderComplete(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_PreRenderComplete()";

			string
				tmpString = GetHeaderValues(new string[] { "Content-Type" }, Environment.NewLine);

			Log.Log.WriteToLog(Mess + (!string.IsNullOrEmpty(tmpString) ? Environment.NewLine + tmpString : string.Empty), true);

			tmpString = GetHeaderValues(new string[] { "Content-Type" }, "<br />");
			LabelInfo.Text += Mess + "<br />" + (!string.IsNullOrEmpty(tmpString) ? tmpString + "<br />" : string.Empty);
		}

		protected void Page_SaveStateComplete(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_SaveStateComplete()";

			string
				tmpString = GetHeaderValues(new string[] { "Content-Type" }, Environment.NewLine);

			Log.Log.WriteToLog(Mess + (!string.IsNullOrEmpty(tmpString) ? Environment.NewLine + tmpString : string.Empty), true);

			tmpString = GetHeaderValues(new string[] { "Content-Type" }, "<br />");
			LabelInfo.Text += Mess + "<br />" + (!string.IsNullOrEmpty(tmpString) ? tmpString + "<br />" : string.Empty);
		}
		
		protected void Page_Unload(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Page_Unload()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Button_Click(object sender, EventArgs e)
		{
			Mess = "TestPageEventsForm::Button_Click()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}
		
		string GetHeaderValues(string[] Keys, string NewLine)
		{
			string
				Result = string.Empty;

			foreach (string key in Keys)
				if (Request.Headers[key] != null)
				{
					if (Result != string.Empty)
						Result += NewLine;
					Result += "Headers[\"" + key + "\"]=\"" + Request.Headers[key] + "\"";
				}
			return (Result);
		}
	}
}

using System;

namespace AnyTestII
{
	public partial class TestTransferRedirectRedirectForm : System.Web.UI.Page
	{
		private string
			Mess = string.Empty;

		protected void Page_DataBinding(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_DataBinding()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Disposed(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_Disposed()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Error(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_Error()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Init(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_Init()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_InitComplete(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_InitComplete()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_Load()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_LoadComplete(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_LoadComplete()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_PreInit(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_PreInit()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_PreLoad(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_PreLoad()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_PreRender()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_PreRenderComplete(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_PreRenderComplete()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_SaveStateComplete(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_SaveStateComplete()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}

		protected void Page_Unload(object sender, EventArgs e)
		{
			Mess = "TestTransferRedirectRedirectForm::Page_Unload()";
			Log.Log.WriteToLog(Mess, true);
			LabelInfo.Text += Mess + "<br />";
		}
	}
}

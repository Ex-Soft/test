using System;
using System.Collections;

namespace AnyTest
{
	/// <summary>
	/// Summary description for TestActionMainForm.
	/// </summary>
	public class TestActionMainForm : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Test_Action_Main_Form;

		string
			tmpString;

		private void Page_Load(object sender, System.EventArgs e)
		{
			//
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
			this.Error += new EventHandler(TestActionMainForm_Error);
			this.Disposed += new EventHandler(TestActionMainForm_Disposed);
			this.DataBinding += new EventHandler(TestActionMainForm_DataBinding);
			this.Unload += new EventHandler(TestActionMainForm_Unload);
			this.PreRender += new EventHandler(TestActionMainForm_PreRender);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new EventHandler(TestActionMainForm_Init);

		}
		#endregion

		private void TestActionMainForm_PreRender(object sender, EventArgs e)
		{
			if(Test_Action_Main_Form.Attributes.Count!=0)
			{
				ICollection
					AllKeys=Test_Action_Main_Form.Attributes.Keys;

				tmpString=string.Empty;

				foreach(string k in AllKeys)
				{
					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;

					tmpString+="Attributes["+k+"]="+Test_Action_Main_Form.Attributes[k];
				}
			}

			Test_Action_Main_Form.Attributes["action"]="TestActionDestForm.aspx";
		}

		private void TestActionMainForm_Unload(object sender, EventArgs e)
		{
			if(Test_Action_Main_Form.Attributes.Count!=0)
			{
				ICollection
					AllKeys=Test_Action_Main_Form.Attributes.Keys;

				tmpString=string.Empty;

				foreach(string k in AllKeys)
				{
					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;

					tmpString+="Attributes[\""+k+"\"]="+Test_Action_Main_Form.Attributes[k];
				}
			}
		}

		private void TestActionMainForm_DataBinding(object sender, EventArgs e)
		{

		}

		private void TestActionMainForm_Disposed(object sender, EventArgs e)
		{

		}

		private void TestActionMainForm_Error(object sender, EventArgs e)
		{

		}

		private void TestActionMainForm_Init(object sender, EventArgs e)
		{

		}
	}
}

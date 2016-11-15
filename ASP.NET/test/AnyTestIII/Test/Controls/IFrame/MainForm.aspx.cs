#define MAKE_IFRAME_SRC_IN_INIT
//#define IFRAME_ENABLED_VIEW_STATE

using System;
using System.Data;

namespace AnyTest
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainIFrameForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox MainFormTextBoxInput1;
		protected System.Web.UI.WebControls.TextBox MainFormTextBoxInput2;
		protected System.Web.UI.WebControls.Label LabelMainFormTextBoxInput1;
		protected System.Web.UI.WebControls.Label LabelMainFormTextBoxInput2;
		protected System.Web.UI.WebControls.Label LabelFrameForm1TextBoxInput1;
		protected System.Web.UI.WebControls.Label LabelFrameForm1TextBoxInput2;
		protected System.Web.UI.WebControls.Label LabelFrameForm2TextBoxInput1;
		protected System.Web.UI.WebControls.Label LabelFrameForm2TextBoxInput2;
		protected System.Web.UI.HtmlControls.HtmlGenericControl IFrame1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl IFrame2;
		
		private TestDS
			TestDSVariable;

		private void Page_Init(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog("MainForm.Page_Init() (IsPostBack=\""+IsPostBack.ToString()+"\")",true);

			if((TestDSVariable=(TestDS)Session["TestDS"])==null)
			{
				TestDSVariable=new TestDS();
				Session.Add("TestDS",TestDSVariable);
			}

			#if !IFRAME_ENABLED_VIEW_STATE
				if(!IsPostBack)
				{
					if(IFrame1.EnableViewState)
						IFrame1.EnableViewState=false;
					if(IFrame2.EnableViewState)
						IFrame2.EnableViewState=false;
				}
			#endif

			#if MAKE_IFRAME_SRC_IN_INIT
				string
					URLFrame1AddStr=string.Empty,
					URLFrame2AddStr=string.Empty;

				if(IsPostBack)
					URLFrame1AddStr=URLFrame2AddStr="IsPostBack=true";

				IFrame1.Attributes["src"]="FrameForm1.aspx"+(URLFrame1AddStr!=string.Empty ? "?" : string.Empty)+URLFrame1AddStr;
				IFrame2.Attributes["src"]="FrameForm2.aspx"+(URLFrame2AddStr!=string.Empty ? "?" : string.Empty)+URLFrame2AddStr;			
			#endif
		}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog("MainForm.Page_Load() (IsPostBack=\""+IsPostBack.ToString()+"\")",true);

			string
				tmpString;

			#if MAKE_IFRAME_SRC_IN_INIT
				tmpString=string.Empty;

				if(tmpString!=string.Empty)
					tmpString+=Environment.NewLine;
				tmpString+=IFrame1.Attributes["src"];
				if(tmpString!=string.Empty)
					tmpString+=Environment.NewLine;
				tmpString+=IFrame2.Attributes["src"];
			#endif

			if(!IsPostBack)
			{
				#if !MAKE_IFRAME_SRC_IN_INIT
					IFrame1.Attributes["src"]="FrameForm1.aspx";
					IFrame2.Attributes["src"]="FrameForm2.aspx";
				#endif
			}
			else
			{
				tmpString=string.Empty;

				if(tmpString!=string.Empty)
					tmpString+=Environment.NewLine;
				tmpString+="MainFormTextBoxInput1.Text=\""+MainFormTextBoxInput1.Text+"\"";

				if(tmpString!=string.Empty)
					tmpString+=Environment.NewLine;
				tmpString+="MainFormTextBoxInput2.Text=\""+MainFormTextBoxInput2.Text+"\"";

				#if !MAKE_IFRAME_SRC_IN_INIT
					IFrame1.Attributes["src"]="FrameForm1.aspx?IsPostBack=true";
					IFrame2.Attributes["src"]="FrameForm2.aspx?IsPostBack=true";
				#endif

				DataRow
					row;

				Log.Log.WriteToLog("MainForm.Page_Load() before lock (IsPostBack=\""+IsPostBack.ToString()+"\")",true);
				lock(TestDSVariable)
				{
					Log.Log.WriteToLog("MainForm.Page_Load() in lock (IsPostBack=\""+IsPostBack.ToString()+"\")",true);

					if(TestDSVariable.Tables["TestTable"].Rows.Count==0)
						row=TestDSVariable.Tables["TestTable"].NewRow();
					else
						row=TestDSVariable.Tables["TestTable"].Rows[0];

					long
						tmpLong;

					try
					{
						tmpLong=Convert.ToInt64(MainFormTextBoxInput1.Text);
					}
					catch(FormatException)
					{
						tmpLong=long.MinValue;
					}
					tmpString="MainFormTextBoxInput1";
					if(tmpLong!=long.MinValue)
						row[tmpString]=tmpLong;
					else
						row[tmpString]=DBNull.Value;

					try
					{
						tmpLong=Convert.ToInt64(MainFormTextBoxInput2.Text);
					}
					catch(FormatException)
					{
						tmpLong=long.MinValue;
					}
					tmpString="MainFormTextBoxInput2";
					if(tmpLong!=long.MinValue)
						row[tmpString]=tmpLong;
					else
						row[tmpString]=DBNull.Value;

					if(row.RowState==DataRowState.Detached)
						TestDSVariable.Tables["TestTable"].Rows.Add(row);

					LabelMainFormTextBoxInput1.Text = !TestDSVariable.Tables["TestTable"].Rows[0].IsNull("MainFormTextBoxInput1") ? Convert.ToString(Convert.ToInt64(TestDSVariable.Tables["TestTable"].Rows[0]["MainFormTextBoxInput1"])) : "NULL";
					LabelMainFormTextBoxInput2.Text = !TestDSVariable.Tables["TestTable"].Rows[0].IsNull("MainFormTextBoxInput2") ? Convert.ToString(Convert.ToInt64(TestDSVariable.Tables["TestTable"].Rows[0]["MainFormTextBoxInput2"])) : "NULL";
					LabelFrameForm1TextBoxInput1.Text = !TestDSVariable.Tables["TestTable"].Rows[0].IsNull("FrameForm1TextBoxInput1") ? Convert.ToString(Convert.ToInt64(TestDSVariable.Tables["TestTable"].Rows[0]["FrameForm1TextBoxInput1"])) : "NULL";
					LabelFrameForm1TextBoxInput2.Text = !TestDSVariable.Tables["TestTable"].Rows[0].IsNull("FrameForm1TextBoxInput2") ? Convert.ToString(Convert.ToInt64(TestDSVariable.Tables["TestTable"].Rows[0]["FrameForm1TextBoxInput2"])) : "NULL";
					LabelFrameForm2TextBoxInput1.Text = !TestDSVariable.Tables["TestTable"].Rows[0].IsNull("FrameForm2TextBoxInput1") ? Convert.ToString(Convert.ToInt64(TestDSVariable.Tables["TestTable"].Rows[0]["FrameForm2TextBoxInput1"])) : "NULL";
					LabelFrameForm2TextBoxInput2.Text = !TestDSVariable.Tables["TestTable"].Rows[0].IsNull("FrameForm2TextBoxInput2") ? Convert.ToString(Convert.ToInt64(TestDSVariable.Tables["TestTable"].Rows[0]["FrameForm2TextBoxInput2"])) : "NULL";
				}
			}
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
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

	}
}

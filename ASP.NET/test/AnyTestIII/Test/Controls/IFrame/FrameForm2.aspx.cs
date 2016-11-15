using System;
using System.Data;
using System.Threading;

namespace AnyTest
{
	/// <summary>
	/// Summary description for FrameForm2.
	/// </summary>
	public class FrameForm2 : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckBoxWithSleep;
		protected System.Web.UI.WebControls.TextBox FrameForm2TextBoxInput1;
		protected System.Web.UI.WebControls.TextBox FrameForm2TextBoxInput2;

		private TestDS
			TestDSVariable;

		private void Page_Init(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog("FrameForm2.Page_Init() (IsPostBack=\""+IsPostBack.ToString()+"\")",true);

			if((TestDSVariable=(TestDS)Session["TestDS"])==null)
			{
				TestDSVariable=new TestDS();
				Session.Add("TestDS",TestDSVariable);
			}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Log.Log.WriteToLog("FrameForm2.Page_Load() (IsPostBack=\""+IsPostBack.ToString()+"\")",true);

			string
				tmpString=string.Empty;

			if(!IsPostBack)
			{
				if(Request.QueryString.GetValues("IsPostBack")!=null)
				{
					tmpString=Request.QueryString.GetValues("IsPostBack")[0];
					if(tmpString.ToLower()=="true")
					{
						if(Session["FrameForm2TextBoxInput1"]!=null)
							FrameForm2TextBoxInput1.Text=(string)Session["FrameForm2TextBoxInput1"];
						if(Session["FrameForm2TextBoxInput2"]!=null)
							FrameForm2TextBoxInput2.Text=(string)Session["FrameForm2TextBoxInput2"];
					}
				}
			}
			else
			{
				Session["FrameForm2TextBoxInput1"]=FrameForm2TextBoxInput1.Text;
				Session["FrameForm2TextBoxInput2"]=FrameForm2TextBoxInput2.Text;

				if(tmpString!=string.Empty)
					tmpString+=Environment.NewLine;
				tmpString+="FrameForm2TextBoxInput1.Text=\""+FrameForm2TextBoxInput1.Text+"\"";

				if(tmpString!=string.Empty)
					tmpString+=Environment.NewLine;
				tmpString+="FrameForm2TextBoxInput2.Text=\""+FrameForm2TextBoxInput2.Text+"\"";

				DataRow
					row;
				
				Log.Log.WriteToLog("FrameForm2.Page_Load() before lock (IsPostBack=\""+IsPostBack.ToString()+"\")",true);
				lock(TestDSVariable)
				{
					Log.Log.WriteToLog("FrameForm2.Page_Load() in lock (IsPostBack=\""+IsPostBack.ToString()+"\")",true);

					if(TestDSVariable.Tables["TestTable"].Rows.Count==0)
						row=TestDSVariable.Tables["TestTable"].NewRow();
					else
						row=TestDSVariable.Tables["TestTable"].Rows[0];

					long
						tmpLong;

					try
					{
						tmpLong=Convert.ToInt64(FrameForm2TextBoxInput1.Text);
					}
					catch(FormatException)
					{
						tmpLong=long.MinValue;
					}
					tmpString="FrameForm2TextBoxInput1";
					if(tmpLong!=long.MinValue)
						row[tmpString]=tmpLong;
					else
						row[tmpString]=DBNull.Value;

					try
					{
						tmpLong=Convert.ToInt64(FrameForm2TextBoxInput2.Text);
					}
					catch(FormatException)
					{
						tmpLong=long.MinValue;
					}
					tmpString="FrameForm2TextBoxInput2";
					if(tmpLong!=long.MinValue)
						row[tmpString]=tmpLong;
					else
						row[tmpString]=DBNull.Value;

					if(row.RowState==DataRowState.Detached)
						TestDSVariable.Tables["TestTable"].Rows.Add(row);

					if(CheckBoxWithSleep.Checked)
					{
						Log.Log.WriteToLog("FrameForm2.Page_Load() before sleep (IsPostBack=\""+IsPostBack.ToString()+"\")",true);
						Thread.Sleep(TestDS.SleepTime);
						Log.Log.WriteToLog("FrameForm2.Page_Load() after sleep (IsPostBack=\""+IsPostBack.ToString()+"\")",true);
					}
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

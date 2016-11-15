using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestingForm : System.Web.UI.Page
	{
		public enum CControlType:byte
		{
			ct_Unknown,
			ct_Radio
		}

		protected System.Web.UI.WebControls.Label LabelQuestionText;
		protected System.Web.UI.WebControls.Panel PanelRadio;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonListAnswers;
		protected System.Web.UI.HtmlControls.HtmlGenericControl DivRemainingTimeTimer;

		protected int
			DelaySleepNextPage=5;

		string
			SessionTestingDataSetSignature="SessionTestingDataSet";

		DataSet
			TestingDataSet=null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if((TestingDataSet=(DataSet)Session[SessionTestingDataSetSignature])==null)
			{
				Session[SessionTestingDataSetSignature]=TestingDataSet=new DataSet();
				FillDataSet();
			}

			string
				tmpString=ConfigurationSettings.AppSettings["DelaySleepTestingNextPage"];

			try
			{
				if(tmpString!=null && tmpString!=string.Empty)
					DelaySleepNextPage=Convert.ToInt32(tmpString);
			}
			catch
			{
				;
			}

			DivRemainingTimeTimer.Style["DISPLAY"] = DelaySleepNextPage!=0 ? "block" : "none";

			if(!IsPostBack)
			{
				
			}
			else
			{
				
			}

			PanelRadio.Visible=false;
			RadioButtonListAnswers.Items.Clear();

			DataRow[]
				tmpDataRows=TestingDataSet.Tables["QuestionMain"].Select("Answer=false");

			if(tmpDataRows.Length>0)
			{
				LabelQuestionText.Text=Convert.ToString(tmpDataRows[0]["Text"]);

				DataRow[]
					tmpDataRowsDetails;

				switch((CControlType)Convert.ToByte(tmpDataRows[0]["Type"]))
				{
					case CControlType.ct_Radio :
					{
						PanelRadio.Visible=true;
						tmpDataRowsDetails=tmpDataRows[0].GetChildRows("Master_Details");
						foreach(DataRow row in tmpDataRowsDetails)
							RadioButtonListAnswers.Items.Add(new ListItem(Convert.ToString(row["Text"]),Convert.ToString(Convert.ToInt64(row["Id"]))));
						break;	
					}
				}
			}
		}

		private void FillDataSet()
		{
			CreateTables();
			FillTables();
		}

		private void CreateTables()
		{
			DataColumn
				col;

			string
				TableName="QuestionMain";

			TestingDataSet.Tables.Add(TableName);
			col=TestingDataSet.Tables[TableName].Columns.Add("Id",typeof(long));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			TestingDataSet.Tables[TableName].Columns.Add("Type",typeof(byte));
			TestingDataSet.Tables[TableName].Columns.Add("Text",typeof(string));
			col=TestingDataSet.Tables[TableName].Columns.Add("Answer",typeof(bool));
			col.DefaultValue=false;
			TestingDataSet.Tables[TableName].PrimaryKey=new DataColumn[]{TestingDataSet.Tables[TableName].Columns["Id"]};

			TableName="QuestionDetails";
			TestingDataSet.Tables.Add(TableName);
			col=TestingDataSet.Tables[TableName].Columns.Add("MasterId",typeof(long));
			col.AllowDBNull=false;
			col=TestingDataSet.Tables[TableName].Columns.Add("Id",typeof(long));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			TestingDataSet.Tables[TableName].Columns.Add("Text",typeof(string));
			TestingDataSet.Tables[TableName].PrimaryKey=new DataColumn[]{TestingDataSet.Tables[TableName].Columns["MasterId"],TestingDataSet.Tables[TableName].Columns["Id"]};

			string
				RelationName="Master_Details";
						
			ForeignKeyConstraint
				_fk_;

			TestingDataSet.Tables[TableName].Constraints.Add(_fk_=new ForeignKeyConstraint("fk"+RelationName,TestingDataSet.Tables["QuestionMain"].Columns["Id"],TestingDataSet.Tables[TableName].Columns["MasterId"]));
			_fk_.UpdateRule=Rule.Cascade;
			_fk_.DeleteRule=Rule.Cascade;
			TestingDataSet.Relations.Add(RelationName,TestingDataSet.Tables["QuestionMain"].Columns["Id"],TestingDataSet.Tables[TableName].Columns["MasterId"]);
		}

		private void FillTables()
		{
			DataRow
				row;

			string
				TableName="QuestionMain";

			row=TestingDataSet.Tables[TableName].NewRow();
			row["Type"]=CControlType.ct_Radio;
			row["Text"]="bla-bla-bla";
			TestingDataSet.Tables[TableName].Rows.Add(row);

			long
				tmpLong=Convert.ToInt64(row["Id"]);

			TableName="QuestionDetails";

			row=TestingDataSet.Tables[TableName].NewRow();
			row["MasterId"]=tmpLong;
			row["Text"]="#1";
			TestingDataSet.Tables[TableName].Rows.Add(row);

			row=TestingDataSet.Tables[TableName].NewRow();
			row["MasterId"]=tmpLong;
			row["Text"]="#2";
			TestingDataSet.Tables[TableName].Rows.Add(row);

			row=TestingDataSet.Tables[TableName].NewRow();
			row["MasterId"]=tmpLong;
			row["Text"]="#3";
			TestingDataSet.Tables[TableName].Rows.Add(row);
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

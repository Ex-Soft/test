using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AnyTest
{
	/// <summary>
	/// Summary description for TableForm.
	/// </summary>
	public class TableForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal VarDef;
		protected System.Web.UI.WebControls.Table ASPTable;
		protected System.Web.UI.WebControls.Button ButtonSubmit;
		protected System.Web.UI.WebControls.Label LabelSubmitInfo;
		protected System.Web.UI.WebControls.Label LabelOnLoadInfo;

		private string
			InsuredPersonCountMaxName="MaxRow";

		public const string
			StrBeginJS="\n<script type=\"text/javascript\">\n<!--\n",
			StrEndJS="\n// -->\n</script>";

		private ArrayList
			TableInfo=new ArrayList();

		public class TableInfoRow
		{
			public string
				Id,
				FIO,
				Seria,
				No,
				Date;

			public TableInfoRow(string aId, string aFIO, string aSeria, string aNo, string aDate)
			{
				Id=aId;
				FIO=aFIO;
				Seria=aSeria;
				No=aNo;
				Date=aDate;
			}

			public TableInfoRow(TableInfoRow obj):this(obj.Id, obj.FIO,obj.Seria,obj.No,obj.Date)
			{}

			public TableInfoRow():this("","","","","")
			{}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			int
				i;

			string
				tmpString;

			if(!IsPostBack)
			{
				string
					StrVarDef="",
					StrVarInit="";			

				if(StrVarInit.Length!=0)
					StrVarInit+=";";
				StrVarInit+=InsuredPersonCountMaxName+"=4";
				StrVarDef="var "+StrVarDef;
				StrVarInit+=";";
				VarDef.Text=StrBeginJS+StrVarDef+StrVarInit+StrEndJS;

				LabelOnLoadInfo.Text+="Page_Load(): "+DateTime.Now+" (IsPostBack=\""+IsPostBack.ToString()+"\")<br>";
			}
			else
			{
				TableInfo.Clear();

				string[]
					rowInfo;

				TableInfoRow
					r=new TableInfoRow();

				for(i=1; i<=4; ++i)
				{
					rowInfo=Request.Params.GetValues("InputId"+i.ToString());
					if(rowInfo==null)
						continue;
					if(rowInfo.Length!=0)
						r.Id=Server.HtmlEncode(rowInfo[0]);

					rowInfo=Request.Params.GetValues("InputSeria"+i.ToString());
					if(rowInfo==null)
						continue;
					if(rowInfo.Length!=0)
						r.Seria=Server.HtmlEncode(rowInfo[0]);

					rowInfo=Request.Params.GetValues("InputNo"+i.ToString());
					if(rowInfo==null)
						continue;
					if(rowInfo.Length!=0)
						r.No=Server.HtmlEncode(rowInfo[0]);

					rowInfo=Request.Params.GetValues("InputDate"+i.ToString());
					if(rowInfo==null)
						continue;
					if(rowInfo.Length!=0)
						r.Date=Server.HtmlEncode(rowInfo[0]);

					TableInfo.Add(new TableInfoRow(r));
				}

				TableRow
					rr;

				TableCell
					c;

				i=1;
				foreach(TableInfoRow row in TableInfo)
				{
					rr=new TableRow();

					c=new TableCell();
					tmpString=row.FIO+"<input id=\"InputId"+i.ToString()+"\" name=\"InputId"+i.ToString()+"\" type=\"hidden\" value=\""+row.Id+"\">";
					c.Controls.Add(new LiteralControl(tmpString));
					rr.Cells.Add(c);

					c=new TableCell();
					tmpString="<input id=\"InputSeria"+i.ToString()+"\" name=\"InputSeria"+i.ToString()+"\" type=\"text\" value=\""+row.Seria+"\" style=\"width: 100%; \">";
					c.Controls.Add(new LiteralControl(tmpString));
					rr.Cells.Add(c);

					c=new TableCell();
					tmpString="<input id=\"InputNo"+i.ToString()+"\" name=\"InputNo"+i.ToString()+"\" type=\"text\" value=\""+row.No+"\" style=\"width: 100%; \">";
					c.Controls.Add(new LiteralControl(tmpString));
					rr.Cells.Add(c);
				
					c=new TableCell();
					tmpString="<input id=\"InputDate"+i.ToString()+"\" name=\"InputDate"+i.ToString()+"\" type=\"text\" value=\""+row.Date+"\" style=\"width: 100%; \">";
					c.Controls.Add(new LiteralControl(tmpString));
					rr.Cells.Add(c);

					c=new TableCell();
					tmpString="<input id=\"DelButt"+i.ToString()+"\" name=\"DellButt"+i.ToString()+"\" type=\"button\" value=\"Del("+i+")\" onclick=\"Del("+i.ToString()+")\" style=\"width: 100%; \">";
					c.Controls.Add(new LiteralControl(tmpString));
					rr.Cells.Add(c);

					c=new TableCell();
					tmpString="<input id=\"EditButt"+i.ToString()+"\" name=\"EditButt"+i.ToString()+"\" type=\"button\" value=\"Edit("+i+")\" onclick=\"Edit("+i.ToString()+")\" style=\"width: 100%; \">";
					c.Controls.Add(new LiteralControl(tmpString));
					rr.Cells.Add(c);

					ASPTable.Rows.Add(rr);

					++i;
				}

				LabelOnLoadInfo.Text+="Page_Load(): "+DateTime.Now+" (IsPostBack=\""+IsPostBack.ToString()+"\")<br>";
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
			this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void ButtonSubmit_Click(object sender, System.EventArgs e)
		{
			LabelSubmitInfo.Text="Hello!!! (from server) ;)";
		}
	}
}

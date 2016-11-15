using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Web;
using System.Web.UI.WebControls;

namespace AnyTest
{
	/// <summary>
	/// Summary description for TestSession.
	/// </summary>
	public class TestSession : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataStaff;
		protected System.Web.UI.WebControls.Label SessionInfo;
		protected System.Web.UI.WebControls.TextBox ContragentId;
		protected System.Web.UI.WebControls.TextBox NewSalaryValue;
		protected System.Web.UI.WebControls.Literal Hidden4Submit;
		
		DataView
			view;
		
		DataSet
			ds;

		CultureInfo
			tmpCultureInfo;

		string
			Hidden4SubmitText="<input id=\"Hidden4Submit\" name=\"Hidden4Submit\" type=\"hidden\" value=\"false\">";

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				Hidden4Submit.Text=Hidden4SubmitText;

				string
					strConn=ConfigurationSettings.AppSettings["MyConnectionString"],
				    SQLText="select ID as IdentificationNumber, Name as FullName, Salary as MinimumSalary from Staff order by ID";

				OleDbDataAdapter
					da=new OleDbDataAdapter(SQLText,strConn);

				ds=new DataSet("DataSetName");
				da.Fill(ds,"Staff");

				view=new DataView(ds.Tables["Staff"]);
				Session.Add("view",view);

				view.Sort="FullName asc";
				DataStaff.DataSource=view;
				DataStaff.DataBind();

				Session.Add("ds",ds);
			}
			else
			{
				string[]
					values=Request.Params.GetValues("Hidden4Submit");

				if(values.Length!=1)
					return;

				string
					value=Server.HtmlEncode(values[0]);

				if(value.ToLower()!="true")
					return;

				string
					id=ContragentId.Text.Trim();

				if(id.Length!=0)
				{
					try
					{
						ds=(DataSet)Session["undefined"];
					}
					catch(HttpException eException)
					{
						string
							err="";
						
						err+="GetHtmlErrorMessage=\""+eException.GetHtmlErrorMessage()+"\"";
						err+=" GetHttpCode=\""+eException.GetHttpCode()+"\"";
						err+=" Message=\""+eException.Message+"\"";
						err+=" Source=\""+eException.Source+"\"";
						err+=" StackTrace=\""+eException.StackTrace+"\"";
					}

					if(ds==null)
						ds=(DataSet)Session["ds"];

					DataRow[]
						volunteer=ds.Tables["Staff"].Select("IdentificationNumber="+id);

					if(volunteer.Length==1)
					{
						tmpCultureInfo=new CultureInfo(Session.LCID);
						if(tmpCultureInfo.NumberFormat.NumberDecimalSeparator!=".")
							tmpCultureInfo.NumberFormat.NumberDecimalSeparator="."; 

						decimal
							SalaryNow=Convert.ToDecimal(volunteer[0][2]),
							SalaryNew;

						try
						{
							SalaryNew=Decimal.Parse(NewSalaryValue.Text,tmpCultureInfo);
						}
						catch(FormatException)
						{
							SalaryNew=Decimal.MaxValue;
						}

						string
							str = SalaryNew<SalaryNow ? "oB!" : "Fuck off!";
						
						Color
							color = SalaryNew<SalaryNow ? Color.Green : Color.Red;

						NewSalaryValue.Text=str;
						NewSalaryValue.ForeColor=color;
					}
					else
					{
						ContragentId.Text="Unknown ID=\""+id+"\"";
						ContragentId.ForeColor=Color.Red;
					}
				}
			}
		}

		private void DataStaff_SortCommand(object source, DataGridSortCommandEventArgs e)
		{
			string
				tmpString="<h1 align=\"center\">Session</h1><hr align=\"center\"><br>";

			tmpString+="Session.CodePage="+Session.CodePage+"<br>";
			tmpString+="Response.ContentEncoding.CodePage="+Response.ContentEncoding.CodePage+"<br>";
			tmpString+="Session.Count="+Session.Count+"<br>";
			tmpString+="Session.IsCookieless="+Session.IsCookieless+"<br>";
			tmpString+="Session.IsNewSession="+Session.IsNewSession+"<br>";
			tmpString+="Session.IsReadOnly="+Session.IsReadOnly+"<br>";
			tmpString+="Session.IsSynchronized="+Session.IsSynchronized+"<br>";

			NameObjectCollectionBase.KeysCollection
				keys = Session.Keys;

			foreach(string key in keys)
				tmpString+="Session.Keys: "+key+"<br>";

			tmpString+="Session.LCID="+Session.LCID+" (0x"+Session.LCID.ToString("x")+")<br>";
			tmpString+="Session.Mode="+Session.Mode+"<br>";
			tmpString+="Session.SessionID="+Session.SessionID+"<br>";
			tmpString+="Session.StaticObjects.Count="+Session.StaticObjects.Count+"<br>";
			tmpString+="Session.Timeout="+Session.Timeout+"<br>";
			SessionInfo.Text=tmpString;

			view=(DataView)Session["view"];
			view.Sort=e.SortExpression;
			DataStaff.DataSource=view;
			DataStaff.DataBind();
		}

		private void DataStaff_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName=="ChangeSalary")
			{
				ContragentId.Text=e.Item.Cells[0].Text;
				tmpCultureInfo=new CultureInfo(Session.LCID);

				decimal
					tmpDecimal=Decimal.Parse(e.Item.Cells[2].Text,NumberStyles.Currency,tmpCultureInfo);
				
				if(tmpCultureInfo.NumberFormat.NumberDecimalSeparator!=".")
					tmpCultureInfo.NumberFormat.NumberDecimalSeparator="."; 

				NewSalaryValue.Text=tmpDecimal.ToString("F",tmpCultureInfo);
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
			this.DataStaff.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataStaff_ItemCommand);
			this.DataStaff.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataStaff_SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}

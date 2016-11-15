using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BeatlesClass;

namespace AnyTest
{
	/// <summary>
	/// Summary description for Controls.
	/// </summary>
	public class Controls : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Literal LiteralWVS;
		protected System.Web.UI.WebControls.Literal LiteralWOVS;
		protected System.Web.UI.WebControls.Literal VarDef;
		protected System.Web.UI.WebControls.Label LabelInfoMsg;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.Table Table1;
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.CheckBox CheckBox2;
		protected System.Web.UI.WebControls.CheckBox CheckBox2_1;
		protected System.Web.UI.WebControls.Label Label1P;
		protected System.Web.UI.WebControls.Label Label2P;
		protected System.Web.UI.WebControls.Label Label3P;
		protected System.Web.UI.WebControls.Label Label4P;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Panel Panel1_1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.ImageButton ImageButton2;
		protected System.Web.UI.WebControls.ImageButton ImageButton3;
		protected System.Web.UI.WebControls.ImageButton ImageButton4;
		protected System.Web.UI.WebControls.ImageButton ImageButton5;
		protected System.Web.UI.WebControls.ListBox ListBox1;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.DropDownList DropDownListDate;
		protected System.Web.UI.WebControls.CheckBoxList CheckBoxList1;
		protected System.Web.UI.WebControls.CheckBoxList CheckBoxList2;
		protected System.Web.UI.WebControls.DropDownList DropDownListRepeatLayout;
		protected System.Web.UI.WebControls.DropDownList DropDownListRepeatDirection;
		protected System.Web.UI.WebControls.TextBox TextBoxRepeatColumns;
		protected System.Web.UI.WebControls.TextBox TextBoxCellSpacing;
		protected System.Web.UI.WebControls.TextBox TextBoxCellPadding;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;
		protected System.Web.UI.WebControls.ListBox ListBox2;
		protected System.Web.UI.WebControls.Label LabelSpan;
		protected System.Web.UI.WebControls.TextBox TextBoxInput;
		protected System.Web.UI.WebControls.RadioButton TableRadioButton1;
		protected System.Web.UI.WebControls.RadioButton TableRadioButton2;
		protected System.Web.UI.WebControls.Button TableButton1;
		protected System.Web.UI.WebControls.DropDownList TableDropDownList;
		protected System.Web.UI.WebControls.ListBox TableListBox;
		protected System.Web.UI.WebControls.HyperLink TableHyperLink1;
		protected System.Web.UI.WebControls.CheckBox TableCheckBox1;
		protected System.Web.UI.WebControls.CheckBox TableCheckBox2;
		protected System.Web.UI.WebControls.Label LabelStatus;
		protected System.Web.UI.WebControls.Table WebTable;
		protected System.Web.UI.WebControls.ListBox ListBoxAdd1;
		protected System.Web.UI.WebControls.ListBox ListBoxAdd2;
		protected System.Web.UI.HtmlControls.HtmlTableRow Row1;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell11;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell12;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell13;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell14;
		protected System.Web.UI.HtmlControls.HtmlTableRow Row2;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell21;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell22;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell23;
		protected System.Web.UI.HtmlControls.HtmlTableCell Cell24;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.Label LabelInfo1;
		protected System.Web.UI.WebControls.Label LabelInfo2;
		protected System.Web.UI.WebControls.Label LabelInfo3;
		protected System.Web.UI.WebControls.Label LabelInfo4;
		protected System.Web.UI.WebControls.Label LabelInfo5;
		protected System.Web.UI.WebControls.Label LabelInfo6;
		protected System.Web.UI.WebControls.Label LabelInfo;
		protected System.Web.UI.WebControls.Label LabelInfo7;
		protected System.Web.UI.WebControls.Label LabelInfo8;
		protected System.Web.UI.WebControls.Label LabelInfo9;
		protected System.Web.UI.WebControls.Label LabelInfo10;
		protected System.Web.UI.WebControls.Label LabelInfo11;
		protected System.Web.UI.WebControls.Label LabelInfo12;
		protected System.Web.UI.WebControls.Label LabelInfo13;
		protected System.Web.UI.WebControls.Label LabelInfo14;
		protected System.Web.UI.WebControls.Label LabelInfo15;
		protected System.Web.UI.WebControls.Label LabelHidden;
		protected System.Web.UI.WebControls.Label LabelFile;
		protected System.Web.UI.WebControls.Label LabelLabelStatus;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
	    protected System.Web.UI.HtmlControls.HtmlGenericControl TestDiv;
		protected System.Web.UI.WebControls.Table TestTable;
		protected System.Web.UI.HtmlControls.HtmlInputButton HtmlButtonSubmit; 
		protected System.Web.UI.WebControls.Label DivLabelInfo;
		protected System.Web.UI.WebControls.Label LabelStaticValue;
		protected System.Web.UI.WebControls.Label LabelApplication;
		protected System.Web.UI.WebControls.Table NewDynamicTable;
		protected System.Web.UI.WebControls.Label LabelEnvironmentCurrentDirectory;
		protected System.Web.UI.WebControls.Label LabelPage;
		protected System.Web.UI.HtmlControls.HtmlTable MainTable;
		protected System.Web.UI.WebControls.CheckBox CheckBox1Disabled;
		protected System.Web.UI.WebControls.CheckBox CheckBox1ReadOnly;
		protected System.Web.UI.WebControls.DropDownList DropDownListTestDataBind;
		protected System.Web.UI.WebControls.DropDownList DropDownListTestDataBindII;
		protected System.Web.UI.WebControls.Label LabelTextBoxReadOnly;
		protected System.Web.UI.WebControls.TextBox TextBoxReadOnly;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton HtmlRunatServerRadio1;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton HtmlRunatServerRadio2;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton HtmlRunatServerRadio3;
		protected System.Web.UI.WebControls.ListBox ListBox1_2;
		protected System.Web.UI.WebControls.ListBox ListBox1_3;
		protected System.Web.UI.WebControls.DropDownList DropDownListEnabledDisabled;
		protected System.Web.UI.WebControls.Label LabelDropDownListEnabledDisabled;

		protected string
			HTMLButtonValue="HTMLButtonValue !!!";

		private void Page_Init(object sender, System.EventArgs e)
		{
			Response.Write("<SCRIPT TYPE=\"text/javascript\">\n<!--\n");
			Response.Write("var PLS=new Date();");
			Response.Write("\n// -->\n</SCRIPT>");

			LabelPage.Text+="PageInit: "+DateTime.Now.ToString("hh:mm:ss")+"<br>";

			HtmlTable
				TableInner;

			TableRow
				tr;

			HtmlTableRow
				trInner;

			TableCell
				tCell;

			HtmlTableCell
				tCellInner;

			LinkButton
					lbtn;

			TextBox
				tmpTextBox;

			for(int i=0; i<6; ++i)
			{
				tr=new TableRow();

				tCell=new TableCell();
				lbtn=new LinkButton();
				lbtn.Text="Добавить";
				lbtn.ID="LinkButton__"+i.ToString();
				lbtn.CommandName="CommandFromLinkButton__"+i.ToString();
				lbtn.CommandArgument="ArgumentFromLinkButton__"+i.ToString();
				lbtn.Click+=new System.EventHandler(LinkButton_Click);
				lbtn.Command+=new System.Web.UI.WebControls.CommandEventHandler(LinkButton_Command);
				tCell.Controls.Add(lbtn);
				tr.Cells.Add(tCell);

				tCell=new TableCell();
				tmpTextBox=new TextBox();
				tmpTextBox.ID="TextBoxInput__"+i.ToString();
				tCell.Controls.Add(tmpTextBox);
				tr.Cells.Add(tCell);

				tCell=new TableCell();
				tmpTextBox=new TextBox();
				tmpTextBox.ID="TextBoxOutput__"+i.ToString();
				tCell.Controls.Add(tmpTextBox);
				tr.Cells.Add(tCell);

				tCell=new TableCell();
				TableInner=new HtmlTable();
				tCell.Controls.Add(TableInner);
				TableInner.CellPadding=0;
				TableInner.CellSpacing=0;
				TableInner.Border=0;
				trInner=new HtmlTableRow();
				tCellInner=new HtmlTableCell();
				trInner.Cells.Add(tCellInner);
				TableInner.Rows.Add(trInner);
				tr.Cells.Add(tCell);

				NewDynamicTable.Rows.Add(tr);
			}

			string
				scriptString="<script type=\"text/javascript\">\n<!--\n";

			scriptString+="function Page_Load(){SetPageLoadInfo('PLS','SpanStarted','SpanFinished','SpanDiffTime');document.getElementById('TextBoxReadOnly').value='TextBoxReadOnly';alert('RegisterStartupScript Example');alert('top.frames.length='+top.frames.length);for(var i=0; i<top.frames.length; ++i){alert('top.frames['+i+'].name=\\u0022'+top.frames[i].name+'\\u0022');}}";
			scriptString+="\n// -->\n";
			scriptString+="<";
			scriptString+="/";
			scriptString+="script>";
        
			if(!this.IsStartupScriptRegistered("Startup"))
				this.RegisterStartupScript("Startup",scriptString);

			#region System.Web.UI.WebControls.Literal
			if(LiteralWOVS.EnableViewState)
				LiteralWOVS.EnableViewState=false;
			#endregion
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			string
				_tmpString_="This is a <Test String>.";

			_tmpString_=Server.HtmlEncode(_tmpString_); // -> "This is a &lt;Test String&gt;."
			_tmpString_=Server.HtmlDecode(_tmpString_); // -> "This is a <Test String>."

			_tmpString_=HttpUtility.HtmlEncode(_tmpString_); // -> "This is a &lt;Test String&gt;."
			_tmpString_=HttpUtility.HtmlDecode(_tmpString_); // -> "This is a <Test String>."
			
			_tmpString_=Server.UrlEncode(_tmpString_); // -> "This+is+a+%3cTest+String%3e."
			_tmpString_=Server.UrlDecode(_tmpString_); // -> "This is a <Test String>."

			_tmpString_=HttpUtility.UrlEncode(_tmpString_); // -> "This+is+a+%3cTest+String%3e."
			_tmpString_=HttpUtility.UrlDecode(_tmpString_); // -> "This is a <Test String>."

			_tmpString_="Это - тест <\"ПрЫвЭт!!!\">";

			_tmpString_=Server.HtmlEncode(_tmpString_);
			_tmpString_=Server.HtmlDecode(_tmpString_);
			
			_tmpString_=HttpUtility.HtmlEncode(_tmpString_);
			_tmpString_=HttpUtility.HtmlDecode(_tmpString_);

			_tmpString_=Server.UrlEncode(_tmpString_);
			_tmpString_=Server.UrlDecode(_tmpString_);
			
			_tmpString_=HttpUtility.UrlEncode(_tmpString_);
			_tmpString_=HttpUtility.UrlDecode(_tmpString_);

			_tmpString_="Привет";

			_tmpString_=Server.UrlEncode(_tmpString_);
			_tmpString_=Server.UrlDecode(_tmpString_);
			
			_tmpString_=HttpUtility.UrlEncode(_tmpString_);
			_tmpString_=HttpUtility.UrlDecode(_tmpString_);

			_tmpString_="При\nвет\r\n";

			_tmpString_=Server.UrlEncode(_tmpString_);
			_tmpString_=Server.UrlDecode(_tmpString_);
			
			_tmpString_=HttpUtility.UrlEncode(_tmpString_);
			_tmpString_=HttpUtility.UrlDecode(_tmpString_);

			_tmpString_=Request.Url.Scheme;
			_tmpString_+=Uri.SchemeDelimiter;
			_tmpString_+=Request.Url.Host;
			_tmpString_+=Request.Url.IsDefaultPort ? string.Empty : ":" + Request.Url.Port;
			_tmpString_+=ResolveUrl("~/MainTitle.aspx");

			LabelPage.Text+="PageLoad: "+DateTime.Now.ToString("hh:mm:ss")+" (IsPostBack=\""+IsPostBack.ToString()+"\")<br>";
			if(!IsPostBack)
			{
				LabelEnvironmentCurrentDirectory.Text+=Environment.CurrentDirectory;

				IEnumerator
					keys=TestDiv.Style.Keys.GetEnumerator();

				String
					key;

				while(keys.MoveNext()) 
				{
					key=(String)keys.Current;
					DivLabelInfo.Text+="["+key+"]="+TestDiv.Style[key]+"<br>";
				}

				TextBox1.ToolTip="Line 1\nLine 2";
				LabelApplication.Text=String.Format("User Online={0}",(int)(Application["UserOnline"]));
				
				MainTable.Border=3;

				TableRow
					row;

				TableCell
					cell;

				int
					i;

				for(i=0; i<2; ++i)
				{
					row=new TableRow();
					for(int j=0; j<2; ++j)
					{
						cell=new TableCell();
						cell.Text=String.Format("Row {0}, Column {1}",i+1,j+1);
						row.Cells.Add(cell);
					}
					Table2.Rows.Add(row);
				}

				DateTime
					date;

				for(i=0; i<5; ++i)
				{
					date=DateTime.Today+new TimeSpan(i,0,0,0);
					DropDownListDate.Items.Add(date.ToString("MMMM dd, yyyy"));
				}

				DataSet
					ds=new DataSet();

				ds.ReadXml(Server.MapPath("data/rates.xml"));
				ListBox2.DataSource=ds;
				ListBox2.DataTextField="Currency";
				ListBox2.DataValueField="Exchange";
				ListBox2.DataBind();
				ListBox2.SelectedIndex=3;

				Cell11.BorderColor="red";
				Cell11.BgColor="green";

				for(i=100; i<=1000; i+=100)
					TableDropDownList.Items.Add(i.ToString());

				ArrayList
					a=new ArrayList();

				for(i=50; i<=1000; i+=50)
					a.Add(i.ToString());
				TableListBox.DataSource=a;
				TableListBox.DataBind();

				string[]
					beatles={"John", "Paul", "George", "Ringo"};

				ListBoxAdd1.DataSource=beatles;
				ListBoxAdd1.DataBind();

				ListBoxAdd2.DataSource=new Beatles();
				ListBoxAdd2.DataBind();

				DropDownListTestDataBind.DataSource=new BeatlesII();
				DropDownListTestDataBind.DataTextField="Name";
				DropDownListTestDataBind.DataValueField="Id";
				DropDownListTestDataBind.DataBind();

				DropDownListTestDataBindII.DataSource=new BeatlesII();
				DropDownListTestDataBindII.DataValueField="Name";
				DropDownListTestDataBindII.DataTextField="Id";
				DropDownListTestDataBindII.DataBind();

				ImageButton4.Attributes["onclick"]="return(confirm('Submit?'));";
				ImageButton5.Attributes["onclick"]="return(false);";

				ListBox1.Attributes.Add("ondblclick","alert('ondblclick');");
				DropDownListDate.Attributes.Add("ondblclick","alert('ondblclick');");

				Button3.Attributes.Add("onclick","alert('ковычки \u0022');");

				DataTable
					SmthTable=new DataTable();

				string
					SmthFieldName="Id";

				SmthTable.Columns.Add(SmthFieldName,typeof(int));

				DataRow
					tmpDataRow=SmthTable.NewRow();

				tmpDataRow[SmthFieldName]=1;
				SmthTable.Rows.Add(tmpDataRow);

				tmpDataRow=SmthTable.NewRow();
				tmpDataRow[SmthFieldName]=2;
				SmthTable.Rows.Add(tmpDataRow);

				tmpDataRow=SmthTable.NewRow();
				tmpDataRow[SmthFieldName]=3;
				SmthTable.Rows.Add(tmpDataRow);

				string
					tmpString=String.Empty;

				foreach(DataRow _row_ in SmthTable.Rows)
				{
					if(tmpString!=String.Empty)
						tmpString+=",";
					tmpString+=!_row_.IsNull(SmthFieldName) ? "\""+Convert.ToString(_row_[SmthFieldName]).Replace("\\","\\\\").Replace("\"","\\\"")+"\"" : "null";
				}
				VarDef.Text="\n<script type=\"text/javascript\">\n<!--\n";
				VarDef.Text+="ArrayName=["+tmpString+"];";
				VarDef.Text+="\n// -->\n</script>";

				Button4.Attributes.Add("onclick","return(confirm('ahha?\\r\\nahha?'));");
			}
			else
			{
				LabelTextBoxReadOnly.Text=TextBoxReadOnly.Text;

				string
					tmpString=TextBox3.Text;

				if((tmpString.IndexOf("\r\n"))!=-1)
					tmpString=tmpString.Replace("\r\n"," ").Trim();

				TextBox3.Text=tmpString;

				lock(typeof(TestClassWithStatic))
				{
					LabelStaticValue.Text=Convert.ToString(TestClassWithStatic.Counter)+"->"+Convert.ToString(--TestClassWithStatic.Counter)+" (SessionID: "+Session.SessionID+")";
				}

				TextBox
					TextBoxInput,
					TextBoxOutput;

				if((TextBoxInput=NewDynamicTable.FindControl("TextBoxInput__0") as TextBox)!=null
					&& (TextBoxOutput=NewDynamicTable.FindControl("TextBoxOutput__0") as TextBox)!=null)
				{
					TextBoxOutput.Text=TextBoxInput.Text;
				}
				else if((TextBoxInput=NewDynamicTable.Rows[0].FindControl("TextBoxInput__0") as TextBox)!=null
						&& (TextBoxOutput=NewDynamicTable.Rows[0].FindControl("TextBoxOutput__0") as TextBox)!=null)
				{
					TextBoxOutput.Text=TextBoxInput.Text;
				}
				else if((TextBoxInput=NewDynamicTable.Rows[0].Cells[0].FindControl("TextBoxInput__0") as TextBox)!=null
						&& (TextBoxOutput=NewDynamicTable.Rows[0].Cells[0].FindControl("TextBoxOutput__0") as TextBox)!=null)
				{
					TextBoxOutput.Text=TextBoxInput.Text;
				}
				for(int row=0; row<NewDynamicTable.Rows.Count; ++row)
				{
					for(int col=0; col<NewDynamicTable.Rows[row].Cells.Count; ++col)
					{
						if((TextBoxInput=NewDynamicTable.Rows[row].Cells[col].FindControl("TextBoxInput__"+row) as TextBox)!=null
							&& (TextBoxOutput=NewDynamicTable.Rows[row].Cells[col].FindControl("TextBoxOutput__"+row) as TextBox)!=null)
						{
							TextBoxOutput.Text=TextBoxInput.Text;		
						}
					}
				}

				#region DropDownListEnabledDisabled
				DropDownListEnabledDisabled.Enabled=Request.Form.GetValues("DropDownListEnabledDisabled")!=null;

				string[]
					ParamArray=Request.Form.GetValues("DropDownListEnabledDisabled");

				string
					ParamValue=string.Empty;

				if(ParamArray!=null && ParamArray.Length>0)
					ParamValue=ParamArray[0]; 

				LabelDropDownListEnabledDisabled.Text=ParamValue;
				#endregion

				#region Test __doPostBack()
				tmpString=Request.Form["__EVENTTARGET"];
				tmpString=Request.Form["__EVENTARGUMENT"];
				#endregion
			}

			#region System.Web.UI.WebControls.Literal
			if(LiteralWOVS.EnableViewState)
				LiteralWOVS.EnableViewState=false;

			if(!IsPostBack)
			{
				LiteralWVS.Text="<!-- LiteralWVS -->";
				LiteralWOVS.Text="<!-- LiteralWOVS -->";
			}
			else
			{
				_tmpString_="\""+LiteralWVS.Text+"\"";
				if(_tmpString_!=string.Empty)
					_tmpString_+=Environment.NewLine;
				_tmpString_="\""+LiteralWOVS.Text+"\"";
			}
			#endregion
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
			this.Button1.Click += new EventHandler(Button_Click);
			this.ListBox1.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
			this.ListBox1_2.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
			this.ListBox1_3.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
			this.TextBox1.TextChanged += new System.EventHandler(this.OnChanged);
			this.TextBox2.TextChanged += new System.EventHandler(this.OnChanged);
			this.TextBox3.TextChanged += new System.EventHandler(this.OnChanged);
			this.CheckBox1.CheckedChanged += new System.EventHandler(this.OnChanged);
			this.RadioButton1.CheckedChanged += new System.EventHandler(this.OnChanged);
			this.RadioButton2.CheckedChanged += new System.EventHandler(this.OnChanged);
			this.RadioButton3.CheckedChanged += new System.EventHandler(this.OnChanged);
			this.CheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
			this.CheckBox2_1.CheckedChanged += new System.EventHandler(this.CheckBox2_1_CheckedChanged);
			this.DropDownListRepeatLayout.SelectedIndexChanged += new System.EventHandler(this.DropDownListRepeatLayout_SelectedIndexChanged);
			this.DropDownListRepeatDirection.SelectedIndexChanged += new System.EventHandler(this.DropDownListRepeatDirection_SelectedIndexChanged);
			this.TextBoxRepeatColumns.TextChanged += new System.EventHandler(this.TextBoxRepeatColumns_TextChanged);
			this.TextBoxCellSpacing.TextChanged += new System.EventHandler(this.TextBoxCellSpacing_TextChanged);
			this.TextBoxCellPadding.TextChanged += new System.EventHandler(this.TextBoxCellPadding_TextChanged);
			this.TableButton1.Click += new System.EventHandler(this.TableButton1_Click);
			this.TableDropDownList.SelectedIndexChanged += new System.EventHandler(this.TableDropDownList_SelectedIndexChanged);
			this.TableListBox.SelectedIndexChanged += new System.EventHandler(this.TableListBox_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void TableDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(LabelStatus.Text.Length!=0)
				LabelStatus.Text+="<br>";

			LabelStatus.Text+="Order status @ "+DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")+" DropDownList_SelectedIndexChanged";
		}

		private void TableButton1_Click(object sender, System.EventArgs e)
		{
			if(LabelStatus.Text.Length!=0)
				LabelStatus.Text+="<br>";

			LabelStatus.Text+="Order status @ "+DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");
			if(TableDropDownList.SelectedIndex!=-1)
				LabelStatus.Text+=" TableDropDownList.SelectedItem.Value="+TableDropDownList.SelectedItem.Value+" TableDropDownList.SelectedValue="+TableDropDownList.SelectedValue;
		}

		private void TableListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(LabelStatus.Text.Length!=0)
				LabelStatus.Text+="<br>";

			LabelStatus.Text+="Order status @ "+DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")+" ListBox_SelectedIndexChanged";
		}

		private void OnChanged(object sender, System.EventArgs argv)
		{
			LabelInfo.Text=sender.ToString()+" argv='"+argv.ToString()+"'";		
		}

		private void CheckBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			Panel1.Visible=CheckBox2.Checked;
		}

		private void CheckBox2_1_CheckedChanged(object sender, System.EventArgs e)
		{
			Panel1_1.Visible=CheckBox2_1.Checked;
		}

		private void DropDownListRepeatLayout_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string
				choice=DropDownListRepeatLayout.SelectedItem.Value.ToLower();

			if(choice.CompareTo("table")==0)
				RadioButtonList1.RepeatLayout=RepeatLayout.Table;
			if(choice.CompareTo("flow")==0)
				RadioButtonList1.RepeatLayout=RepeatLayout.Flow;
		}

		private void DropDownListRepeatDirection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string
				choice=DropDownListRepeatDirection.SelectedItem.Value.ToLower();

			if(choice.CompareTo("vertical")==0)
				RadioButtonList1.RepeatDirection=RepeatDirection.Vertical;
			if(choice.CompareTo("horizontal")==0)
				RadioButtonList1.RepeatDirection=RepeatDirection.Horizontal;
		}

		private void TextBoxRepeatColumns_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				RadioButtonList1.RepeatColumns=Convert.ToInt32(TextBoxRepeatColumns.Text);
			}
			catch(Exception)
			{
				RadioButtonList1.RepeatColumns=1;
			}
		}

		private void TextBoxCellSpacing_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				RadioButtonList1.CellSpacing=Convert.ToInt32(TextBoxCellSpacing.Text);
			}
			catch(Exception)
			{
				RadioButtonList1.CellSpacing=1;
			}
		}

		private void TextBoxCellPadding_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				RadioButtonList1.CellPadding=Convert.ToInt32(TextBoxCellPadding.Text);
			}
			catch(Exception)
			{
				RadioButtonList1.CellPadding=1;
			}
		}

		private void LinkButton_Click(object sender, System.EventArgs e)
		{
			;
		}

		private void LinkButton_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			;
		}

		private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox
				tmpListBox;

			if((tmpListBox=sender as ListBox)==null)
				return;

			string
				tmpString;

			if(tmpListBox.SelectedIndex!=-1)
			{
				tmpString=tmpListBox.SelectedIndex+" "+tmpListBox.SelectedValue+" "+tmpListBox.SelectedItem.Text;
			}

			tmpString=string.Empty;
			foreach(ListItem li in tmpListBox.Items)
			{
				if(li.Selected)
				{
					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;
					tmpString+=li.Value+" "+li.Text;
				}
			}
		}

		private void Button_Click(object sender, EventArgs e)
		{

		}
	}

	public class TestClassWithStatic
	{
		public static long
			Counter;

		public TestClassWithStatic()
		{}
	}
}

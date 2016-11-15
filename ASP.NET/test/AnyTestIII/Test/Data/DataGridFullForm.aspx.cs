#define USE_ITEM_CREATED
#define USE_VIEW_STATE
//#define ANALIZE_VIEW_STATE
//#define USE_REFERENCE

using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class DataGridFullForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGridFull;

		DataSet
			ds=null;

		string
			DataGridFullFormSessionSignature="DataGridFullFormSession",
			DataGridFullFormViewStateSortSignature="DataGridFullFormViewStateSort",
			DataGridFullFormViewStateFilterSignature="DataGridFullFormViewStateFilter",
			TableName="TestTable",
			CheckedFieldName="Checked",
			connstring=ConfigurationSettings.AppSettings["MyConnectionString"],
			CheckBoxSignature="tmpCheckBox",
			LinkButtonSignature="LinkButtonDelete",
			CheckBoxInHeader1Signature="CheckBoxInHeader1";

		#if !USE_VIEW_STATE
			bool
				CheckBoxInHeader1Checked;
		#endif

		#if USE_REFERENCE
			CheckBox
				chkGridHeadCheckbox=null;

			bool
				gridHeadCheckboxInitValue=false;
		#endif

		void Page_Init(object sender, System.EventArgs e)
		{
			//
		}
		//---------------------------------------------------------------------------

		void Page_Load(object sender, System.EventArgs e)
		{
			#if ANALIZE_VIEW_STATE
				string
					Value;

				byte[]
					BinaryData=null;

				char[]
					CharData=null;

				if(Request.Params.GetValues("__VIEWSTATE")!=null)
				{
					Value=Request.Params.GetValues("__VIEWSTATE")[0];
					try
					{
						BinaryData=Convert.FromBase64String(Value);
						CharData=new char[BinaryData.Length];
						for(int i=0; i<BinaryData.Length; ++i)
							CharData[i]=Convert.ToChar(BinaryData[i]);
						Value=new string(CharData);
						if(Value!=string.Empty)
							Value=string.Empty;
					}
					catch(OutOfMemoryException)
					{
						Value="Insufficient memory.";
					}
					catch(ArgumentNullException) 
					{
						Value="Base 64 string is null.";
					}
					catch(System.FormatException) 
					{
						Value="Base 64 string length is not 4 or is not an even multiple of 4.";
					}
				}
			#endif

			if((ds=(DataSet)Session[DataGridFullFormSessionSignature])==null)
			{
				ds=new DataSet();
				Session[DataGridFullFormSessionSignature]=ds;

				if(!ds.Tables.Contains(TableName))
					ds.Tables.Add(TableName);
				if(!ds.Tables[TableName].Columns.Contains(CheckedFieldName))
					ds.Tables[TableName].Columns.Add(CheckedFieldName,typeof(bool));
			}

			if(!IsPostBack)
			{
				FillDataTable(ds.Tables[TableName]);
				SetDataSource(DataGridFull,ds.Tables[TableName]);
				DataGridFull.DataBind();
			}

			if(IsPostBack)
			{
				CheckBox
					tmpCheckBox;

				int
					tmpInt;

				DataRow
					tmpDataRow;

				foreach(DataGridItem item in DataGridFull.Items)
				{
					if((tmpCheckBox=(item.FindControl(CheckBoxSignature) as CheckBox))==null)
						continue;

					if((tmpDataRow=ds.Tables[TableName].Rows.Find(tmpInt=Convert.ToInt32(DataGridFull.DataKeys[item.ItemIndex])))!=null)
					{
						if(tmpDataRow.IsNull(CheckedFieldName) || Convert.ToBoolean(tmpDataRow[CheckedFieldName])!=tmpCheckBox.Checked)
							tmpDataRow[CheckedFieldName]=tmpCheckBox.Checked;
					}
					else
						throw(new Exception("Unknown ID: '"+tmpInt+"'"));
				}
			}
		}
		//---------------------------------------------------------------------------

		void FillDataTable(DataTable dt)
		{
			OleDbConnection
				connection=new OleDbConnection(connstring);
      
			OleDbDataAdapter
				da=new OleDbDataAdapter("select * from Staff",connection);
              
			da.Fill(dt);
			if(dt.PrimaryKey.Length==0)
				dt.PrimaryKey=new DataColumn[]{dt.Columns["Id"]};
		}
		//---------------------------------------------------------------------------

		void SetDataSource(DataGrid aDataGrid, DataTable dt)
		{
			if(ViewState[DataGridFullFormViewStateSortSignature]!=null)
				dt.DefaultView.Sort=(string)ViewState[DataGridFullFormViewStateSortSignature];
			if(ViewState[DataGridFullFormViewStateFilterSignature]!=null)
				dt.DefaultView.RowFilter=(string)ViewState[DataGridFullFormViewStateFilterSignature];
			aDataGrid.DataSource=dt.DefaultView;
		}
		//---------------------------------------------------------------------------

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
			this.DataGridFull.ItemCommand+=new DataGridCommandEventHandler(DataGrid_ItemCommand);
			this.DataGridFull.SortCommand+=new DataGridSortCommandEventHandler(DataGrid_SortCommand);
			this.DataGridFull.PageIndexChanged+=new DataGridPageChangedEventHandler(DataGrid_PageIndexChanged);
			#if USE_ITEM_CREATED
				this.DataGridFull.ItemCreated+=new DataGridItemEventHandler(DataGrid_ItemCreated);
			#endif
			this.DataGridFull.ItemDataBound+=new DataGridItemEventHandler(DataGrid_ItemDataBound);
			this.Load+=new System.EventHandler(this.Page_Load);
			this.Init+=new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void DataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=source as DataGrid)==null)
				return;

			if(tmpDataGrid.DataSource==null)
				SetDataSource(tmpDataGrid,ds.Tables[TableName]);
			tmpDataGrid.CurrentPageIndex=e.NewPageIndex;
			Global.CheckDataGridPageIndex(tmpDataGrid,((DataView)tmpDataGrid.DataSource).Count);
			tmpDataGrid.DataBind();
		}
		//---------------------------------------------------------------------------

		#if USE_ITEM_CREATED
			private void DataGrid_ItemCreated(object sender, DataGridItemEventArgs e)
			{
				DataGrid
					tmpDataGrid;

				if((tmpDataGrid=sender as DataGrid)==null)
					return;

				#if !USE_REFERENCE
					CheckBox
						tmpCheckBox;
				#endif

				switch(e.Item.ItemType)
				{
					case ListItemType.Header :
					{
						Literal
							tmpLiteral;

						tmpLiteral=new Literal();
						tmpLiteral.Text="<br>";
						e.Item.Cells[4].Controls.Add(tmpLiteral);

						#if !USE_REFERENCE
							tmpCheckBox
						#else
							chkGridHeadCheckbox
						#endif
							=new CheckBox();

						#if !USE_REFERENCE
							tmpCheckBox.ID
						#else
							chkGridHeadCheckbox.ID
						#endif
							=CheckBoxInHeader1Signature;

						#if !USE_REFERENCE
							tmpCheckBox.Text
						#else
							chkGridHeadCheckbox.Text
						#endif
							="NOT&nbsp;NULL";

						#if !USE_REFERENCE
							tmpCheckBox.TextAlign
						#else
							chkGridHeadCheckbox.TextAlign
						#endif
							=TextAlign.Right;

						#if !USE_REFERENCE
							tmpCheckBox.AutoPostBack
						#else
							chkGridHeadCheckbox.AutoPostBack
						#endif
							=true;

						#if USE_VIEW_STATE
							#if !USE_REFERENCE
								tmpCheckBox.Checked
							#else
								chkGridHeadCheckbox.Checked
							#endif
								= ViewState[DataGridFullFormViewStateFilterSignature]!=null && ((string)ViewState[DataGridFullFormViewStateFilterSignature])!=string.Empty;
						#else
							#if !USE_REFERENCE
								tmpCheckBox.Checked
							#else
								chkGridHeadCheckbox.Checked
							#endif
								=
							#if !USE_REFERENCE
								CheckBoxInHeader1Checked
							#else
								gridHeadCheckboxInitValue
							#endif
								;
						#endif
						#if !USE_REFERENCE
							tmpCheckBox.CheckedChanged
						#else
							chkGridHeadCheckbox.CheckedChanged
						#endif
							+=new EventHandler(CheckBox_CheckedChanged);
						e.Item.Cells[4].Controls.Add(
						#if !USE_REFERENCE
							tmpCheckBox
						#else
							chkGridHeadCheckbox
						#endif
							);

						break;	
					}
					case ListItemType.Item :
					case ListItemType.AlternatingItem :
					{
						DataRowView
							tmpDataRowView;
						
						if((tmpDataRowView=e.Item.DataItem as DataRowView)!=null)
						{
							string
								tmpString,
								FieldName="BirthDate";

							tmpString = !tmpDataRowView.Row.IsNull(FieldName) ? Convert.ToDateTime(tmpDataRowView.Row[FieldName]).ToString("dd.MM.yyyy") : "null";

							tmpString+=tmpString;
						}

						break;	
					}
				}
			}
			//---------------------------------------------------------------------------
		#endif

		private void DataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			CheckBox
				tmpCheckBox;

			switch(e.Item.ItemType)
			{
				#if !USE_ITEM_CREATED
					case ListItemType.Header:
					{
						Literal
							tmpLiteral;

						tmpLiteral=new Literal();
						tmpLiteral.Text="<br>";
						e.Item.Cells[4].Controls.Add(tmpLiteral);

						tmpCheckBox=new CheckBox();
						tmpCheckBox.ID=CheckBoxInHeader1Signature;
						tmpCheckBox.Text="NOT&nbsp;NULL";
						tmpCheckBox.TextAlign=TextAlign.Right;
						tmpCheckBox.AutoPostBack=true;
						#if USE_VIEW_STATE
							tmpCheckBox.Checked = ViewState[DataGridFullFormViewStateFilterSignature]!=null && ((string)ViewState[DataGridFullFormViewStateFilterSignature])!=string.Empty;
						#else
							tmpCheckBox.Checked=CheckBoxInHeader1Checked;
						#endif
						tmpCheckBox.CheckedChanged+=new EventHandler(CheckBox_CheckedChanged);
						e.Item.Cells[4].Controls.Add(tmpCheckBox);

						break;	
					}
				#endif
				case ListItemType.Item :
				case ListItemType.AlternatingItem :
				{
					DataRowView
						tmpDataRowView=e.Item.DataItem as System.Data.DataRowView;

					bool
						tmpBool = !tmpDataRowView.Row.IsNull(CheckedFieldName) ? Convert.ToBoolean(tmpDataRowView.Row[CheckedFieldName]) : false;

					if((tmpCheckBox=e.Item.FindControl(CheckBoxSignature) as CheckBox)!=null
						&& tmpCheckBox.Checked!=tmpBool)
						tmpCheckBox.Checked=tmpBool;

					LinkButton
						tmpLinkButton;

					if((tmpLinkButton=e.Item.FindControl(LinkButtonSignature) as LinkButton)!=null)
						tmpLinkButton.CommandArgument=Convert.ToString(Convert.ToInt64(tmpDataRowView.Row["ID"]));

					e.Item.Cells[2].CssClass=tmpDataRowView.Row.IsNull("BirthDate") ? "InsufficientInfo" : string.Empty;

					string
						tmpString="' \" \\\\ \\ / // \" '";

					e.Item.Cells[0].Attributes.Add("onclick","alert('"+tmpString.Replace("\\","\\\\").Replace("'","\\'").Replace("\"","\\x22")+"')");
					e.Item.Cells[1].Attributes.Add("onclick","alert('"+tmpString.Replace("\\","\\\\").Replace("'","\\'").Replace("\"","\\\"")+"')");

					break;
				}
			}
		}
		//---------------------------------------------------------------------------

		private void DataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=source as DataGrid)==null)
				return;

			ViewState[DataGridFullFormViewStateSortSignature]=e.SortExpression;
			foreach(DataGridColumn column in tmpDataGrid.Columns)
			{
				column.HeaderText=column.HeaderText.Replace(" v","");
				column.HeaderText=column.HeaderText.Replace(" ^","");
				if(column.SortExpression==e.SortExpression)
				{
					if(e.SortExpression.IndexOf(" desc")!=-1)
					{
						column.SortExpression=column.SortExpression.Replace(" desc","");
						column.HeaderText+=" ^";
					}
					else
					{
						column.SortExpression+=" desc";
						column.HeaderText+=" v";
					}
				}
			}			
			SetDataSource(tmpDataGrid,ds.Tables[TableName]);
			tmpDataGrid.DataBind();
		}
		//---------------------------------------------------------------------------

		private void DataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			switch(e.CommandName)
			{
				case "Delete" :
				{
					if(Convert.ToInt64(e.CommandArgument)!=long.MinValue)
					{
						
					}
					break;	
				}
			}
		}
		//---------------------------------------------------------------------------

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox
				tmpCheckBox;

			if((tmpCheckBox=sender as CheckBox)==null)
				return;

			ViewState[DataGridFullFormViewStateFilterSignature] = tmpCheckBox.Checked ? "(BirthDate is not null)" : string.Empty;

			#if !USE_VIEW_STATE
				CheckBoxInHeader1Checked=tmpCheckBox.Checked;
			#endif

			#if USE_REFERENCE
				gridHeadCheckboxInitValue=tmpCheckBox.Checked;
			#endif

			DataGrid
				tmpDataGrid=DataGridFull;

			SetDataSource(tmpDataGrid,ds.Tables[TableName]);
			Global.CheckDataGridPageIndex(tmpDataGrid,((DataView)tmpDataGrid.DataSource).Count);
			tmpDataGrid.DataBind();
		}
		//---------------------------------------------------------------------------
	}
}
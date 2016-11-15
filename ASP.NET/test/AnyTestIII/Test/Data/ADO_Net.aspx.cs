using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace AnyTest
{
	public class ADONETForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LabelInit;
		protected System.Web.UI.WebControls.Label LabelLoad;
		protected System.Web.UI.WebControls.DataGrid MyDataGrid;
		protected System.Web.UI.WebControls.TextBox ChangedId;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorChangedId;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorChangedId;
		protected System.Web.UI.WebControls.TextBox Salary;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorSalary;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorSalary;
		protected System.Web.UI.WebControls.Button ButtonSave;
		protected System.Web.UI.WebControls.Label Output;

		private void Page_Init(object sender, System.EventArgs e)
		{
			LabelInit.Text="Page_Init @ "+DateTime.Now.ToLongTimeString();
		}
		
		private void MyPage_Init()
		{
			string
				connstring=ConfigurationSettings.AppSettings["MyConnectionString"];

			if(connstring.Length!=0)
			{
				OleDbConnection
					connection=null;

				try
				{
					connection=new OleDbConnection(connstring);
					connection.Open();

					OleDbCommand
						cmd=new OleDbCommand();

					cmd.Connection=connection;
					cmd.CommandText="select max(id) as max_id from staff";

					object // int ???
						MaxId=cmd.ExecuteScalar();

					RangeValidatorChangedId.MaximumValue=MaxId.ToString();
					RangeValidatorChangedId.ErrorMessage+=" ["+RangeValidatorChangedId.MinimumValue+".."+RangeValidatorChangedId.MaximumValue+"]";

					/*
					int
						Max=100;

					ArrayList
						aConn=new ArrayList();

					for(int i=0; i<Max; ++i)
					{
						connection=new OleDbConnection(connstring);
						connection.Open();
						System.Threading.Thread.Sleep(500);
						aConn.Add(connection);
					}
					*/
				}
				catch (OleDbException eException)
				{
					Output.Text=eException.Message;
				}
				catch(OverflowException eException)
				{
					Output.Text=eException.Message;
				}
				catch(InvalidCastException eException)
				{
					Output.Text=eException.Message;
				}
				catch(FormatException eException)
				{
					Output.Text=eException.Message;
				}
				catch(Exception eException)
				{
					Output.Text=eException.Message;
				}
				finally
				{
					if(connection!=null)
						connection.Close();
				}
			}
		}

		private void bindData()
		{
			string
				connstring=ConfigurationSettings.AppSettings["MyConnectionString"];

			if(connstring.Length!=0)
			{
				OleDbConnection
					connection=null;

				try
				{
					connection=new OleDbConnection(connstring);

					OleDbDataAdapter
						da=new OleDbDataAdapter("select * from staff",connection);

					DataSet
						ds=new DataSet();

					da.Fill(ds);
					if(ViewState["sort"]!=null)
						ds.Tables[0].DefaultView.Sort=(string)ViewState["sort"];
					MyDataGrid.DataSource=ds.Tables[0].DefaultView;
					MyDataGrid.DataBind();
				}
				catch (OleDbException eException)
				{
					Output.Text=eException.Message;
				}
				catch(Exception eException)
				{
					Output.Text=eException.Message;
				}
				finally
				{
					if(connection!=null)
						connection.Close();
				}
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			LabelLoad.Text="Page_Load @ "+DateTime.Now.ToLongTimeString()+" IsPostBack="+IsPostBack;

			if(!IsPostBack)
			{
				try
				{
					MyPage_Init();
					bindData();
				}
				catch(Exception eException)
				{
					Output.Text=eException.Message;
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
			this.MyDataGrid.ItemCreated+=new DataGridItemEventHandler(MyDataGrid_ItemCreated);
			this.MyDataGrid.ItemCommand += new DataGridCommandEventHandler(MyDataGrid_ItemCommand);
			this.MyDataGrid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.MyDataGrid_SortCommand);
			this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void MyDataGrid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			try
			{
				ViewState["sort"]=e.SortExpression;
				foreach(DataGridColumn column in MyDataGrid.Columns)
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
				bindData();
			}
			catch(Exception eException)
			{
				Output.Text=eException.Message;
			}
		}

		private void ButtonSave_Click(object sender, System.EventArgs e)
		{
			if(!RequiredFieldValidatorChangedId.IsValid
				|| !RangeValidatorChangedId.IsValid)
			{
				Output.Text="Invalid Id";

				return;
			}

			if(!RequiredFieldValidatorSalary.IsValid
				|| !RegularExpressionValidatorSalary.IsValid)
			{
				Output.Text="Invalid Salary";

				return;
			}

			string
				connstring=ConfigurationSettings.AppSettings["MyConnectionString"];

			if(connstring.Length!=0)
			{
				OleDbConnection
					connection=null;

				OleDbTransaction
					transaction=null;

				try
				{
					connection=new OleDbConnection(connstring);
					connection.Open();
					transaction=connection.BeginTransaction(IsolationLevel.ReadCommitted);

					OleDbCommand
						cmd=new OleDbCommand();

					cmd.Connection=connection;
					cmd.Transaction=transaction;
					cmd.CommandText="update staff set salary=? where id=?";
					cmd.Parameters.Add("@salary",OleDbType.Currency);
					cmd.Parameters.Add("@id",OleDbType.SmallInt);
					cmd.Parameters["@salary"].Value=Convert.ToDouble(Salary.Text);
					cmd.Parameters["@id"].Value=Convert.ToInt16(ChangedId.Text);
					cmd.ExecuteNonQuery();
					transaction.Commit();
					bindData();
				}
				catch (OleDbException eException)
				{
					if(transaction!=null)
						transaction.Rollback();
					Output.Text=eException.Message;
				}
				catch(OverflowException eException)
				{
					if(transaction!=null)
						transaction.Rollback();
					Output.Text=eException.Message;
				}
				catch(InvalidCastException eException)
				{
					if(transaction!=null)
						transaction.Rollback();
					Output.Text=eException.Message;
				}
				catch(FormatException eException)
				{
					if(transaction!=null)
						transaction.Rollback();
					Output.Text=eException.Message;
				}
				catch(Exception eException)
				{
					if(transaction!=null)
						transaction.Rollback();
					Output.Text=eException.Message;
				}
				finally
				{
					if(connection!=null)
						connection.Close();
				}
			}
		}

		private void MyDataGrid_ItemCommand(object sender, DataGridCommandEventArgs e)
		{
			DataGrid
				dg;

			if((dg=sender as DataGrid)==null)
				return;

			string
				tmpString=string.Empty;

			switch(e.CommandName)
			{
				case "TestImage" :
				{
					if(Convert.ToString(e.CommandArgument)=="SmthCommandArgument")
					{
						if(tmpString!=string.Empty)
							tmpString+=Environment.NewLine;
						tmpString+=e.CommandSource.ToString();

						if(tmpString!=string.Empty)
							tmpString+=Environment.NewLine;
						try
						{
							tmpString+=Convert.ToInt64((e.Item.DataItem as System.Data.DataRowView).Row["ID"]);
						}
						catch(Exception eException)
						{
							tmpString+=eException.GetType().ToString()+": with message \""+eException.Message+"\"";
							if(tmpString!=string.Empty)
								tmpString+=Environment.NewLine;
							tmpString+=e.Item.Cells[0].Text;
						}
					}

					break;
				}
				case "TestText" :
				{
					if(tmpString!=string.Empty)
						tmpString+=Environment.NewLine;

					tmpString=Convert.ToString(e.CommandArgument);

					break;	
				}
			}
		}

		private void MyDataGrid_ItemCreated(object sender, DataGridItemEventArgs e)
		{
			DataGrid
				tmpDataGrid;

			if((tmpDataGrid=sender as DataGrid)==null)
				return;

			CheckBox
				tmpCheckBox;

			if(e.Item.ItemType==ListItemType.Header)
			{
				tmpCheckBox=new CheckBox();
				tmpCheckBox.ID="CheckBoxHeaderNo2";
				tmpCheckBox.Text="CheckBoxHeaderNo2";
				tmpCheckBox.TextAlign=TextAlign.Right;
				tmpCheckBox.AutoPostBack=true;
				e.Item.Cells[1].Controls.Add(tmpCheckBox);
			}
		}
	}
}
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Strict
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter2;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private Strict.DataSet1 dataSet11;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Windows.Forms.Button button1;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDataAdapter2 = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.dataSet11 = new Strict.DataSet1();
			this.button1 = new System.Windows.Forms.Button();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
			this.SuspendLayout();
			// 
			// oleDbDataAdapter1
			// 
			this.oleDbDataAdapter1.DeleteCommand = this.oleDbCommand1;
			this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "TERRITORY", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("TERRITORY_ID", "TERRITORY_ID"),
																																																					 new System.Data.Common.DataColumnMapping("TERRITORY_NAME", "TERRITORY_NAME"),
																																																					 new System.Data.Common.DataColumnMapping("TERRITORY_PARAM_ID", "TERRITORY_PARAM_ID"),
																																																					 new System.Data.Common.DataColumnMapping("RECORD_STATE", "RECORD_STATE"),
																																																					 new System.Data.Common.DataColumnMapping("USER_ID", "USER_ID"),
																																																					 new System.Data.Common.DataColumnMapping("RECORD_MODIFY", "RECORD_MODIFY")})});
			this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO TERRITORY(TERRITORY_ID, TERRITORY_NAME, TERRITORY_PARAM_ID, RECORD_ST" +
				"ATE, USER_ID, RECORD_MODIFY) VALUES (?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "TERRITORY_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_NAME", System.Data.OleDb.OleDbType.VarChar, 50, "TERRITORY_NAME"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_PARAM_ID", System.Data.OleDb.OleDbType.SmallInt, 0, "TERRITORY_PARAM_ID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_STATE", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "RECORD_STATE"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("USER_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "USER_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_MODIFY", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RECORD_MODIFY"));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Raise Error Behavior=MS Compatible;HA Server Name=;Row Cache Size=50;WorkStation ID=;Interfaces File=;Server Name=NOZHENKO;Trusted Root File Name=;TruncateTimeTypeFractions=1;Data Source=DS_Veksel;UseLDAPHAServer=0;Optimize Prepare=Partial;Extended ErrorInfo=FALSE;EnableSPColumnTypes=True;Server Port Address=5000;Enable Quoted Identifiers=0;SybaseServerName=389;Extended Properties=;Network Protocol=Winsock;Initial Catalog=veksel;Interfaces File Server Name=;UseSybaseLDAP=False;Print Statement Behavior=MS Compatible;Password=;Packet Size=1;Language=;User ID=sa;Application Name=;SybaseLDAPURL=;HA Server Port Address=;Default Length For Long Data=1024;Provider=""Sybase.ASEOLEDBProvider.2"";Select Method=Direct;Character Set=;Stored Proc Row Count=Last Statement Only;Use SSL=0";
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT TERRITORY_ID, TERRITORY_NAME, TERRITORY_PARAM_ID, RECORD_STATE, USER_ID, R" +
				"ECORD_MODIFY FROM TERRITORY";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"update territory set territory_id=?, territory_name=?, territory_name=?, territory_param_id=?, record_state=?, user_id=?, record_modify=? where territory_id=? and territory_name=? and  territory_name=? and territory_param_id=? and record_state=? and user_id=? and record_modify=?";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "TERRITORY_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_NAME", System.Data.OleDb.OleDbType.VarChar, 50, "TERRITORY_NAME"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_NAME1", System.Data.OleDb.OleDbType.VarChar, 50, "TERRITORY_NAME"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_PARAM_ID", System.Data.OleDb.OleDbType.SmallInt, 0, "TERRITORY_PARAM_ID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_STATE", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "RECORD_STATE"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("USER_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "USER_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_MODIFY", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RECORD_MODIFY"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TERRITORY_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "TERRITORY_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TERRITORY_NAME", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TERRITORY_NAME", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TERRITORY_NAME1", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TERRITORY_NAME", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_TERRITORY_PARAM_ID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TERRITORY_PARAM_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RECORD_STATE", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RECORD_STATE", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_USER_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "USER_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_RECORD_MODIFY", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RECORD_MODIFY", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDataAdapter2
			// 
			this.oleDbDataAdapter2.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapter2.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "CITY", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("CITY_ID", "CITY_ID"),
																																																				new System.Data.Common.DataColumnMapping("CITY_NAME_ID", "CITY_NAME_ID"),
																																																				new System.Data.Common.DataColumnMapping("COUNTRY_ID", "COUNTRY_ID"),
																																																				new System.Data.Common.DataColumnMapping("AREA_ID", "AREA_ID"),
																																																				new System.Data.Common.DataColumnMapping("REGION_ID", "REGION_ID"),
																																																				new System.Data.Common.DataColumnMapping("PHONE_COD", "PHONE_COD"),
																																																				new System.Data.Common.DataColumnMapping("CITY_TYPE_ID", "CITY_TYPE_ID"),
																																																				new System.Data.Common.DataColumnMapping("RECORD_STATE", "RECORD_STATE"),
																																																				new System.Data.Common.DataColumnMapping("USER_ID", "USER_ID"),
																																																				new System.Data.Common.DataColumnMapping("RECORD_MODIFY", "RECORD_MODIFY")})});
			this.oleDbDataAdapter2.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.oleDbDataAdapter2_RowUpdated);
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO CITY(CITY_ID, CITY_NAME_ID, COUNTRY_ID, AREA_ID, REGION_ID, PHONE_COD" +
				", CITY_TYPE_ID, RECORD_STATE, USER_ID, RECORD_MODIFY) VALUES (?, ?, ?, ?, ?, ?, " +
				"?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CITY_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "CITY_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CITY_NAME_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "CITY_NAME_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("COUNTRY_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "COUNTRY_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("AREA_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "AREA_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("REGION_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "REGION_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("PHONE_COD", System.Data.OleDb.OleDbType.VarChar, 10, "PHONE_COD"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("CITY_TYPE_ID", System.Data.OleDb.OleDbType.SmallInt, 0, "CITY_TYPE_ID"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_STATE", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, "RECORD_STATE"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("USER_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "USER_ID", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_MODIFY", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RECORD_MODIFY"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT CITY_ID, CITY_NAME_ID, COUNTRY_ID, AREA_ID, REGION_ID, PHONE_COD, CITY_TYP" +
				"E_ID, RECORD_STATE, USER_ID, RECORD_MODIFY FROM CITY";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			// 
			// dataSet11
			// 
			this.dataSet11.DataSetName = "DataSet1";
			this.dataSet11.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "delete from territory where territory_id=? and territory_name=? and  territory_na" +
				"me=? and territory_param_id=? and record_state=? and user_id=? and record_modify" +
				"=?";
			this.oleDbCommand1.Connection = this.oleDbConnection1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "TERRITORY_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_NAME", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TERRITORY_NAME", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_NAME1", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TERRITORY_NAME", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("TERRITORY_PARAM_ID", System.Data.OleDb.OleDbType.SmallInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "TERRITORY_PARAM_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_STATE", System.Data.OleDb.OleDbType.UnsignedTinyInt, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RECORD_STATE", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("USER_ID", System.Data.OleDb.OleDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(18)), ((System.Byte)(0)), "USER_ID", System.Data.DataRowVersion.Original, null));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("RECORD_MODIFY", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "RECORD_MODIFY", System.Data.DataRowVersion.Original, null));
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void oleDbDataAdapter2_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
		{
		
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			DataSet1
				ds=new DataSet1();

			DataSet1.TERRITORYDataTable
				tblTerritory=ds.TERRITORY;

			DataSet1.TERRITORYRow
				rowTerritory=tblTerritory.NewTERRITORYRow();

			rowTerritory.TERRITORY_ID=1;
			rowTerritory.TERRITORY_NAME="Украина";
			rowTerritory.TERRITORY_PARAM_ID=0;
			rowTerritory.RECORD_STATE=100;
			rowTerritory.USER_ID=1;
			rowTerritory.RECORD_MODIFY=DateTime.Now;
			tblTerritory.AddTERRITORYRow(rowTerritory);
		}
	}
}

#define WITH_ADD_HANDLER

using System;
using System.Data;

namespace DataTableEvents
{
	/// <summary>
	/// Summary description for CustomDS.
	/// </summary>
	public class CustomDS:DataSet
	{
		public
		#if !WITH_ADD_HANDLER
			static
		#endif
		DataTable
			ChangedTable;

		public CustomDS()
		{
			DataColumn
				col;

			Tables.Add("CustomMasterTable");
			ChangedTable=Tables["CustomMasterTable"];
			col=Tables["CustomMasterTable"].Columns.Add("Id",typeof(int));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			Tables["CustomMasterTable"].Columns.Add("MasterId",typeof(int));
			Tables["CustomMasterTable"].PrimaryKey=new DataColumn[]{Tables["CustomMasterTable"].Columns["Id"]};
		}
		//---------------------------------------------------------------------------

		public
		#if !WITH_ADD_HANDLER
			static
		#endif
		void CascadeTable(object sender, DataColumnChangeEventArgs e)
		{
			if(sender.ToString()!="MasterTable"
				|| e.Column.ColumnName!="Id")
				return;

			int
				tmpId;

			string
				ColumnName="MasterId";

			foreach(DataRow row in ChangedTable.Rows)
				if(Convert.ToInt32(row[ColumnName])==Convert.ToInt32(e.Row[e.Column.ColumnName,DataRowVersion.Current])
					&& Convert.ToInt64(row[ColumnName])!=(tmpId=Convert.ToInt32(e.Row[e.Column.ColumnName])))
					row[ColumnName]=tmpId;
		}
		//---------------------------------------------------------------------------

		#if WITH_ADD_HANDLER
			public void AddCascadeHandler(DataTable tbl)
			{
				tbl.ColumnChanged+=new DataColumnChangeEventHandler(CascadeTable);
			}
			//---------------------------------------------------------------------------

			public void DelCascadeHandler(DataTable tbl)
			{
				tbl.ColumnChanged-=new DataColumnChangeEventHandler(CascadeTable);
			}
			//---------------------------------------------------------------------------
		#endif
	}
}

using System.Data;

namespace DataTableEvents
{
	/// <summary>
	/// Summary description for MainDS.
	/// </summary>
	public class MainDS:DataSet
	{
		public MainDS()
		{
			DataColumn
				col;

			Tables.Add("MasterTable");
			col=Tables["MasterTable"].Columns.Add("Id",typeof(int));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			Tables["MasterTable"].Columns.Add("Value",typeof(int));
			Tables["MasterTable"].PrimaryKey=new DataColumn[]{Tables["MasterTable"].Columns["Id"]};
					
			Tables.Add("DetailTable");
			Tables["DetailTable"].Columns.Add("Id",typeof(int));
			Tables["DetailTable"].Columns.Add("SubId",typeof(int));
			Tables["DetailTable"].Columns.Add("Value",typeof(int));
			Tables["DetailTable"].PrimaryKey=new DataColumn[]{Tables["DetailTable"].Columns["Id"],Tables["DetailTable"].Columns["SubId"]};

			Relations.Add(new DataRelation("Master_Detail",Tables["MasterTable"].Columns["Id"],Tables["DetailTable"].Columns["Id"]));

			Tables.Add("TablesWithPages");
			Tables["TablesWithPages"].Columns.Add("Id",typeof(int));
			Tables["TablesWithPages"].Columns.Add("Name",typeof(int));

			DataRow
				row;

			for(int i=1; i<20; ++i)
			{
				row=Tables["TablesWithPages"].NewRow();
				row["Id"]=i;
				row["Name"]=i;
				Tables["TablesWithPages"].Rows.Add(row);
			}
		}
	}
}

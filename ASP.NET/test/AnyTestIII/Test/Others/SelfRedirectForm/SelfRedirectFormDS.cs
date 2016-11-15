using System.Data;

namespace AnyTest
{
	public class SelfRedirectFormDS:DataSet
	{
		public static string
			TableName="TestTable";

		public SelfRedirectFormDS()
		{
			Tables.Add(TableName);
			
			DataColumn
				col;

			col=Tables[TableName].Columns.Add("Id",typeof(long));
			col.AllowDBNull=false;
			col.Unique=true;
			col.AutoIncrement=true;
			col.AutoIncrementSeed=-1;
			col.AutoIncrementStep=-1;
			Tables[TableName].Columns.Add("Name",typeof(string));
			Tables[TableName].PrimaryKey=new DataColumn[]{Tables[TableName].Columns["Id"]};
		}

		public void FillDataTable(bool Switch)
		{
			DataRow
				row;

			row=Tables[TableName].NewRow();
			row["Id"]=1;
			row["Name"] = Switch ? "Ленин" : "Иванов";
			Tables[TableName].Rows.Add(row);

			row=Tables[TableName].NewRow();
			row["Id"]=2;
			row["Name"] = Switch ? "Сталин" : "Петров";
			Tables[TableName].Rows.Add(row);
			
			row=Tables[TableName].NewRow();
			row["Id"]=3;
			row["Name"] = Switch ? "Хрущев" : "Сидоров";
			Tables[TableName].Rows.Add(row);			
		}
	}
}

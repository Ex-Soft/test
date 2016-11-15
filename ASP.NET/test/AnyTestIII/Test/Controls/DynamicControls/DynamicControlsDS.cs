using System.Data;

namespace AnyTest
{
		public class DynamicControlsDS: DataSet
		{
			public DynamicControlsDS()
			{
				string
					TableName="TestTable";

				DataColumn
					col;

				Tables.Add(TableName);
				col=Tables[TableName].Columns.Add("Id",typeof(long));
				col.AllowDBNull=false;
				col.AutoIncrement=true;
				col.AutoIncrementSeed=1;
				col.AutoIncrementStep=1;
				Tables[TableName].Columns.Add("Description",typeof(string));

				DataRow
					row;

				for(int i=0; i<10; ++i)
				{
					row=Tables[TableName].NewRow();
					row["Description"]="Desc# "+i;
					Tables[TableName].Rows.Add(row);
				}
			}
		}
}
using System.Data;

namespace TwoInOne
{
	class ComboBoxData
	{
		public DataTable
			Info;

		public ComboBoxData()
		{
			Info=new DataTable();

			Info.Columns.Add("Id",typeof(int));
			Info.Columns.Add("Description",typeof(string));

			DataRow
				row;

			row=Info.NewRow();
			row["Id"]=1;
			row["Description"]="Line #1";
			Info.Rows.Add(row);
			row=Info.NewRow();
			row["Id"]=2;
			row["Description"]="Line #2";
			Info.Rows.Add(row);
			row=Info.NewRow();
			row["Id"]=3;
			row["Description"]="Line #3";
			Info.Rows.Add(row);
			row=Info.NewRow();
			row["Id"]=4;
			row["Description"]="Line #4";
			Info.Rows.Add(row);
			row=Info.NewRow();
			row["Id"]=5;
			row["Description"]="Line #5";
			Info.Rows.Add(row);
		}
	}
}
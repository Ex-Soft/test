using System.Data;

namespace Vladsm.Samples.RadioButtonSamples
{
	public class DataSource
	{
		/// <summary>
		/// Generates sample data source.
		/// </summary>
		/// <returns>
		/// DataTable object. Format:
		///		ID (int) - country identifier;
		///		Country (string) - country name;
		///		Capital (string) - capital.
		/// </returns>
		public static DataTable CreateSampleDataSource()
		{
			DataTable dt = new DataTable();
			
			DataColumn idColumn = dt.Columns.Add("ID", typeof(int));
			dt.Columns.Add("Country", typeof(string));
			dt.Columns.Add("Capital", typeof(string));

			dt.PrimaryKey = new DataColumn[] {idColumn};

			dt.Rows.Add(new object[] {1, "USA", "Washington"});
			dt.Rows.Add(new object[] {2, "Canada", "Ottawa"});
			dt.Rows.Add(new object[] {3, "Russia", "Moscow"});
			dt.Rows.Add(new object[] {4, "France", "Paris"});
			dt.Rows.Add(new object[] {5, "Germany", "Berlin"});

			return dt;
		}

	}
}

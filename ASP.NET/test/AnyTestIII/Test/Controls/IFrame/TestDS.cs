using System.Data;

namespace AnyTest
{
		/// <summary>
		/// Summary description for TestDS.
		/// </summary>
		public class TestDS: DataSet
		{
			public const int
				SleepTime=10000;

			public TestDS()
			{
				Tables.Add("TestTable");
				Tables["TestTable"].Columns.Add("MainFormTextBoxInput1",typeof(long));
				Tables["TestTable"].Columns.Add("MainFormTextBoxInput2",typeof(long));
				Tables["TestTable"].Columns.Add("FrameForm1TextBoxInput1",typeof(long));
				Tables["TestTable"].Columns.Add("FrameForm1TextBoxInput2",typeof(long));
				Tables["TestTable"].Columns.Add("FrameForm2TextBoxInput1",typeof(long));
				Tables["TestTable"].Columns.Add("FrameForm2TextBoxInput2",typeof(long));
			}
		}
}
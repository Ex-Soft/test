#define TEST_DUPLICATES
//#define TEST_SERIALIZATION
//#define TEST_NULL
//#define TEST_SELECT
//#define TEST_DATA_SET
//#define TEST_COLUMN_NAME
//#define TEST_SORT
//#define TEST_TO_XML
//#define TEST_EXIST // http://www.sql.ru/forum/actualthread.aspx?tid=896944
//#define TEST_PK
//#define TEST_COPY_BY_LINQ
//#define TEST_COMPUTE
//#define TEST_DELETE
//#define TEST_DBNULL // http://blogs.msdn.com/b/aconrad/archive/2005/02/28/381859.aspx
//#define TEST_FILTER
//#define TEST_DELETE_BY_LINQ
//#define TEST_SELECT_DATE
//#define TEST_LIKE
//#define TEST_CALCULATED_FIELD
//#define TEST_SET_FIELD
//#define TEST_INSERT_AND_MODIFY_WITH_RELATIONS
//#define TEST_RELATIONS
//#define TEST_CHANGE_ROW_VALUE
//#define TEST_COPY_OBJECT
//#define TEST_AUTOINCREMENT
//#define TEST_TWO_DATASET
//#define TEST_INSERT

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ADONET
{
	class Program
    {
        #if TEST_TWO_DATASET
			static DataTable
				TableToCascade=null;
        #endif

        static void Main(string[] args)
		{
		    DataSet
		        tmpDataSet = null;

			DataTable
				tmpDataTable = null,
				tmpDataTableII = null,
				tmpDataTableIII = null,
				tmpDataTableIV = null;

			DataColumn
				tmpDataColumn;

			DataRow
				tmpDataRow;

			DataRow[]
				tmpDataRows;

			int
				i,
				tmpInt;

			long
				tmpLong;

			string
				tmpString,
				FieldName;

			object
				tmpObject;

		    bool
		        tmpBoolean;

		    Type
		        tmpType;

		    TypeCode
		        tmpTypeCode;

			try
			{
                #if TEST_DUPLICATES
                    if (tmpDataTable == null)
                        tmpDataTable = new DataTable();
                    else
                        tmpDataTable.Reset();

                    tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(int));
                    tmpDataColumn.AllowDBNull = false;
                    tmpDataColumn.Unique = true;
                    tmpDataColumn.AutoIncrement = true;
                    tmpDataColumn.AutoIncrementSeed = -1;
                    tmpDataColumn.AutoIncrementStep = -1;
                    tmpDataTable.Columns.Add("F1", typeof(int));
                    tmpDataTable.Columns.Add("F2", typeof(int));
                    tmpDataTable.Columns.Add("F3", typeof(int));
			        tmpDataTable.Columns.Add("F4", typeof(string));
			        tmpDataTable.Columns.Add("F5", typeof(string));
			        tmpDataTable.Columns.Add("F6", typeof(string));
                    tmpDataTable.PrimaryKey = new[] { tmpDataTable.Columns["Id"] };

                    new[] {
                        new object[] {null, 1, 1, 1, "1", "1", "1"},
                        new object[] {null, 1, 1, 2, "2", "2", "2"},
                        new object[] {null, 1, 1, 3, "3", "3", "3"},
                        new object[] {null, 1, 2, 1, "1", "1", "1"},
                        new object[] {null, 1, 2, 2, "2", "2", "2"},
                        new object[] {null, 1, 2, 3, "3", "3", "3" }
                    }.ToList().ForEach(data =>
                        {
                            tmpDataRow = tmpDataTable.NewRow();
                            tmpDataRow.ItemArray = data;
                            tmpDataTable.Rows.Add(tmpDataRow);
                        });

                    for(var ii = 0; ii < 5; ++ii)
                    { 
			            tmpDataRow = tmpDataTable.NewRow();
                        if (ii % 2 == 0)
                            tmpDataRow["F4"] = "";
			            tmpDataTable.Rows.Add(tmpDataRow);
                    }

			        Expression<Func<DataRow, bool>> isRowEmptyExpression = row => (row.IsNull(4) || string.IsNullOrWhiteSpace(Convert.ToString(row[4]))) && row.IsNull(5) && row.IsNull(6);

			        var param = Expression.Parameter(typeof(DataRow), "row");
			        var callIsNull1 = Expression.Call(param, typeof(DataRow).GetMethod("IsNull", new[] {typeof(int)}), Expression.Constant(4));
                    var callGetItem1 = Expression.Call(param, typeof(DataRow).GetProperty("Item", new[] { typeof(int) }).GetGetMethod(), Expression.Constant(4));
			        var members = typeof(Convert).FindMembers(MemberTypes.Method, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, Type.FilterNameIgnoreCase, (object)"ToString");
                    var member = typeof(Convert).GetMethod("ToString", new[] { typeof(object) });
			        var callConvert1 = Expression.Call(member, callGetItem1);
                    members = typeof(string).FindMembers(MemberTypes.Method, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy, Type.FilterNameIgnoreCase, (object)"IsNullOrWhiteSpace");
			        member = typeof(string).GetMethod("IsNullOrWhiteSpace", new[] { typeof(string) });
			        var callIsNullOrWhiteSpace1 = Expression.Call(member, callConvert1);
			        var expression1 = Expression.OrElse(callIsNull1, callIsNullOrWhiteSpace1);
                    var expression2 = Expression.Call(param, typeof(DataRow).GetMethod("IsNull", new[] {typeof(int)}), Expression.Constant(5));
			        var expression3 = Expression.Call(param, typeof(DataRow).GetMethod("IsNull", new[] {typeof(int)}), Expression.Constant(6));
			        var expressionAnd1 = Expression.And(expression1, expression2);
			        var expressionAnd = Expression.And(expressionAnd1, expression3);
                    Console.WriteLine(expressionAnd.ToString());
			        var isRowEmpty = Expression.Lambda<Func<DataRow, bool>>(expressionAnd, new[] { param }).Compile();
                    var emptyRows = tmpDataTable.AsEnumerable().Where(row => isRowEmpty(row)).ToArray();
			        emptyRows = tmpDataTable.AsEnumerable().Where(row => row.IsNull(4) && row.IsNull(5) && row.IsNull(6)).ToArray();

                    tmpDataRow = tmpDataTable.Rows[0];

                    var mi = typeof(string).GetMethod("Format", new[] { typeof(string), typeof(object[]) });
                    var miArgs = new object[] { "F1: \"{0}\" F2:\"{1}\" F3:\"{2}\"", new[] { tmpDataRow["F1"], tmpDataRow["F2"], tmpDataRow["F3"] } };
                    tmpString = mi.Invoke(null, miArgs).ToString();

                    param = Expression.Parameter(typeof(DataRow), "row");
                    var callIsNull = Expression.Not(Expression.Call(param, typeof(DataRow).GetMethod("IsNull", new[] { typeof(string) }), Expression.Constant("F1")));
                    Console.WriteLine(callIsNull.ToString());
			        var fBool = Expression.Lambda<Func<DataRow, bool>>(callIsNull, new[] { param }).Compile();
			        Console.WriteLine("{0}", fBool(tmpDataTable.Rows[0]));

                    var callGetItem = Expression.Call(param, typeof(DataRow).GetProperty("Item", new[] { typeof(string) }).GetGetMethod(), Expression.Constant("F1"));
                    Console.WriteLine(callGetItem.ToString());
                    var fObject = Expression.Lambda<Func<DataRow, object>>(callGetItem, new[] { param }).Compile();
                    Console.WriteLine("{0}", fObject(tmpDataTable.Rows[0]));

			        var arguments = new List<Expression>();
                    
                    new List<string> { "F1", "F2", "F3" }.ForEach(field =>
                    {
                        arguments.Add(Expression.Call(param, typeof(DataRow).GetProperty("Item", new[] { typeof(string) }).GetGetMethod(), Expression.Constant(field)));
                    });

                    var argumants4call = new Expression[] { Expression.Constant("F1:\"{0}\" F2:\"{1}\" F3:\"{2}\""), Expression.NewArrayInit(typeof(object), arguments) };
                    members = typeof(string).FindMembers(MemberTypes.Method, BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.FlattenHierarchy, Type.FilterNameIgnoreCase, (object)"Format");
			        member = typeof(string).GetMethod("Format", new[] { typeof(string), typeof(object[])});
			        var fExprFormat = Expression.Call(member, argumants4call);
                    //var fFormat = Expression.Call(typeof(string), "Format", new[] { typeof(string), typeof(object[]) }, argumants4call);    
                    Console.WriteLine(fExprFormat.ToString());
                    var f = Expression.Lambda<Func<DataRow, string>>(fExprFormat, new[] { param }).Compile();
			        tmpString = f(tmpDataTable.Rows[tmpDataTable.Rows.Count-1]);

                    var groups = tmpDataTable.AsEnumerable().GroupBy(row => row["F1"]);
			        var gr = tmpDataTable.AsEnumerable().GroupBy(row => row["F1"]).Where(g => g.Count() > 1);
			        var keys = tmpDataTable.AsEnumerable().GroupBy(row => row["F1"]).Where(g => g.Count() > 1).Select(g => g.Key);
                    groups = tmpDataTable.AsEnumerable().GroupBy(row => row["F2"]);
                    gr = tmpDataTable.AsEnumerable().GroupBy(row => row["F2"]).Where(g => g.Count() > 1);
                    keys = tmpDataTable.AsEnumerable().GroupBy(row => row["F2"]).Where(g => g.Count() > 1).Select(g => g.Key);
                    groups = tmpDataTable.AsEnumerable().GroupBy(row => row["F3"]);
                    gr = tmpDataTable.AsEnumerable().GroupBy(row => row["F3"]).Where(g => g.Count() > 1);
                    keys = tmpDataTable.AsEnumerable().GroupBy(row => row["F3"]).Where(g => g.Count() > 1).Select(g => g.Key);

                    var mgroups = tmpDataTable.AsEnumerable().GroupBy(row => string.Format("\"{0}\"_\"{1}\"", row["F1"], row["F2"]));
                    var mgr = tmpDataTable.AsEnumerable().GroupBy(row => string.Format("\"{0}\"_\"{1}\"", row["F1"], row["F2"])).Where(g => g.Count() > 1);
                    var mkeys = tmpDataTable.AsEnumerable().GroupBy(row => string.Format("\"{0}\"_\"{1}\"", row["F1"], row["F2"])).Where(g => g.Count() > 1).Select(g => g.Key);

                    var errorMessagesList = new List<string>();

                    if (HasDuplicates(tmpDataTable, CreateKeySelector(tmpDataTable, new List<string> { "F1", "F10" }), errorMessagesList))
                    {
                        var duplicatesKeys = errorMessagesList.Aggregate("", (str, next) =>
                        {
                            if (!string.IsNullOrEmpty(str))
                                str += " ";

                            return str + next;
                        });

                        Console.WriteLine("HasDuplicates({0})", duplicatesKeys);
                    }

                    errorMessagesList.Clear();
                    if (HasDuplicates(tmpDataTable, CreateKeySelector(tmpDataTable, new List<string> { "F10", "F1", "F2"}), errorMessagesList))
                    {
                        var duplicatesKeys = errorMessagesList.Aggregate("", (str, next) =>
                        {
                            if (!string.IsNullOrEmpty(str))
                                str += " ";

                            return str + next;
                        });

                        Console.WriteLine("HasDuplicates({0})", duplicatesKeys);
                    }

                    errorMessagesList.Clear();
                    if (HasDuplicates(tmpDataTable, CreateKeySelector(tmpDataTable, new List<string> { "F1", "F2", "F10", "F3" }), errorMessagesList))
                    {
                        var duplicatesKeys = errorMessagesList.Aggregate("", (str, next) =>
                        {
                            if (!string.IsNullOrEmpty(str))
                                str += " ";

                            return str + next;
                        });

                        Console.WriteLine("HasDuplicates({0})", duplicatesKeys);
                    }
                #endif

				#if TEST_SERIALIZATION
					if(ds==null)
						ds=new DataSet();
					else
						ds.Reset();

					tmpDataTable=ds.Tables.Add("Table1");
					tmpDataTable.Columns.Add("Id",typeof(int));
					tmpDataTable.Columns.Add("Name",typeof(string));
					tmpDataTable=ds.Tables.Add("Table2");
					tmpDataTable.Columns.Add("Id",typeof(int));
					tmpDataTable.Columns.Add("Name",typeof(string));

					tmpDataTable=ds.Tables["Table1"];
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Id"]=1;
					tmpDataRow["Name"]="Иванов Иван Иванович";
					tmpDataTable.Rows.Add(tmpDataRow);
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Id"]=1;
					tmpDataRow["Name"]="Сидоров Сидор Сидорович";
					tmpDataTable.Rows.Add(tmpDataRow);
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Id"]=1;
					tmpDataRow["Name"]="Петров Петр Петрович";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataTable=ds.Tables["Table2"];
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Id"]=1;
					tmpDataRow["Name"]="Ivanov Ivan Ivanovich";
					tmpDataTable.Rows.Add(tmpDataRow);
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Id"]=1;
					tmpDataRow["Name"]="Sidorov Sidor Sidorovich";
					tmpDataTable.Rows.Add(tmpDataRow);
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Id"]=1;
					tmpDataRow["Name"]="Petrov Petr Petrovich";
					tmpDataTable.Rows.Add(tmpDataRow);

					ds.WriteXml("DataSetSerializeByWriteXml");

					FileStream
						fs=new FileStream("DataSetSerializeByFileStream",FileMode.Create);
						
					ds.WriteXml(fs);
					fs.Close();

					BinaryFormatter
						bf=new BinaryFormatter();
						
					tmpDataTable=ds.Tables["Table1"];
					fs=new FileStream(tmpDataTable.TableName,FileMode.Create);
					bf.Serialize(fs,tmpDataTable);
					fs.Close();

					tmpDataTable=ds.Tables["Table2"];
					fs=new FileStream(tmpDataTable.TableName,FileMode.Create);
					bf.Serialize(fs,tmpDataTable);
					fs.Close();

					fs=new FileStream(ds.Tables["Table1"].TableName,FileMode.Open);
					tmpDataTable=(DataTable)bf.Deserialize(fs);
					fs.Close();

					fstr_out.WriteLine(tmpDataTable.TableName);
					foreach(DataRow r in tmpDataTable.Rows)
						fstr_out.WriteLine(Convert.ToInt64(r["Id"])+": "+Convert.ToString(r["Name"]));

					fs=new FileStream(ds.Tables["Table2"].TableName,FileMode.Open);
					tmpDataTable=(DataTable)bf.Deserialize(fs);
					fs.Close();

					fstr_out.WriteLine(tmpDataTable.TableName);
					foreach(DataRow r in tmpDataTable.Rows)
						fstr_out.WriteLine(Convert.ToInt64(r["Id"])+": "+Convert.ToString(r["Name"]));

					DataSet
						dss=new DataSet();

					dss.ReadXml("DataSetSerializeByWriteXml");
					foreach(DataTable t in dss.Tables)
					{
						fstr_out.WriteLine(t.TableName);
						foreach(DataRow r in t.Rows)
							fstr_out.WriteLine(Convert.ToInt64(r["Id"])+": "+Convert.ToString(r["Name"]));
					}
				#endif

                #if TEST_NULL
					if(tmpDataTable==null)
						tmpDataTable=new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn=tmpDataTable.Columns.Add("Id",typeof(int));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					tmpDataTable.Columns.Add("Name",typeof(string));
					tmpDataTable.Columns.Add("BirthDate",typeof(DateTime));
					tmpDataTable.PrimaryKey=new[]{tmpDataTable.Columns["Id"]};

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Ленин Владимир Илльич";
					tmpDataRow["BirthDate"]=new DateTime(1870,04,22);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Сталин Иосиф Виссарионович";
					tmpDataTable.Rows.Add(tmpDataRow);

                    tmpString = string.Format("\"{0}\"", tmpDataRow["BirthDate"]);

                    try
                    {
                        tmpDataRow = tmpDataTable.NewRow();
                        tmpDataRow["Name"] = "Хрущев Никита Сергеевич";
			            tmpDataRow["BirthDate"] = null; // ArgumentException "Невозможно присвоить столбцу \"BirthDate\" пустое значение. Используйте DBNull."
                        tmpDataTable.Rows.Add(tmpDataRow);

                        tmpString = string.Format("\"{0}\"", tmpDataRow["BirthDate"]);
                    }
                    catch(ArgumentException eException)
                    {
                        tmpString = eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace;
                    }

                    tmpDataRow = tmpDataTable.NewRow();
                    tmpDataRow["Name"] = "Брежнев Леонид Ильич";
                    tmpDataRow["BirthDate"] = DBNull.Value;
                    tmpDataTable.Rows.Add(tmpDataRow);

                    tmpString = string.Format("\"{0}\"", tmpDataRow["BirthDate"]);

					tmpDataRows=tmpDataTable.Select("BirthDate is null");
					tmpString=tmpDataRows.Length.ToString();
				#endif

                #if TEST_DATA_SET
                    tmpDataSet = new DataSet("TestDataSet");

                    tmpDataSet.Tables.Add(new DataTable("TestDataTableI"));
                    tmpDataSet.Tables.Add(new DataTable("TestDataTableII"));

                    if((tmpDataTable = tmpDataSet.Tables["TestDataTableI"]) != null)
                    {
                        tmpDataTable.Columns.Add(new DataColumn("TestColumnI"));
                        tmpDataTable.Columns.Add(new DataColumn("TestColumnII"));

                        tmpDataColumn = tmpDataTable.Columns["TestColumnI"];
                        tmpDataColumn = tmpDataTable.Columns["Test_Column"];
                        tmpDataColumn = tmpDataTable.Columns[""];
                        tmpInt = tmpDataTable.Columns.IndexOf("TestColumnII");
                        tmpInt = tmpDataTable.Columns.IndexOf("Test_Column");

                        tmpDataTable.ExtendedProperties.Add("KeyI", "KeyI");
                        tmpDataTable.ExtendedProperties.Add("KeyII", "KeyII");

                        tmpObject = tmpDataTable.ExtendedProperties["KeyI"];
                        tmpObject = tmpDataTable.ExtendedProperties["Key"];
                    }

                    tmpDataTable = tmpDataSet.Tables["Test_Data_Table"];
                    tmpInt = tmpDataSet.Tables.IndexOf("TestDataTableII");
                    tmpInt = tmpDataSet.Tables.IndexOf("Test_Data_Table");
			        tmpString = null;
                    tmpDataTable = tmpDataSet.Tables[tmpString];
                #endif

                #if TEST_COLUMN_NAME
                    tmpDataColumn = new DataColumn("Тест!Тест", typeof(string));
                #endif

                #if TEST_SORT
                    tmpDataTable = getTable();
                    tmpDataTable.DefaultView.Sort = "Salary desc, Name asc";
                    foreach (DataRowView rowView in tmpDataTable.DefaultView)
                    {
                        DataRow row = rowView.Row;

                        Console.WriteLine("{0}\t{1}", row["Name"], row["Salary"]);
                    }
                #endif

                #if TEST_TO_XML
                    tmpDataTable = getTable();
                    tmpDataTable.WriteXml("test.xml");
                #endif

                #if TEST_EXIST
                    if (tmpDataTable == null)
                        tmpDataTable = new DataTable();
                    else
                        tmpDataTable.Reset();

                    tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
                    tmpDataColumn.AllowDBNull = false;
                    tmpDataColumn.Unique = true;
                    tmpDataColumn.AutoIncrement = true;
                    tmpDataColumn.AutoIncrementSeed = -1;
                    tmpDataColumn.AutoIncrementStep = -1;
                    tmpDataTable.Columns.Add("val", typeof(long));

                    if (tmpDataTable.PrimaryKey.Length == 0)
                        tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

                    for(i=0; i<1000; ++i)
                    {
                        tmpDataRow = tmpDataTable.NewRow();
                        tmpDataRow["val"] = i;
                        tmpDataTable.Rows.Add(tmpDataRow);
                    }

                    tmpBoolean = tmpDataTable.Select(string.Format("val={0}", 99)).Length > 0;
                    tmpBoolean = tmpDataTable.AsEnumerable().Where(d => new long[] { 99 }.Contains(d.Field<long>("val"))).Any();
                    tmpBoolean = tmpDataTable.AsEnumerable().Where(d => d.Field<long>("val") == 99).Any();
                #endif

				#if TEST_PK
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
					//tmpDataColumn.AllowDBNull = false;
					//tmpDataColumn.Unique = true;
					//tmpDataColumn.AutoIncrement = true;
					//tmpDataColumn.AutoIncrementSeed = -1;
					//tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add("val", typeof(long));

					if (tmpDataTable.PrimaryKey.Length == 0)
						tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["val"] = 10;
					tmpDataTable.Rows.Add(tmpDataRow);

				#endif

				#if TEST_COPY_BY_LINQ
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataColumn.AutoIncrement = true;
					tmpDataColumn.AutoIncrementSeed = -1;
					tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add("sign", typeof(int));
					tmpDataTable.Columns.Add("val", typeof(decimal));
					tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = 1;
					tmpDataRow["val"] = 10;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = 1;
					tmpDataRow["val"] = 100;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = 1;
					tmpDataRow["val"] = 1000;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = -1;
					tmpDataRow["val"] = -10;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = -1;
					tmpDataRow["val"] = -100;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = -1;
					tmpDataRow["val"] = -1000;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpInt = 1;
					tmpDataTableII = (from t in tmpDataTable.AsEnumerable() where (int)t["sign"] == tmpInt select t).CopyToDataTable();

					tmpInt = -1;
					tmpDataTableIII = (from t in tmpDataTable.AsEnumerable() where (int)t["sign"] == tmpInt select t).CopyToDataTable();

					tmpInt = 13;
					//tmpDataTableIV = (from t in tmpDataTable.AsEnumerable() where (int)t["sign"] == tmpInt select t).CopyToDataTable(); // Exception: The source contains no DataRows
					tmpDataTableIV = (from t in tmpDataTable.AsEnumerable() where (int)t["sign"] == tmpInt select t).AsDataView().ToTable();

					EnumerableRowCollection<DataRow>
						dataRows = from t in tmpDataTable.AsEnumerable() where (int)t["sign"] == tmpInt select t;
						//dataRows = from row in tmpDataTable.AsEnumerable() where row.Field<int>("sign") eq tmpInt select row;

					IEnumerator<DataRow>
						iEnum = dataRows.GetEnumerator();

					if(iEnum.MoveNext())
						tmpDataTableIV=dataRows.CopyToDataTable();
					else
						Console.WriteLine("No data available");

					List<long>
						Vals = new List<long>((from t in tmpDataTable.AsEnumerable() select (long)t["Id"]).AsEnumerable<long>());

					Vals.ForEach((val) => {
						Console.WriteLine(val);
					});
				#endif

				#if TEST_COMPUTE
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(int));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataColumn.AutoIncrement = true;
					tmpDataColumn.AutoIncrementSeed = -1;
					tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add("sign", typeof(int));
					tmpDataTable.Columns.Add("val", typeof(decimal));
					tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = 1;
					tmpDataRow["val"] = 10;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = 1;
					tmpDataRow["val"] = 100;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = 1;
					tmpDataRow["val"] = 1000;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = -1;
					tmpDataRow["val"] = -10;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = -1;
					tmpDataRow["val"] = -100;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["sign"] = -1;
					tmpDataRow["val"] = -1000;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpObject = tmpDataTable.Compute("sum(val)", "(sign=1)");
					tmpDataTable.DefaultView.RowFilter = "(sign=1)";
					tmpObject = tmpDataTable.Compute("sum(val)", "(sign=-1)");
					tmpObject = tmpDataTable.Compute("sum(val)", "(sign=1)");
				#endif

				#if TEST_DELETE
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(int));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataColumn.AutoIncrement = true;
					tmpDataColumn.AutoIncrementSeed = -1;
					tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add("FirstName", typeof(string));
					tmpDataTable.Columns.Add("SurName", typeof(string));
					tmpDataTable.Columns.Add("LastName", typeof(string));
					tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FirstName"] = "Владимир";
					tmpDataRow["SurName"] = "Илльич";
					tmpDataRow["LastName"] = "Ленин";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FirstName"] = "Иосиф";
					tmpDataRow["SurName"] = "Виссарионович";
					tmpDataRow["LastName"] = "Сталин";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FirstName"] = "Никита";
					tmpDataRow["SurName"] = "Сергеевич";
					tmpDataRow["LastName"] = "Хрущев";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpString = tmpDataTable.Rows.Count.ToString(); // 3
					tmpString = tmpDataTable.Select().Length.ToString(); // 3
					tmpString = tmpDataTable.Compute("count(" + tmpDataTable.Columns[0].ColumnName + ")", null).ToString(); // 3
			        tmpString = tmpDataTable.AsEnumerable().Select(row => row).Count().ToString(); // 3
					if ((tmpDataRow = tmpDataTable.Rows.Find(-2)) != null)
						tmpDataRow.Delete();
					tmpString = tmpDataTable.Rows.Count.ToString(); // 2
					tmpString = tmpDataTable.Select().Length.ToString(); // 2
					tmpString = tmpDataTable.Compute("count(" + tmpDataTable.Columns[0].ColumnName + ")", null).ToString(); // 2
                    tmpString = tmpDataTable.AsEnumerable().Select(row => row).Count().ToString(); // 2

					tmpString = string.Empty;
					foreach (DataRow row in tmpDataTable.Rows)
					{
						if (tmpString != string.Empty)
							tmpString += " ";
						tmpString += Convert.ToInt32(row["Id", row.RowState != DataRowState.Deleted ? DataRowVersion.Current : DataRowVersion.Original]); // -1 -3
						if (row.RowState == DataRowState.Deleted)
							tmpString += " (DataRowState.Deleted)";
					}

					tmpDataTable.AcceptChanges();

					//for (i = 0; i < tmpDataTable.Rows.Count; ++i)
					//	tmpDataTable.Rows[i].Delete();

					tmpString = tmpDataTable.Rows.Count.ToString(); // 2
					tmpString = tmpDataTable.Select().Length.ToString(); // 2
					tmpString = tmpDataTable.Compute("count(" + tmpDataTable.Columns[0].ColumnName + ")", null).ToString(); // 2
                    tmpString = tmpDataTable.AsEnumerable().Select(row => row).Count().ToString(); // 2
					if ((tmpDataRow = tmpDataTable.Rows.Find(-3)) != null)
						tmpDataRow.Delete();

					if ((tmpDataRow = tmpDataTable.Rows.Find(-3)) != null) // Not found deleted row
						tmpString = "Found deleted row!!!";

					tmpString = tmpDataTable.Rows.Count.ToString(); // 2 !!!
					tmpString = tmpDataTable.Select().Length.ToString(); // 1
					tmpString = tmpDataTable.Compute("count(" + tmpDataTable.Columns[0].ColumnName + ")", null).ToString(); // 1
                    tmpString = tmpDataTable.AsEnumerable().Select(row => row).Count().ToString(); // 2 !!!

					tmpString = string.Empty;
					foreach (DataRow row in tmpDataTable.Rows)
					{
						if (tmpString != string.Empty)
							tmpString += " ";
						tmpString += Convert.ToInt32(row["Id", row.RowState != DataRowState.Deleted ? DataRowVersion.Current : DataRowVersion.Original]); // -1 -3 (DataRowState.Deleted)
						if (row.RowState == DataRowState.Deleted)
							tmpString += " (DataRowState.Deleted)";
					}

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FirstName"] = "Иосиф";
					tmpDataRow["SurName"] = "Виссарионович";
					tmpDataRow["LastName"] = "Сталин";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FirstName"] = "Никита";
					tmpDataRow["SurName"] = "Сергеевич";
					tmpDataRow["LastName"] = "Хрущев";
					tmpDataTable.Rows.Add(tmpDataRow);

					try
					{
						foreach (DataRow row in tmpDataTable.Rows)
						{
							if (row.RowState == DataRowState.Deleted)
								continue;

							if (Convert.ToInt32(row["Id"]) < -1)
								row.Delete();
						}
					}
					catch (InvalidOperationException eException)
					{
						Console.WriteLine();
						Console.WriteLine("Don't call DataRow.Delete() in foreach(DataRow row in DataTable.Rows)!!!");
						Console.WriteLine();
						Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
					}
				#endif

				#if TEST_DBNULL
			        tmpObject = DBNull.Value;

			        tmpString = tmpObject.ToString();

                    Console.WriteLine("DBNull.Value == DBNull.Value {0}", DBNull.Value == DBNull.Value);

					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					FieldName = "FInt";

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataColumn.AutoIncrement = true;
					tmpDataColumn.AutoIncrementSeed = -1;
					tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add(FieldName, typeof(int));
                    tmpDataTable.Columns.Add("FString", typeof(string));
                    tmpDataTable.Columns.Add("FDateTime", typeof(DateTime));

					tmpDataRow = tmpDataTable.NewRow();
                    tmpType = tmpDataRow[FieldName].GetType(); // System.DBNull
                    tmpTypeCode = Type.GetTypeCode(tmpType); // TypeCode.DBNull
					tmpDataRow[FieldName] = DBNull.Value;
					Console.WriteLine(tmpDataRow[FieldName] == DBNull.Value); // True
					Console.WriteLine(tmpDataRow.IsNull(FieldName)); // True
                    tmpType = tmpDataRow[FieldName].GetType(); // System.DBNull
                    tmpTypeCode = Type.GetTypeCode(tmpType); // TypeCode.DBNull

                    FieldName="FString";
                    if (tmpDataRow.IsNull(FieldName))
                    {
                        try
                        {
                            tmpString = (string)tmpDataRow[FieldName];
                        }
                        catch(InvalidCastException e)
                        {
                            tmpString = string.Empty;
                        }

                        tmpString = "blah-blah-blah";
                        tmpString = Convert.ToString(tmpDataRow[FieldName]);
                    }

                    FieldName="FDateTime";
                    if (tmpDataRow.IsNull(FieldName))
                    {
                        try
                        {
                            tmpString = (string)tmpDataRow[FieldName];
                        }
                        catch (InvalidCastException e)
                        {
                            tmpString = string.Empty;
                        }
                    }
					tmpDataTable.Rows.Add(tmpDataRow);
				#endif

				#if TEST_FILTER
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(int));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataTable.Columns.Add("Val", typeof(int));
					tmpDataTable.PrimaryKey = new[] { tmpDataTable.Columns["Id"] };

					for (i = 0; i < 10; ++i)
					{
						tmpDataRow = tmpDataTable.NewRow();
						tmpDataRow["Id"] = i;
						if (i % 2 == 1)
							tmpDataRow["Val"] = i; //DBNull.Value;
						tmpDataTable.Rows.Add(tmpDataRow);
					}

					tmpDataTable.AcceptChanges();

					tmpDataTable.DefaultView.RowFilter = "Id>5";
					i = tmpDataTable.Rows.Count;
					i = tmpDataTable.DefaultView.Count;
					foreach (DataRowView r in tmpDataTable.DefaultView)
						Console.WriteLine(r.Row["Id"].ToString());

					tmpDataTable.DefaultView.RowFilter = "(Id>5) and (Val is not null)";
					i = tmpDataTable.Rows.Count;
					i = tmpDataTable.DefaultView.Count;
					foreach (DataRowView r in tmpDataTable.DefaultView)
						Console.WriteLine(r.Row["Id"].ToString());

                    tmpDataTableII = tmpDataTable.DefaultView.ToTable(false, "Id");
				#endif

				#if TEST_DELETE_BY_LINQ
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					if (tmpDataTableII == null)
						tmpDataTableII = new DataTable();
					else
						tmpDataTableII.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(int));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns["Id"] };

					tmpDataColumn = tmpDataTableII.Columns.Add("Id", typeof(int));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataTableII.PrimaryKey = new DataColumn[] { tmpDataTableII.Columns["Id"] };

					for (i = 0; i < 10; ++i)
					{
						tmpDataRow = tmpDataTable.NewRow();
						tmpDataRow["Id"] = i;
						tmpDataTable.Rows.Add(tmpDataRow);
					}

					tmpDataRow = tmpDataTableII.NewRow();
					tmpDataRow["Id"] = 5;
					tmpDataTableII.Rows.Add(tmpDataRow);

					tmpDataTableIII = (from q1 in tmpDataTable.AsEnumerable()
									   join q2 in tmpDataTableII.AsEnumerable() on q1.Field<int>("Id") equals q2.Field<int>("Id")
									   select q1).CopyToDataTable();

					tmpDataTableIV = tmpDataTable.AsEnumerable().Join(tmpDataTableII.AsEnumerable(), p => p["Id"], c => c["Id"], (x, y) => x).CopyToDataTable();
				#endif

				#if TEST_SELECT
                    if(tmpDataTable==null)
						tmpDataTable=new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn=tmpDataTable.Columns.Add("Id",typeof(int));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					tmpDataTable.Columns.Add("Name",typeof(string));
					tmpDataTable.Columns.Add("BirthDate", typeof(DateTime));
					tmpDataTable.PrimaryKey=new DataColumn[]{tmpDataTable.Columns["Id"]};

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Ленин Владимир Илльич";
					tmpDataRow["BirthDate"]=new DateTime(1870,4,22);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Ленин Владимир Илльич";
					tmpDataRow["BirthDate"]=new DateTime(1870,4,22);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Сталин Иосиф Виссарионович";
					tmpDataRow["BirthDate"]=new DateTime(1878, 12, 18);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRows=tmpDataTable.Select();
					tmpString=tmpDataRows.Length.ToString();

					//tmpDataRows=tmpDataTable.Select("where 1=1");

					tmpDataRows=tmpDataTable.Select("BirthDate=#"+new DateTime(1870,4,22).ToString(CultureInfo.InvariantCulture)+"#");
					tmpDataRows=tmpDataTable.Select(string.Format(CultureInfo.InvariantCulture.DateTimeFormat,"BirthDate=#{0}#",new DateTime(1878,12,18)));

					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataColumn.AutoIncrement = true;
					tmpDataColumn.AutoIncrementSeed = -1;
					tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add("Val1", typeof(decimal));
					tmpDataTable.Columns.Add("Val2", typeof(decimal));
					tmpDataTable.Columns.Add("Val3", typeof(decimal));
                    tmpDataTable.Columns.Add("One Two", typeof(decimal));

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["Val1"] = 1;
					tmpDataRow["Val2"] = 2;
					tmpDataRow["Val3"] = 3;
			        tmpDataRow["One Two"] = 12;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["Val1"] = 1;
					tmpDataRow["Val2"] = 2;
					tmpDataRow["Val3"] = 0;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["Val1"] = 1;
					tmpDataRow["Val2"] = 2;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["Val1"] = 1;
					tmpDataRow["Val3"] = 3;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["Val1"] = 1;
					tmpDataRow["Val3"] = 0;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["Val1"] = 1;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRows = tmpDataTable.Select("((Val1-Val2)<0) and ((Val3 is null) or (Val3=0))");
                    tmpDataRows = tmpDataTable.Select(string.Format("[{0}] = {1}", "One Two", 12));

                    tmpDataRow = tmpDataTable.AsEnumerable().FirstOrDefault(row => Convert.ToDecimal(row["Val1"]) == 1);
                    tmpDataRow = tmpDataTable.AsEnumerable().FirstOrDefault(row => Convert.ToDecimal(row["Val1"]) == 10);

                    tmpDataRows = tmpDataTable.AsEnumerable().Where(row => Convert.ToDecimal(row["Val1"]) == 1).ToArray();
                    tmpDataRows = tmpDataTable.AsEnumerable().Where(row => Convert.ToDecimal(row["Val1"]) == 10).ToArray();
				#endif

				#if TEST_SELECT_DATE
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataColumn.AutoIncrement = true;
					tmpDataColumn.AutoIncrementSeed = -1;
					tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add("FDate", typeof(DateTime));

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FDate"] = new DateTime(2004, 12, 31, 23, 59, 59);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FDate"] = new DateTime(2005, 1, 1);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FDate"] = new DateTime(2005, 1, 1, 12, 0, 0);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FDate"] = new DateTime(2005, 1, 1, 23, 59, 59);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FDate"] = new DateTime(2005, 1, 2);
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpString = string.Format(CultureInfo.InvariantCulture.DateTimeFormat, "(FDate>=#{0}#) and (FDate<=#{1}#)", new DateTime(2005, 1, 1), new DateTime(2005, 1, 1, 23, 59, 59));
					tmpDataRows = tmpDataTable.Select(tmpString);
				#endif

   				#if TEST_LIKE
					if (tmpDataTable == null)
						tmpDataTable = new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn = tmpDataTable.Columns.Add("Id", typeof(long));
					tmpDataColumn.AllowDBNull = false;
					tmpDataColumn.Unique = true;
					tmpDataColumn.AutoIncrement = true;
					tmpDataColumn.AutoIncrementSeed = -1;
					tmpDataColumn.AutoIncrementStep = -1;
					tmpDataTable.Columns.Add("FString", typeof(string));

					tmpDataRow = tmpDataTable.NewRow();
					tmpDataRow["FString"] = "Новая";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow = tmpDataTable.NewRow();
                    tmpDataRow["FString"] = "Новая линия";
					tmpDataTable.Rows.Add(tmpDataRow);

                    tmpString = string.Format(CultureInfo.InvariantCulture.DateTimeFormat, "FString like '{0}%'", "Новая");
					tmpDataRows = tmpDataTable.Select(tmpString);
				#endif

                #if TEST_CALCULATED_FIELD
					if(tmpDataTable==null)
						tmpDataTable=new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataTable.Columns.Add("FirstName",typeof(string));
					tmpDataTable.Columns.Add("SurName",typeof(string));
					tmpDataTable.Columns.Add("LastName",typeof(string));
					tmpDataTable.Columns.Add("NameWithInitials",typeof(string),"LastName+' '+substring(FirstName,1,1)+'. '+substring(SurName,1,1)+'.'");
					tmpDataTable.Columns.Add("BirthDate",typeof(DateTime));
					//tmpDataTable.Columns.Add("BirthTime",typeof(TimeSpan),"convert(BirthDate,'System.TimeSpan')"); // TimeSpan can be coerced to and from String and itself only.
					tmpDataTable.Columns.Add("NowDate",typeof(DateTime));
					//tmpDataTable.Columns.Add("Age",typeof(double),"NowDate-isnull(BirthDate,0)");
					//tmpDataTable.Columns.Add("Age",typeof(double),"convert(NowDate,'System.Double')-convert(isnull(BirthDate,0),'System.Double')");
					tmpDataTable.Columns.Add("Field1",typeof(decimal));
					tmpDataTable.Columns.Add("Field2",typeof(decimal));
					tmpDataTable.Columns.Add("FieldSum1",typeof(decimal),"iif(Field1 is not null,Field1,Field2)");
					tmpDataTable.Columns.Add("FieldSum2",typeof(decimal),"isnull(Field1,Field2)");
						
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["FirstName"]="Владимир";
					tmpDataRow["SurName"]="Илльич";
					tmpDataRow["LastName"]="Ленин";
					tmpDataRow["BirthDate"]=new DateTime(1870,04,22);
					tmpDataRow["NowDate"]=DateTime.Now;
					//tmpDataRow["Field1"]=1;
					//tmpDataRow["Field2"]=2;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpString=Convert.ToString(tmpDataTable.Rows[0]["NameWithInitials"]);
					tmpString=Convert.ToString(tmpDataTable.Rows[0]["FieldSum1"]);
					tmpString=Convert.ToString(tmpDataTable.Rows[0]["FieldSum2"]);
					//tmpString=Convert.ToString(tmpDataTable.Rows[0]["Age"]);
				#endif

				#if TEST_SET_FIELD
					if(ds==null)
						ds=new DataSet();
					else
						ds.Reset();

					tmpDataTable=ds.Tables.Add("TestTableForTestSetField");
					tmpDataTable.Columns.Add("FByte",typeof(byte)); // 0
					tmpDataTable.Columns.Add("FInt16",typeof(short)); // 1
					tmpDataTable.Columns.Add("FInt32",typeof(int)); // 2
					tmpDataTable.Columns.Add("FInt64",typeof(long)); // 3
					tmpDataTable.Columns.Add("FFloat",typeof(float)); // 4
					tmpDataTable.Columns.Add("FDouble",typeof(double)); // 5
					tmpDataTable.Columns.Add("FDecimal",typeof(decimal)); // 6
					tmpDataTable.Columns.Add("FDateTime",typeof(string)); // 7
					tmpDataTable.Columns.Add("FChar",typeof(char)); // 8
					tmpDataTable.Columns.Add("FString",typeof(string)); // 9
					tmpDataTable.Columns.Add("FBoolean",typeof(bool)); // 10
					tmpDataTable.Columns.Add("FSByte",typeof(sbyte)); // 11
					tmpDataTable.Columns.Add("FUInt16",typeof(ushort)); // 12
					tmpDataTable.Columns.Add("FUInt32",typeof(uint)); // 13
					tmpDataTable.Columns.Add("FUInt64",typeof(ulong)); // 14

					tmpDataRow=tmpDataTable.NewRow();
					SetField(tmpDataRow,"FByte",1);
					tmpDataTable.Rows.Add(tmpDataRow);
					SetField(tmpDataRow,"FByte",1);
					SetField(tmpDataRow,"FByte",2);
					SetField(tmpDataRow,"FInt16",DBNull.Value);
					SetField(tmpDataRow,"FInt16",DBNull.Value,true);
					SetField(tmpDataRow,"FInt16",1);
					SetField(tmpDataRow,"FInt16",DBNull.Value);
					SetField(tmpDataRow,"FInt16",DBNull.Value,true);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataTable.Rows.Add(tmpDataRow);
					EqualsDataField(tmpDataTable.Rows[0],"FByte",tmpDataRow,"FByte");
					SetField(tmpDataRow,"FByte",1);
					EqualsDataField(tmpDataTable.Rows[0],"FByte",tmpDataRow,"FByte");
					SetField(tmpDataRow,"FByte",2);
					EqualsDataField(tmpDataTable.Rows[0],"FByte",tmpDataRow,"FByte");

					ds.Reset();
				#endif

				#if TEST_INSERT_AND_MODIFY_WITH_RELATIONS
					if(ds==null)
						ds=new DataSet();

					#region Create MasterTable
						tmpString="MasterTable";
						ds.Tables.Add(tmpString);
						tmpDataColumn=ds.Tables[tmpString].Columns.Add("Id",typeof(long));
						tmpDataColumn.AllowDBNull=false;
						tmpDataColumn.Unique=true;
						tmpDataColumn.AutoIncrement=true;
						tmpDataColumn.AutoIncrementSeed=-1;
						tmpDataColumn.AutoIncrementStep=-1;
						ds.Tables[tmpString].Columns.Add("Department",typeof(string));
						ds.Tables[tmpString].PrimaryKey=new DataColumn[]{ds.Tables[tmpString].Columns["Id"]};
					#endregion

					#region Create DetailsTable
						tmpString="DetailsTable";
						ds.Tables.Add(tmpString);
						tmpDataColumn=ds.Tables[tmpString].Columns.Add("DepartmentId",typeof(long));
						tmpDataColumn.AllowDBNull=false;
						tmpDataColumn=ds.Tables[tmpString].Columns.Add("Id",typeof(long));
						tmpDataColumn.AllowDBNull=false;
						tmpDataColumn.Unique=true;
						tmpDataColumn.AutoIncrement=true;
						tmpDataColumn.AutoIncrementSeed=-1;
						tmpDataColumn.AutoIncrementStep=-1;
						ds.Tables[tmpString].Columns.Add("Name",typeof(string));
						ds.Tables[tmpString].Columns.Add("Sum",typeof(decimal));
						ds.Tables[tmpString].PrimaryKey=new DataColumn[]{ds.Tables[tmpString].Columns["DepartmentId"],ds.Tables[tmpString].Columns["Id"]};
					#endregion

					#region Fill MasterTable
						tmpString="MasterTable";

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["Id"]=1;
						tmpDataRow["Department"]="USSR";
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["Id"]=2;
						tmpDataRow["Department"]="Ukraine";
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						ds.Tables[tmpString].AcceptChanges();
					#endregion

					#region Fill DetailsTable
						tmpString="DetailsTable";

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["DepartmentId"]=1;
						tmpDataRow["Name"]="Ленин";
						tmpDataRow["Sum"]=1;
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["DepartmentId"]=1;
						tmpDataRow["Name"]="Сталин";
						tmpDataRow["Sum"]=11;
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["DepartmentId"]=1;
						tmpDataRow["Name"]="Хрущев";
						tmpDataRow["Sum"]=111;
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["DepartmentId"]=2;
						tmpDataRow["Name"]="Кравчук";
						tmpDataRow["Sum"]=1;
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["DepartmentId"]=2;
						tmpDataRow["Name"]="Кучма";
						tmpDataRow["Sum"]=11;
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						tmpDataRow=ds.Tables[tmpString].NewRow();
						tmpDataRow["DepartmentId"]=2;
						tmpDataRow["Name"]="Ющенко";
						tmpDataRow["Sum"]=111;
						ds.Tables[tmpString].Rows.Add(tmpDataRow);

						ds.Tables[tmpString].AcceptChanges();
					#endregion

					RelationName="Master_Details";

					if(!ds.Tables[tmpString].Constraints.Contains("fk"+RelationName))
						ds.Tables[tmpString].Constraints.Add(new ForeignKeyConstraint("fk"+RelationName,ds.Tables["MasterTable"].Columns["Id"],ds.Tables[tmpString].Columns["DepartmentId"]));
					if(!ds.Relations.Contains(RelationName))
						ds.Relations.Add(new DataRelation(RelationName,ds.Tables["MasterTable"].Columns["Id"],ds.Tables[tmpString].Columns["DepartmentId"]));

					tmpString="DetailsTable";
					ds.Tables[tmpString].Columns.Add("Department",typeof(string),"Parent("+RelationName+").Department");
					tmpString="MasterTable";
					ds.Tables[tmpString].Columns.Add("Sum",typeof(decimal),"Sum(Child("+RelationName+").Sum)");

					foreach(DataRow row in ds.Tables[tmpString].Rows)
					{
						fstr_out.WriteLine("{0} {1} {2}",!row.IsNull("Id") ? row["Id"] : "NULL",!row.IsNull("Department") ? row["Department"] : "NULL",!row.IsNull("Sum") ? row["Sum"] : "NULL");
						tmpDataRows=row.GetChildRows(RelationName);
						foreach(DataRow rr in tmpDataRows)
							fstr_out.WriteLine("\t{0} {1} {2} {3}",!rr.IsNull("DepartmentId") ? rr["DepartmentId"] : "NULL",!rr.IsNull("Id") ? rr["Id"] : "NULL",!rr.IsNull("Name") ? rr["Name"] : "NULL",!rr.IsNull("Sum") ? rr["Sum"] : "NULL");
					}
					fstr_out.WriteLine();

					#region Insert/Edit DetailsTable
						tmpString="DetailsTable";

						#region Not necessarily
							fstr_out.Write("Edit exists row in details table (Find (1, -2))... ");
							if((tmpDataRow=ds.Tables[tmpString].Rows.Find(new object[]{1,-2}))!=null)
							{
								tmpDataRow["Name"]="Сталин Иосиф Виссарионович (edit by find)";
								tmpDataRow["Sum"]=111111;
							}
							fstr_out.WriteLine("oB!");
						#endregion

						// Insert
						fstr_out.Write("Insert new row in details table (Find (1, -7))... ");
						if((tmpDataRow=ds.Tables[tmpString].Rows.Find(new object[]{1,-7}))==null)
						{
							tmpDataRow=ds.Tables[tmpString].NewRow();
							tmpDataRow["DepartmentId"]=1;
							tmpDataRow["Name"]="Брежнев (insert by find)";
							tmpDataRow["Sum"]=1111;
							ds.Tables[tmpString].Rows.Add(tmpDataRow);
						}
						fstr_out.WriteLine("oB!");

						// Edit
						fstr_out.Write("Edit exists row in details table (Find (1, -1))... ");
						if((tmpDataRow=ds.Tables[tmpString].Rows.Find(new object[]{1,-1}))!=null)
						{
							tmpDataRow["Name"]="Ленин Владимир Ильич (edit by find)"; // FW 1.1. System.Data.VersionNotFoundException Message: There is no Original data to access.
							tmpDataRow["Sum"]=11111;
						}
						fstr_out.WriteLine("oB!");

						fstr_out.Write("Edit exists row in master table (Select (2, -5))... ");
						tmpDataRows=ds.Tables[tmpString].Select("(DepartmentId=2) and (Id=-5)");
						if(tmpDataRows.Length>0)
						{
							tmpDataRow=tmpDataRows[0];
							tmpDataRow["Name"]="Кучма Леонид Данилович (edit by select)";
							tmpDataRow["Sum"]=11111;
						}
						fstr_out.WriteLine("oB!");

						fstr_out.Write("Insert new row in details table (Select (1, -8))... ");
						tmpDataRows=ds.Tables[tmpString].Select("(DepartmentId=1) and (Id=-8)");
						if(tmpDataRows.Length==0)
						{
							tmpDataRow=ds.Tables[tmpString].NewRow();
							tmpDataRow["DepartmentId"]=1;
							tmpDataRow["Name"]="Андропов (insert by select)";
							tmpDataRow["Sum"]=1111111;
							ds.Tables[tmpString].Rows.Add(tmpDataRow);
						}
						fstr_out.WriteLine("oB!");

						fstr_out.Write("Edit exists row in master table (Select (2, -4))... ");
						tmpDataRows=ds.Tables[tmpString].Select("(DepartmentId=2) and (Id=-4)");
						if(tmpDataRows.Length>0)
						{
							tmpDataRow=tmpDataRows[0];
							tmpDataRow["Name"]="Кравчук Леонид Макарович (edit by select)";
							tmpDataRow["Sum"]=1111;
						}
						fstr_out.WriteLine("oB!");

						tmpString="MasterTable";
						fstr_out.WriteLine();
						foreach(DataRow row in ds.Tables[tmpString].Rows)
						{
							fstr_out.WriteLine("{0} {1} {2}",!row.IsNull("Id") ? row["Id"] : "NULL",!row.IsNull("Department") ? row["Department"] : "NULL",!row.IsNull("Sum") ? row["Sum"] : "NULL");
							tmpDataRows=row.GetChildRows(RelationName);
							foreach(DataRow rr in tmpDataRows)
								fstr_out.WriteLine("\t{0} {1} {2} {3}",!rr.IsNull("DepartmentId") ? rr["DepartmentId"] : "NULL",!rr.IsNull("Id") ? rr["Id"] : "NULL",!rr.IsNull("Name") ? rr["Name"] : "NULL",!rr.IsNull("Sum") ? rr["Sum"] : "NULL");
						}
						fstr_out.WriteLine();
					#endregion

					ds.Reset();
				#endif

                #if TEST_RELATIONS
					if(ds==null)
						ds=new DataSet();

					tmpString="MasterTable";
					ds.Tables.Add(tmpString);
					tmpDataColumn=ds.Tables[tmpString].Columns.Add("Id",typeof(long));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					ds.Tables[tmpString].Columns.Add("Name",typeof(string));
					ds.Tables[tmpString].PrimaryKey=new DataColumn[]{ds.Tables[tmpString].Columns["Id"]};

					tmpString="DetailsTable";
					ds.Tables.Add(tmpString);
					tmpDataColumn=ds.Tables[tmpString].Columns.Add("Id",typeof(long));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					ds.Tables[tmpString].Columns.Add("MasterId",typeof(long));
					ds.Tables[tmpString].Columns.Add("Sum",typeof(decimal));
					ds.Tables[tmpString].PrimaryKey=new DataColumn[]{ds.Tables[tmpString].Columns["Id"],ds.Tables[tmpString].Columns["MasterId"]};

					RelationName="Master_Details";
							
					ForeignKeyConstraint
						_fk_;

					ds.Tables[tmpString].Constraints.Add(_fk_=new ForeignKeyConstraint("fk"+RelationName,ds.Tables["MasterTable"].Columns["Id"],ds.Tables["DetailsTable"].Columns["MasterId"]));
					_fk_.UpdateRule=Rule.Cascade;
					_fk_.DeleteRule=Rule.Cascade;
					ds.Relations.Add(RelationName,ds.Tables["MasterTable"].Columns["Id"],ds.Tables["DetailsTable"].Columns["MasterId"]);
					tmpString="MasterTable";
					ds.Tables[tmpString].Columns.Add("TotalSum",typeof(decimal),"Sum(Child("+RelationName+").Sum)");

					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["Name"]="Ленин";
					ds.Tables[tmpString].Rows.Add(tmpDataRow);

					tmpLong=Convert.ToInt64(tmpDataRow["Id"]);

					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=1m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=11m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=111m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);

					//ds.Tables[tmpString].Clear();
					// EQU
					//ds.Tables[tmpString].Rows.Clear();

					tmpString="MasterTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["Name"]="Сталин";
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpLong=Convert.ToInt64(tmpDataRow["Id"]);

					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=2m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=22m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=222m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);

					tmpString="MasterTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpObject=null;
					tmpDataRow["Name"]=tmpObject;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpLong=Convert.ToInt64(tmpDataRow["Id"]);

					tmpString="DetailsTable";

					int
						CharFillLength=80;

					foreach(DataRow row in ds.Tables["MasterTable"].Rows)
					{
						fstr_out.WriteLine("{0} {1} {2}",!row.IsNull("Id") ? Convert.ToString(Convert.ToInt64(row["Id"])) : "NULL",!row.IsNull("Name") ? Convert.ToString(row["Name"]) : "NULL",!row.IsNull("TotalSum") ? Convert.ToString(Convert.ToDecimal(row["TotalSum"])) : "NULL");
						foreach(DataRow r in ds.Tables["DetailsTable"].Rows)
						{
							if(Convert.ToInt64(row["Id"])!=Convert.ToInt64(r["MasterId"]))
								continue;
							fstr_out.WriteLine("\t{0} {1} {2}",Convert.ToInt64(r["Id"]),Convert.ToInt64(r["MasterId"]),Convert.ToDecimal(r["Sum"]));
						}
					}
					fstr_out.WriteLine(new string('-',CharFillLength));
					fstr_out.WriteLine();

					ds.Tables["MasterTable"].Rows[0]["Id"]=13;
					// !!!
					// Especially 4 NET 1.x
					ds.Tables["MasterTable"].Columns["TotalSum"].Expression="Sum(Child("+RelationName+").Sum)";
					// !!!
					foreach(DataRow row in ds.Tables["MasterTable"].Rows)
					{
						fstr_out.WriteLine("{0} {1} {2}",!row.IsNull("Id") ? Convert.ToString(Convert.ToInt64(row["Id"])) : "NULL",!row.IsNull("Name") ? Convert.ToString(row["Name"]) : "NULL",!row.IsNull("TotalSum") ? Convert.ToString(Convert.ToDecimal(row["TotalSum"])) : "NULL");
						foreach(DataRow r in ds.Tables["DetailsTable"].Rows)
						{
							if(Convert.ToInt64(row["Id"])!=Convert.ToInt64(r["MasterId"]))
								continue;
							fstr_out.WriteLine("\t{0} {1} {2}",Convert.ToInt64(r["Id"]),Convert.ToInt64(r["MasterId"]),Convert.ToDecimal(r["Sum"]));
						}
					}
					fstr_out.WriteLine(new string('-',CharFillLength));
					fstr_out.WriteLine();

					if(ds.Tables["MasterTable"].Columns.Contains("TotalSum"))
					{
						if(ds.Tables["MasterTable"].Columns.CanRemove(ds.Tables["MasterTable"].Columns["TotalSum"]))
							ds.Tables["MasterTable"].Columns.Remove("TotalSum");
					}

					if(ds.Relations.Contains(RelationName))
					{
						if(ds.Relations.CanRemove(ds.Relations[RelationName]))
						{
							ds.Relations.Remove(RelationName);
							if(ds.Tables[tmpString].Constraints.Contains("fk"+RelationName))
							{
								if(ds.Tables[tmpString].Constraints.CanRemove(ds.Tables[tmpString].Constraints["fk"+RelationName]))
									ds.Tables[tmpString].Constraints.Remove("fk"+RelationName);
							}
						}
					}

					ds.Tables["MasterTable"].Rows[1]["Id"]=9;

					tmpLong=-3;
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=3m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=33m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);
					tmpString="DetailsTable";
					tmpDataRow=ds.Tables[tmpString].NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=333m;
					ds.Tables[tmpString].Rows.Add(tmpDataRow);

					foreach(DataRow row in ds.Tables["MasterTable"].Rows)
					{
						fstr_out.WriteLine("{0} {1}",!row.IsNull("Id") ? Convert.ToString(Convert.ToInt64(row["Id"])) : "NULL",!row.IsNull("Name") ? Convert.ToString(row["Name"]) : "NULL");
						foreach(DataRow r in ds.Tables["DetailsTable"].Rows)
							fstr_out.WriteLine("\t{0} {1} {2}",Convert.ToInt64(r["Id"]),Convert.ToInt64(r["MasterId"]),Convert.ToDecimal(r["Sum"]));
					}
					fstr_out.WriteLine(new string('-',CharFillLength));
					fstr_out.WriteLine();

					ds.Reset();
						
					TableName="Clients";
					ds.Tables.Add(TableName);
					tmpDataColumn=ds.Tables[TableName].Columns.Add("Id",typeof(long));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					ds.Tables[TableName].Columns.Add("Name",typeof(string));
					ds.Tables[TableName].PrimaryKey=new DataColumn[]{ds.Tables[TableName].Columns["Id"]};

					TableName="SmthTable";
					ds.Tables.Add(TableName);
					tmpDataColumn=ds.Tables[TableName].Columns.Add("Id",typeof(long));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					ds.Tables[TableName].Columns.Add("Id_Client",typeof(long));
					ds.Relations.Add(RelationName="Clients_SmthTable",ds.Tables["Clients"].Columns["Id"],ds.Tables["SmthTable"].Columns["Id_Client"]);
					ds.Tables[TableName].Columns.Add("Name_Client",typeof(string),"Parent("+RelationName+").Name");

					TableName="Clients";
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Name"]="Ленин";
					ds.Tables[TableName].Rows.Add(tmpDataRow);
					tmpLong=Convert.ToInt64(tmpDataRow["Id"]);

					TableName="SmthTable";
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Id_Client"]=tmpLong;
					ds.Tables[TableName].Rows.Add(tmpDataRow);
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Id_Client"]=tmpLong;
					ds.Tables[TableName].Rows.Add(tmpDataRow);
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Id_Client"]=tmpLong;
					ds.Tables[TableName].Rows.Add(tmpDataRow);

					TableName="Clients";
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Name"]="Сталин";
					ds.Tables[TableName].Rows.Add(tmpDataRow);
					tmpLong=Convert.ToInt64(tmpDataRow["Id"]);

					TableName="SmthTable";
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Id_Client"]=tmpLong;
					ds.Tables[TableName].Rows.Add(tmpDataRow);
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Id_Client"]=tmpLong;
					ds.Tables[TableName].Rows.Add(tmpDataRow);
					tmpDataRow=ds.Tables[TableName].NewRow();
					tmpDataRow["Id_Client"]=tmpLong;
					ds.Tables[TableName].Rows.Add(tmpDataRow);

					tmpString=string.Empty;
					foreach(DataRow r in ds.Tables["SmthTable"].Rows)
					{
						if(tmpString!=string.Empty)
							tmpString+=Environment.NewLine;

						tmpString+=Convert.ToInt64(r["Id"])+" "+Convert.ToInt64(r["Id_Client"])+" "+Convert.ToString(r["Name_Client"]);
					}

					ds.Reset();

					TableName="MasterTable";
					ds.Tables.Add(TableName);
					tmpDataColumn=ds.Tables[TableName].Columns.Add("Id",typeof(long));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					ds.Tables[TableName].Columns.Add("Name",typeof(string));
					ds.Tables[TableName].PrimaryKey=new DataColumn[]{ds.Tables[TableName].Columns["Id"]};

					TableName="DetailsTable";
					ds.Tables.Add(TableName);
					tmpDataColumn=ds.Tables[TableName].Columns.Add("Id",typeof(long));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.Unique=true;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=-1;
					tmpDataColumn.AutoIncrementStep=-1;
					ds.Tables[TableName].Columns.Add("MasterId",typeof(long));
					ds.Tables[TableName].Columns.Add("Sum",typeof(decimal));
					ds.Tables[TableName].PrimaryKey=new DataColumn[]{ds.Tables[TableName].Columns["Id"],ds.Tables[TableName].Columns["MasterId"]};

					RelationName="Master_Details";
					ds.Tables[TableName].Constraints.Add(_fk_=new ForeignKeyConstraint("fk"+RelationName,ds.Tables["MasterTable"].Columns["Id"],ds.Tables["DetailsTable"].Columns["MasterId"]));
					_fk_.UpdateRule=Rule.Cascade;
					_fk_.DeleteRule=Rule.Cascade;
					ds.Relations.Add(RelationName,ds.Tables["MasterTable"].Columns["Id"],ds.Tables["DetailsTable"].Columns["MasterId"]);

					tmpDataTable=ds.Tables["MasterTable"];
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Ленин";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpLong=Convert.ToInt64(tmpDataRow["Id"]);

					tmpDataTable=ds.Tables["DetailsTable"];
					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=1m;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=11m;
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["MasterId"]=tmpLong;
					tmpDataRow["Sum"]=111m;
					tmpDataTable.Rows.Add(tmpDataRow);

					ds.Tables["DetailsTable"].Clear();
					ds.Tables["MasterTable"].Clear();

					ds.Reset();
				#endif

                #if TEST_CHANGE_ROW_VALUE
					DataTable
						Src=new DataTable();

					Src.Columns.Add("FByte",typeof(byte)); // 0
					Src.Columns.Add("FInt16",typeof(short)); // 1
					Src.Columns.Add("FInt32",typeof(int)); // 2
					Src.Columns.Add("FInt64",typeof(long)); // 3
					Src.Columns.Add("FFloat",typeof(float)); // 4
					Src.Columns.Add("FDouble",typeof(double)); // 5
					Src.Columns.Add("FDecimal",typeof(decimal)); // 6
					Src.Columns.Add("FDateTime",typeof(string)); // 7
					Src.Columns.Add("FChar",typeof(char)); // 8
					Src.Columns.Add("FString",typeof(string)); // 9
					Src.Columns.Add("FBoolean",typeof(bool)); // 10
					Src.Columns.Add("FSByte",typeof(sbyte)); // 11
					Src.Columns.Add("FUInt16",typeof(ushort)); // 12
					Src.Columns.Add("FUInt32",typeof(uint)); // 13
					Src.Columns.Add("FUInt64",typeof(ulong)); // 14

					/*
					DataTable
						Dest=Src.Clone();
					*/
						
					DataTable
						Dest=new DataTable();

					Dest.Columns.Add("FByte",typeof(byte));
					Dest.Columns.Add("FInt16",typeof(short));
					Dest.Columns.Add("FInt32",typeof(int));
					Dest.Columns.Add("FInt64",typeof(long));
					Dest.Columns.Add("FFloat",typeof(float));
					Dest.Columns.Add("FDouble",typeof(double));
					Dest.Columns.Add("FDecimal",typeof(decimal));
					Dest.Columns.Add("FDateTime",typeof(DateTime));
					Dest.Columns.Add("FChar",typeof(char));
					Dest.Columns.Add("FString",typeof(string));
					Dest.Columns.Add("FBoolean",typeof(bool));
					Dest.Columns.Add("FSByte",typeof(sbyte));
					Dest.Columns.Add("FUInt16",typeof(ushort));
					Dest.Columns.Add("FUInt32",typeof(uint));
					Dest.Columns.Add("FUInt64",typeof(ulong));

					tmpDataRow=Src.NewRow();
					tmpDataRow["FByte"]=1;
					tmpDataRow["FInt16"]=16;
					tmpDataRow["FInt32"]=32;
					tmpDataRow["FInt64"]=64L;
					tmpDataRow["FFloat"]=1.1;
					tmpDataRow["FDouble"]=2.2;
					tmpDataRow["FDecimal"]=3.3m;
					tmpDataRow["FDateTime"]=DateTime.Now.Date.ToString();
					tmpDataRow["FChar"]='q';
					tmpDataRow["FString"]="qwerty";
					tmpDataRow["FBoolean"]=true;
					Src.Rows.Add(tmpDataRow);

					tmpDataRow=Dest.NewRow();
					tmpDataRow["FByte"]=1;
					tmpDataRow["FInt16"]=16;
					tmpDataRow["FInt32"]=32;
					tmpDataRow["FInt64"]=64L;
					tmpDataRow["FFloat"]=1.1;
					tmpDataRow["FDouble"]=2.2;
					tmpDataRow["FDecimal"]=3.3m;
					tmpDataRow["FDateTime"]=DateTime.Now.Date;
					tmpDataRow["FChar"]='q';
					tmpDataRow["FString"]="qwerty";
					tmpDataRow["FBoolean"]=true;
					Dest.Rows.Add(tmpDataRow);

					bool
						IsEqual=false;
					
					int
						FieldNo=10;

					IsEqual = Dest.Rows[0][FieldNo]==Src.Rows[0][FieldNo]; // System.DBNull

					IsEqual = Convert.Equals(Dest.Rows[0][FieldNo],Src.Rows[0][FieldNo]);

					if(Dest.Rows[0].IsNull(FieldNo) && Src.Rows[0].IsNull(FieldNo))
						IsEqual=true;
					else if(!Dest.Rows[0].IsNull(FieldNo) && Src.Rows[0].IsNull(FieldNo))
					{
						Dest.Rows[0][FieldNo]=DBNull.Value;
						IsEqual=true;
					}
					else if(Dest.Rows[0].IsNull(FieldNo) && !Src.Rows[0].IsNull(FieldNo))
						IsEqual=false;
					else if(!Dest.Rows[0].IsNull(FieldNo) && !Src.Rows[0].IsNull(FieldNo))
					{
						switch(Dest.Rows[0][FieldNo].GetType().Name)
						{
							case "SByte" :
							{
								IsEqual = Convert.ToSByte(Dest.Rows[0][FieldNo])==Convert.ToSByte(Src.Rows[0][FieldNo]);
								break;
							}
							case "Byte" :
							{
								IsEqual = Convert.ToByte(Dest.Rows[0][FieldNo])==Convert.ToByte(Src.Rows[0][FieldNo]);
								break;
							}
							case "Int16" :
							{
								IsEqual = Convert.ToInt16(Dest.Rows[0][FieldNo])==Convert.ToInt16(Src.Rows[0][FieldNo]);
								break;
							}
							case "UInt16" :
							{
								IsEqual = Convert.ToUInt16(Dest.Rows[0][FieldNo])==Convert.ToUInt16(Src.Rows[0][FieldNo]);
								break;
							}
							case "Int32" :
							{
								IsEqual = Convert.ToInt32(Dest.Rows[0][FieldNo])==Convert.ToInt32(Src.Rows[0][FieldNo]);
								break;
							}
							case "UInt32" :
							{
								IsEqual = Convert.ToUInt32(Dest.Rows[0][FieldNo])==Convert.ToUInt32(Src.Rows[0][FieldNo]);
								break;
							}
							case "Int64" :
							{
								IsEqual = Convert.ToInt64(Dest.Rows[0][FieldNo])==Convert.ToInt64(Src.Rows[0][FieldNo]);
								break;
							}
							case "UInt64" :
							{
								IsEqual = Convert.ToUInt64(Dest.Rows[0][FieldNo])==Convert.ToUInt64(Src.Rows[0][FieldNo]);
								break;
							}
							case "Single" :
							{
								IsEqual = Convert.ToSingle(Dest.Rows[0][FieldNo])==Convert.ToSingle(Src.Rows[0][FieldNo]);
								break;
							}
							case "Double" :
							{
								IsEqual = Convert.ToDouble(Dest.Rows[0][FieldNo])==Convert.ToDouble(Src.Rows[0][FieldNo]);
								break;
							}
							case "Decimal" :
							{
								IsEqual = Convert.ToDecimal(Dest.Rows[0][FieldNo])==Convert.ToDecimal(Src.Rows[0][FieldNo]);
								break;
							}
							case "DateTime" :
							{
								IsEqual = Convert.ToDateTime(Dest.Rows[0][FieldNo])==Convert.ToDateTime(Src.Rows[0][FieldNo]);
								break;
							}
							case "Char" :
							{
								IsEqual = Convert.ToChar(Dest.Rows[0][FieldNo])==Convert.ToChar(Src.Rows[0][FieldNo]);
								break;
							}
							case "String" :
							{
								IsEqual = Convert.ToString(Dest.Rows[0][FieldNo])==Convert.ToString(Src.Rows[0][FieldNo]);
								break;
							}
							case "Boolean" :
							{
								IsEqual = Convert. ToBoolean(Dest.Rows[0][FieldNo])==Convert.ToBoolean(Src.Rows[0][FieldNo]);
								break;
							}
						}

						switch(Type.GetTypeCode(Dest.Rows[0][FieldNo].GetType()))
						{
							case TypeCode.SByte :
							{
								IsEqual = Convert.ToSByte(Dest.Rows[0][FieldNo])==Convert.ToSByte(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Byte :
							{
								IsEqual = Convert.ToByte(Dest.Rows[0][FieldNo])==Convert.ToByte(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Int16 :
							{
								IsEqual = Convert.ToInt16(Dest.Rows[0][FieldNo])==Convert.ToInt16(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.UInt16 :
							{
								IsEqual = Convert.ToUInt16(Dest.Rows[0][FieldNo])==Convert.ToUInt16(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Int32 :
							{
								IsEqual = Convert.ToInt32(Dest.Rows[0][FieldNo])==Convert.ToInt32(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.UInt32 :
							{
								IsEqual = Convert.ToUInt32(Dest.Rows[0][FieldNo])==Convert.ToUInt32(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Int64 :
							{
								IsEqual = Convert.ToInt64(Dest.Rows[0][FieldNo])==Convert.ToInt64(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.UInt64 :
							{
								IsEqual = Convert.ToUInt64(Dest.Rows[0][FieldNo])==Convert.ToUInt64(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Single :
							{
								IsEqual = Convert.ToSingle(Dest.Rows[0][FieldNo])==Convert.ToSingle(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Double :
							{
								IsEqual = Convert.ToDouble(Dest.Rows[0][FieldNo])==Convert.ToDouble(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Decimal :
							{
								IsEqual = Convert.ToDecimal(Dest.Rows[0][FieldNo])==Convert.ToDecimal(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.DateTime :
							{
								IsEqual = Convert.ToDateTime(Dest.Rows[0][FieldNo])==Convert.ToDateTime(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Char :
							{
								IsEqual = Convert.ToChar(Dest.Rows[0][FieldNo])==Convert.ToChar(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.String :
							{
								IsEqual = Convert.ToString(Dest.Rows[0][FieldNo])==Convert.ToString(Src.Rows[0][FieldNo]);
								break;
							}
							case TypeCode.Boolean :
							{
								IsEqual = Convert. ToBoolean(Dest.Rows[0][FieldNo])==Convert.ToBoolean(Src.Rows[0][FieldNo]);
								break;
							}
						}
					}

					if(!IsEqual)
						Dest.Rows[0][FieldNo]=Src.Rows[0][FieldNo];
				#endif

                #if TEST_COPY_OBJECT
					DataTable
						DataTableSrc=new DataTable(),
						DataTableDest;

					DataTableSrc.Columns.Add("FString",typeof(string));
					DataTableSrc.Columns.Add("FDateTime",typeof(DateTime));
					DataTableSrc.Columns.Add("FDecimal",typeof(decimal));
					DataTableDest=DataTableSrc.Clone();

					tmpDataRow=DataTableSrc.NewRow();
					tmpDataRow["FString"]=" String ";
					tmpDataRow["FDateTime"]=DateTime.Now.Date;
					tmpDataRow["FDecimal"]=123.56m;
					DataTableSrc.Rows.Add(tmpDataRow);

					tmpDataRow=DataTableSrc.NewRow();
					tmpDataRow["FString"]=" String II ";
					tmpDataRow["FDateTime"]=DateTime.Now.AddYears(1).Date;
					tmpDataRow["FDecimal"]=123.56m*2;
					DataTableSrc.Rows.Add(tmpDataRow);

					foreach(DataRow row in DataTableSrc.Rows)
					{
						tmpDataRow=DataTableDest.NewRow();
						foreach(DataColumn col in DataTableSrc.Columns)
							tmpDataRow[col.ColumnName]=row[col.ColumnName];
						DataTableDest.Rows.Add(tmpDataRow);
					}

					foreach(DataRow row in DataTableSrc.Rows)
						DataTableDest.ImportRow(row);

					foreach(DataRow row in DataTableSrc.Rows)
					{
						foreach(DataColumn col in DataTableSrc.Columns)
						{
							tmpString=col.DataType.Name;
							fstr_out.Write(row[col.ColumnName]);
							fstr_out.Write("\t");
						}
						fstr_out.WriteLine();
					}
					fstr_out.WriteLine();

					foreach(DataRow row in DataTableDest.Rows)
					{
						foreach(DataColumn col in DataTableDest.Columns)
						{
							tmpObject=row[col.ColumnName];
							tmpString=tmpObject.GetType().Name;
							fstr_out.Write(tmpObject);
							fstr_out.Write("\t");
						}
						fstr_out.WriteLine();
					}
					fstr_out.WriteLine();
				#endif

                #if TEST_AUTOINCREMENT
					if(ds==null)
						ds=new DataSet();

					ds.Tables.Add("TestTable");
					tmpDataColumn=ds.Tables["TestTable"].Columns.Add("Id",typeof(int));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=1;
					tmpDataColumn.AutoIncrementStep=1;
					ds.Tables["TestTable"].Columns.Add("IdStr",typeof(string));
					ds.Tables["TestTable"].PrimaryKey=new DataColumn[]{ds.Tables["TestTable"].Columns["Id"]};

					for(int i=1; i<11; ++i)
					{
						tmpDataRow=ds.Tables["TestTable"].NewRow();
						tmpDataRow["IdStr"]=Convert.ToString(i);
						ds.Tables["TestTable"].Rows.Add(tmpDataRow);
					}

					tmpString=string.Empty;
					foreach(DataRow r in ds.Tables["TestTable"].Rows)
					{
						if(tmpString!=string.Empty)
							tmpString+=Environment.NewLine;
						tmpString+="Id="+Convert.ToString(Convert.ToInt32(r["Id"]))+" "+"IdStr="+Convert.ToString(r["IdStr"]);
					}

					ds.Tables["TestTable"].Clear();

					for(int i=1; i<11; ++i)
					{
						tmpDataRow=ds.Tables["TestTable"].NewRow();
						tmpDataRow["IdStr"]=Convert.ToString(i);
						ds.Tables["TestTable"].Rows.Add(tmpDataRow);
					}

					tmpString=string.Empty;
					foreach(DataRow r in ds.Tables["TestTable"].Rows)
					{
						if(tmpString!=string.Empty)
							tmpString+=Environment.NewLine;
						tmpString+="Id="+Convert.ToString(Convert.ToInt32(r["Id"]))+" "+"IdStr="+Convert.ToString(r["IdStr"]);
					}

					ds.Tables["TestTable"].Clear();
					tmpDataRow=ds.Tables["TestTable"].NewRow();
					tmpDataRow["IdStr"]="1"; 
					ds.Tables["TestTable"].Rows.Add(tmpDataRow);

					if(tmpDataTable==null)
						tmpDataTable=new DataTable();
					else
						tmpDataTable.Reset();

					tmpDataColumn=tmpDataTable.Columns.Add("Id",typeof(int));
					tmpDataColumn.AllowDBNull=false;
					tmpDataColumn.AutoIncrement=true;
					tmpDataColumn.AutoIncrementSeed=1;
					tmpDataColumn.AutoIncrementStep=1;
					tmpDataTable.Columns.Add("Name",typeof(string));
					tmpDataTable.PrimaryKey=new DataColumn[]{tmpDataTable.Columns["Id"]};

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Иванов Иван Иванович";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Id"]=3;
					tmpDataRow["Name"]="Петров Петр Петрович";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Сидоров Сидор Сидорович";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataRow=tmpDataTable.NewRow();
					tmpDataRow["Name"]="Александров Александр Александрович";
					tmpDataTable.Rows.Add(tmpDataRow);

					tmpDataTable.Reset();
					tmpDataTable=null;
				#endif

                #if TEST_TWO_DATASET
					ds=new DataSet();
					ds.Tables.Add("Staff");
					ds.Tables["Staff"].Columns.Add("ID",typeof(short));
					ds.Tables["Staff"].Columns.Add("Name",typeof(string));
					ds.Tables["Staff"].Columns.Add("Salary",typeof(decimal));
					ds.Tables["Staff"].PrimaryKey=new DataColumn[]{ds.Tables["Staff"].Columns["ID"]};

					tmpDataRow=ds.Tables["Staff"].NewRow();
					tmpDataRow["ID"]=999;
					tmpDataRow["Name"]="Шариков";
					tmpDataRow["Salary"]=2500.00m;
					ds.Tables["Staff"].Rows.Add(tmpDataRow);

					DataSet
						ds2=new DataSet();

					ds2.Tables.Add("SubStaff");
					ds2.Tables["SubStaff"].Columns.Add("ID",typeof(short));
					ds2.Tables["SubStaff"].Columns.Add("SubID",typeof(short));
					ds2.Tables["SubStaff"].Columns.Add("SubName",typeof(string));
					ds2.Tables["SubStaff"].PrimaryKey=new DataColumn[]{ds2.Tables["SubStaff"].Columns["ID"],ds2.Tables["SubStaff"].Columns["SubID"]};

					tmpDataRow=ds2.Tables["SubStaff"].NewRow();
					tmpDataRow["ID"]=999;
					tmpDataRow["SubID"]=999;
					tmpDataRow["SubName"]="Полиграф Полиграфович";
					ds2.Tables["SubStaff"].Rows.Add(tmpDataRow);

					/*
					!!!Error!!!
					"Cannot have a relationship between tables in different DataSets."
						
					DataRelation
						ExternRelation;

					ExternRelation=new DataRelation("ExternRelation",ds.Tables["Staff"].Columns["ID"],ds2.Tables["SubStaff"].Columns["ID"]);
					ds2.Relations.Add(ExternRelation); 
					*/
						
					ds.Tables["Staff"].ColumnChanged+=new DataColumnChangeEventHandler(MyCascade);						
					TableToCascade=ds2.Tables["SubStaff"];
					tmpDataRow=ds.Tables["Staff"].Rows[0];
					tmpDataRow["ID"]=333;
						
					tmpString="";
					foreach(DataRow row in ds2.Tables["SubStaff"].Rows)
					{
						if(tmpString.Length!=0)
							tmpString+=" ";
						tmpString+=Convert.ToString(Convert.ToInt16(row["ID"]))+" "+Convert.ToString(Convert.ToInt16(row["SubID"]))+" "+Convert.ToString(row["SubName"]);
					}

					ds.Tables["Staff"].ColumnChanged-=new DataColumnChangeEventHandler(MyCascade);
					tmpDataRow=ds.Tables["Staff"].Rows[0];
					tmpDataRow["ID"]=111;

					tmpString="";
					ds.Reset();
				#endif

                #if TEST_INSERT
					if(ds==null)
						ds=new DataSet();
					ds.Tables.Add("TestTable");
					ds.Tables["TestTable"].Columns.Add("FInt",typeof(int));
					ds.Tables["TestTable"].Columns.Add("FString",typeof(string));
					ds.Tables["TestTable"].Columns.Add("FDecimal",typeof(decimal));
					ds.Tables["TestTable"].Columns.Add("FDateTime",typeof(DateTime));
					ds.Tables["TestTable"].Columns.Add("Comment",typeof(string));
					ds.Tables["TestTable"].Columns.Add("Sub_1",typeof(string));
					ds.Tables["TestTable"].Columns.Add("Sub_2",typeof(string));
					ds.Tables["TestTable"].Columns.Add("Sub_1_Sub_2",typeof(string),"IIF((Sub_1 is not null) and (LEN(TRIM(Sub_1))<>0),TRIM(Sub_1),'')+IIF((Sub_1 is not null) and (LEN(TRIM(Sub_1))<>0) and (Sub_2 is not null) and (LEN(TRIM(Sub_2))<>0),' ','')+IIF((Sub_2 is not null) and (LEN(TRIM(Sub_2))<>0),'N '+TRIM(Sub_2),'')");

					object[]
						aVal={null,null,null,null,"By LoadDataRow","Seria"};

					ds.Tables["TestTable"].LoadDataRow(aVal,true);

					aVal=new object[7];
					aVal[0]=null;
					aVal[1]=null;
					aVal[2]=null;
					aVal[3]=null;
					aVal[4]="By Rows.Add";
					aVal[5]="     ";
					aVal[6]="123456789";
					ds.Tables["TestTable"].Rows.Add(aVal);

					aVal[4]="By ItemArray";
					tmpDataRow=ds.Tables["TestTable"].NewRow();
					aVal[5]="ABC";
					tmpDataRow.ItemArray=aVal;
					ds.Tables["TestTable"].Rows.Add(tmpDataRow);

					tmpDataRow=ds.Tables["TestTable"].NewRow();
					tmpDataRow["Comment"]="By NewRow";
					ds.Tables["TestTable"].Rows.Add(tmpDataRow);
						
					string
						FName;

					tmpString="";
					foreach(DataRow rr in ds.Tables["TestTable"].Rows)
					{
						if(tmpString.Length!=0)
							tmpString+=Environment.NewLine;

						tmpString+=(FName="FInt")+": '";
						if(rr[FName]!=DBNull.Value)
						{
							try
							{
								tmpString+=Convert.ToInt32(rr[FName]);
							}
							catch
							{
								tmpString+=Convert.ToString(rr[FName]);
							}
						}
						else
							tmpString+="NULL";
						tmpString+="'";

						if(tmpString.Length!=0)
							tmpString+="\t";
						tmpString+=(FName="FString")+": '";
						if(rr[FName]!=DBNull.Value)
						{
							try
							{
								tmpString+=Convert.ToString(rr[FName]);
							}
							catch
							{
								tmpString+=Convert.ToString(rr[FName]);
							}
						}
						else
							tmpString+="NULL";
						tmpString+="'";

						if(tmpString.Length!=0)
							tmpString+="\t";
						tmpString+=(FName="FDecimal")+": '";
						if(rr[FName]!=DBNull.Value)
						{
							try
							{
								tmpString+=Convert.ToDecimal(rr[FName]);
							}
							catch
							{
								tmpString+=Convert.ToString(rr[FName]);
							}
						}
						else
							tmpString+="NULL";
						tmpString+="'";

						if(tmpString.Length!=0)
							tmpString+="\t";
						tmpString+=(FName="FDateTime")+": '";
						if(rr[FName]!=DBNull.Value)
						{
							try
							{
								tmpString+=Convert.ToDateTime(rr[FName]);
							}
							catch
							{
								tmpString+=Convert.ToString(rr[FName]);
							}
						}
						else
							tmpString+="NULL";
						tmpString+="'";

						if(tmpString.Length!=0)
							tmpString+="\t";
						tmpString+=Convert.ToString(rr["Comment"]);

						if(tmpString!=string.Empty)
							tmpString+="\t";
						tmpString+="'"+Convert.ToString(rr["Sub_1"])+"'";

						if(tmpString!=string.Empty)
							tmpString+="\t";
						tmpString+="'"+Convert.ToString(rr["Sub_2"])+"'";

						if(tmpString!=string.Empty)
							tmpString+="\t";
						tmpString+="'"+Convert.ToString(rr["Sub_1_Sub_2"])+"'";
					}

					fstr_out.WriteLine(tmpString);
					fstr_out.WriteLine();

					ds.Reset();
				#endif 
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
		}

        static DataTable getTable()
        {
            DataTable
                tmpDataTable = new DataTable("TableName", "TableNamespace");

            DataColumn
                tmpDataColumn;

            string
                idPropertyName = "id";

            tmpDataColumn = tmpDataTable.Columns.Add(idPropertyName, typeof(long));
            tmpDataColumn.AllowDBNull = false;
            tmpDataColumn.Unique = true;
            tmpDataColumn.AutoIncrement = true;
            tmpDataColumn.AutoIncrementSeed = -1;
            tmpDataColumn.AutoIncrementStep = -1;
            tmpDataTable.Columns.Add("Name", typeof(string));
            tmpDataTable.Columns.Add("Salary", typeof(decimal));
            tmpDataTable.Columns.Add("Dep", typeof(int));
            tmpDataTable.Columns.Add("BirthDate", typeof(DateTime));
            tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns[idPropertyName] };

            DataRow
                tmpDataRow;

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Иванов Иван Иванович";
            tmpDataRow["Salary"] = 100;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1870, 4, 22);
            tmpDataTable.Rows.Add(tmpDataRow);

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Петров Петр Петрович";
            tmpDataRow["Salary"] = 1000;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1878, 12, 18);
            tmpDataTable.Rows.Add(tmpDataRow);

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Сидоров Сидор Сидорович";
            tmpDataRow["Salary"] = 100;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1894, 4, 17);
            tmpDataTable.Rows.Add(tmpDataRow);

            return tmpDataTable;
        }

		#if TEST_TWO_DATASET
			static void MyCascade(object sender, DataColumnChangeEventArgs e)
			{
				Console.WriteLine("ColumnChanged event occurred (sender: "+sender.ToString()+")");
				Console.WriteLine("Column={0}; Value={1}; Value(Current)={2}; Value(Original)={3}; Value(Proposed)={4}; Value(Default)={5}",
					e.Column.ColumnName,
					e.Row[e.Column.ColumnName],
					e.Row.HasVersion(DataRowVersion.Current) ? (e.Row[e.Column.ColumnName,DataRowVersion.Current] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Current] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Current)",
					e.Row.HasVersion(DataRowVersion.Original) ? (e.Row[e.Column.ColumnName,DataRowVersion.Original] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Original] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Original)",
					e.Row.HasVersion(DataRowVersion.Proposed) ? (e.Row[e.Column.ColumnName,DataRowVersion.Proposed] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Proposed] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Proposed)",
					e.Row.HasVersion(DataRowVersion.Default) ? (e.Row[e.Column.ColumnName,DataRowVersion.Default] != DBNull.Value ? e.Row[e.Column.ColumnName,DataRowVersion.Default] : DBNull.Value.ToString()) : "!HasVersion(DataRowVersion.Default)");

				if(sender.ToString()!="Staff"
					|| e.Column.ColumnName!="ID")
					return;

				short
					Id;

				foreach(DataRow row in TestAdoNetClass.TableToCascade.Rows)
					if(Convert.ToInt16(row["ID"])==Convert.ToInt16(e.Row[e.Column.ColumnName,DataRowVersion.Current])
						&& Convert.ToInt16(row["ID"])!=(Id=Convert.ToInt16(e.Row[e.Column.ColumnName])))
						row["ID"]=Id;
			}
		#endif

		#if TEST_SET_FIELD
			static void SetField(DataRow Row, string FieldName, object Value)
			{
				SetField(Row,FieldName,Value,false);
			}
			//---------------------------------------------------------------------------

			static void SetField(DataRow Row, string FieldName, object Value, bool SetDBNullValue)
			{
				if(!Row.Table.Columns.Contains(FieldName))
					throw(new Exception("Unknown FieldName: \""+FieldName+"\""));

				if(!EqualsDataField(Row,FieldName,Value))
				{
					if(!Convert.IsDBNull(Value) || SetDBNullValue)
						Row[FieldName]=Value;
				}
			}
			//---------------------------------------------------------------------------

			public static bool EqualsDataField(DataRow Row, string FieldName, object Value)
			{
				if(!Row.Table.Columns.Contains(FieldName))
					throw(new Exception("Unknown FieldName: \""+FieldName+"\""));

				bool
					IsEqual=false;

				try
				{
					if(Row.IsNull(FieldName) && Convert.IsDBNull(Value))
						IsEqual=true;
					else if((!Row.IsNull(FieldName) && Convert.IsDBNull(Value))
						|| (Row.IsNull(FieldName) && !Convert.IsDBNull(Value)))
						IsEqual=false;
					else if(!Row.IsNull(FieldName) && !Convert.IsDBNull(Value))
					{
						TypeCode
							tc;

						switch(tc=Type.GetTypeCode(Row[FieldName].GetType()))
						{
							case System.TypeCode.SByte :
							{
								IsEqual = Convert.ToSByte(Row[FieldName])==Convert.ToSByte(Value);
								break;
							}
							case System.TypeCode.Byte :
							{
								IsEqual = Convert.ToByte(Row[FieldName])==Convert.ToByte(Value);
								break;
							}
							case System.TypeCode.Int16 :
							{
								IsEqual = Convert.ToInt16(Row[FieldName])==Convert.ToInt16(Value);
								break;
							}
							case System.TypeCode.UInt16 :
							{
								IsEqual = Convert.ToUInt16(Row[FieldName])==Convert.ToUInt16(Value);
								break;
							}
							case System.TypeCode.Int32 :
							{
								IsEqual = Convert.ToInt32(Row[FieldName])==Convert.ToInt32(Value);
								break;
							}
							case System.TypeCode.UInt32 :
							{
								IsEqual = Convert.ToUInt32(Row[FieldName])==Convert.ToUInt32(Value);
								break;
							}
							case System.TypeCode.Int64 :
							{
								IsEqual = Convert.ToInt64(Row[FieldName])==Convert.ToInt64(Value);
								break;
							}
							case System.TypeCode.UInt64 :
							{
								IsEqual = Convert.ToUInt64(Row[FieldName])==Convert.ToUInt64(Value);
								break;
							}
							case System.TypeCode.Single :
							{
								IsEqual = Convert.ToSingle(Row[FieldName])==Convert.ToSingle(Value);
								break;
							}
							case System.TypeCode.Double :
							{
								IsEqual = Convert.ToDouble(Row[FieldName])==Convert.ToDouble(Value);
								break;
							}
							case System.TypeCode.Decimal :
							{
								IsEqual = Convert.ToDecimal(Row[FieldName])==Convert.ToDecimal(Value);
								break;
							}
							case System.TypeCode.DateTime :
							{
								IsEqual = Convert.ToDateTime(Row[FieldName])==Convert.ToDateTime(Value);
								break;
							}
							case System.TypeCode.Char :
							{
								IsEqual = Convert.ToChar(Row[FieldName])==Convert.ToChar(Value);
								break;
							}
							case System.TypeCode.String :
							{
								IsEqual = Convert.ToString(Row[FieldName])==Convert.ToString(Value);
								break;
							}
							case System.TypeCode.Boolean :
							{
								IsEqual = Convert. ToBoolean(Row[FieldName])==Convert.ToBoolean(Value);
								break;
							}
							default :
							{
								throw(new Exception("Unknown TypeCode: \""+tc.ToString()+"\""+Environment.NewLine+"(\""+Row.Table.TableName+"\"[\""+FieldName+"\"]=\""+Row[FieldName].ToString()+"\", Value=\""+Value.ToString()+"\")"));
							}
						}
					}
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}

				return(IsEqual);
			}
			//---------------------------------------------------------------------------

			public static bool EqualsDataField(DataRow DataRowLeft, string FieldNameLeft, DataRow DataRowRight, string FieldNameRight)
			{
				if(!DataRowRight.Table.Columns.Contains(FieldNameRight))
					throw(new Exception("Unknown FieldName: \""+FieldNameRight+"\""));
				
				return(EqualsDataField(DataRowLeft,FieldNameLeft,DataRowRight[FieldNameRight]));
			}
			//---------------------------------------------------------------------------
		#endif

        #if TEST_DUPLICATES
	        static Func<DataRow, string> CreateKeySelector(DataTable table, List<string> fields)
	        {
	            var sbFormat = new StringBuilder();
                var arguments = new List<Expression>();
	            var methodInfo = typeof(DataRow).GetProperty("Item", new[] { typeof(string)} ).GetGetMethod();
                var param = Expression.Parameter(typeof(DataRow), "row");
	            var i = 0;

	            fields.ForEach(field =>
	            {
	                if (!table.Columns.Contains(field))
	                    return;

	                if (sbFormat.Length != 0)
	                    sbFormat.Append("_");

	                sbFormat.Append(string.Format("\"{{{0}}}\"", i++));

                    arguments.Add(Expression.Call(param, methodInfo, Expression.Constant(field)));
	            });

                var argumants4call = new Expression[] { Expression.Constant(sbFormat.ToString()), Expression.NewArrayInit(typeof(object), arguments) };
                var methodFormat = typeof(string).GetMethod("Format", new[] { typeof(string), typeof(object[]) });
                var expressionFormat = Expression.Call(methodFormat, argumants4call);

	            return Expression.Lambda<Func<DataRow, string>>(expressionFormat, new[] { param }).Compile();
	        }

	        static bool HasDuplicates(DataTable table, Func<DataRow, string> keySelector, ICollection<string> errorMessagesList)
	        {
	            var duplicates = table.AsEnumerable().GroupBy(keySelector).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

                duplicates.ForEach(errorMessagesList.Add);

	            return duplicates.Count != 0;
	        }
        #endif
    }
}
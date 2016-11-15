using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace TestBoxSelect
{
    public class StaffHandler : IHttpHandler, IRequiresSessionState
    {
        const string
            DataTableSessionSignature = "DataTableStaff",
            IdPropertyName = "Id",
            IdDelimiter="|";

        public void ProcessRequest(HttpContext context)
        {
            var idsStr = context.Request.Params[IdPropertyName];
            var query = context.Request.Params["query"];
            var ids = !string.IsNullOrEmpty(idsStr) ? idsStr.Split(new string[] {IdDelimiter}, StringSplitOptions.RemoveEmptyEntries).AsEnumerable().Select(id => long.Parse(id)).ToList() : new List<long>();
            var javaScriptSerializer = new JavaScriptSerializer();
            var staffs = GetData(context).AsEnumerable().Select(r => new Staff
                {
                    Id = r.Field<long>("Id"),
                    Name = r.Field<string>("Name"),
                    Salary = r.Field<decimal?>("Salary"),
                    Dep = r.Field<int?>("Dep"),
                    BirthDate = r.Field<DateTime?>("BirthDate"),
                    NullField = r.Field<decimal?>("NullField")
                }).ToList();

            List<Staff>
                result = staffs;

            if (ids.Count != 0)
                result = staffs.Where(r => ids.Contains(r.Id)).ToList();
            else if(!string.IsNullOrEmpty(query))
                result = staffs.Where(r => r.Name.IndexOf(query)!=-1).ToList();

            var responseStaff = new ResponseStaff
            {
                success = true,
                staffs = result,
                total = staffs.Count
            };

            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Charset = "utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Write(javaScriptSerializer.Serialize(responseStaff));
            context.Response.Flush();
            context.Response.Close();
            context.Response.End();

        }

        public bool IsReusable
        {
            get { return false; }
        }

        public static DataTable GetData(HttpContext context)
        {
            DataTable
                tmpDataTable;

            if ((tmpDataTable = (DataTable)context.Session[DataTableSessionSignature]) == null)
            {
                context.Session[DataTableSessionSignature] = tmpDataTable = new DataTable();

                DataColumn
                    tmpDataColumn;

                tmpDataColumn = tmpDataTable.Columns.Add(IdPropertyName, typeof(long));
                tmpDataColumn.AllowDBNull = false;
                tmpDataColumn.Unique = true;
                tmpDataColumn.AutoIncrement = true;
                tmpDataColumn.AutoIncrementSeed = -1;
                tmpDataColumn.AutoIncrementStep = -1;
                tmpDataTable.Columns.Add("Name", typeof(string));
                tmpDataTable.Columns.Add("Salary", typeof(decimal));
                tmpDataTable.Columns.Add("Dep", typeof(int));
                tmpDataTable.Columns.Add("BirthDate", typeof(DateTime));
                tmpDataTable.Columns.Add("NullField", typeof(decimal));
                tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns[IdPropertyName] };

                DataRow
                    tmpDataRow;

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Ленин Владимир Ильич";
                tmpDataRow["Salary"] = 100;
                tmpDataRow["Dep"] = 1;
                tmpDataRow["BirthDate"] = new DateTime(1870, 4, 22);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Сталин Иосиф Виссарионович";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 1;
                tmpDataRow["BirthDate"] = new DateTime(1878, 12, 18);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Хрущев Никита Сергеевич";
                tmpDataRow["Salary"] = 100;
                tmpDataRow["Dep"] = 1;
                tmpDataRow["BirthDate"] = new DateTime(1894, 4, 17);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Брежнев Леонид Ильич";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 1;
                tmpDataRow["BirthDate"] = new DateTime(1906, 12, 19);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Андропов  Юрий Владимрович";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 1;
                tmpDataRow["BirthDate"] = new DateTime(1914, 6, 15);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Черненко Константин Устинович";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 1;
                tmpDataRow["BirthDate"] = new DateTime(1911, 9, 24);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Горбачёв Михаил Сергеевич";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 1;
                tmpDataRow["BirthDate"] = new DateTime(1931, 3, 2);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Кравчук Леонид Макарович";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 2;
                tmpDataRow["BirthDate"] = new DateTime(1934, 1, 10);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Кучма Леонид Данилович";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 2;
                tmpDataRow["BirthDate"] = new DateTime(1938, 8, 9);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Ющенко Виктор Андреевич";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 2;
                tmpDataRow["BirthDate"] = new DateTime(1954, 2, 23);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Янукович Виктор Федорович";
                tmpDataRow["Salary"] = 1000;
                tmpDataRow["Dep"] = 2;
                tmpDataRow["BirthDate"] = new DateTime(1950, 7, 9);
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["Name"] = "Вашингтон Джордж";
                tmpDataRow["Salary"] = 8000;
                tmpDataRow["Dep"] = 3;
                tmpDataRow["BirthDate"] = new DateTime(1732, 2, 22);
                tmpDataTable.Rows.Add(tmpDataRow);
            }

            return tmpDataTable;
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace TestGridWithInfiniteScrolling
{
    public class DataHandler : IHttpHandler, IRequiresSessionState
    {
        const string
            DataTableSessionSignature = "DataTable1",
            IdPropertyName = "id";

        const int
            Max = 50000;

        public void ProcessRequest(HttpContext context)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            var allRows = GetTable(context);
            var pageStr = context.Request.Params["page"];
            var startStr = context.Request.Params["start"];
            var limitStr = context.Request.Params["limit"];
            int? start = !string.IsNullOrEmpty(startStr) ? (int?)int.Parse(startStr) : null;
            int? limit = !string.IsNullOrEmpty(limitStr) ? (int?)int.Parse(limitStr) : null;
            var rows = GetData(allRows, start, limit);
            var responseRow = new ResponseRow
            {
                success = true,
                rows = rows,
                total = allRows.AsEnumerable().Count()
            };

            string response = javaScriptSerializer.Serialize(responseRow);

            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Charset = "utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;
            byte[] bytes = context.Response.ContentEncoding.GetBytes(response);
            context.Response.AddHeader("Content-Length", bytes.Length.ToString());
            context.Response.Write(response);
            context.Response.Flush();
            context.Response.Close();
            context.Response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }

        static DataTable GetTable(HttpContext context)
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
                tmpDataTable.Columns.Add("name", typeof(string));
                tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns[IdPropertyName] };

                for (int i = 0; i < Max; ++i)
                {
                    DataRow
                        tmpDataRow = tmpDataTable.NewRow();

                    tmpDataRow[IdPropertyName] = i;
                    tmpDataRow["name"] = string.Format("Record# {0}", i);
                    tmpDataTable.Rows.Add(tmpDataRow);
                }
            }

            return tmpDataTable;
        }

        static List<Row> GetData(DataTable dataTable, int? start, int? limit)
        {
            var fromStart = start.HasValue ? dataTable.AsEnumerable().Skip(start.Value) : dataTable.AsEnumerable();
            var toLimit = limit.HasValue ? fromStart.Take(limit.Value) : fromStart;

            return toLimit.Select(r => new Row
            {
                id = r.Field<long>("id"),
                name = r.Field<string>("name")
            }).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Jayrock.Json;

namespace TestCustomProxy
{
    public class TestHandler : IHttpHandler, IRequiresSessionState
    {
        const string
            DataTableSessionSignature = "DataTableTest",
            IdPropertyName = "Id";

        const int
            maxRecordSize = 1000;

        public void ProcessRequest(HttpContext context)
        {
            string
                pageStr,
                startStr,
                limitStr,
                filterStr;

            int
                page = 1,
                start = 0,
                limit = 2;

            if(!String.IsNullOrWhiteSpace(pageStr = context.Request.Form["page"]))
                int.TryParse(pageStr, out page);
            if (!String.IsNullOrWhiteSpace(pageStr = context.Request.QueryString["page"]))
                int.TryParse(pageStr, out page);
            if(!String.IsNullOrWhiteSpace(startStr = context.Request.Form["start"]))
                int.TryParse(startStr, out start);
            if (!String.IsNullOrWhiteSpace(startStr = context.Request.QueryString["start"]))
                int.TryParse(startStr, out start);
            if(!String.IsNullOrWhiteSpace(limitStr = context.Request.Form["limit"]))
                int.TryParse(limitStr, out limit);
            if (!String.IsNullOrWhiteSpace(limitStr = context.Request.QueryString["limit"]))
                int.TryParse(limitStr, out limit);

            if (!String.IsNullOrWhiteSpace(filterStr = context.Request.Form["filter"]))
                ;
            if (!String.IsNullOrWhiteSpace(filterStr = context.Request.QueryString["filter"]))
                ;

            List<TestModel>
                response = GetData(context).AsEnumerable().Skip(start).Take(limit).Select(r => new TestModel
                                                                                                   {
                                                                                                       Id = r.Field<long>("Id"),
                                                                                                       Name = r.Field<string>("Name")
                                                                                                   }).ToList();

            JsonArray
                tmpJsonArray = new JsonArray();

            response.ForEach(r => tmpJsonArray.Add(new JsonArray(new object[] { r.Id, r.Name })));

            JsonObject
                rootJsonObject = new JsonObject(new Dictionary<string, object>
                                                    {
                                                        { "data", tmpJsonArray },
                                                        { "total", maxRecordSize }
                                                    });

            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();
            context.Response.CacheControl = "no-cache";
            context.Response.Expires = -1;
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Charset = "utf=8";
            context.Response.ContentEncoding = Encoding.UTF8;

            JsonTextWriter
                tmpJsonTextWriter = new JsonTextWriter(context.Response.Output);

            rootJsonObject.Export(tmpJsonTextWriter);

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

                tmpDataColumn = tmpDataTable.Columns.Add(IdPropertyName, typeof (long));
                tmpDataColumn.AllowDBNull = false;
                tmpDataColumn.Unique = true;
                tmpDataColumn.AutoIncrement = true;
                tmpDataColumn.AutoIncrementSeed = -1;
                tmpDataColumn.AutoIncrementStep = -1;
                tmpDataTable.Columns.Add("Name", typeof (string));
                tmpDataTable.PrimaryKey = new DataColumn[] {tmpDataTable.Columns[IdPropertyName]};

                DataRow
                    tmpDataRow;

                for (int i = 1; i <= maxRecordSize; ++i)
                {
                    tmpDataRow = tmpDataTable.NewRow();
                    tmpDataRow["Name"] = String.Format("Record# {0}", i);
                    tmpDataTable.Rows.Add(tmpDataRow);
                }
            }

            return tmpDataTable;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace TestGridWithFiltersFeature
{
    public class DataHandler : IHttpHandler, IRequiresSessionState
    {
        const string
            DataTableSessionSignature = "DataTable",
            IdPropertyName = "id";

        const int
            maxRecords = 50;

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer
                javaScriptSerializer = new JavaScriptSerializer();

            string
                startStr,
                limitStr,
                filterStr = context.Request.QueryString["filter"];

            int
                start,
                limit;

            DataTable
                data = getData(context);

            DataResponse
                dataResponse = null;

            if (!string.IsNullOrEmpty(startStr = context.Request.QueryString["start"])
                && !string.IsNullOrEmpty(limitStr = context.Request.QueryString["limit"]))
            {
                int.TryParse(startStr, out start);
                int.TryParse(limitStr, out limit);

                List<Data>
                    dataPage = getDataPage(data, start, limit);

                dataResponse = new DataResponse
                    {
                        success = true,
                        data = dataPage,
                        total = data.AsEnumerable().Count()
                    };
            }

            string
                response = javaScriptSerializer.Serialize(dataResponse);

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

        public static DataTable getData(HttpContext context)
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
                tmpDataTable.Columns.Add("fstring", typeof(string));
                tmpDataTable.Columns.Add("ffloat", typeof(decimal));
                tmpDataTable.Columns.Add("fdate", typeof(DateTime));
                tmpDataTable.Columns.Add("fboolean", typeof(bool));
                tmpDataTable.Columns.Add("fint", typeof(int));
                
                tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns[IdPropertyName] };

                DataRow
                    tmpDataRow;

                DateTime
                    tmpDateTime = new DateTime(1900, 1, 1);

                for (int i = 1; i <= maxRecords; ++i)
                {
                    tmpDataRow = tmpDataTable.NewRow();
                    tmpDataRow["fstring"] = "Record# " + i;
                    tmpDataRow["ffloat"] = i * 1.1;
                    tmpDataRow["fdate"] = tmpDateTime.AddDays(i);
                    tmpDataRow["fboolean"] = i%2==0;
                    tmpDataRow["fint"] = i;
                    tmpDataTable.Rows.Add(tmpDataRow);
                }

                /*
                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["fstring"] = "Record# 1";
                tmpDataRow["ffloat"] = 123.45;
                tmpDataRow["fdate"] = new DateTime(1900, 1, 1);
                tmpDataRow["fboolean"] = true;
                tmpDataRow["fint"] = 1;
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["fstring"] = "Record# 2";
                tmpDataRow["ffloat"] = 234.56;
                tmpDataRow["fdate"] = new DateTime(1901, 1, 1);
                tmpDataRow["fboolean"] = false;
                tmpDataRow["fint"] = 1;
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["fstring"] = "Record# 3";
                tmpDataRow["ffloat"] = 345.67;
                tmpDataRow["fdate"] = new DateTime(1902, 1, 1);
                tmpDataRow["fboolean"] = false;
                tmpDataRow["fint"] = 2;
                tmpDataTable.Rows.Add(tmpDataRow);

                tmpDataRow = tmpDataTable.NewRow();
                tmpDataRow["fstring"] = "Record# 3";
                tmpDataRow["ffloat"] = 345.67;
                tmpDataRow["fdate"] = new DateTime(1902, 1, 1);
                tmpDataRow["fboolean"] = false;
                tmpDataRow["fint"] = 2;
                tmpDataTable.Rows.Add(tmpDataRow);
                */
            }

            return tmpDataTable;
        }

        List<Data> getDataPage(DataTable dataTable, int start, int limit)
        {
            return dataTable.AsEnumerable().Skip(start).Take(limit).Select(r => new Data
                {
                    id = r.Field<long>("id"),
                    fstring = r.Field<string>("fstring"),
                    ffloat = r.Field<decimal?>("ffloat"),
                    fdate = r.Field<DateTime?>("fdate"),
                    fboolean = r.Field<bool?>("fboolean"),
                    fint = r.Field<int?>("fint")
                }).ToList();
        }
    }
}
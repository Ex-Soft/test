using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace TestLazyLoad
{
    public class StaffHandler : IHttpHandler, IRequiresSessionState
    {
        const string
            DataTableSessionSignature = "DataTableStaff",
            IdPropertyName = "Id";

        public void ProcessRequest(HttpContext context)
        {
            DataTable
                staffs = getStaffs(context);

            string
                response = "";

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

        public static DataTable getStaffs(HttpContext context)
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
                tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns[IdPropertyName] };

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
            }

            return tmpDataTable;
        }
    }
}
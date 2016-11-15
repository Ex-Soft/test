using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace TestGrid.remote.app.handlers
{
    public class Staff : IHttpHandler, IRequiresSessionState
    {
        const string
            DataTableSessionSignature = "DataTable1",
            IdPropertyName = "Id";

        public void ProcessRequest(HttpContext context)
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            var action = context.Request.Params["action"];
            var allStaffs = GetData(context);
            var controllerStaff = new controllers.Staff();
            string response = string.Empty;

            switch(action)
            {
                case "create":
                case "update":
                case "destroy":
                    {
                        var json = context.Request.GetJson();
                        var staffs = !string.IsNullOrEmpty(json) ? javaScriptSerializer.Deserialize<List<models.Staff>>(json) : null;
                        switch(action)
                        {
                            case "create":
                                {
                                    var staffsResponse = controllerStaff.Create(allStaffs, staffs);
                                    var responseStaff = new ResponseStaff
                                                            {
                                                                success = true,
                                                                staffs = staffs,
                                                                total = staffsResponse.AsEnumerable().Count()
                                                            };
                                    response = javaScriptSerializer.Serialize(responseStaff);
                                    break;
                                }
                            case "update":
                                {
                                    controllerStaff.Update(allStaffs,staffs);
                                    var responseStaff = new ResponseStaff
                                    {
                                        success = true
                                    };
                                    response = javaScriptSerializer.Serialize(responseStaff);
                                    break;
                                }
                            case "destroy":
                                {
                                    controllerStaff.Destroy(allStaffs, staffs);
                                    var responseStaff = new ResponseStaff
                                    {
                                        success = true
                                    };
                                    response = javaScriptSerializer.Serialize(responseStaff);
                                    break;
                                }
                        }
                        break;
                    }
                case "read":
                    {
                        var pageStr = context.Request.Params["page"];
                        var startStr = context.Request.Params["start"];
                        var limitStr = context.Request.Params["limit"];
                        int? start = !string.IsNullOrEmpty(startStr) ? (int?)int.Parse(startStr) : null;
                        int? limit = !string.IsNullOrEmpty(limitStr) ? (int?)int.Parse(limitStr) : null;
                        var staffs = controllerStaff.View(allStaffs, start, limit);
                        var responseStaff = new ResponseStaff
                        {
                            success = true,
                            staffs = staffs,
                            total = allStaffs.AsEnumerable().Count()
                        };
                        response = javaScriptSerializer.Serialize(responseStaff);
                        break;
                    }
            }

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
                tmpDataTable.Columns.Add("NullField", typeof (decimal));
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
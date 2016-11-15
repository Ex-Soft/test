using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace TestFormsAuthentication
{
    public class StaffHandler : IHttpHandler, IRequiresSessionState
    {
        const string
            DataTableSessionSignature = "DataTableStaff",
            IdPropertyName = "Id";

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer
                javaScriptSerializer = new JavaScriptSerializer();

            string
                startStr,
                limitStr;

            int
                start,
                limit;

            DataTable
                staffs = getStaffs(context);

            StaffResponse
                staffResponse = null;

            switch (context.Request.HttpMethod)
            {
                case "GET":
                    {
                        if (!string.IsNullOrEmpty(startStr = context.Request.QueryString["start"])
                            && !string.IsNullOrEmpty(limitStr = context.Request.QueryString["limit"]))
                        {
                            int.TryParse(startStr, out start);
                            int.TryParse(limitStr, out limit);

                            List<Staff>
                                staffsPage = getStaffsPage(staffs, start, limit);

                            staffResponse = new StaffResponse
                                {
                                    success = true,
                                    staff = staffsPage,
                                    total = staffs.AsEnumerable().Count()
                                };
                        }

                        break;
                    }
                case "POST":
                case "PUT":
                case "DELETE":
                    {
                        string
                            request = context.Request.getJson();

                        List<Staff>
                            cudStaffs = !string.IsNullOrEmpty(request) ? javaScriptSerializer.Deserialize<List<Staff>>(request) : null;

                        switch (context.Request.HttpMethod)
                        {
                            case "POST":
                                {
                                    List<Staff>
                                        createdStaffs = createStaffs(staffs, cudStaffs);

                                    staffResponse = new StaffResponse
                                    {
                                        success = true,
                                        staff = createdStaffs,
                                        total = createdStaffs.AsEnumerable().Count()
                                    };

                                    break;
                                }
                            case "PUT":
                                {
                                    updateStaffs(staffs, cudStaffs);
                                    staffResponse = new StaffResponse
                                    {
                                        success = true
                                    };

                                    break;
                                }
                            case "DELETE":
                                {
                                    deleteStaffs(staffs, cudStaffs);
                                    staffResponse = new StaffResponse
                                    {
                                        success = true
                                    };

                                    break;
                                }
                        }

                        break;
                    }
            }

            string
                response = javaScriptSerializer.Serialize(staffResponse);

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

        List<Staff> getStaffsPage(DataTable dataTable, int start, int limit)
        {
            return dataTable.AsEnumerable().Skip(start).Take(limit).Select(r => new Staff
                {
                    Id = r.Field<long>("Id"),
                    Name = r.Field<string>("Name"),
                    Salary = r.Field<decimal?>("Salary"),
                    Dep = r.Field<int?>("Dep"),
                    BirthDate = r.Field<DateTime?>("BirthDate")
                }).ToList();
        }

        List<Staff> createStaffs(DataTable dataTable, List<Staff> staffs)
        {
            staffs.ForEach(staff =>
            {
                DataRow
                    tmpDataRow = dataTable.NewRow();

                tmpDataRow["Name"] = staff.Name;
                tmpDataRow["Salary"] = staff.Salary *= 2;
                tmpDataRow["Dep"] = staff.Dep;
                tmpDataRow["BirthDate"] = staff.BirthDate;

                dataTable.Rows.Add(tmpDataRow);
                staff.Id = Convert.ToInt64(tmpDataRow["Id"]);
            });

            return staffs;
        }

        void updateStaffs(DataTable dataTable, List<Staff> staffs)
        {
            staffs.ForEach(staff =>
            {
                DataRow
                    tmpDataRow;

                if ((tmpDataRow = dataTable.Rows.Find(staff.Id)) != null)
                {
                    tmpDataRow["Name"] = staff.Name;
                    tmpDataRow["Salary"] = staff.Salary.HasValue ? (object)staff.Salary.Value : DBNull.Value;
                    tmpDataRow["Dep"] = staff.Dep.HasValue ? (object)staff.Dep.Value : DBNull.Value;
                    tmpDataRow["BirthDate"] = staff.BirthDate.HasValue ? (object)staff.BirthDate.Value : DBNull.Value;
                }
            });
        }

        void deleteStaffs(DataTable dataTable, List<Staff> staffs)
        {
            staffs.ForEach(staff =>
            {
                DataRow
                    tmpDataRow;

                if ((tmpDataRow = dataTable.Rows.Find(staff.Id)) != null)
                    dataTable.Rows.Remove(tmpDataRow);
            });
        }
    }
}
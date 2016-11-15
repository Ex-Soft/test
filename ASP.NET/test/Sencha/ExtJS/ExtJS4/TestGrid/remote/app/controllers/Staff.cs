using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TestGrid.remote.app.controllers
{
    public class Staff
    {
        public List<models.Staff> Create(DataTable dataTable, List<models.Staff> staffs)
        {
            staffs.ForEach(staff => {
                DataRow
                    tmpDataRow = dataTable.NewRow();

                tmpDataRow["Name"] = staff.Name;
                tmpDataRow["Salary"] = staff.Salary;
                tmpDataRow["Dep"] = staff.Dep;
                tmpDataRow["BirthDate"] = staff.BirthDate;

                dataTable.Rows.Add(tmpDataRow);
                staff.Id = Convert.ToInt64(tmpDataRow["Id"]);
            });

            return staffs;
        }

        public void Update(DataTable dataTable, List<models.Staff> staffs)
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

        public void Destroy(DataTable dataTable, List<models.Staff> staffs)
        {
            staffs.ForEach(staff =>
            {
                DataRow
                    tmpDataRow;

                if ((tmpDataRow = dataTable.Rows.Find(staff.Id)) != null)
                    dataTable.Rows.Remove(tmpDataRow);
            });
        }

        public List<models.Staff> View(DataTable dataTable, int? start, int? limit)
        {
            var fromStart = start.HasValue ? dataTable.AsEnumerable().Skip(start.Value) : dataTable.AsEnumerable();
            var toLimit = limit.HasValue ? fromStart.Take(limit.Value) : fromStart;

            return toLimit.Select(r => new models.Staff
                                           {
                                                Id = r.Field<long>("Id"),
                                                Name = r.Field<string>("Name"),
                                                Salary = r.Field<decimal?>("Salary"),
                                                Dep = r.Field<int?>("Dep"),
                                                BirthDate = r.Field<DateTime?>("BirthDate"),
                                                NullField = r.Field<decimal?>("NullField")
                                           }).ToList();
        }
    }
}
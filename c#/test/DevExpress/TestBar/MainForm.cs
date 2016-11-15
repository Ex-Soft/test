using System;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TestBar
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            riReferenceSelect.DataSource = GetDataTable();
            riReferenceSelect.ValueMember = "id";
            riReferenceSelect.DisplayMember = "Name";
            riReferenceSelect.Columns.Clear();
            riReferenceSelect.Columns.Add(new LookUpColumnInfo("Name"));
            riReferenceSelect.ShowHeader = false;
            riReferenceSelect.ShowFooter = false;

        }

        static DataTable GetDataTable()
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
            tmpDataColumn.Caption = "Идентификатор";
            tmpDataTable.Columns.Add("Name", typeof(string)).Caption = "Ф.И.О.";
            tmpDataTable.Columns.Add("Salary", typeof(decimal)).Caption = "Зряплата";
            tmpDataTable.Columns.Add("Dep", typeof(int)).Caption = "Отдел";
            tmpDataTable.Columns.Add("BirthDate", typeof(DateTime)).Caption = "ДР";
            tmpDataTable.PrimaryKey = new[] { tmpDataTable.Columns[idPropertyName] };

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
            tmpDataRow["Dep"] = 2;
            tmpDataRow["BirthDate"] = new DateTime(1878, 12, 18);
            tmpDataTable.Rows.Add(tmpDataRow);

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Сидоров Сидор Сидорович";
            tmpDataRow["Salary"] = 100;
            tmpDataRow["Dep"] = 3;
            tmpDataRow["BirthDate"] = new DateTime(1894, 4, 17);
            tmpDataTable.Rows.Add(tmpDataRow);

            return tmpDataTable;
        }

    }
}

using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;

namespace TestExportToXls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            gridControl.DataSource = GetDataTable();

            var repositoryItemTextEditPCI = new RepositoryItemTextEdit();
            repositoryItemTextEditPCI.Mask.MaskType = MaskType.Numeric;
            //repositoryItemTextEditPCI.Mask.EditMask = "# ##0.00%%";
            repositoryItemTextEditPCI.DisplayFormat.FormatString = "# ##0.00%";
            repositoryItemTextEditPCI.EditFormat.FormatString = "# ##0.00%";
            repositoryItemTextEditPCI.Mask.UseMaskAsDisplayFormat = false;

            var repositoryItemTextEditPCII = new RepositoryItemTextEdit();
            repositoryItemTextEditPCII.Mask.MaskType = MaskType.Numeric;
            repositoryItemTextEditPCI.Mask.EditMask = "# ##0.00%%";
            repositoryItemTextEditPCII.DisplayFormat.FormatString = "# ##0.00%";
            repositoryItemTextEditPCII.EditFormat.FormatString = "# ##0.00%";
            repositoryItemTextEditPCII.Mask.UseMaskAsDisplayFormat = true;

            gridControl.RepositoryItems.Add(repositoryItemTextEditPCI);
            gridControl.RepositoryItems.Add(repositoryItemTextEditPCII);
            gridView.Columns.ColumnByFieldName("PC I").ColumnEdit = repositoryItemTextEditPCI;
            gridView.Columns.ColumnByFieldName("PC II").ColumnEdit = repositoryItemTextEditPCII;
        }

        static DataTable GetDataTable()
        {
            const string idPropertyName = "id";

            var tmpDataTable = new DataTable("TableName", "TableNamespace");
            var tmpDataColumn = tmpDataTable.Columns.Add(idPropertyName, typeof(long));

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
            tmpDataTable.Columns.Add("PC I", typeof(decimal)).Caption = "PC I";
            tmpDataTable.Columns.Add("PC II", typeof(decimal)).Caption = "PC II";
            tmpDataTable.PrimaryKey = new[] { tmpDataTable.Columns[idPropertyName] };

            var tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Иванов Иван Иванович";
            tmpDataRow["Salary"] = 100;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1870, 4, 22);
            tmpDataRow["PC I"] = 33;
            tmpDataRow["PC II"] = 0.44;
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

        private void btnDoIt_Click(object sender, EventArgs e)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));
            var outputFileName = Path.Combine(currentDirectory, "export.xls");

            if(File.Exists(outputFileName))
                File.Delete(outputFileName);

            gridControl.ExportToXls(outputFileName);
        }
    }
}

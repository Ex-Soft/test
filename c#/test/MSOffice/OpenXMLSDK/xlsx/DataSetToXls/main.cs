using System;
using System.Data;
using System.IO;

namespace DataSetToXls
{
    class Program
    {
        static void Main()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            DataSet dataSet = CreateDataSet();

            dataSet.WriteXml(Path.Combine(currentDirectory, dataSet.DataSetName + ".xml"));

            Exporter exporter = new Exporter();
            string errorMessage;

            exporter.Export(dataSet, currentDirectory, out errorMessage);
        }

        static DataSet CreateDataSet()
        {
            DataSet dataSet = new DataSet("TestDataSet");

            CreateDataTable(dataSet, "TestDataTable #1");
            CreateDataTable(dataSet, "TestDataTable #2");
            CreateDataTable(dataSet, "TestDataTable #3");
            CreateDataTable(dataSet);

            return dataSet;
        }

        static DataTable CreateDataTable(DataSet dataSet, string dataTableName)
        {
            DataTable dataTable = dataSet.Tables.Add(dataTableName);

            DataColumn
                tmpDataColumn;

            string
                idPropertyName = "id";

            tmpDataColumn = dataTable.Columns.Add(idPropertyName, typeof(long));
            tmpDataColumn.AllowDBNull = false;
            tmpDataColumn.Unique = true;
            tmpDataColumn.AutoIncrement = true;
            tmpDataColumn.AutoIncrementSeed = -1;
            tmpDataColumn.AutoIncrementStep = -1;
            tmpDataColumn.Caption = "Идентификатор";
            dataTable.Columns.Add("FString", typeof(string)).Caption = "Строка";
            dataTable.Columns.Add("FInt", typeof(int)).Caption = "Целое";
            dataTable.Columns.Add("FDateTime", typeof(DateTime)).Caption = "ДатаВремя";
            dataTable.Columns.Add("FBool", typeof(bool)).Caption = "Логический";
            dataTable.Columns.Add("FCombo", typeof(string)).Caption = "Combo";
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[idPropertyName] };

            DataRow
                tmpDataRow;

            tmpDataRow = dataTable.NewRow();
            tmpDataRow["FString"] = string.Format("{0} (\"{1}\")", "Иванов Иван Иванович", dataTable.TableName);
            tmpDataRow["FInt"] = 100;
            tmpDataRow["FDateTime"] = new DateTime(2013, 1, 1);
            tmpDataRow["FBool"] = true;
            tmpDataRow["FCombo"] = "1st";
            dataTable.Rows.Add(tmpDataRow);

            tmpDataRow = dataTable.NewRow();
            tmpDataRow["FString"] = string.Format("{0} (\"{1}\")", "Петров Петр Петрович", dataTable.TableName);
            tmpDataRow["FInt"] = 200;
            tmpDataRow["FDateTime"] = new DateTime(2013, 2, 1);
            tmpDataRow["FBool"] = false;
            tmpDataRow["FCombo"] = "2nd";
            dataTable.Rows.Add(tmpDataRow);

            tmpDataRow = dataTable.NewRow();
            tmpDataRow["FString"] = string.Format("{0} (\"{1}\")", "Line# 1\r\nLine# 2\r\nLine# 3", dataTable.TableName);
            tmpDataRow["FInt"] = 300;
            tmpDataRow["FDateTime"] = new DateTime(2013, 3, 1);
            tmpDataRow["FBool"] = false;
            tmpDataRow["FCombo"] = "3rd";
            dataTable.Rows.Add(tmpDataRow);

            return dataTable;
        }

        static DataTable CreateDataTable(DataSet dataSet)
        {
            DataTable dataTable = dataSet.Tables.Add("Дата");

            DataColumn
                tmpDataColumn;

            string
                idPropertyName = "id";

            tmpDataColumn = dataTable.Columns.Add(idPropertyName, typeof(long));
            tmpDataColumn.AllowDBNull = false;
            tmpDataColumn.Unique = true;
            tmpDataColumn.AutoIncrement = true;
            tmpDataColumn.AutoIncrementSeed = -1;
            tmpDataColumn.AutoIncrementStep = -1;
            tmpDataColumn.Caption = "Идентификатор";
            dataTable.Columns.Add("Value", typeof(string)).Caption = "Значение";
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[idPropertyName] };

            DataRow
                tmpDataRow;

            tmpDataRow = dataTable.NewRow();
            tmpDataRow["Value"] = "1st";
            dataTable.Rows.Add(tmpDataRow);

            tmpDataRow = dataTable.NewRow();
            tmpDataRow["Value"] = "2nd";
            dataTable.Rows.Add(tmpDataRow);

            tmpDataRow = dataTable.NewRow();
            tmpDataRow["Value"] = "3rd";
            dataTable.Rows.Add(tmpDataRow);

            return dataTable;
        }
    }
}

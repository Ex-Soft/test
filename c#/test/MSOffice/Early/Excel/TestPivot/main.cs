using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace TestPivot
{
    public enum ExcelVersion
    {
        Excel, // before 2010, so 32 bits
        ExcelX32,
        ExcelX64
    }

    class Programm
    {
        static void Main(string[] args)
        {
            string
                currentDirectory = System.IO.Directory.GetCurrentDirectory();

            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            Application excel = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            PivotCaches pivotCaches = null;

            try
            {
                excel = new Application();
                excel.Visible = true;
                excel.DisplayAlerts = false;
                excel.UserControl = false;

                Console.WriteLine(GetExcelVersion(excel));
                Console.WriteLine(_GetExcelVersion_(excel));

                workbooks = excel.Workbooks;
                workbook = workbooks.Add(currentDirectory + "SaleBuyPoints.xls");
                pivotCaches = workbook.PivotCaches();

                /*
                foreach (WorkbookConnection connection in workbook.Connections)
                {
                    if (connection.Type == XlConnectionType.xlConnectionTypeODBC)
                        connection.ODBCConnection.Connection = "ODBC;DRIVER=SQL Server;SERVER=(local);UID=chicago_reports;PWD=poiUYT56;APP=Microsoft Office 2003;WSID=R-EXEL;DATABASE=chicago_2_11_0";
                    else if (connection.Type == XlConnectionType.xlConnectionTypeOLEDB)
                        connection.OLEDBConnection.Connection = "OLEDB;Provider=SQLOLEDB.1;Password=poiUYT56;Persist Security Info=True;User ID=chicago_reports;Data Source=i-nozhenko;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=I-NOZHENKO;Use Encryption for Data=False;Tag with column collation when possible=False;Initial Catalog=chicago_2_11_0";
                }
                */

                foreach (PivotCache pivotCache in pivotCaches)
                {
                    try
                    {
                        pivotCache.SavePassword = true;
                        //pivotCache.Connection = "ODBC;DRIVER=SQL Server;SERVER=(local);UID=chicago_reports;PWD=poiUYT56;APP=Microsoft Office 2003;WSID=R-EXEL;DATABASE=chicago_2_11_0";
                        pivotCache.Connection = "OLEDB;Provider=SQLOLEDB.1;Password=poiUYT56;Persist Security Info=True;User ID=chicago_reports;Data Source=i-nozhenko;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=I-NOZHENKO;Use Encryption for Data=False;Tag with column collation when possible=False;Initial Catalog=chicago_2_11_0";
                        pivotCache.CommandText = "EXEC Reports.report_xls_SalesBuyPoints @paramStart = '20111101', @paramEnd = '20111130', @enDistributors = '', @idPosition = '', @Goods_Type = 'True', @Unit_Type = 'False', @idPhysicalPerson = '0', @guid = '7f2c17c072a04b3492966e5896722590', @need_empty=0";
                        //pivotCache.CommandText = new string[] {"EXEC Reports.report_xls_SalesBuyPoints @paramStart = '20111101', @paramEnd = '20111130', @enDistributors = '', @idPosition = '', @Goods_Type = 'True', @Unit_Type = 'False', @id", "PhysicalPerson = '0', @guid = '7f2c17c072a04b3492966e5896722590', @need_empty=0" };
                        pivotCache.SavePassword = false;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.ToString());
                    }
                    finally
                    {
                        if (pivotCache != null)
                            Marshal.ReleaseComObject(pivotCache);
                    }
                }
            }
            finally
            {
                if (pivotCaches!=null)
                {
                    Marshal.ReleaseComObject(pivotCaches);
                    pivotCaches = null;
                }
                if (workbook != null)
                {
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (workbooks != null)
                {
                    Marshal.ReleaseComObject(workbooks);
                    workbooks = null;
                }
                if (excel != null)
                {
                    excel.Quit();
                    Marshal.ReleaseComObject(excel);
                    excel = null;
                }

                GC.GetTotalMemory(true);
            }
        }

        public static ExcelVersion GetExcelVersion(object applicationClass)
        {
            if (applicationClass == null)
                throw new ArgumentNullException("applicationClass");

            PropertyInfo
                property = applicationClass.GetType().GetProperty("HinstancePtr", BindingFlags.Instance | BindingFlags.Public);

            if (property == null)
                return ExcelVersion.Excel;

            return (Marshal.SizeOf(property.GetValue(applicationClass, null)) == 8) ? ExcelVersion.ExcelX64 : ExcelVersion.ExcelX32;
        }

        public static int _GetExcelVersion_(_Application excel)
        {
            if (excel == null)
                throw new ArgumentNullException("applicationClass");

            PropertyInfo
                property = excel.GetType().GetProperty("Version", BindingFlags.Instance | BindingFlags.Public);

            if (property == null)
                return 0;

            Regex
                r = new Regex(@"^(\d*)\..*$");

            Match
                match = r.Match(excel.Version);

            if (match.Success && match.Groups.Count > 1)
                return Convert.ToInt32(match.Groups[1].Value);

            return 0;
        }

    }
}

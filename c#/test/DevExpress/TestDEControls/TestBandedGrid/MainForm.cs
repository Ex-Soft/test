using System;
using System.Data;
using System.IO;
using DevExpress.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraPrinting;

namespace TestBandedGrid
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            SetBandedGridView();
            gridControl.DataSource = GetDataTable();
        }

        private static DataTable GetDataTable()
        {
            var dt = new DataTable();

            dt.Columns.AddRange(new[]
            {
                new DataColumn("CustomerId", typeof (Int32)),
                new DataColumn("NotMapped", typeof (Int32)),
                new DataColumn("LastName", typeof (String)),
                new DataColumn("FirstName", typeof (String)),
                new DataColumn("PLZ", typeof (Int32)),
                new DataColumn("City", typeof (String)),
                new DataColumn("Street", typeof (String))
            });

            dt.Rows.Add(1, 0, "John", "Barista", 80245, "Manhatten", "Broadway");
            dt.Rows.Add(2, 0, "Mike", "Handyman", 87032, "Brooklyn", "Martin Luther Drive");
            dt.Rows.Add(3, 0, "Jane", "Teacher", 80245, "Manhatten", "Broadway 7");
            dt.Rows.Add(4, 0, "Quentin", "Producer", 80245, "Manhatten", "Broadway 15");

            return dt;
        }

        void SetGridBand(BandedGridView bandedView, string gridBandCaption, string[] columnNames)
        {
            var gridBand = new GridBand();
            gridBand.Caption = gridBandCaption;
            int nrOfColumns = columnNames.Length;
            BandedGridColumn[] bandedColumns = new BandedGridColumn[nrOfColumns];
            for (int i = 0; i < nrOfColumns; i++)
            {
                bandedColumns[i] = bandedView.Columns.AddField(columnNames[i]);
                bandedColumns[i].OwnerBand = gridBand;
                bandedColumns[i].Visible = true;
            }
        }

        void SetBandedGridView()
        {
            SetGridBand(bandedView, "Customer", new string[3] {"CustomerId", "LastName", "FirstName"});
            SetGridBand(bandedView, "Address", new string[3] {"PLZ", "City", "Street"});
        }

        private void SimpleButtonClick(object sender, EventArgs e)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));
            var outputFileName = Path.Combine(currentDirectory, "export.xlsx");

            if (File.Exists(outputFileName))
                File.Delete(outputFileName);

            ExportSettings.DefaultExportType = ExportType.WYSIWYG;
            bandedView.ExportToXlsx(outputFileName);

            //var xlsxExportOptionsEx = new XlsxExportOptionsEx();
            //xlsxExportOptionsEx.ExportType = ExportType.WYSIWYG;
           
            //bandedView.ExportToXlsx(outputFileName, xlsxExportOptionsEx);
        }
    }
}

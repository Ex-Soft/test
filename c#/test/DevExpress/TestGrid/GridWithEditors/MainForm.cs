using System;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Helpers;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace GridWithEditors
{
    public partial class MainForm : XtraForm
    {
        private const int MainDataMaxRowsCount = 10;
        private const int LookUpDataMaxRowsCount = 3;

        private const string TableNameWithMainData = "DataMain";
        private const string TableNameWithLookUpData = "DataLookUp";
        
        private const string FieldNameWithId = "Id";
        private const string FieldNameWithString = "FString";
        private const string FieldNameWithLookUp = "FLookUp";
        private const string FieldNameWithGridLookUp = "FGridLookUp";
        private const string FieldNameWithBoolean = "FBoolean";
        private const string FieldNameWithMix = "FMix";

        private readonly DataSet _dataSet;

        private readonly RepositoryItemCheckEdit _repositoryItemCheckEdit = new RepositoryItemCheckEdit();
        private readonly RepositoryItemLookUpEdit _repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();

        public MainForm()
        {
            InitializeComponent();

            _dataSet = GenerateDataSet();

            SetDataSource(_dataSet.Tables[TableNameWithMainData]);

            gridView.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown; // https://www.devexpress.com/Support/Center/Question/Details/Q295448 In order to edit checkbox column 2 click is needed, how do I get around that?

            gridView.Columns[FieldNameWithLookUp].ColumnEdit = CreateLookUpEditor();
            gridView.Columns[FieldNameWithGridLookUp].ColumnEdit = CreateGridLookUpEditor();
            gridView.BestFitColumns();

            gridView.ShowingEditor += GridView_ShowingEditor;
            gridView.ShownEditor += GridView_ShownEditor;

            gridView.CellValueChanging += GridView_CellValueChanging;
            gridView.CellValueChanged += GridView_CellValueChanged;

            gridView.HiddenEditor += GridView_HiddenEditor;

            gridView.CustomRowCellEditForEditing += GridView_CustomRowCellEditForEditing;
            gridView.CustomRowCellEdit += GridView_CustomRowCellEdit;
        }

        private void GridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CustomRowCellEdit()");
        }

        private void GridView_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CustomRowCellEditForEditing()");

            if (e.Column.FieldName != FieldNameWithMix)
                return;

            bool tmpBool;
            if (bool.TryParse(e.CellValue.ToString(), out tmpBool))
            {
                _repositoryItemCheckEdit.ValueChecked = true;
                _repositoryItemCheckEdit.ValueUnchecked = false;
                e.RepositoryItem = _repositoryItemCheckEdit;
            }

            int tmpInt;
            if (int.TryParse(e.CellValue.ToString(), out tmpInt))
            {
                _repositoryItemLookUpEdit.DataSource = _dataSet.Tables[TableNameWithLookUpData];
                e.RepositoryItem = _repositoryItemLookUpEdit;
            }
        }

        private void GridView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GridView.ShowingEditor()");
        }

        private void GridView_ShownEditor(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GridView.ShownEditor()");
        }

        private void GridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GridView.CellValueChanging()");

            LookUpEdit lookUpEdit;
            if (e.Column.FieldName == FieldNameWithLookUp
                && (int)e.Value == 2
                && (lookUpEdit = gridView.ActiveEditor as LookUpEdit) != null)
            {
                //lookUpEdit.ItemIndex = 0;
            }
        }

        private void GridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GridView.CellValueChanged()");

            if (e.Column.FieldName == FieldNameWithLookUp && (int)e.Value == 2)
            {
                gridView.ActiveEditor.EditValue = 0;
            }
        }

        private void GridView_HiddenEditor(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("GridView.HiddenEditor()");
        }

        private RepositoryItemLookUpEdit CreateLookUpEditor()
        {
            // Create an in-place LookupEdit control.
            var riLookup = new RepositoryItemLookUpEdit();
            riLookup.DataSource = _dataSet.Tables[TableNameWithLookUpData];
            riLookup.ValueMember = FieldNameWithId;
            riLookup.DisplayMember = FieldNameWithString;

            // Enable the "best-fit" functionality mode in which columns have proportional widths and the popup window is resized to fit all the columns.
            riLookup.BestFitMode = BestFitMode.BestFitResizePopup;
            // Specify the dropdown height.
            riLookup.DropDownRows = _dataSet.Tables[TableNameWithLookUpData].Rows.Count;

            // Enable the automatic completion feature. In this mode, when the dropdown is closed, 
            // the text in the edit box is automatically completed if it matches a DisplayMember field value of one of dropdown rows. 
            riLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            // Specify the column against which an incremental search is performed in SearchMode.AutoComplete and SearchMode.OnlyInPopup modes
            riLookup.AutoSearchColumnIndex = 1;

            // Optionally hide the Description column in the dropdown.
            riLookup.PopulateColumns();
            riLookup.Columns[FieldNameWithId].Visible = false;
            riLookup.ShowHeader = false;

            riLookup.EditValueChanging += RepositoryItemLookUpEdit_EditValueChanging;
            riLookup.EditValueChanged += RepositoryItemLookUpEdit_EditValueChanged;

            //riLookup.EditValueChangedFiringMode = EditValueChangedFiringMode.Default;

            return riLookup;
        }

        private void RepositoryItemLookUpEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            LookUpEdit lookUpEdit;

            if ((lookUpEdit = sender as LookUpEdit) == null)
                return;

            if ((int)e.NewValue == 2)
                e.Cancel = true;
        }

        private void RepositoryItemLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit;

            if ((lookUpEdit = sender as LookUpEdit) == null)
                return;

            //var displayValue = lookUpEdit.Properties.GetDisplayValueByKeyValue(e.NewValue);
        }

        private RepositoryItemGridLookUpEdit CreateGridLookUpEditor()
        {
            var riGridLookup = new RepositoryItemGridLookUpEdit();
            riGridLookup.ValueMember = FieldNameWithId;
            riGridLookup.DisplayMember = FieldNameWithString;

            riGridLookup.View.PopulateColumns(_dataSet.Tables[TableNameWithLookUpData]); // https://www.devexpress.com/Support/Center/Question/Details/Q296392
            riGridLookup.DataSource = _dataSet.Tables[TableNameWithLookUpData];
            riGridLookup.View.Columns[FieldNameWithId].Visible = false;

            riGridLookup.View.OptionsView.ShowColumnHeaders = false;
            riGridLookup.View.OptionsView.ShowIndicator = false;

            riGridLookup.View.RowStyle += GridLookUpEdit_View_RowStyle;
            riGridLookup.EditValueChanging += GridLookUpEdit_EditValueChanging;

            riGridLookup.EditValueChangedFiringMode = EditValueChangedFiringMode.Default;

            return riGridLookup;
        }

        private void GridLookUpEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if ((int)e.NewValue == 2)
                e.Cancel = true;
        }

        private void GridLookUpEdit_View_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView _gridView;
            DataRowView rowView;
            if (e.RowHandle < 0
                || (_gridView = sender as GridView) == null
                || (rowView = _gridView.GetRow(e.RowHandle) as DataRowView) == null
                || rowView.Row.IsNull(FieldNameWithId)
                || Convert.ToInt32(rowView.Row[FieldNameWithId]) < 2)
                return;
            
            var appearance = new AppearanceObject();
            appearance.ForeColor = Color.Red;
            e.CombineAppearance(appearance);
        }

        private void SetDataSource(DataTable dataTable)
        {
            gridControl.DataSource = dataTable;
        }

        private static DataSet GenerateDataSet()
        {
            var result = new DataSet();

            result.Tables.Add(GenerateTableWithMainData());
            result.Tables.Add(GenerateTableWithLookUpData());

            var relationName = "LookUp_MainData";

            if (!result.Tables[TableNameWithMainData].Constraints.Contains($"fk{relationName}"))
                result.Tables[TableNameWithMainData].Constraints.Add(new ForeignKeyConstraint($"fk{relationName}", result.Tables[TableNameWithLookUpData].Columns[FieldNameWithId], result.Tables[TableNameWithMainData].Columns[FieldNameWithLookUp]));
            if (!result.Relations.Contains(relationName))
                result.Relations.Add(new DataRelation(relationName, result.Tables[TableNameWithLookUpData].Columns[FieldNameWithId], result.Tables[TableNameWithMainData].Columns[FieldNameWithLookUp]));

            relationName = "GridLookUp_MainData";

            if (!result.Tables[TableNameWithMainData].Constraints.Contains($"fk{relationName}"))
                result.Tables[TableNameWithMainData].Constraints.Add(new ForeignKeyConstraint($"fk{relationName}", result.Tables[TableNameWithLookUpData].Columns[FieldNameWithId], result.Tables[TableNameWithMainData].Columns[FieldNameWithGridLookUp]));
            if (!result.Relations.Contains(relationName))
                result.Relations.Add(new DataRelation(relationName, result.Tables[TableNameWithLookUpData].Columns[FieldNameWithId], result.Tables[TableNameWithMainData].Columns[FieldNameWithGridLookUp]));

            result.AcceptChanges();

            return result;
        }

        private static DataTable GenerateTableWithMainData()
        {
            return FillTableWithMainData(CreateTableWithMainData());
        }

        private static DataTable GenerateTableWithLookUpData()
        {
            return FillTableWithLookUpData(CreateTableWithLookUpData());
        }

        private static DataTable CreateTableWithMainData()
        {
            var result = new DataTable(TableNameWithMainData);

            result.Columns.Add(FieldNameWithId, typeof(int));
            result.Columns.Add(FieldNameWithString, typeof(string));
            result.Columns.Add(FieldNameWithLookUp, typeof(int));
            result.Columns.Add(FieldNameWithGridLookUp, typeof(int));
            result.Columns.Add(FieldNameWithBoolean, typeof(bool));
            result.Columns.Add(FieldNameWithMix, typeof(string));
            result.PrimaryKey = new[] { result.Columns[FieldNameWithId] };

            return result;
        }

        private static DataTable CreateTableWithLookUpData()
        {
            var result = new DataTable(TableNameWithLookUpData);

            result.Columns.Add(FieldNameWithId, typeof(int));
            result.Columns.Add(FieldNameWithString, typeof(string));
            result.PrimaryKey = new[] { result.Columns[FieldNameWithId] };

            return result;
        }

        private static DataTable FillTableWithMainData(DataTable dataTable)
        {
            for (var i = 0; i < MainDataMaxRowsCount; ++i)
            {
                var row = dataTable.NewRow();

                row[FieldNameWithId] = i;
                row[FieldNameWithString] = $"Row {i}";
                row[FieldNameWithLookUp] = i % LookUpDataMaxRowsCount;
                row[FieldNameWithGridLookUp] = i % LookUpDataMaxRowsCount;
                row[FieldNameWithBoolean] = i % 2 == 1;
                row[FieldNameWithMix] = i % 2 == 1 ? (i % LookUpDataMaxRowsCount).ToString() : "True";
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private static DataTable FillTableWithLookUpData(DataTable dataTable)
        {
            for (var i = 0; i < LookUpDataMaxRowsCount; ++i)
            {
                var row = dataTable.NewRow();

                row[FieldNameWithId] = i;
                row[FieldNameWithString] = $"Row {i}";

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}

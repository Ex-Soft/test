using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace TestOverridedGrid
{
    public class OverridedGridView : GridView
    {
        public OverridedGridView() : base()
        {
            InitDefaultSettings();
        }

        public OverridedGridView(GridControl ownerGrid) : base(ownerGrid)
        {
            InitDefaultSettings();
        }

        private void InitDefaultSettings()
        {
            OptionsBehavior.Editable = false;

            OptionsSelection.MultiSelect = true;
            OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

            OptionsView.ShowGroupPanel = false;
            OptionsView.ShowFooter = true;
        }

        protected override void OnPopulateColumns()
        {
            System.Diagnostics.Debug.WriteLine("protected override void OnPopulateColumns()");
            base.OnPopulateColumns();
            if (!DesignMode && (DataController != null))
                PatchColumns();
        }

        public override void PopulateColumns()
        {
            System.Diagnostics.Debug.WriteLine("public override void PopulateColumns()");
            base.PopulateColumns();
        }

        private void PatchColumns()
        {
            System.Diagnostics.Debug.WriteLine("private void PatchColumns()");

            for (var i = 0; i < Columns.Count; ++i)
            {
                var column = Columns[i];
                var columnInfo = DataController.Columns[column.FieldName];

                switch (i)
                {
                    case 0:
                        {
                            column.OptionsColumn.ReadOnly = true;
                            break;
                        }
                    case 1:
                        {
                            column.OptionsColumn.ReadOnly = false;
                            break;
                        }
                    case 2:
                        {
                            column.OptionsColumn.AllowEdit = true;
                            break;
                        }
                    case 3:
                        {
                            column.OptionsColumn.AllowEdit = false;
                            break;
                        }
                }

                column.ColumnEdit = new RepositoryItemTextEdit();
            }
        }
    }
}

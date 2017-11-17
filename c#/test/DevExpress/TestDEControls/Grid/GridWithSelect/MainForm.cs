#define TEST_CHECK_BOX_ROW_SELECT
#define TEST_CHECK_BOX_ROW_SELECT_DISABLE_CHECK_BOX // https://www.devexpress.com/Support/Center/Question/Details/Q445275

using System;
using System.Drawing;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using GridWithSelect.Db;

namespace GridWithSelect
{
    public partial class MainForm : XtraForm
    {
        #if TEST_CHECK_BOX_ROW_SELECT && TEST_CHECK_BOX_ROW_SELECT_DISABLE_CHECK_BOX
            private CheckEdit _checkEdit;
        #endif

        public MainForm()
        {
            InitializeComponent();

            XpoDefault.ConnectionString = MSSqlConnectionProvider.GetConnectionString("i-nozhenko", "sa", "123", "testdb");
            
            #if TEST_CHECK_BOX_ROW_SELECT
                gridView.OptionsSelection.MultiSelect = true;
                gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

                gridView.SelectionChanged += GridView_SelectionChanged;

                #if TEST_CHECK_BOX_ROW_SELECT_DISABLE_CHECK_BOX
                    gridView.CustomDrawCell += GridView_CustomDrawCell;
                #endif
            #endif
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            var session = new Session();

            SetDataSource(session);

            #if TEST_CHECK_BOX_ROW_SELECT && TEST_CHECK_BOX_ROW_SELECT_DISABLE_CHECK_BOX
                _checkEdit = new CheckEdit { Text = string.Empty };
                _checkEdit.Properties.GlyphAlignment = HorzAlignment.Center;
            #endif
        }
    
        #if TEST_CHECK_BOX_ROW_SELECT

            private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("gridView.SelectionChanged");
            }

            #if TEST_CHECK_BOX_ROW_SELECT_DISABLE_CHECK_BOX

                private void GridView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
                {
                    if (e.Column.FieldName != "DX$CheckboxSelectorColumn" /*e.Column.AbsoluteIndex != -1*/)
                        return;
            
                    ObjectState state;
                    var value = IsNeedDisable(e, gridView);
                    if (value)
                    {
                        _checkEdit.Enabled = true;
                        state = ObjectState.Normal;
                    }
                    else
                    {
                        _checkEdit.Enabled = false;
                        state = ObjectState.Disabled;
                    }

                    DrawCheckBox(e.Graphics, new Rectangle(e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Convert.ToBoolean(e.CellValue), state);

                    e.Handled = true;
                }

                private bool IsNeedDisable(RowCellCustomDrawEventArgs e, GridView gridView)
                {
                    return (bool)gridView.GetRowCellValue(e.RowHandle, gridView.Columns[2]);
                }

                protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked, ObjectState state)
                {
                    CheckEditViewInfo info;
                    CheckEditPainter painter;
                    ControlGraphicsInfoArgs args;

                    _checkEdit.EditValue = Checked;

                    info = _checkEdit.Properties.CreateViewInfo() as CheckEditViewInfo;
                    painter = _checkEdit.Properties.CreatePainter() as CheckEditPainter;

                    info.State = state;

                    //info.Appearance.BackColor = Color.White;
                    //info.AppearanceDisabled.BackColor = Color.Aqua;
                    info.Item.UseParentBackground = true;

                    info.EditValue = Checked;
                    info.Bounds = r;

                    info.CalcViewInfo(g);
                    args = new ControlGraphicsInfoArgs(info, new GraphicsCache(g), r);

                    painter.Draw(args);
                    args.Cache.Dispose();
                }
            #endif
        #endif

        private void SetDataSource(Session session)
        {
            var classInfo = session.GetClassInfo(typeof(TestTable4Types));
            var xpCollection = new XPCollection(session, classInfo);

            gridControl.DataSource = xpCollection;
        }
    }
}

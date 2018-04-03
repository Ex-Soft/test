//#define FIX

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using DevExpress.Utils;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;

namespace TestVGrid
{
    public partial class MainForm : XtraForm
    {
        private readonly DateTimeFormatInfo _dateTimeFormatInfo;

        public MainForm()
        {
            InitializeComponent();

            _dateTimeFormatInfo = new DateTimeFormatInfo
            {
                ShortDatePattern = "yyyy.dd.MM",
                LongDatePattern = "yyyy.dd.MM H:mm:ss",
                ShortTimePattern = "H:mm",
                LongTimePattern = "H:mm:ss"
            };

            var categoryRow = new CategoryRow("CategoryRow1");
            vGridControl.Rows.Add(categoryRow);

            var editRow1 = new EditorRow { Name = "EditorRow1" };
            editRow1.Properties.Caption = "EditorRow1";
            editRow1.Properties.Value = 2;
            editRow1.Properties.RowEdit = GetLookUpEditor();
            categoryRow.ChildRows.Add(editRow1);

            var editRow2 = new EditorRow { Name = "EditorRow2" };
            editRow2.Properties.Caption = "EditorRow2";
            editRow2.Properties.Value = 3;
            editRow2.Properties.RowEdit = GetLookUpEditor();
            editRow2.Properties.RowEdit.EditValueChanged += RowEditOnEditValueChanged;
            categoryRow.ChildRows.Add(editRow2);

            var editRow3 = new EditorRow { Name = "EditorRow3" };
            editRow3.Properties.Caption = "EditorRow3";
            editRow3.Properties.Value = 4;
            editRow3.Properties.RowEdit = GetLookUpEditor();
            categoryRow.ChildRows.Add(editRow3);

            var editRowDateOnly = new EditorRow { Name = "EditorRowDateOnly" };
            editRowDateOnly.Properties.Caption = "EditorRowDateOnly";
            editRowDateOnly.Properties.RowEdit = GetDateOnlyEditor();
            categoryRow.ChildRows.Add(editRowDateOnly);

            var editRowTimeOnly = new EditorRow { Name = "EditorRowTimeOnly" };
            editRowTimeOnly.Properties.Caption = "EditorRowTimeOnly";
            editRowTimeOnly.Properties.RowEdit = GetTimeOnlyEditor();
            categoryRow.ChildRows.Add(editRowTimeOnly);

            var editRowDateTime = new EditorRow { Name = "EditorRowDateTime" };
            editRowDateTime.Properties.Caption = "EditorRowDateTime";
            editRowDateTime.Properties.RowEdit = GetDateTimeEditor();
            categoryRow.ChildRows.Add(editRowDateTime);
        }

        private void RowEditOnEditValueChanged(object sender, EventArgs eventArgs)
        {
            BaseEdit baseEdit;
            EditorRow row2, row3;

            if ((baseEdit = sender as BaseEdit) == null
                || (row2 = FindRow(vGridControl.Rows[vGridControl.Rows.Count - 1].ChildRows, "EditorRow2")) == null
                || (row3 = FindRow(vGridControl.Rows[vGridControl.Rows.Count - 1].ChildRows, "EditorRow3")) == null)
                return;

            #if FIX
                var tmpNewEditValue = baseEdit.EditValue;
            #endif

            Debug.WriteLine($"before: baseEdit.EditValue={baseEdit.EditValue}, row2.Properties.Value={row2.Properties.Value}, row3.Properties.Value={row3.Properties.Value}");
            vGridControl.PostEditor();
            row3.Properties.Value = null;
            Debug.WriteLine($"after : baseEdit.EditValue={baseEdit.EditValue}, row2.Properties.Value={row2.Properties.Value}, row3.Properties.Value={row3.Properties.Value}");

            #if FIX
                row2.Properties.Value = tmpNewEditValue;
            #endif
        }

        private void BtnShowValueClick(object sender, EventArgs e)
        {
            foreach (EditorRow row in vGridControl.Rows[vGridControl.Rows.Count - 1].ChildRows)
            {
                Debug.WriteLine($"\"{row.Name}\"={row.Properties.Value}");

                try
                {
                    var tmpDateTime = Convert.ToDateTime(row.Properties.Value, _dateTimeFormatInfo);
                }
                catch (Exception eException)
                {
                    Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
                }
            }
        }

        private static EditorRow FindRow(IEnumerable rows, string rowName)
        {
            return rows.OfType<EditorRow>().FirstOrDefault(item => item.Name == rowName);
        }

        private static RepositoryItemLookUpEdit GetLookUpEditor()
        {
            const string valueMember = "Id";

            var repositoryItemLookUpEdit = new RepositoryItemLookUpEdit
            { 
                DataSource = new[] {new {Id = 1, Value = "1.1"}, new {Id = 2, Value = "1.2"}, new {Id = 3, Value = "1.3"}, new {Id = 4, Value = "1.4"}, new {Id = 5, Value = "1.5"}},
                ShowHeader = false,
                ShowFooter = false,
                ValueMember = valueMember,
                DisplayMember = "Value"
            };
            repositoryItemLookUpEdit.PopulateColumns();
            repositoryItemLookUpEdit.Columns[valueMember].Visible = false;

            return repositoryItemLookUpEdit;
        }

        protected RepositoryItem GetDateTimeEditor()
        {
            return GetDateEditorCore(_dateTimeFormatInfo.LongDatePattern);
        }

        protected RepositoryItem GetDateOnlyEditor()
        {
            return GetDateEditorCore(_dateTimeFormatInfo.ShortDatePattern);
        }

        protected RepositoryItem GetTimeOnlyEditor()
        {
            var editor = new RepositoryItemTimeEdit
            {
                AllowNullInput = DefaultBoolean.False,
                EditValueChangedFiringMode = EditValueChangedFiringMode.Default,
            };

            editor.DisplayFormat.FormatString = _dateTimeFormatInfo.LongTimePattern;
            editor.Mask.EditMask = _dateTimeFormatInfo.LongTimePattern;
            editor.Mask.UseMaskAsDisplayFormat = true;

            return editor;
        }

        private RepositoryItem GetDateEditorCore(string mask)
        {
            var editor = new RepositoryItemDateEdit
            {
                VistaDisplayMode = DefaultBoolean.True,
                VistaEditTime = DefaultBoolean.True,
                MinValue = new DateTime(1900, 1, 1)
            };

            editor.DisplayFormat.FormatString = mask;
            editor.Mask.EditMask = mask;
            editor.Mask.UseMaskAsDisplayFormat = true;

            editor.ParseEditValue += delegate (object sender, ConvertEditValueEventArgs e)
            {
                if ((e.Value != null) && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    DateTime dateTime;
                    if (DateTime.TryParse(e.Value.ToString(), _dateTimeFormatInfo, DateTimeStyles.None, out dateTime))
                        e.Value = dateTime;
                    e.Handled = true;
                }
            };

            editor.FormatEditValue += delegate (object sender, ConvertEditValueEventArgs e)
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    DateTime dateTime;
                    if (DateTime.TryParse(e.Value.ToString(), _dateTimeFormatInfo, DateTimeStyles.None, out dateTime))
                        e.Value = dateTime;
                    e.Handled = true;
                }
            };

            return editor;
        }
    }
}

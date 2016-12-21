using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace TestDEControls
{
    public partial class MainForm : XtraForm
    {
	// DxFtsContainsHelperAlt. private static bool AllowColumn(FindColumnInfo column, ref object value, ref FilterCondition filterCondition) проверка подходит ли введенное для поиска значение для колонки

        EditObjectWithBool editObjectWithBool = new EditObjectWithBool();
        EditObjectWithNullableBool editObjectWithNullableBool = new EditObjectWithNullableBool();
        EditObjectWithDevExpressDefaultBoolean editObjectWithDevExpressDefaultBoolean = new EditObjectWithDevExpressDefaultBoolean();
        EditObjectWithInt editObjectWithInt = new EditObjectWithInt();

        bool
            _boolVictim4CheckBox,
            _boolVictim4ToggleSwitch,
            _pictureEditMenuCustomized;

        DefaultBoolean
            _defaultBooleanVictim4ToggleSwitch;

        List<Action<object, EventArgs>> listOfAction = new List<Action<object, EventArgs>>();

        public bool BoolVictim4CheckBox
        {
            get
            {
                return _boolVictim4CheckBox;
            }
            set
            {
                if (_boolVictim4CheckBox == value)
                    return;

                _boolVictim4CheckBox = value;
                AddToLog(string.Format("\"BoolVictim4CheckBox\" has been changed \"{0}\" -> \"{1}\"", !_boolVictim4CheckBox, _boolVictim4CheckBox));
            }
        }

        public bool BoolVictim4ToggleSwitch
        {
            get
            {
                return _boolVictim4ToggleSwitch;
            }
            set
            {
                if (_boolVictim4ToggleSwitch == value)
                    return;

                _boolVictim4ToggleSwitch = value;
                AddToLog(string.Format("\"BoolVictim4ToggleSwitch\" has been changed \"{0}\" -> \"{1}\"", !_boolVictim4ToggleSwitch, _boolVictim4ToggleSwitch));
            }
        }

        public DefaultBoolean DefaultBooleanVictim4ToggleSwitch
        {
            get
            {
                return _defaultBooleanVictim4ToggleSwitch;
            }
            set
            {
                if (_defaultBooleanVictim4ToggleSwitch == value)
                    return;

                AddToLog(string.Format("\"DefaultBooleanVictim4ToggleSwitch\" has been changed \"{0}\" -> \"{1}\"", _defaultBooleanVictim4ToggleSwitch, value));
                _defaultBooleanVictim4ToggleSwitch = value;
            }
        }

        string _stringVictim;

        public string StringVictim
        {
            get
            {
                return _stringVictim;
            }
            set
            {
                if (_stringVictim == value)
                    return;

                AddToLog(string.Format("\"StringVictim\" has been changed \"{0}\" -> \"{1}\"", _stringVictim, value));
                _stringVictim = value;
            }
        }

        public decimal DecimalVictim { get; set; }

        Binding
            _textEdit3Binding,
            _toggleSwitch2Binding;

        public MainForm()
        {
            InitializeComponent();

            //textEdit4.ReadOnly = true;
            textEdit4.Properties.Appearance.Image = global::TestDEControls.Properties.Resources.save_16x16;
            textEdit4.Properties.Appearance.Options.UseImage = true;
            textEdit4.Properties.AppearanceFocused.Image = global::TestDEControls.Properties.Resources.save_16x16;
            textEdit4.Properties.AppearanceFocused.Options.UseImage = true;
            textEdit4.Properties.AppearanceDisabled.Image = global::TestDEControls.Properties.Resources.save_16x16;
            textEdit4.Properties.AppearanceDisabled.Options.UseImage = true;
            textEdit4.Properties.AppearanceReadOnly.Image = global::TestDEControls.Properties.Resources.save_16x16;
            textEdit4.Properties.AppearanceReadOnly.Options.UseImage = true;

            btnSet.Visible = false;

            _boolVictim4CheckBox = _boolVictim4ToggleSwitch = true;
            _defaultBooleanVictim4ToggleSwitch = DefaultBoolean.True;
            _stringVictim = "123456789012";

            _textEdit3Binding = textEdit3.DataBindings.Add("EditValue", this, "StringVictim", true, DataSourceUpdateMode.OnPropertyChanged);
            _textEdit3Binding.BindingComplete += TextEdit3BindingBindingComplete;
            _textEdit3Binding.Format += TextEdit3BindingFormat;
            _textEdit3Binding.Parse += TextEdit3BindingParse;
            textEdit3.CustomDisplayText += TextEdit3CustomDisplayText;

            //tabControl.SelectedTabPage = tabPageButtons;

            lookUpEdit1.Properties.DataSource = GetDataTable();
            lookUpEdit1.Properties.ValueMember = "id";
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.Properties.Columns.Clear();
            lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Name"));
            lookUpEdit1.Properties.ShowHeader = false;
            lookUpEdit1.Properties.ShowFooter = false;

            lookUpEdit2.Properties.DataSource = GetListStubsWithIdBool();
            lookUpEdit2.Properties.ValueMember = "Id";
            lookUpEdit2.Properties.DisplayMember = "Name";
            lookUpEdit2.Properties.Columns.Clear();
            lookUpEdit2.Properties.Columns.Add(new LookUpColumnInfo("Name"));
            lookUpEdit2.Properties.ShowHeader = false;
            lookUpEdit2.Properties.ShowFooter = false;
            //lookUpEdit2.DataBindings.Add("EditValue", editObjectWithBool, "FBool", false, DataSourceUpdateMode.OnPropertyChanged);
            lookUpEdit2.DataBindings.Add("EditValue", editObjectWithNullableBool, "FBool", false, DataSourceUpdateMode.OnPropertyChanged);

            lookUpEdit3.Properties.DataSource = GetListStubsWithIdInt();
            lookUpEdit3.Properties.ValueMember = "Id";
            lookUpEdit3.Properties.DisplayMember = "Name";
            lookUpEdit3.Properties.Columns.Clear();
            lookUpEdit3.Properties.Columns.Add(new LookUpColumnInfo("Name"));
            lookUpEdit3.Properties.ShowHeader = false;
            lookUpEdit3.Properties.ShowFooter = false;
            lookUpEdit3.DataBindings.Add("EditValue", editObjectWithInt, "FInt", false, DataSourceUpdateMode.OnPropertyChanged);

            lookUpEdit4.Properties.DataSource = GetListStubsWithIdDevExpressDefaultBoolean();
            lookUpEdit4.Properties.ValueMember = "Id";
            lookUpEdit4.Properties.DisplayMember = "Name";
            lookUpEdit4.Properties.Columns.Clear();
            lookUpEdit4.Properties.Columns.Add(new LookUpColumnInfo("Name"));
            lookUpEdit4.Properties.ShowHeader = false;
            lookUpEdit4.Properties.ShowFooter = false;
            lookUpEdit4.DataBindings.Add("EditValue", editObjectWithDevExpressDefaultBoolean, "FBool", false, DataSourceUpdateMode.OnPropertyChanged);
            
            textEdit1.Properties.Mask.MaskType = MaskType.RegEx;
            textEdit1.Properties.Mask.EditMask = "a{1,3}";
            textEdit1.Properties.Mask.AutoComplete = AutoCompleteType.None;

            gridControl1.DataSource = GetDataTable();

            var repositoryItemComboBox = new RepositoryItemComboBox();
            repositoryItemComboBox.Items.AddRange(new[] { 1, 2, 3 });

            // https://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsHyperLinkEdit_OpenLinktopic
            var repositoryItemHyperLinkEdit = new RepositoryItemHyperLinkEdit();
            repositoryItemHyperLinkEdit.SingleClick = true;
            //repositoryItemHyperLinkEdit.ReadOnly = true;
            repositoryItemHyperLinkEdit.TextEditStyle = TextEditStyles.DisableTextEditor;

            var repositoryItemSpinEdit = new RepositoryItemSpinEdit();
            repositoryItemSpinEdit.DisplayFormat.FormatString = "0.###############";
            repositoryItemSpinEdit.DisplayFormat.FormatType = FormatType.Numeric;
            repositoryItemSpinEdit.Mask.EditMask = "n15";
            repositoryItemSpinEdit.MaxLength = 30;
            repositoryItemSpinEdit.MaxValue = 79228162514264.337593543950335m;
            
            gridControl1.RepositoryItems.Add(repositoryItemComboBox);
            gridControl1.RepositoryItems.Add(repositoryItemHyperLinkEdit);
            gridControl1.RepositoryItems.Add(repositoryItemSpinEdit);
            gridView1.Columns.ColumnByFieldName("Dep").ColumnEdit = repositoryItemComboBox;
            gridView1.Columns.ColumnByFieldName("Url").ColumnEdit = repositoryItemHyperLinkEdit;
            gridView1.Columns.ColumnByFieldName("Salary").ColumnEdit = repositoryItemSpinEdit;

            repositoryItemComboBox.EditValueChanging += RepositoryItemComboBoxOnEditValueChanging;
            repositoryItemComboBox.EditValueChanged += RepositoryItemComboBoxOnEditValueChanged;

            gridView1.CustomRowCellEdit += GridViewOnCustomRowCellEdit;
            //gridView1.OptionsBehavior.Editable = false;
            gridView1.Click += gridViewClick;
            //gridView1.CustomDrawRowIndicator += GridViewCustomDrawRowIndicatorFake;

            checkEdit4.DataBindings.Add("EditValue", this, "BoolVictim4CheckBox", false, DataSourceUpdateMode.OnPropertyChanged);
            //checkEdit4.DataBindings.Add("EditValue", this, "BoolVictim4CheckBox", false, DataSourceUpdateMode.OnValidation);

            //pictureEdit.Enabled = false;
            pictureEdit.ReadOnly = true;
            pictureEdit.Properties.ReadOnly = true;
            pictureEdit.Properties.AllowFocused = false;
            //pictureEdit.Properties.ShowMenu = false;

            var assembly = typeof(PictureMenu).Assembly;
            var imageList = ImageHelper.CreateImageCollectionFromResources("DevExpress.XtraEditors.Images.PictureMenu.png", typeof(PictureMenu).Assembly, new Size(0x10, 0x10), Color.Empty);

            Image img = null;
            try
            {
                img = ResourceImageHelper.CreateBitmapFromResources("DevExpress.XtraEditors.ImageEdit.bmp", typeof(ButtonEdit).Assembly);
                img.Save("ImageEdit.bmp");
                imageList = ImageHelper.CreateImageCollectionFromResources("DevExpress.XtraEditors.Images.Editors.bmp", typeof(PictureMenu).Assembly, new Size(0x10, 0x10), Color.Empty);
                imageList.Images[12].Save("12.bmp");
                //img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("DevExpress.XtraEditors.Images.Editors.bmp"));
            }
            catch (Exception)
            {
            }

            comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            comboBoxEdit1.Properties.Items.AddRange(Enumerable.Range(65, 26).Select(item => (object)(new string((char)item, 10))).ToArray());

            //timeEdit1.Properties.ReadOnly = true;
            timeEdit1.Enabled = false;

            listOfAction.Add(GridViewCustomDrawRowIndicatorFake);

            DecimalVictim = 1.123456789010000m;
            //DecimalVictim = 0.00000001m;

            spinEdit1.DataBindings.Add("EditValue", this, "DecimalVictim", false, DataSourceUpdateMode.OnPropertyChanged);
            //spinEdit1.EditValueChanged += SpinEditEditValueChanged;
            //spinEdit1.CustomDisplayText += SpinEditCustomDisplayText;

            toggleSwitch1.DataBindings.Add("EditValue", this, "BoolVictim4ToggleSwitch", false, DataSourceUpdateMode.OnPropertyChanged);
            _toggleSwitch2Binding = toggleSwitch2.DataBindings.Add(/*"EditValue"*/ "IsOn", this, "DefaultBooleanVictim4ToggleSwitch", true, DataSourceUpdateMode.OnPropertyChanged);
            _toggleSwitch2Binding.Parse += ToggleSwitchBindingParse;
            _toggleSwitch2Binding.Format += ToggleSwitchBindingFormat;
            _toggleSwitch2Binding.BindingComplete += ToggleSwitchBindingBindingComplete;

            buttonEdit1.ReadOnly = true;
            buttonEdit1.ButtonClick += ButtonEdit1_ButtonClick;
            buttonEdit1.Properties.Buttons[1].Enabled = false;
            buttonEdit1.EditValue = "blah-blah-blah";
        }

        private void ButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit;
            if ((buttonEdit = sender as ButtonEdit) == null)
                return;

            Debug.WriteLine(string.Format("\"{0}\" \"{1}\"", buttonEdit.Name, e.Button.Kind));
        }

        void ToggleSwitchBindingBindingComplete(object sender, BindingCompleteEventArgs e)
        {
            AddToLog(string.Format("ToggleSwitchBindingBindingComplete: {0} {1}", e.BindingCompleteContext, e.BindingCompleteState));
        }

        void ToggleSwitchBindingFormat(object sender, ConvertEventArgs e)
        {
            AddToLog(string.Format("ToggleSwitchBindingFormat: DesiredType = \"{0}\", typeof(Value) = \"{1}\"", e.DesiredType, e.Value.GetType()));

            if (e.DesiredType == typeof(DefaultBoolean))
                e.Value = (bool)e.Value ? DefaultBoolean.True : DefaultBoolean.False;
            else if (e.DesiredType == typeof(Object) || e.DesiredType == typeof(bool))
                e.Value = (DefaultBoolean)e.Value == DefaultBoolean.True;
        }

        void ToggleSwitchBindingParse(object sender, ConvertEventArgs e)
        {
            AddToLog(string.Format("ToggleSwitchBindingParse: DesiredType = \"{0}\", typeof(Value) = \"{1}\"", e.DesiredType, e.Value.GetType()));

            if (e.DesiredType == typeof (DefaultBoolean))
                e.Value = (bool)e.Value ? DefaultBoolean.True : DefaultBoolean.False;
            else if (e.DesiredType == typeof(Object) || e.DesiredType == typeof(bool))
                e.Value = (DefaultBoolean)e.Value == DefaultBoolean.True;
        }

        void SpinEditCustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if ((Decimal)e.Value == 0m)
                return;

            e.DisplayText = e.DisplayText.TrimEnd(new char[] { '0' });
            return;

            SpinEdit spinEdit;

            if ((spinEdit = sender as SpinEdit) == null)
                return;

            var regex = new Regex("0+$");
            var match = regex.Match(e.DisplayText);

            if (match.Success)
                e.DisplayText = regex.Replace(e.DisplayText, string.Empty);
        }

        void GridViewCustomDrawRowIndicatorFake(object sender, EventArgs e)
        {
            //listOfAction[0](sender, e);
        }

        void GridViewCustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            var imageCollection = e.Info.ImageCollection as ImageCollection;
            if (imageCollection != null)
            {
                e.Info.ImageIndex = 6;
                e.Info.DisplayText = "blah"; // doesn't work https://www.devexpress.com/Support/Center/Question/Details/Q442514 -> https://documentation.devexpress.com/#WindowsForms/CustomDocument1964
            }
        }

        void TextEdit3CustomDisplayText(object sender, CustomDisplayTextEventArgs customDisplayTextEventArgs)
        {
            // https://documentation.devexpress.com/#WPF/CustomDocument11336
            // https://documentation.devexpress.com/#WindowsForms/DevExpressXtraEditorsRepositoryRepositoryItem_CustomDisplayTexttopic

            if (customDisplayTextEventArgs.Value == null)
                return;

            var valueStr = customDisplayTextEventArgs.Value.ToString();
            var regex = new Regex("(\\d{4})(\\d{4})(\\d{4})");
            var match = regex.Match(valueStr);
            if (match.Success)
                customDisplayTextEventArgs.DisplayText = regex.Replace(valueStr, "$1...$3");
        }

        void TextEdit3BindingParse(object sender, ConvertEventArgs e)
        {
            AddToLog("TextEdit3BindingParse");

            e.Value = "TextEdit3BindingParse";
        }

        void TextEdit3BindingFormat(object sender, ConvertEventArgs e)
        {
            AddToLog("TextEdit3BindingFormat");

            //if (e.DesiredType != typeof(string))
            //    return;

            e.Value = "TextEdit3BindingFormat";
        }

        void TextEdit3BindingBindingComplete(object sender, BindingCompleteEventArgs e)
        {
            AddToLog("TextEdit3BindingBindingComplete");
        }

        //https://www.devexpress.com/Support/Center/Question/Details/Q299763
        void gridViewClick(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs;
            GridHitInfo hi;
            string url;

            if ((mouseEventArgs = e as MouseEventArgs) == null
                || (hi = gridView1.CalcHitInfo(new Point(mouseEventArgs.X, mouseEventArgs.Y))) == null
                || !hi.InRowCell
                || hi.Column == null
                //|| hi.Column != gridView1.Columns["Url"]
                || (hi.Column.ColumnEdit as RepositoryItemHyperLinkEdit) == null
                || string.IsNullOrWhiteSpace(url = gridView1.GetRowCellDisplayText(hi.RowHandle, hi.Column)))
                return;
            
            Process.Start(url);
        }

        private void GridViewOnCustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName != "BirthDate")
                return;

            var ri = e.RepositoryItem;

            AddToLog(string.Format("GridViewOnCustomRowCellEdit: RepositoryItem {0}= null", ReferenceEquals(ri, null) ? "=" : "!"));

            if (ri == null)
                return;

            var t = ri.GetType();

            AddToLog(string.Format("GridViewOnCustomRowCellEdit: typeof(RepositoryItem) = \"{0}\"", t));
        }

        private void RepositoryItemComboBoxOnEditValueChanged(object sender, EventArgs e)
        {
            AddToLog("RepositoryItemComboBoxOnEditValueChanged");
        }

        private void RepositoryItemComboBoxOnEditValueChanging(object sender, ChangingEventArgs e)
        {
            AddToLog(string.Format("RepositoryItemComboBoxOnEditValueChanging: \"{0}\" -> \"{1}\" (Cancel = \"{2}\")", e.OldValue, e.NewValue, e.Cancel));
        }

        private void LookUpEditEditValueChanged(object sender, EventArgs e)
        {
            AddToLog("LookUpEditEditValueChanged");
        }

        private void LookUpEditEditValueChanging(object sender, ChangingEventArgs e)
        {
            AddToLog("LookUpEditEditValueChanging");
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
            tmpDataTable.Columns.Add("TmpBool", typeof(bool)).Caption = "Bool";
            tmpDataTable.Columns.Add("Url", typeof(string));
            tmpDataTable.PrimaryKey = new DataColumn[] { tmpDataTable.Columns[idPropertyName] };

            DataRow
                tmpDataRow;

            tmpDataRow = tmpDataTable.NewRow();
            tmpDataRow["Name"] = "Иванов Иван Иванович";
            tmpDataRow["Salary"] = 1.123456789010000m;
            tmpDataRow["Dep"] = 1;
            tmpDataRow["BirthDate"] = new DateTime(1870, 4, 22);
            tmpDataRow["TmpBool"] = true;
            tmpDataRow["Url"] = "http://google.com.ua/";
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

        static List<StubWithIdBool> GetListStubsWithIdBool()
        {
            return new List<StubWithIdBool>(new[] { new StubWithIdBool(false, "No"), new StubWithIdBool(true, "Yes") });
        }

        static List<StubWithIdDevExpressDefaultBoolean> GetListStubsWithIdDevExpressDefaultBoolean()
        {
            return new List<StubWithIdDevExpressDefaultBoolean>(new[] { new StubWithIdDevExpressDefaultBoolean(DevExpress.Utils.DefaultBoolean.False, "No"), new StubWithIdDevExpressDefaultBoolean(DevExpress.Utils.DefaultBoolean.True, "Yes") });
        }

        static List<StubWithIdInt> GetListStubsWithIdInt()
        {
            return new List<StubWithIdInt>(new[] { new StubWithIdInt(0, "No"), new StubWithIdInt(1, "Yes") });
        }

        void AddToLog(string message)
        {
            message = DateTime.Now.ToString("HH:mm:ss.fffffff tt") + " " + message;

            if (listBoxControlLog.InvokeRequired)
                listBoxControlLog.Invoke(new MethodInvoker(() => listBoxControlLog.Items.Add(message + " (InvokeRequired)")));
            else
                listBoxControlLog.Items.Add(message + " (!InvokeRequired)");
        }

        void BtnDoItClick(object sender, EventArgs e)
        {
            AddToLog(string.Format("lookUpEdit2.EditValue = {0}", lookUpEdit2.EditValue));
            AddToLog(string.Format("editObjectWithNullableBool.FBool = {0}", editObjectWithNullableBool.FBool.HasValue ? editObjectWithNullableBool.FBool.ToString() : "null"));

            AddToLog(string.Format("lookUpEdit3.EditValue = {0}", lookUpEdit3.EditValue));
            AddToLog(string.Format("editObjectWithInt.FInt = {0}", editObjectWithInt.FInt));

            AddToLog(string.Format("lookUpEdit4.EditValue = {0}", lookUpEdit4.EditValue));
            AddToLog(string.Format("editObjectWithDevExpressDefaultBoolean.FBool = {0}", editObjectWithDevExpressDefaultBoolean.FBool));
        }

        private void BtnSetClick(object sender, EventArgs e)
        {
            lookUpEdit4.EditValue = lookUpEdit4.EditValue !=null && (DefaultBoolean)lookUpEdit4.EditValue == DefaultBoolean.True ? DefaultBoolean.False : DefaultBoolean.True;
        }

        private void BtnSetChkBoxValueClick(object sender, EventArgs e)
        {
            checkEdit3.EditValue = DefaultBoolean.Default;
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            // https://www.devexpress.com/Support/Center/Question/Details/Q504181
            // https://documentation.devexpress.com/#WindowsForms/CustomDocument4874
            // https://documentation.devexpress.com/#WindowsForms/CustomDocument15721

            // Access the controller that manages tooltips for all controls:
            ToolTipController defaultTooltipController = DevExpress.Utils.ToolTipController.DefaultController;

            // Create and customize a SuperToolTip:
            SuperToolTip sTooltip = new SuperToolTip();
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            args.Title.Text = "Header";
            args.Contents.Text = "This tooltip contains a hyperlink. Visit the <href=http://help.devexpress.com>DevExpress Knowledge Center</href> to learn more.";
            args.ShowFooterSeparator = true;
            args.Footer.Text = "Footer";
            sTooltip.Setup(args);
            // Enable HTML Text Formatting for the created SuperToolTip:
            sTooltip.AllowHtmlText = DefaultBoolean.True;
            //..or enable this feature for all tooltips:
            //defaultTooltipController.AllowHtmlText = true;

            // Respond to clicking hyperlinks in tooltips:
            defaultTooltipController.HyperlinkClick += defaultTooltipController_HyperlinkClick;

            // Assign a SuperToolTip to the button:
            memoEdit1.SuperTip = sTooltip;
        }

        void defaultTooltipController_HyperlinkClick(object sender, HyperlinkClickEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = (e.Link);
            process.StartInfo.Verb = "open";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                process.Start();
            }
            catch { }
        }

        private void CheckEditCheckedChanged(object sender, EventArgs e)
        {
            AddToLog("CheckEditCheckedChanged");
        }

        private void CheckEditCheckStateChanged(object sender, EventArgs e)
        {
            AddToLog("CheckEditCheckStateChanged");
        }

        private void CheckEditClick(object sender, EventArgs e)
        {
            AddToLog("CheckEditClick");
        }

        private void CheckEditEditValueChanged(object sender, EventArgs e)
        {
            AddToLog("CheckEditEditValueChanged");
        }

        private void CheckEditEditValueChanging(object sender, ChangingEventArgs e)
        {
            AddToLog(string.Format("CheckEditEditValueChanging: \"{0}\" -> \"{1}\" (Cancel = \"{2}\")", e.OldValue, e.NewValue, e.Cancel));
        }

        private void TabPageWithPictureBtnLoadClick(object sender, EventArgs e)
        {
            string errorMessage;

            pictureEdit.Image = Misc.LoadPictureByUri("http://localhost/JavaScript/test/pix/xpfirewall.jpg", out errorMessage);

            if (!string.IsNullOrWhiteSpace(errorMessage))
                AddToLog(errorMessage);
        }

        private void TabPageWithPictureBtnTestClick(object sender, EventArgs e)
        {
            if (sender != null)
                ;
        }

        void PictureEditPopupMenuShowing(object sender, DevExpress.XtraEditors.Events.PopupMenuShowingEventArgs e)
        {
            if (_pictureEditMenuCustomized)
                return;

            var menuItemsForDelete = new List<StringId>(new[]
            {
                DevExpress.XtraEditors.Controls.StringId.PictureEditMenuZoom,
                DevExpress.XtraEditors.Controls.StringId.PictureEditMenuSave,
                DevExpress.XtraEditors.Controls.StringId.PictureEditMenuPaste,
                DevExpress.XtraEditors.Controls.StringId.PictureEditMenuCopy,
                DevExpress.XtraEditors.Controls.StringId.PictureEditMenuCut
            });

            for (var i = e.PopupMenu.Items.Count - 1; i >= 0; --i)
            {
                DXMenuItem menuItem;
                StringId tag;

                if (menuItemsForDelete.Contains(tag = (StringId)(menuItem = e.PopupMenu.Items[i]).Tag))
                {
                    e.PopupMenu.Items.Remove(menuItem);
                    continue;
                }

                menuItem.Enabled = true;

                switch (tag)
                {
                    case StringId.PictureEditMenuLoad:
                    {
                        //menuItem.Click += MenuItemClick;
                        //menuItem.BindCommand(this, () => "blah");
                        break;
                    }
                    case StringId.PictureEditMenuDelete:
                    {
                        var customMenuItem = new DXMenuItem(menuItem.Caption, (_sender, _e) => MenuItemClick(_sender, _e, "blah"), menuItem.Image);
                        e.PopupMenu.Items.Remove(menuItem);
                        e.PopupMenu.Items.Insert(i, customMenuItem);
                        break;
                    }
                }
            }

            _pictureEditMenuCustomized = true;
        }

        void MenuItemClick(object sender, EventArgs e, string smthParam)
        {
            Debug.WriteLine("MenuItemClick");
        }

        public void Execute(object p)
        {
            Debug.WriteLine("Execute");
        }

        private void MenuItemToolStripMenuItemClick(object sender, EventArgs e)
        {
            Clipboard.SetText("http://www.google.com/");
        }

        private void BarButtonItemItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarManager barManager;
            BarButtonItem mainBarButtonItem;

            if ((barManager = sender as BarManager) == null
                || (mainBarButtonItem = barManager.Items.OfType<BarButtonItem>().FirstOrDefault(item => ReferenceEquals(e.Link.LinkedObject, item.DropDownControl))) == null)
                return;

            mainBarButtonItem.Glyph = e.Item.Glyph;
            mainBarButtonItem.Caption = e.Item.Caption;
        }

        private void CheckEditEnableDisableBarButtonCheckedChanged(object sender, EventArgs e)
        {
            barButtonItem1.Enabled = checkEditEnableDisableBarButton.Checked;
        }

        private void BarButtonItem1ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void textEdit4_Enter(object sender, EventArgs e)
        {
            Debug.WriteLine("textEdit4_Enter()");
        }

        private void textEdit4_Leave(object sender, EventArgs e)
        {
            Debug.WriteLine("textEdit4_Leave()");
        }

        private void comboBoxEdit1_Spin(object sender, SpinEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Spin");
        }

        void comboBoxEdit1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MouseWheel");
        }

        void SpinEditEditValueChanged(object sender, EventArgs e)
        {
            SpinEdit spinEdit;

            if ((spinEdit = sender as SpinEdit) == null)
                return;
        }

        //this.hyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.HyperLinkEditOpenLink);
        //private void HyperLinkEditOpenLink(object sender, OpenLinkEventArgs e)
        //{
        //    e.EditValue
        //}
    }
}

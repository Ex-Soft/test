using System.Windows.Forms;
using DevExpress.XtraEditors;
using TestDEControlsII.Db;

namespace TestDEControlsII
{
    public partial class ValidationForm1 : XtraForm
    {
        private TestValidate _testValidate;

        public TestValidate TestValidate
        {
            get { return _testValidate; }
            set { _testValidate = value; }
        }

        public ValidationForm1()
        {
            _testValidate = new TestValidate(true, "StringValue1", "StringValue2");

            InitializeComponent();

            checkEdit1.DataBindings.Add(new Binding("EditValue", TestValidate, "BoolValue", true, DataSourceUpdateMode.OnPropertyChanged));

            textEdit1.DataBindings.Add(new Binding("Enabled", TestValidate, "BoolValue", true, DataSourceUpdateMode.OnPropertyChanged));
            textEdit1.DataBindings.Add(new Binding("EditValue", TestValidate, "StringValue1", true, DataSourceUpdateMode.OnPropertyChanged));

            textEdit2.DataBindings.Add(new Binding("ReadOnly", TestValidate, "BoolValue", true, DataSourceUpdateMode.OnPropertyChanged));
            textEdit2.DataBindings.Add(new Binding("EditValue", TestValidate, "StringValue2", true, DataSourceUpdateMode.OnPropertyChanged));

            dxErrorProvider1.DataSource = TestValidate;
        }
    }
}

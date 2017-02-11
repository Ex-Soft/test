using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace TestDE16WinApp
{
    public partial class GridForm2 : XtraForm
    {
        public GridForm2()
        {
            InitializeComponent();
            gridControl.DataSource = CreateData();
        }

        private static IEnumerable<string> CreateData()
        {
            var result = new List<string>();

            for (var i = 0; i < 5; ++i)
                result.Add(new string((char)(i + 0x30), 1600));

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace TestDE16WinApp
{
    public partial class GridForm3 : XtraForm
    {
        public GridForm3()
        {
            InitializeComponent();
            gridControl.DataSource = CreateData();
        }

        private static IEnumerable<string> CreateData()
        {
            var result = new List<string>();

            for (var i = 0; i < 26; ++i)
            {
                string str = String.Empty;

                for (var j = 0; j < 5; ++j)
                {
                    if (!string.IsNullOrWhiteSpace(str))
                        str += " ";

                    str += new string((char)(i + 0x41), 1);
                }

                result.Add(str);
            }
            return result;
        }
    }
}

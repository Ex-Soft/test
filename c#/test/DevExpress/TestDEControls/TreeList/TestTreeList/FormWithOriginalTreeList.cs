using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using DevExpress.XtraEditors;

namespace TestTreeList
{
    public partial class FormWithOriginalTreeList : XtraForm
    {
        public FormWithOriginalTreeList()
        {
            InitializeComponent();

            treeList.DataSource = Form1.GetData();
        }

        private void BtnGetCheckedClick(object sender, System.EventArgs e)
        {
            if (!(treeList.DataSource is List<Data> data))
                return;

            Debug.WriteLine(data.Where(item => item.Selected).Aggregate(string.Empty, (str, item) => { if (!string.IsNullOrWhiteSpace(str)) str += ", "; return str + item.Val; }));
        }
    }
}

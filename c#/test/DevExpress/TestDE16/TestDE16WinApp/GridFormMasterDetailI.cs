using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using TestDE16WinApp.Db;

namespace TestDE16WinApp
{
    public partial class GridFormMasterDetailI : XtraForm
    {
        public GridFormMasterDetailI()
        {
            InitializeComponent();
            gridControl.DataSource = new XPCollection(unitOfWork, typeof(TestMaster));
            //gridControl.DataSource = new XPServerCollectionSource(unitOfWork, typeof(TestMaster));
            //gridControl.DataSource = GetTestMasterCollection(1);

            gridControl.ViewRegistered += GridControl_ViewRegistered;

            gridView.OptionsDetail.ShowDetailTabs = false;
            //gridView.OptionsDetail.EnableMasterViewMode = false;
        }

        private void GridControl_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            if (sender == null)
                return;
        }

        private void simpleButtonDoIt_Click(object sender, System.EventArgs e)
        {
            //var collection = gridControl.DataSource as ICollection<TestMaster>;
            var collection = gridControl.DataSource as XPCollection;
            if (collection == null)
                return;

            collection.Add(CreateTestMaster(collection.Count, 100));

            (gridControl.MainView as GridView).SetMasterRowExpanded(collection.Count - 1, true);
        }

        private ICollection<TestMaster> GetTestMasterCollection(int count)
        {
            var list = new List<TestMaster>();

            for(var i = 0; i < count; ++i)
                list.Add(CreateTestMaster(i, 3));

            return list;
        }

        private TestMaster CreateTestMaster(int i, int detailsCount)
        {
            var master = new TestMaster(unitOfWork);
            master.Val = i.ToString();
            master.Details.AddRange(CreateTestDetailCollection(master, detailsCount));
            return master;
        }

        private IEnumerable<TestDetail> CreateTestDetailCollection(TestMaster master, int count)
        {
            var list = new List<TestDetail>();

            for (var i = 0; i < count; ++i)
                list.Add(CreateTestDetail(master, i));

            return list;

        }

        private TestDetail CreateTestDetail(TestMaster master, int val)
        {
            var detail = new TestDetail(unitOfWork);
            detail.Master = master;
            detail.Val = val.ToString();
            return detail;
        }
    }
}

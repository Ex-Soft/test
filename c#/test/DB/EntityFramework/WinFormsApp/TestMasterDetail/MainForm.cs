using System;
using System.Windows.Forms;
using System.Data.Entity;
using System.ComponentModel;
using System.Linq;

namespace TestMasterDetail
{
    public partial class MainForm : Form
    {
        TestDbContext db = null;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            db = new TestDbContext();

            db.Masters.Load();
            masterBindingSource.DataSource = db.Masters.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            db.Dispose();
        }

        private void MasterBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            Validate();

            foreach (var detail in db.Details.Local.ToList())
            {
                if (detail.Master == null)
                {
                    db.Details.Remove(detail);
                }
            }

            db.SaveChanges();

            masterDataGridView.Refresh();
            detailsDataGridView.Refresh();
        }
    }
}

using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Forms;
using TestGridView.Models;

namespace TestGridView
{
    public partial class MainForm : Form
    {
        testdbContext db = null;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            db = new testdbContext();

            db.Staffs.Load();

            staffBindingSource.DataSource = db.Staffs.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            db.Dispose();
        }

        private void StaffBindingNavigatorSaveItemClick(object sender, EventArgs e)
        {
            Validate();
            db.SaveChanges();
            staffDataGridView.Refresh();
        }
    }
}

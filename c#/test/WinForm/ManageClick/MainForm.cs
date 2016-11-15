// http://stackoverflow.com/questions/91778/how-to-remove-all-event-handlers-from-a-control

using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace ManageClick
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnSetClick(object sender, EventArgs e)
        {
            btnVictim.Click += BtnVictimClick;
        }

        private void BtnResetClick(object sender, EventArgs e)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(btnVictim);
            PropertyInfo pi = btnVictim.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(btnVictim, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void BtnVictimClick(object sender, EventArgs e)
        {
            MessageBox.Show("BtnVictimClick");
        }
    }
}

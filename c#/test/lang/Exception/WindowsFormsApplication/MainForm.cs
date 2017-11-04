using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonException_Click(object sender, EventArgs e)
        {
            throw new Exception("MainForm.Exception");
        }

        private void buttonAggregateException_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Factory.StartNew(Run);
            }
            catch (AggregateException eException)
            {
                Debug.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (int j = 0; j < eException.InnerExceptions.Count; j++)
                {
                    Debug.WriteLine("\n-------------------------------------------------\n{0}", eException.InnerExceptions[j].ToString());
                }
            }
        }

        private void Run()
        {
            throw new Exception("MainForm.Run.Exception");
        }
    }
}

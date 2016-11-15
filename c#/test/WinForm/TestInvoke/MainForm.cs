using System;
using System.Threading;
using System.Windows.Forms;

namespace TestInvoke
{
    public partial class MainForm : Form
    {
        public delegate void AddListItem(string message);
        public AddListItem AddListItemDelegate;
        Thread _thread;

        public MainForm()
        {
            InitializeComponent();
            AddListItemDelegate = AddListItemMethod;
        }

        void BtnInvokeClick(object sender, EventArgs e)
        {
            _thread = new Thread(ThreadFunction);
            _thread.Start();
        }
        
        void ThreadFunction()
        {
            var testThreadClassObject = new TestThreadClass(this);
            testThreadClassObject.Run();
        }

        public void AddListItemMethod(string message)
        {
            listBoxLog.Items.Add(message);
        }
    }

    public class TestThreadClass
    {
        readonly MainForm _mainForm;

        public TestThreadClass(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        string _tmpString;

        public void Run()
        {
            var asyncResult = _mainForm.BeginInvoke(_mainForm.AddListItemDelegate, new Object[] { "BeginInvoke" });
            var result = _mainForm.EndInvoke(asyncResult);

            for (var i = 1; i <= 5; i++)
            {
                _tmpString = string.Format("Step number {0} executed", i);
                Thread.Sleep(400);
                _mainForm.Invoke(_mainForm.AddListItemDelegate, new Object[] { _tmpString });
            }
        }
    }
}

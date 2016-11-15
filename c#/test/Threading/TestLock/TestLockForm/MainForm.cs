using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace TestLockForm
{
    public partial class MainForm : Form
    {
        Form _slaveForm;
        MasterForm _masterForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            if (_slaveForm == null || _slaveForm.IsDisposed || !_slaveForm.IsHandleCreated)
            {
                _slaveForm = new SlaveForm {Location = new Point(Location.X - Size.Width, Location.Y)};
                _slaveForm.Show(this);
            }

            if (_masterForm != null && !_masterForm.IsDisposed && _masterForm.IsHandleCreated)
                return;

            Action<object> action = Run;
            var param = new CreateMasterFormTaskParam { MainForm = this, MasterForm = _masterForm, SlaveForm = _slaveForm};
            Task.Factory.StartNew(Run, param);

            //_masterForm = new MasterForm { Location = new Point(Location.X + Size.Width, Location.Y) };
            //_masterForm.SetSlaveForm(_slaveForm);
            //_masterForm.Show(this);
        }

        void ShowMasterForm(MasterForm form)
        {
            _masterForm = form;
            _masterForm.Show(this);
        }

        void Run(object param)
        {
            CreateMasterFormTaskParam taskParam;

            if ((taskParam = param as CreateMasterFormTaskParam) == null)
                return;

            System.Diagnostics.Debug.WriteLine("Run() started... (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);

            taskParam.MasterForm = new MasterForm { Location = new Point(taskParam.MainForm.Location.X + taskParam.MainForm.Size.Width, taskParam.MainForm.Location.Y) };
            taskParam.MasterForm.SetSlaveForm(taskParam.SlaveForm);

            try
            {
                //if (taskParam.MasterForm.InvokeRequired)
                //taskParam.MasterForm.EndInvoke(taskParam.MasterForm.BeginInvoke(new Action(taskParam.MasterForm.Show), new object[] { taskParam.MainForm }));

                if (!taskParam.MasterForm.IsHandleCreated)
                    taskParam.MasterForm.CreateHandle();
                taskParam.MasterForm.Invoke(new Action(taskParam.MasterForm.Show), new object[] {taskParam.MainForm});
                
                //else
                
                //taskParam.MasterForm.Show(/*taskParam.MainForm*/);
                
                //taskParam.MainForm.Invoke(new Action<MasterForm>(taskParam.MainForm.ShowMasterForm), new object[] { taskParam.MasterForm });
            }
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            System.Diagnostics.Debug.WriteLine("Run() finished (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);
        }
    }
}

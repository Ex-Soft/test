using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCountdownEventWinApp
{
    public partial class MainForm : Form
    {
        private const int DefaultBatchSize = 10;

        private readonly SynchronizationContext _uiContext;

        private readonly CancellationTokenSource _cancellationTokenSourceCommit = new();
        private CountdownEvent _countdownEvent;

        public MainForm()
        {
            InitializeComponent();

            tbCommitBatchSize.Text = DefaultBatchSize.ToString();
            btnCommitCancel.Tag = _cancellationTokenSourceCommit;

            _uiContext = SynchronizationContext.Current;
        }

        private void BtnCancel(object sender, EventArgs e)
        {
            if (sender is not Button { Tag: CancellationTokenSource cancellationTokenSource } button)
                return;

            cancellationTokenSource.Cancel();
            button.Enabled = false;
        }

        private void BtnCommitClick(object sender, EventArgs e)
        {
            if (!int.TryParse(tbCommitBatchSize.Text, out var batchSize))
                batchSize = DefaultBatchSize;

            if (sender is Button button)
                button.Enabled = false;

            try
            {
                Task.Factory.StartNew(() => TestCommit(batchSize, _cancellationTokenSourceCommit, 1));
                //Task.Factory.StartNew(() => TestCommit(batchSize, _cancellationTokenSourceCommit, 2));
            }
            catch (Exception exception)
            {
                WriteToLog(lbCommitLog, exception.Message);
            }
        }

        void TestCommit(int batchSize, CancellationTokenSource cancellationTokenSource, int id)
        {
            var consumer = new Consumer(batchSize, cancellationTokenSource, id);
            consumer.OnBatchStart = OnBatchStart;
            consumer.OnConsume = OnConsume;
            consumer.IsBatchProcessed = IsBatchProcessed;
            consumer.Pulse = Pulse;
            consumer.Consume().Wait();
        }

        void OnBatchStart(int batchSize)
        {
            if (_countdownEvent == null)
                _countdownEvent = new CountdownEvent(batchSize);
            else
                _countdownEvent.Reset();
        }

        void OnConsume()
        {
            try
            {
                _countdownEvent.Signal();
            }
            catch (Exception e)
            {
                WriteToLog(lbCommitLog, e.Message);
            }
        }

        bool IsBatchProcessed()
        {
            _countdownEvent.Wait();
            return true;
        }

        void Pulse(string message)
        {
            WriteToLog(lbCommitLog, message);
        }

        public void WriteToLog(ListBox listBoxLog, string message)
        {
            Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(listBoxLog, message));
        }

        private static void AddToListBoxCallback(object state)
        {
            ListBox listBox;
            if (state is not AddToListBoxParam param || (listBox = param.ListBox) == null)
                return;

            listBox.Items.Insert(0, param.Message);
        }

    }

    public class AddToListBoxParam
    {
        public ListBox ListBox { get; }
        public string Message { get; }

        public AddToListBoxParam(ListBox listBox = null, string message = "")
        {
            ListBox = listBox;
            Message = message;
        }
    }
}

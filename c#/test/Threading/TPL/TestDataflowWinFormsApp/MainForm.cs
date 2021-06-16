using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace TestDataflowWinFormsApp
{
    public partial class MainForm : Form
    {
        private const int MSec = 100;

        private readonly CancellationTokenSource _cancellationTokenSourceMix;
        private readonly BufferBlock<long> _bufferBlockMix;
        private readonly ActionBlock<long> _actionBlockMix;

        private readonly CancellationTokenSource _cancellationTokenSourcePipeline;
        private readonly BufferBlock<OriginalMessage> _bufferBlockPipeline;
        private readonly TransformBlock<OriginalMessage, PreparedMessage> _transformBlockPreparePipeline;
        private readonly TransformBlock<PreparedMessage, TransformedMessage> _transformBlockTransformPipeline;
        private readonly ActionBlock<TransformedMessage> _actionBlockPipelineOk;
        private readonly ActionBlock<TransformedMessage> _actionBlockPipelineError;
        
        private readonly SynchronizationContext _uiContext;

        public MainForm()
        {
            InitializeComponent();

            _uiContext = SynchronizationContext.Current;

            _cancellationTokenSourceMix = new CancellationTokenSource();
            _bufferBlockMix = new BufferBlock<long>(new DataflowBlockOptions { BoundedCapacity = 10 });
            _actionBlockMix = new ActionBlock<long>(ConsumeMix, new ExecutionDataflowBlockOptions { BoundedCapacity = 3 });
            _bufferBlockMix.LinkTo(_actionBlockMix);

            _cancellationTokenSourcePipeline = new CancellationTokenSource();
            _bufferBlockPipeline = new BufferBlock<OriginalMessage>(new DataflowBlockOptions { BoundedCapacity = 10 });
            _transformBlockPreparePipeline = new TransformBlock<OriginalMessage, PreparedMessage>(PreparePipeline, new ExecutionDataflowBlockOptions { BoundedCapacity = 3 });
            _transformBlockTransformPipeline = new TransformBlock<PreparedMessage, TransformedMessage>(TransformPipeline, new ExecutionDataflowBlockOptions { BoundedCapacity = 3 });
            _actionBlockPipelineOk = new ActionBlock<TransformedMessage>(ConsumePipelineOk, new ExecutionDataflowBlockOptions { BoundedCapacity = 3 });
            _actionBlockPipelineError = new ActionBlock<TransformedMessage>(ConsumePipelineError, new ExecutionDataflowBlockOptions { BoundedCapacity = 3 });
            _bufferBlockPipeline.LinkTo(_transformBlockPreparePipeline);
            _transformBlockPreparePipeline.LinkTo(_transformBlockTransformPipeline);
            _transformBlockTransformPipeline.LinkTo(_actionBlockPipelineOk, transformedMessage => transformedMessage.Error == null);
            _transformBlockTransformPipeline.LinkTo(_actionBlockPipelineError, transformedMessage => transformedMessage.Error != null);
        }

        private void ProduceMix(CancellationToken token)
        {
            var data = 1L;
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            while (!token.IsCancellationRequested)
            {
                string message;

                while (!token.IsCancellationRequested && !_bufferBlockMix.Post(data))
                {
                    message = $"!Post({data}) ({_bufferBlockMix.Count})";
                    System.Diagnostics.Debug.WriteLine(message);
                    _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogMix, message));

                    Thread.Sleep(1000);
                }

                message = $"Post({data}) ({_bufferBlockMix.Count})";
                System.Diagnostics.Debug.WriteLine(message);
                _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogMix, message));

                ++data;

                Thread.Sleep(MSec * rnd.Next(10));
            }
        }

        private void ConsumeMix(long data)
        {
            var message = $"{data} ({_actionBlockMix.InputCount})";
            System.Diagnostics.Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogMix, message));

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(MSec * rnd.Next(10));

            if (cbThrowExceptionMix.Checked)
            {
                throw new Exception("blah-blah-blah");
            }
        }

        private void BtnPostMixClick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var ticks = now.Ticks;
            var isPosted = _bufferBlockMix.Post(ticks);

            var message = $"{(!isPosted ? "!" : string.Empty)}Post({ticks}) ({_bufferBlockMix.Count})";
            System.Diagnostics.Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogMix, message));
        }

        private void BtnProduceMixClick(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => ProduceMix(_cancellationTokenSourceMix.Token));
        }

        private void BtnCancelMixClick(object sender, EventArgs e)
        {
            _cancellationTokenSourceMix.Cancel();
        }

        private void ProducePipeline(CancellationToken token)
        {
            var counter = 1L;
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            while (!token.IsCancellationRequested)
            {
                var data = new OriginalMessage(counter, $"#{counter}");
                string message;

                while (!token.IsCancellationRequested && !_bufferBlockPipeline.Post(data))
                {
                    message = $"!Post({data}) ({_bufferBlockMix.Count})";
                    System.Diagnostics.Debug.WriteLine(message);
                    _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogPipeline, message));

                    Thread.Sleep(1000);
                }

                message = $"Post({data}) ({_bufferBlockMix.Count})";
                System.Diagnostics.Debug.WriteLine(message);
                _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogPipeline, message));

                ++counter;

                Thread.Sleep(MSec * rnd.Next(10));
            }
        }

        private PreparedMessage PreparePipeline(OriginalMessage originalMessage)
        {
            var message = $"{originalMessage} ({_transformBlockPreparePipeline.InputCount}/{_transformBlockPreparePipeline.OutputCount})";
            System.Diagnostics.Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogPipeline, message));

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(MSec * rnd.Next(10));

            return new PreparedMessage(originalMessage, originalMessage.Value % 2 == 0 ? TransformOriginalMessage : TransformOriginalMessageThrowException);
        }

        private TransformedMessage TransformOriginalMessage(OriginalMessage originalMessage)
        {
            return new(originalMessage);
        }

        private TransformedMessage TransformOriginalMessageThrowException(OriginalMessage originalMessage)
        {
            throw new Exception(originalMessage.ToString());
        }

        private TransformedMessage TransformPipeline(PreparedMessage preparedMessage)
        {
            var message = $"{preparedMessage} ({_transformBlockTransformPipeline.InputCount}/{_transformBlockTransformPipeline.OutputCount})";
            System.Diagnostics.Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogPipeline, message));

            TransformedMessage transformedMessage = null;
            Exception exception = null;

            try
            {
                transformedMessage = preparedMessage?.Func(preparedMessage.OriginalMessage);
            }
            catch (Exception e)
            {
                exception = e;
            }

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(MSec * rnd.Next(10));

            return transformedMessage ?? new TransformedMessage(preparedMessage?.OriginalMessage, exception != null ? new Error(exception) : null);
        }

        private void ConsumePipelineOk(TransformedMessage transformedMessage)
        {
            var message = $"Ok {transformedMessage} ({_actionBlockPipelineOk.InputCount})";
            System.Diagnostics.Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogPipeline, message));

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(MSec * rnd.Next(10));
        }

        private void ConsumePipelineError(TransformedMessage transformedMessage)
        {
            var message = $"Error {transformedMessage} ({_actionBlockPipelineError.InputCount})";
            System.Diagnostics.Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogPipeline, message));

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(MSec * rnd.Next(10));
        }

        private void BtnPostPipelineClick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var ticks = now.Ticks;
            var data = new OriginalMessage(ticks, $"#{ticks}");
            var isPosted = _bufferBlockPipeline.Post(data);

            var message = $"{(!isPosted ? "!" : string.Empty)}Post({data}) ({_bufferBlockPipeline.Count})";
            System.Diagnostics.Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(lbLogPipeline, message));
        }

        private void BtnProducePipelineClick(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => ProducePipeline(_cancellationTokenSourcePipeline.Token));
        }

        private void BtnCancelPipelineClick(object sender, EventArgs e)
        {
            _cancellationTokenSourcePipeline.Cancel();
        }

        private void BtnClearClick(object sender, EventArgs e)
        {
            if (sender is not Button button)
                return;

            var listBox = Convert.ToString(button.Tag).Equals("Mix", StringComparison.InvariantCultureIgnoreCase) ? lbLogMix : lbLogPipeline;
            listBox.Items.Clear();
        }

        private static void AddToListBoxCallback(object state)
        {
            if (state is not AddToListBoxParam param)
                return;

            param.ListBox?.Items.Add(param.Message);
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

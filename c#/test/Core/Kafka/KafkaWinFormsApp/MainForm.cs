using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.example;

namespace KafkaWinFormsApp
{
    public partial class MainForm : Form
    {
        private const int
            DefaultProduceMax = 1000,
            DefaultProduceMSec = 100,
            DefaultConsumeMin = 3,
            DefaultConsumeMax = 10,
            DefaultConsumeMSec = 100;

        private readonly SynchronizationContext _uiContext;

        private CancellationTokenSource
            _cancellationTokenSourceProduce,
            _cancellationTokenSourceConsume;

        public MainForm()
        {
            InitializeComponent();

            tbProduceMax.Text = DefaultProduceMax.ToString();
            tbProduceMSec.Text = DefaultProduceMSec.ToString();

            tbConsumeMin.Text = DefaultConsumeMin.ToString();
            tbConsumeMax.Text = DefaultConsumeMax.ToString();
            tbConsumeMSec.Text = DefaultConsumeMSec.ToString();

            _uiContext = SynchronizationContext.Current;
        }

        private void BtnProduceCancelClick(object sender, EventArgs e)
        {
            _cancellationTokenSourceProduce?.Cancel();
        }

        private void BtnProduceClick(object sender, EventArgs e)
        {
            _cancellationTokenSourceProduce = new CancellationTokenSource();
            Task.Run(() => Produce(GetProduceParam(), _cancellationTokenSourceProduce.Token));
        }

        private ProduceParam GetProduceParam()
        {
            if (!int.TryParse(tbProduceMax.Text, out var max))
                max = DefaultProduceMax;

            if (!int.TryParse(tbProduceMSec.Text, out var mSec))
                mSec = DefaultProduceMSec;

            return new ProduceParam(max, mSec);
        }

        private void Produce(object param, CancellationToken cancellationToken)
        {
            if (param is not ProduceParam produceParam)
            {
                return;
            }

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            var kafkaProducer = new KafkaProducer<TestTypes>();

            try
            {
                for (var i = 0; i < produceParam.Max; ++i)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var testTypes = new TestTypes
                    {
                        fBoolean = true,
                        fInt = i,
                        fLong = DateTimeOffset.Now.Ticks,
                        fFloat = 13.13F,
                        fDouble = 169.169,
                        fString = DateTimeOffset.Now.ToString("o"),
                        fEnum = (TestEnum)(i % 6)
                    };

                    kafkaProducer.Produce(testTypes);

                    WriteToLog(lbLogProduce,$"Produce: {testTypes.fLong} ({Thread.CurrentThread.ManagedThreadId})");

                    Thread.Sleep(produceParam.MSec * rnd.Next(10));
                }
            }
            catch (OperationCanceledException)
            {
                WriteToLog(lbLogProduce,$"{Thread.CurrentThread.ManagedThreadId} has been canceled");
            }
            catch (Exception eException)
            {
                WriteToLog(lbLogProduce,$"{eException.GetType().FullName}: {eException.Message}");
            }
            finally
            {
                kafkaProducer.Dispose();
                kafkaProducer = null;
            }
        }

        private void BtnConsumeCancelClick(object sender, EventArgs e)
        {
            _cancellationTokenSourceConsume?.Cancel();
        }

        private void BtnConsumeClick(object sender, EventArgs e)
        {
            _cancellationTokenSourceConsume = new CancellationTokenSource();
            Task.Run(() => Consume(GetConsumeParam(), _cancellationTokenSourceConsume.Token));
        }

        private ConsumeParam GetConsumeParam()
        {
            if (!int.TryParse(tbConsumeMin.Text, out var min))
                min = DefaultConsumeMin;

            if (!int.TryParse(tbConsumeMax.Text, out var max))
                max = DefaultConsumeMax;

            if (!int.TryParse(tbConsumeMSec.Text, out var mSec))
                mSec = DefaultConsumeMSec;

            return new ConsumeParam(min, max, mSec);
        }

        private void Processor(TestTypes testTypes)
        {
            if (testTypes?.fLong % 2 == 0)
            {
                throw new Exception(testTypes.fLong.ToString());
            }

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(int.Parse(tbConsumeMSec.Text) * rnd.Next(10));
        }

        private void OnOk(TestTypes testTypes)
        {
            WriteToLog(lbLogConsume,$"OnOk: {testTypes?.fLong}");
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(int.Parse(tbConsumeMSec.Text) * rnd.Next(10));
        }

        private void OnError(TestTypes testTypes)
        {
            WriteToLog(lbLogConsume,$"OnError: {testTypes?.fLong}");
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(int.Parse(tbConsumeMSec.Text) * rnd.Next(10));
        }

        private void Consume(object param, CancellationToken cancellationToken)
        {
            if (param is not ConsumeParam consumeParam)
            {
                return;
            }

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            var kafkaConsumer = new KafkaConsumer<TestTypes>();

            var consumer = new ConsumerBuilder<TestTypes>(consumeParam.Min, consumeParam.Max)
                .SetProcessor(Processor)
                .SetOnOk(OnOk)
                .SetOnError(OnError)
                .Build();

            WriteToLog(lbLogConsume, $"{Thread.CurrentThread.ManagedThreadId}");

            try
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var testTypes = kafkaConsumer.Consume();
                    WriteToLog(lbLogConsume,$"Consume: {(testTypes != null ? testTypes.fLong.ToString() : "null")} ({Thread.CurrentThread.ManagedThreadId})");

                    if (testTypes != null)
                    {
                        consumer.Post(testTypes);
                    }

                    Thread.Sleep(consumeParam.MSec * rnd.Next(10));
                }
            }
            catch (OperationCanceledException)
            {
                WriteToLog(lbLogConsume,$"{Thread.CurrentThread.ManagedThreadId} has been canceled");
            }
            catch (Exception eException)
            {
                WriteToLog(lbLogConsume,$"{eException.GetType().FullName}: {eException.Message}");
            }
            finally
            {
                kafkaConsumer.Dispose();
                kafkaConsumer = null;
            }
        }

        public void WriteToLog(ListBox listBoxLog, string message)
        {
            Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(listBoxLog, message));
        }

        private static void AddToListBoxCallback(object state)
        {
            if (state is not AddToListBoxParam {ListBox: ListBox listBox} param)
                return;

            listBox.Items.Add(param.Message);
            listBox.TopIndex = listBox.Items.Count - 1;
        }
    }

    public class ProduceParam
    {
        public int Max { get; set; }
        public int MSec { get; set; }

        public ProduceParam(int max = 0, int mSec = 0)
        {
            Max = max;
            MSec = mSec;
        }
    }

    public class ConsumeParam
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int MSec { get; set; }

        public ConsumeParam(int min = 0, int max = 0, int mSec = 0)
        {
            Min = min;
            Max = max;
            MSec = mSec;
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

using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avro.Generic;
using Avro.Specific;
using Confluent.Kafka;
using MultiTypesWinFormsApp.Consumer;
using MultiTypesWinFormsApp.Producer;
using org.example;

namespace MultiTypesWinFormsApp
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

        private readonly CancellationTokenSource
            _cancellationTokenSourceProduce = new(),
            _cancellationTokenSourceConsume = new();

        private readonly IConsumerBuilder _consumerBuilder;

        public MainForm(IConsumerBuilder consumerBuilder)
        {
            InitializeComponent();

            btnCancelProduce.Tag = _cancellationTokenSourceProduce;
            btnCancelConsume.Tag = _cancellationTokenSourceConsume;
            
            tbProduceMax.Text = DefaultProduceMax.ToString();
            tbProduceMSec.Text = DefaultProduceMSec.ToString();

            tbConsumeMin.Text = DefaultConsumeMin.ToString();
            tbConsumeMax.Text = DefaultConsumeMax.ToString();
            tbConsumeMSec.Text = DefaultConsumeMSec.ToString();

            _uiContext = SynchronizationContext.Current;

            _consumerBuilder = consumerBuilder;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            if (sender is not Button {Tag: CancellationTokenSource cancellationTokenSource})
            {
                return;
            }
            cancellationTokenSource.Cancel();
        }

        private void BtnProduceClick(object sender, EventArgs e)
        {
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

            var kafkaProducer = new KafkaProducer(cancellationToken);

            try
            {
                for (var i = 0; i < produceParam.Max; ++i)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var genericRecord = Common.Common.SpecificRecordToGenericRecord(
                        i % 2 == 0
                            ? new TestTypes
                            {
                                fBoolean = true,
                                fInt = 13,
                                fLong = DateTimeOffset.Now.Ticks,
                                fFloat = 13.13F,
                                fDouble = 169.169,
                                fString = DateTimeOffset.Now.ToString("o"),
                                fEnum = (TestEnum) (i % 6)
                            }
                            : new Customer
                            {
                                FirstName = "FirstName",
                                LastName = "LastName",
                                Age = 13,
                                AutomatedEmail = true,
                                Height = 13.13F,
                                Weight = 169.169F,
                                Payment = (PaymentTypes) (i % 3)
                            });

                    DeliveryResult<string, GenericRecord> result = kafkaProducer.Produce(genericRecord);

                    WriteToLog(lbLogProduce, $"Produce: {result.Message.Value.Schema.Name} {result.Message.Key} ({Thread.CurrentThread.ManagedThreadId})");

                    Thread.Sleep(produceParam.MSec * rnd.Next(10));
                }

                kafkaProducer.Flush(TimeSpan.FromSeconds(30));

            }
            catch (ProduceException<string, GenericRecord> eException)
            {
                WriteToLog(lbLogProduce, $"{eException.GetType().FullName}: {eException.Message}");
            }
            catch (OperationCanceledException)
            {
                WriteToLog(lbLogProduce, $"{Thread.CurrentThread.ManagedThreadId} has been canceled");
            }
            catch (Exception eException)
            {
                WriteToLog(lbLogProduce, $"{eException.GetType().FullName}: {eException.Message}");
            }
            finally
            {
                kafkaProducer.Dispose();
                kafkaProducer = null;
            }
        }

        private void BtnConsumeClick(object sender, EventArgs e)
        {
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

        private async Task Consume(object param, CancellationToken cancellationToken)
        {
            if (param is not ConsumeParam consumeParam)
            {
                return;
            }

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            var consumer = _consumerBuilder
                .SetCancellationToken(cancellationToken)
                .SetSpecificRecords(new[] { typeof(Customer), typeof(TestTypes) })
                .SetProcessor(OnProcess)
                .SetOnOk(OnOk)
                .SetOnError(OnError)
                .Build();

            WriteToLog(lbLogConsume, $"{Thread.CurrentThread.ManagedThreadId}");

            try
            {
                await consumer.Consume();
            }
            catch (OperationCanceledException)
            {
                WriteToLog(lbLogConsume, $"{Thread.CurrentThread.ManagedThreadId} has been canceled");
            }
            catch (Exception eException)
            {
                WriteToLog(lbLogConsume, $"{eException.GetType().FullName}: {eException.Message}");
            }
        }

        private void OnProcess(ISpecificRecord specificRecord)
        {
            WriteToLog(lbLogConsume, $"{MethodBase.GetCurrentMethod().Name}()");
        }

        private void OnOk(ISpecificRecord specificRecord)
        {
            WriteToLog(lbLogConsume, $"{MethodBase.GetCurrentMethod().Name}()");
        }

        private void OnError(ISpecificRecord specificRecord)
        {
            WriteToLog(lbLogConsume, $"{MethodBase.GetCurrentMethod().Name}()");
        }

        public void WriteToLog(ListBox listBoxLog, string message)
        {
            Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(listBoxLog, message));
        }

        private static void AddToListBoxCallback(object state)
        {
            if (state is not AddToListBoxParam { ListBox: ListBox listBox } param)
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

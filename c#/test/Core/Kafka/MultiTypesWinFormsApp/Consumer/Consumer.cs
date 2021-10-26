using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Avro.Specific;
using org.example;

namespace MultiTypesWinFormsApp.Consumer
{
    public class Consumer : IConsumer
    {
        private readonly BufferBlock<ISpecificRecord> _bufferBlock;
        private readonly TransformBlock<ISpecificRecord, ProcessedMessage> _transformBlock;
        private readonly ActionBlock<ProcessedMessage> _actionBlockOnOk;
        private readonly ActionBlock<ProcessedMessage> _actionBlockOnError;

        private Action<ISpecificRecord> _processor = null;
        private Action<ISpecificRecord> _onOk = null;
        private Action<ISpecificRecord> _onError = null;

        private IKafkaConsumer _kafkaConsumer;
        private readonly IKafkaConsumerBuilder _kafkaConsumerBuilder;
        private ConsumerConfiguration _consumerConfig;

        public Consumer(IKafkaConsumerBuilder kafkaConsumerBuilder)
        {
            _kafkaConsumerBuilder = kafkaConsumerBuilder ?? throw new ArgumentNullException(nameof(kafkaConsumerBuilder));

            var dataflowBlockOptions = new DataflowBlockOptions
            {
                //BoundedCapacity = max
            };

            var executionDataflowBlockOptions = new ExecutionDataflowBlockOptions
            {
                //BoundedCapacity = min
            };

            _bufferBlock = new BufferBlock<ISpecificRecord>(dataflowBlockOptions);
            _transformBlock = new TransformBlock<ISpecificRecord, ProcessedMessage>((Func<ISpecificRecord, ProcessedMessage>)Transform, executionDataflowBlockOptions);
            _actionBlockOnOk = new ActionBlock<ProcessedMessage>(OnOk, executionDataflowBlockOptions);
            _actionBlockOnError = new ActionBlock<ProcessedMessage>(OnError, executionDataflowBlockOptions);

            _bufferBlock.LinkTo(_transformBlock);
            _transformBlock.LinkTo(_actionBlockOnOk, processedMessage => processedMessage.Error == null);
            _transformBlock.LinkTo(_actionBlockOnError, processedMessage => processedMessage.Error != null);
        }

        public void Dispose()
        {
            _kafkaConsumer?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Configure(ConsumerConfiguration consumerConfig)
        {
            _consumerConfig = consumerConfig;
            _kafkaConsumer = CreateKafkaConsumer();
        }

        public void SetProcessor(Action<ISpecificRecord> processor)
        {
            _processor = processor;
        }

        public void SetOnOk(Action<ISpecificRecord> onOk)
        {
            _onOk = onOk;
        }

        public void SetOnError(Action<ISpecificRecord> onError)
        {
            _onError = onError;
        }

        public async Task Consume()
        {
            try
            {
                await _kafkaConsumer.Consume();
            }
            catch (OperationCanceledException e)
            {
                Debug.WriteLine($"{e.GetType().FullName}: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }
        }

        private IKafkaConsumer CreateKafkaConsumer()
        {
            _kafkaConsumer = _kafkaConsumerBuilder
                .SetCancellationToken(_consumerConfig.CancellationToken)
                .SetSpecificRecords(_consumerConfig.SpecificTypes)
                .SetOnConsumeHandler(Post)
                .Build();

            return _kafkaConsumer;
        }

        private void Post(ISpecificRecord message)
        {
            while (!_bufferBlock.Post(message))
            {
                Thread.Sleep(1000);
            }
        }

        private ProcessedMessage Transform(ISpecificRecord message)
        {
            Error error = null;

            try
            {
                _processor?.Invoke(message);
            }
            catch (Exception e)
            {
                error = new Error(e);
            }

            return new ProcessedMessage(message, error);
        }

        private void OnOk(ProcessedMessage message)
        {
            try
            {
                _onOk?.Invoke(message.Message);
            }
            catch (Exception e)
            {}
        }

        private void OnError(ProcessedMessage message)
        {
            try
            {
                _onError?.Invoke(message.Message);
            }
            catch (Exception e)
            {}
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace TestDataflowSimple
{
    public class Consumer<T>
    {
        private readonly BufferBlock<T> _bufferBlock;
        private readonly TransformBlock<T, ProcessedMessage<T>> _transformBlock;
        private readonly ActionBlock<ProcessedMessage<T>> _actionBlockOnOk;
        private readonly ActionBlock<ProcessedMessage<T>> _actionBlockOnError;

        private Action<T> _processor = null;
        private Action<T> _onOk = null;
        private Action<T> _onError = null;

        public Consumer()
        {
            var dataflowBlockOptions = new DataflowBlockOptions
            {
                BoundedCapacity = 10
            };

            var executionDataflowBlockOptions = new ExecutionDataflowBlockOptions
            {
                BoundedCapacity = 3
            };

            _bufferBlock = new BufferBlock<T>(dataflowBlockOptions);
            _transformBlock = new TransformBlock<T, ProcessedMessage<T>>((Func<T, ProcessedMessage<T>>)Transform, executionDataflowBlockOptions);
            _actionBlockOnOk = new ActionBlock<ProcessedMessage<T>>(OnOk, executionDataflowBlockOptions);
            _actionBlockOnError = new ActionBlock<ProcessedMessage<T>>(OnError, executionDataflowBlockOptions);

            _bufferBlock.LinkTo(_transformBlock);
            _transformBlock.LinkTo(_actionBlockOnOk, processedMessage => processedMessage.Error == null);
            _transformBlock.LinkTo(_actionBlockOnError, processedMessage => processedMessage.Error != null);
        }

        public void SetProcessor(Action<T> processor)
        {
            _processor = processor;
        }

        public void SetOnOk(Action<T> onOk)
        {
            _onOk = onOk;
        }

        public void SetOnError(Action<T> onError)
        {
            _onError = onError;
        }

        public void Post(T message)
        {
            while (!_bufferBlock.Post(message))
            {
                Thread.Sleep(1000);
            }
        }

        private ProcessedMessage<T> Transform(T message)
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

            return new ProcessedMessage<T>(message, error);
        }

        private void OnOk(ProcessedMessage<T> message)
        {
            try
            {
                _onOk?.Invoke(message.Message);
            }
            catch (Exception e)
            {}
        }

        private void OnError(ProcessedMessage<T> message)
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

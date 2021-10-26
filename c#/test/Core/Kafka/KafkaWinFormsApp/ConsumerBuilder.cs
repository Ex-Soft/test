using System;

namespace KafkaWinFormsApp
{
    public class ConsumerBuilder<T>
    {
        private readonly Consumer<T> _consumer;

        public ConsumerBuilder(int min = default, int max = default)
        {
            _consumer = new Consumer<T>(min, max);
        }

        public ConsumerBuilder<T> SetProcessor(Action<T> processor)
        {
            _consumer.SetProcessor(processor);
            return this;
        }

        public ConsumerBuilder<T> SetOnOk(Action<T> onOk)
        {
            _consumer.SetOnOk(onOk);
            return this;
        }

        public ConsumerBuilder<T> SetOnError(Action<T> onError)
        {
            _consumer.SetOnError(onError);
            return this;
        }

        public Consumer<T> Build()
        {
            return _consumer;
        }
    }
}

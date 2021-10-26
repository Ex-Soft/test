using System;

namespace TestDataflowSimple
{
    public class Builder<T>
    {
        private readonly Consumer<T> _consumer;

        public Builder()
        {
            _consumer = new Consumer<T>();
        }

        public Builder<T> SetProcessor(Action<T> processor)
        {
            _consumer.SetProcessor(processor);
            return this;
        }

        public Builder<T> SetOnOk(Action<T> onOk)
        {
            _consumer.SetOnOk(onOk);
            return this;
        }

        public Builder<T> SetOnError(Action<T> onError)
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

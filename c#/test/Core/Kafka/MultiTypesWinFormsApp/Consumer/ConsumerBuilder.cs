using System;
using System.Collections.Generic;
using System.Threading;
using Avro.Specific;

namespace MultiTypesWinFormsApp.Consumer
{
    public class ConsumerBuilder : IConsumerBuilder
    {
        private readonly IConsumer _consumer;
        private readonly ConsumerConfiguration _consumerConfig;

        public ConsumerBuilder(IConsumer consumer)
        {
            _consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
            _consumerConfig = new ConsumerConfiguration();
        }

        public ConsumerBuilder SetCancellationToken(CancellationToken cancellationToken)
        {
            _consumerConfig.CancellationToken = cancellationToken;
            return this;
        }

        public ConsumerBuilder SetSpecificRecords(IEnumerable<Type> types)
        {
            _consumerConfig.SpecificTypes = types;
            return this;
        }

        public ConsumerBuilder SetProcessor(Action<ISpecificRecord> processor)
        {
            _consumer.SetProcessor(processor);
            return this;
        }

        public ConsumerBuilder SetOnOk(Action<ISpecificRecord> onOk)
        {
            _consumer.SetOnOk(onOk);
            return this;
        }

        public ConsumerBuilder SetOnError(Action<ISpecificRecord> onError)
        {
            _consumer.SetOnError(onError);
            return this;
        }

        public IConsumer Build()
        {
            _consumer.Configure(_consumerConfig);
            return _consumer;
        }
    }
}

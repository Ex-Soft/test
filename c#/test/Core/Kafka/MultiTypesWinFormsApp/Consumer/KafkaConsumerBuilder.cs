using System;
using System.Collections.Generic;
using System.Threading;
using Avro.Specific;

namespace MultiTypesWinFormsApp.Consumer
{
    public class KafkaConsumerBuilder : IKafkaConsumerBuilder
    {
        private readonly IKafkaConsumer _consumer;
        private readonly KafkaConsumerConfiguration _consumerConfig;
        

        public KafkaConsumerBuilder(IKafkaConsumer consumer)
        {
            _consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
            _consumerConfig = new KafkaConsumerConfiguration();
        }

        public KafkaConsumerBuilder SetCancellationToken(CancellationToken cancellationToken)
        {
            _consumerConfig.CancellationToken = cancellationToken;
            return this;
        }

        public KafkaConsumerBuilder SetSpecificRecords(IEnumerable<Type> types)
        {
            _consumerConfig.SpecificTypes = types;
            return this;
        }

        public KafkaConsumerBuilder SetOnConsumeHandler(Action<ISpecificRecord> onConsume)
        {
            _consumerConfig.OnConsume = onConsume;
            return this;
        }

        public IKafkaConsumer Build()
        {
            _consumer.Configure(_consumerConfig);
            return _consumer;
        }
    }
}

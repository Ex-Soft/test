using System;
using System.Collections.Generic;
using System.Threading;
using Avro.Specific;

namespace MultiTypesWinFormsApp.Consumer
{
    public interface IKafkaConsumerBuilder
    {
        KafkaConsumerBuilder SetCancellationToken(CancellationToken cancellationToken);
        KafkaConsumerBuilder SetSpecificRecords(IEnumerable<Type> types);
        KafkaConsumerBuilder SetOnConsumeHandler(Action<ISpecificRecord> onConsume);
        IKafkaConsumer Build();
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using Avro.Specific;

namespace MultiTypesWinFormsApp.Consumer
{
    public interface IConsumerBuilder
    {
        ConsumerBuilder SetCancellationToken(CancellationToken cancellationToken);
        ConsumerBuilder SetSpecificRecords(IEnumerable<Type> types);
        ConsumerBuilder SetProcessor(Action<ISpecificRecord> processor);
        IConsumer Build();
    }
}

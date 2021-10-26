using System;
using System.Collections.Generic;
using System.Threading;
using Avro.Specific;

namespace MultiTypesWinFormsApp.Consumer
{
    public class KafkaConsumerConfiguration
    {
        public CancellationToken CancellationToken { get; set; }
        public IEnumerable<Type> SpecificTypes { get; set; }
        public Action<ISpecificRecord> OnConsume { get; set; }
    }
}

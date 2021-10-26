using System;

namespace TestTypeFromStringConfiguration
{
    public class ProtonProducerConfig
    {
        /// <summary>
        /// Delay in milliseconds to wait for messages in the producer queue to accumulate before constructing message 
        /// batches (MessageSets) to transmit to brokers.  A higher value allows larger and more effective (less 
        /// overhead, improved compression) batches of messages to accumulate at the expense of increased message
        /// delivery latency.  Note that this is sometimes referred to as "queue.buffering.max.ms" in Kafka literature.
        /// </summary>
        public double LingerMs { get; set; } = 0.5;

        /// <summary>
        /// The name that you want to give to your Producer.  This is passed to DataDog so that when you are looking at 
        /// stats for a bunch of different Producers you know which one is yours.
        /// </summary>
        public string ProducerName { get; set; } = "Unnamed Producer";

        /// <summary>
        /// DLQ to dump Kafka event into if it cannot be successfully produced.
        /// </summary>
        public string DlqUrl { get; set; } = null;

        public Type[] KafkaTypes { get; set; }
        public string Topic { get; set; }
    }
}
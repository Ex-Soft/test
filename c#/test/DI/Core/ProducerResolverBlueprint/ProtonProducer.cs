using System;

namespace TestTypeFromStringConfiguration
{
    public class ProtonProducer<T> : IProtonProducer<T>, IProtonProducer where T : ISpecificRecord
    {
        private string _topic;

        public void Produce(T message)
        {
            Console.WriteLine($"Topic: {_topic}. Message of type {typeof(T)} has been produced.");
        }

        public void Produce(ISpecificRecord message)
        {
            if (message is T message1)
            {
                Produce(message1);
            }
        }

        public void Configure(ProtonProducerConfig configuration)
        {
            _topic = configuration?.Topic ?? throw new ArgumentException(nameof(configuration));
        }
    }

    public interface IProtonProducer<in T>
    {
        void Produce(T message);
    }

    public interface IProtonProducer
    {
        void Produce(ISpecificRecord message);
        void Configure(ProtonProducerConfig configuration);
    }

    interface IBusinessEvent
    {
        public string Topic { get; set; }
        public ISpecificRecord Value { get; set; }
    }

    class BusinessEvent : IBusinessEvent
    {
        public string Topic { get; set; }
        public ISpecificRecord Value { get; set; }
    }

    class ProducerResolutionContext
    {
        public string Topic { get; set; }
        public Type SpecificRecordType { get; set; }
    }
}
